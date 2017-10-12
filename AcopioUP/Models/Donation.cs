using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcopioUP.Models
{
    public class Donation
    {
        public int Units { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}