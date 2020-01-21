using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonSite.Models.ViewModels
{
    [NotMapped]
    public class ProductTypesViewModel
    {
        public List<GroupedProducts> GroupedProducts { get; set; } = new List<GroupedProducts>();
    }
}
