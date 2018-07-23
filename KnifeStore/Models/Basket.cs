using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnifeStore.Models
{
    public class Basket
    {
        public int ID { get; set; }
        public List<Knife> Items { get; set; }
    }
}
