using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRentAndUse_V3.Models
{
    public class UserClass
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please Enter Name")]
        [Display(Name = "Enter Name :")]
        [StringLength(maximumLength:50,MinimumLength =2,ErrorMessage ="Name must be Max 50 and Min 2" )]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        [Display(Name = "Gender :")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Email Address")]
        [Display(Name = "Email Id :")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password cannot be blank")]
        [Display(Name = "Confirm Password :")]
        [DataType(DataType.Password)]
        [Compare("UserPassword")]
        public string UserRePassword { get; set; }
        public DateTime DateAdded { get; set; }
        public int Rating { get; set; }
        public string Feedback { get; set; }

    }
}