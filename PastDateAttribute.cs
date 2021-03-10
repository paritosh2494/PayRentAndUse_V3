using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRentAndUse_V3
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            if(d >= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Please Enter a Valid Date.");
            }
             //Dates Greater than or equal to today are valid (true)
        }
    }
}