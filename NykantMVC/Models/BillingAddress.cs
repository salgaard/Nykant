﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class BillingAddress
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Postal")]
        public string Postal { get; set; }
    }
}
