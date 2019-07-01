using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Movie.Models
{
    public class MaxNumberOfRentedMovies : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Models.Customer)validationContext.ObjectInstance;
         
            if (customer.MoviesRentedAtOneTime < 1)
                return new ValidationResult("Number must be > 0");

            return ValidationResult.Success;
        }
    }
}