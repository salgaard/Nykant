﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var json = await GetRequest("/Product/GetProducts");

            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var json = await GetRequest($"/Product/GetProduct/{id}");

            ProductVM productVM = JsonConvert.DeserializeObject<ProductVM>(json);

            return View(productVM);
        }
    }
}
