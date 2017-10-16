using System.Collections.Generic;
using AcopioUP.Models;

namespace AcopioUP.ViewModels
{
    public class ProductsReadOnlyListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}