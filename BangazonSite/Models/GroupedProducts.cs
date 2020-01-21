using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonSite.Models
{
    [NotMapped]
    public class GroupedProducts
    {
        public string TypeName { get; set; }
        public int ProductCount { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
