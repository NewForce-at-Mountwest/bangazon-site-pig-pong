using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonSite.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        
        public long AcctNumber { get; set; }
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; } 
        public bool Active { get; set; }

    }
}
