using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodMovies.Models
{
    public class AgeMin18 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MemberShipType.Unknown ||
                customer.MembershipTypeId == MemberShipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is Required");
            return (customer.Birthdate.Value.Year > 2004)
                ? new ValidationResult("Your age must be above 18")
                : ValidationResult.Success;
        }
    }
}