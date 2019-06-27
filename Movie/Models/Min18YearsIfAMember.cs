using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Min18YearsIfAMember :  ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == Models.Customer.Values.Unknown || 
                customer.MembershipTypeId == Models.Customer.Values.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null || customer.BirthDate.Value.Year == 9999)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership");

            
        }
    }
}