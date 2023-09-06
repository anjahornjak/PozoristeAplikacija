using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace PozoristeAplikacija.Models
{
    public class Pozoriste
    {
        [Key]
        public int Id { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public string? Fotografija { get; set; }
        [ForeignKey("Adresa")]
        public int? AdresaId { get; set; }
        public Adresa? Adresa { get; set; }
        [ForeignKey("KorisnikAplikacije")]
        public string? KorisnikAplikacijeId { get; set; }
        public KorisnikAplikacije? KorisnikAplikacije { get; set; }
    }
}
