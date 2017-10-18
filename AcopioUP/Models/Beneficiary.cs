using System.ComponentModel.DataAnnotations;

namespace AcopioUP.Models
{
    public class Beneficiary
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}