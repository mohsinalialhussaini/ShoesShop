using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JOOTASHOP.Models
{
    public class Contact
    {
        [Required]
        public string name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [Phone]
        public string phone { get; set; }

        [Required]
        public string message { get; set; }


    }
}