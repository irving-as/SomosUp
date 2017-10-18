using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AcopioUP.Models;

namespace AcopioUP.ViewModels
{
    public class BeneficiaryFormViewModel
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

        public string Title => Id != 0 ? "Editar Beneficiario" : "Nuevo Beneficiario";

        public BeneficiaryFormViewModel()
        {
            Id = 0; 
        }

        public BeneficiaryFormViewModel(Beneficiary beneficiary)
        {
            Id = beneficiary.Id;
            FirstName = beneficiary.FirstName;
            LastName = beneficiary.LastName;
            Email = beneficiary.Email;
        }
    }
}