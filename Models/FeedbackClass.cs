using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRentAndUse_V3.Models
{
    public class FeedbackClass
    {
        public int Id { get; set; }
        public UserClass UserClass { get; set; }
        public int UserClassId { get; set; }
        [Required]
        [Display(Name = "Rating : ")]
        public string Rating { get; set; }
        [Display(Name = "Feedback Comment : ")]
        public string FeedBack { get; set; }
    }
}