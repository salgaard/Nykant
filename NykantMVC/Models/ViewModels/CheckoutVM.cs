﻿using NykantMVC.Models.XmlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.ViewModels
{
    public class CheckoutVM
    {
        public Checkout Checkout { get; set; }
        public Customer Customer { get; set; }
    }
}
