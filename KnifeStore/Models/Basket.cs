using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnifeStore.Models
{
    public class Basket
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string KnifeModel { get; set; }
    }
}
