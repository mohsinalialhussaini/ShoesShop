using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JOOTASHOP.Models
{
    public class confirmOrder
    {
        [Required]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Address { get; set; }
    }
}