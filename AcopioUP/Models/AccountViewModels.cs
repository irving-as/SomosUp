using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcopioUP.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(255, ErrorMessage = "El {0} debe de tener mínimo {2} caracteres", MinimumLength = 6)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe de tener mínimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Direccion")]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Número de Teléfono")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Latitud")]
        public double Lat { get; set; }

        [Display(Name = "Longitud")]
        public double Long { get; set; }
    }

    public class EditProfileViewModel
    {
        [StringLength(255)]
        public string Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "El {0} debe de tener mínimo {2} caracteres", MinimumLength = 6)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Direccion")]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Número de Teléfono")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Latitud")]
        public double Lat { get; set; }

        [Display(Name = "Longitud")]
        public double Long { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
