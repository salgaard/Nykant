﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.ViewModels
{
    public class GalleryVM
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
