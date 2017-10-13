using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcopioUP.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string StreetAddress { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

    }
}