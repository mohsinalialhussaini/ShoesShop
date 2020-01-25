using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JOOTASHOP.Models
{
    public class RegestrationModel
    {

        [Required(ErrorMessage = "Do you have a good name please?")]
        public string firstName { get; set; }
        public string lastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(14,ErrorMessage ="Enter a valid CNIC of 14 Digits")]
        [MinLength(14, ErrorMessage = "Enter a valid CNIC 14 Digits")]

        public string CNIC { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Enter a valid Contact Format: 03XXxxxxxxx")]
        [MinLength(11, ErrorMessage = "Enter a valid contact Format: 03XXxxxxxxx")]


        public string Contact { get; set; }

        [Required]
        [MinLength(8, ErrorMessage ="Password Should Be Minimum Of 8 Char")]
        
        public string UserPassword { get; set; }

    }
}