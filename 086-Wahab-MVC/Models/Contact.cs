using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _086_Wahab_MVC.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string fname { get; set; }
        [Required]
        public string Description{ get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string Price { get; set; }

        
    }
}
