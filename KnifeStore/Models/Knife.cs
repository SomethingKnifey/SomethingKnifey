﻿using System.ComponentModel.DataAnnotations;

namespace KnifeStore.Models
{
    public class Knife
    {
        public int ID { get; set; }
        public string SKU { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Style Style { get; set; }        
        public KnifeManufacturer Manufacturer { get; set; }
    }

    public enum Style
    {
        [Display(Name = "Kitchen and Dining")]
        KitchenAndDining,
        Pocket,
        Tactical,
        Utility
    }
}
