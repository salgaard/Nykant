﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Order
    {
        [Key]
        public string UserId { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}