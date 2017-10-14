using System.ComponentModel.DataAnnotations;
using AcopioUP.ViewModels;

namespace AcopioUP.Models
{
    public class StockLessThanOrEqualThanNeeded : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;

            return product.UnitsInStock <= product.UnitsNeeded ? ValidationResult.Success : new ValidationResult("Ya se llegó a la meta del producto.");
        }
    }
}