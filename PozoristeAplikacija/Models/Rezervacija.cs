using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PozoristeAplikacija.Models
{
    public class Rezervacija
    {
        [Key]
        public int Id { get; set; }
        public int CenaKarte { get; set; }
        public DateTime VremeIzvodjenja { get; set; }
        public Boolean Placeno { get; set; }
        [ForeignKey("KorisnikAplikacije")]
        public string? KorisnikAplikacijeId { get; set; }
        public KorisnikAplikacije? KorisnikAplikacije { get; set; }
        [ForeignKey("Predstava")]
        public int? PredstavaId { get; set; }
        public Predstava? Predstava { get; set; }
    }
}
