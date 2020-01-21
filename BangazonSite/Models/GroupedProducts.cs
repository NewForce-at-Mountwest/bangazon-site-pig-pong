using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonSite.Models
{
    public class GroupedProducts
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int ProductCount { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
