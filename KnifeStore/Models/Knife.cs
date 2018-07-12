using KnifeStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

        //[Key]
        //[ForeignKey("KnifeManufacturer")]
        //public int ManufacturerID { get; set; }
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
