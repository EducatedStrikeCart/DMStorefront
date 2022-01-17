using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMStorefront.Shared
{
    public class PriceValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString() == "0, 0, 0, 0"){

                return new ValidationResult
                    ("Please enter a price.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}

