using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using PozoristeAplikacija.Data.Enum;

namespace PozoristeAplikacija.Models
{
    public class Predstava
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string? Fotografija { get; set; }
        public string? Tekst { get; set; }
        public string? Rezija { get; set; }
        public string? Trajanje { get; set; }
        public VrstaPredstave VrstaPredstave { get; set; }
        [ForeignKey("KorisnikAplikacije")]
        public string? KorisnikAplikacijeId { get; set; }
        public KorisnikAplikacije? KorisnikAplikacije { get; set; }
        [ForeignKey("Pozoriste")]
        public int? PozoristeId { get; set; }
        public Pozoriste? Pozoriste { get; set; }
    }
}
