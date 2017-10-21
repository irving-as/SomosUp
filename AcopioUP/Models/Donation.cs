using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcopioUP.Models
{
    public class Donation
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Units { get; set; }

        public DateTime Date { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string DonorEmail { get; set; }

        [Required]
        [StringLength(255)]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}