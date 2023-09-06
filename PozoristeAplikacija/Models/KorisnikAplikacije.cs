using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace PozoristeAplikacija.Models
{
    public class KorisnikAplikacije : IdentityUser
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? Grad { get; set; }
        public string? Kontakt { get; set; }
        [ForeignKey("Adresa")]
        public int? AdresaId { get; set; }
        public Adresa? Adresa { get; set; }
        public ICollection<Predstava> Predstave { get; set; }
        public ICollection<Rezervacija> Rezervacije { get; set; }
    }
}
