using System.ComponentModel.DataAnnotations;
using AcopioUP.Dtos;

namespace AcopioUP.Models
{
    public class StockLessThanOrEqualThanNeeded : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (ProductDto)validationContext.ObjectInstance;

            return product.UnitsInStock <= product.UnitsNeeded ? ValidationResult.Success : new ValidationResult("Ya se llegó a la meta del producto.");
        }
    }
}