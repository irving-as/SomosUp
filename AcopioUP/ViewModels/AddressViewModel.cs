using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AcopioUP.Models;

namespace AcopioUP.ViewModels
{
    public class AddressViewModel
    {
        public AddressViewModel(Address address)
        {
            Id = address.Id;
            StreetAddress = address.StreetAddress;
            Lat = address.Lat;
            Long = address.Long;
        }

        public AddressViewModel()
        {
            
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Dirección")]
        public string StreetAddress { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public string Title => Id == 0 ? "Nueva dirección" : "Editar dirección";

    }
}