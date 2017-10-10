using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcopioUP.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgSrc { get; set; }

        public int UnitsNeeded { get; set; }

        public int UnitsInStock { get; set; }
    }
}