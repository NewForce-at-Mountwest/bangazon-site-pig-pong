using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonSite.Models.ViewModels
{
    public class SellAProductViewModel
    {
        public Product Product { get; set; }
        public List<SelectListItem> ListOfProductTypes { get; set; }
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }
        public int SelectedProductTypeId { get; set; }
    }
}
