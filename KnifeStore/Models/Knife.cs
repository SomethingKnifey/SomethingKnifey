using System;
using System.Collections.Generic;
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

        [ForeignKey("KnifeManufacturer")]
        public int ManufacturerID { get; set; }
        public KnifeManufacturer Manufacturer { get; set; }
    }

    public enum Style
    {
        Pocket,
        Kitchen,
        Dinnerware,
        Tactical,
        Utility
    }
}
