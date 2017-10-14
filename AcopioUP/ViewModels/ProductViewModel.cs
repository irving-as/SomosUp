using System.ComponentModel.DataAnnotations;
using AcopioUP.Models;

namespace AcopioUP.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            UnitsNeeded = product.UnitsNeeded;
            UnitsInStock = product.UnitsInStock;
        }

        public ProductViewModel()
        {
            
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public int UnitsNeeded { get; set; }

        public int UnitsInStock { get; set; }

        public string Title => "Product";
    }
}