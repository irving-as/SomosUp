using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AcopioUP.Models;

namespace AcopioUP.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int UnitsNeeded { get; set; }

        [StockLessThanOrEqualThanNeeded]
        public int UnitsInStock { get; set; }
    }
}