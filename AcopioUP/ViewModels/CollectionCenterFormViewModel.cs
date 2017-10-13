using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AcopioUP.Models;

namespace AcopioUP.ViewModels
{
    public class CollectionCenterFormViewModel
    {
        public CollectionCenterFormViewModel(CollectionCenter collectionCenter)
        {
            Id = collectionCenter.Id;
            Name = collectionCenter.Name;
            PhoneNumber = collectionCenter.PhoneNumber;
            Address = collectionCenter.Address;
            Lat = collectionCenter.Lat;
            Long = collectionCenter.Long;
        }

        public CollectionCenterFormViewModel()
        {
            
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Número de teléfono")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Dirección")]
        public string Address { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public string Title => Id == 0 ? "Nuevo centro de acopio" : "Editar centro de acopio";

    }
}