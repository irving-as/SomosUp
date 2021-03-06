﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AcopioUP.Models;

namespace AcopioUP.ViewModels
{
    public class DonationFormViewModel
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Producto")]
        public int ProductId { get; set; }

        [DisplayName("Unidades")]
        public int Units { get; set; }
        
        public DateTime Date { get; set; }
        
        [DisplayName("Descripción")]
        [StringLength(255)]
        public string Description { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public bool IsDonationContainsMoreProductsThanNeeded { get; set; }

        public string Title => "Nueva Donación";

        [DisplayName("Email del donador")]
        [StringLength(255)]
        public string DonorEmail { get; set; }

        public DonationFormViewModel()
        {
            Date = DateTime.Now;
        }

    }
}