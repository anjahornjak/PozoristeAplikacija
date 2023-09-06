using System.ComponentModel.DataAnnotations;

namespace PozoristeAplikacija.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email adresa je obavezna! ")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage ="Potvrdna lozinka je obavezna!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Lozinke se ne podudaraju! ")]
        public string ConfirmPassword { get; set; }

    }
}
