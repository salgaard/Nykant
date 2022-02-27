﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [AllowAnonymous]
    public class BagController : BaseController
    {
        public BagController(ILogger<BaseController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder)
        {
        }

        [Route("Kurv")]
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            if (User.Identity.IsAuthenticated)
            {
                string subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
                var json = await GetRequest($"/BagItem/GetBagItems/{subject}");
                List<BagItem> bagItems = JsonConvert.DeserializeObject<List<BagItem>>(json);

                ViewBag.PriceSum = CalculateAmount(bagItems);

                return View(bagItems);
            }
            else
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                if (bagItems == null)
                {
                    bagItems = new List<BagItem>();
                    ViewBag.DeliveryInfo = null;
                    ViewBag.DeliveryDate = null;
                    ViewBag.PriceSum = 0;
                    return View(bagItems);
                }
                else
                {
                    ViewBag.DeliveryInfo = DeliveryDateInfo(bagItems);
                    var date = CalculateDeliveryDate(bagItems);
                    ViewBag.DeliveryDate = $"{date.Day}-{date.Month}-{date.Year}";
                    ViewBag.PriceSum = CalculateAmount(bagItems);
                    return View(bagItems);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBagItem(BagItem bagItem, int selection)
        {
            int bagItemQuantity = HttpContext.Session.Get<int>(BagItemAmountKey);
            if (User.Identity.IsAuthenticated)
            {
                if (selection == 1)
                {
                    bagItem.Quantity += 1;
                }
                else if (selection == 2)
                {
                    bagItem.Quantity -= 1;
                }
                else
                {
                    return NoContent();
                }

                if (bagItem.Quantity <= 0)
                {
                    var response = await DeleteRequest($"/BagItem/DeleteBagItem/{bagItem.Subject}/{bagItem.ProductId}");

                    if (response.IsSuccessStatusCode)
                    {
                        bagItemQuantity -= 1;
                        HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                        ViewData.Model = JsonConvert.DeserializeObject<List<BagItem>>(await GetRequest($"/bagitem/getbagitems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}"));
                        return new PartialViewResult
                        {
                            ViewName = "_BagTablePartial",
                            ViewData = this.ViewData
                        };
                    }
                    return Content("Failed");
                }
                else
                {
                    var response = await PatchRequest("/BagItem/UpdateBagItem", bagItem);

                    if (response.IsSuccessStatusCode)
                    {
                        ViewData.Model = JsonConvert.DeserializeObject<List<BagItem>>(await GetRequest($"/bagitem/getbagitems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}"));
                        return new PartialViewResult
                        {
                            ViewName = "_BagTablePartial",
                            ViewData = this.ViewData
                        };
                    }
                    return Content("Failed");
                }

            }
            else
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);

                for (int i = 0; i < bagItems.Count(); i++)
                {
                    if (bagItems[i].ProductId == bagItem.ProductId)
                    {
                        switch (selection)
                        {
                            case 1:
                                bagItems[i].Quantity += 1;
                                if (bagItems[i].Quantity <= 0)
                                {
                                    bagItems.RemoveAt(i);
                                    bagItemQuantity -= 1;
                                    HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                                }
                                break;

                            case 2:
                                bagItems[i].Quantity -= 1;
                                if (bagItems[i].Quantity <= 0)
                                {
                                    bagItems.RemoveAt(i);
                                    bagItemQuantity -= 1;
                                    HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                                }
                                break;
                        }
                    }
                }
                ViewData.Model = bagItems;
                HttpContext.Session.Set<List<BagItem>>(BagSessionKey, bagItems);
                return new PartialViewResult
                {
                    ViewName = "_BagTablePartial",
                    ViewData = this.ViewData
                };
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPrice()
        {
            if (User.Identity.IsAuthenticated)
            {
                var sub = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
                var bagitemList = JsonConvert.DeserializeObject<List<BagItem>>(await GetRequest($"/BagItem/GetBagItems/{sub}"));
                var price = CalculateAmount(bagitemList);
                return Json( new { price });
            }
            else
            {
                var bagitemList = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                var price = CalculateAmount(bagitemList);
                return Json(new { price });
            }
        }

        private double CalculateAmount(List<BagItem> items)
        {
            double price = 0;
            foreach (var item in items)
            {
                for (int i = 0; i < item.Quantity; i++)
                    price += item.Product.Price;
            }
            return price;
        }

        private DateTime CalculateDeliveryDate(List<BagItem> bagItems)
        {
            var deliveryDate = new DateTime();
            foreach (var item in bagItems)
            {
                if (item.Product.ExpectedDelivery != new DateTime())
                {
                    if (deliveryDate != new DateTime())
                    {
                        if (DateTime.Compare(deliveryDate, item.Product.ExpectedDelivery) < 0)
                        {
                            deliveryDate = item.Product.ExpectedDelivery;
                        }
                    }
                    else
                    {
                        deliveryDate = item.Product.ExpectedDelivery;
                    }
                }
            }
            if (deliveryDate == new DateTime())
            {
                deliveryDate = DateTime.Now;
                if (DateTime.Now.Hour < 12)
                {
                    deliveryDate = deliveryDate.AddDays(1);
                    if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        deliveryDate = deliveryDate.AddDays(1);
                    }
                }
                else
                {
                    deliveryDate = deliveryDate.AddDays(2);
                    if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Monday)
                    {
                        deliveryDate = deliveryDate.AddDays(1);
                    }
                }
            }
            else
            {
                deliveryDate = deliveryDate.AddDays(2);
                if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    deliveryDate = deliveryDate.AddDays(2);
                }
                else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    deliveryDate = deliveryDate.AddDays(2);
                }
                else if (deliveryDate.DayOfWeek == DayOfWeek.Monday)
                {
                    deliveryDate = deliveryDate.AddDays(1);
                }
            }
            return deliveryDate;
        }

        private string DeliveryDateInfo(List<BagItem> bagItems)
        {
            foreach (var item in bagItems)
            {
                if (item.Product.ExpectedDelivery != new DateTime())
                {
                    return "En eller flere produkter i din kurv, er ikke på lager. Derfor er forventet leveringstid for ordren desværre forlænget.";
                }
            }
            return null;
        }
    }
}
