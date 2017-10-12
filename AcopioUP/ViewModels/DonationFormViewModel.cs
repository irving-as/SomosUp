using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AcopioUP.ViewModels
{
    public class DonationFormViewModel
    {
        [DisplayName("Unidades")]
        public int Units { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public string Title => "Nueva Donación";

        public DonationFormViewModel()
        {
            Date = DateTime.Now;
        }

    }
}