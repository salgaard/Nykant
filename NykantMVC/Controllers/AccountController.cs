﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(ILogger<BaseController> logger) : base(logger)
        {

        }
        [HttpGet]
        public IActionResult Logout()
        {
            int bagItemsCount = 0;
            if (HttpContext.Session.Get<List<BagItem>>(BagSessionKey) != null)
            {
                bagItemsCount = HttpContext.Session.Get<List<BagItem>>(BagSessionKey).Count();
            }
            HttpContext.Session.Set<int>(BagItemAmountKey, bagItemsCount);
            return SignOut("Cookies", "oidc");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string redirectUrl)
        {
            var json = await GetRequest($"/BagItem/GetBagItemsQuantity/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
            int bagItemsQuantity = JsonConvert.DeserializeObject<int>(json);
            HttpContext.Session.Set<int>(BagItemAmountKey, bagItemsQuantity);
            return Redirect(redirectUrl);
        }
        [Route("sign-me-in")]
        [HttpGet]
        public IActionResult SignMeIn()
        {
            HttpContext.Session.Set<List<BagItem>>(BagSessionKey, null);
            return RedirectToAction("Index", "Nykant");
        }
    }
}
