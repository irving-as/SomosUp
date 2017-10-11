using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AcopioUP.Models;

namespace AcopioUP.ViewModels
{
    public class VictimFormViewModel
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [DisplayName("Apellidos")]
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public string Title => Id != 0 ? "Editar Víctima" : "Nueva Víctima";

        public VictimFormViewModel()
        {
            Id = 0;
        }

        public VictimFormViewModel(Victim victim)
        {
            Id = victim.Id;
            FirstName = victim.FirstName;
            LastName = victim.LastName;
            Email = victim.Email;
        }
    }
}