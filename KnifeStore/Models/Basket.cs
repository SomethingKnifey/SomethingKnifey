using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnifeStore.Models
{
    public class Basket
    {
        public int ID { get; set; }
        public List<Knife> Items { get; set; }
    }
}
