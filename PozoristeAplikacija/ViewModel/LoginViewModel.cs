using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PozoristeAplikacija.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "Email Adress")]
        [Required(ErrorMessage = "Email adresa je obavezna!")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
