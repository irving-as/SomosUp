using System.ComponentModel.DataAnnotations;

namespace AcopioUP.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string ImgSrc { get; set; }

        public int UnitsNeeded { get; set; }

        [StockLessThanOrEqualThanNeeded]
        public int UnitsInStock { get; set; }
    }
}