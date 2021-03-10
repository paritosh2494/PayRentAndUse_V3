using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRentAndUse_V3.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage ="Please Enter Email Id")]
        [Display(Name ="Email Id :")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}