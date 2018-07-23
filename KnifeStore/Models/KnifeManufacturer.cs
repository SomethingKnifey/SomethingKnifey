using System.Collections.Generic;

namespace KnifeStore.Models
{
    public class KnifeManufacturer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Knife> Knives { get; set; }
    }
}
