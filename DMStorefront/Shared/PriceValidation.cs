using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMStorefront.Shared
{
    internal class PriceValidationAttribute : ValidationAttribute
    {
        public PriceValidationAttribute(Price price)
        {
            Price = price;
        }
        public Price Price { get; set; }

        public string GetErrorMessage() =>
            $"Please enter price in at least one box (copper, silver, or gold)";

        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            if (Price.Value == 0)
            {
                return new ValidationResult(GetErrorMessage());
            }
           
            return ValidationResult.Success;
        }
    }
}
