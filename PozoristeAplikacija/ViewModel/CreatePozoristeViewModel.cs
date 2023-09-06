using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.ViewModel
{
    public class CreatePozoristeViewModel
    {
        public int Id { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public Adresa Adresa { get; set; } 
        public IFormFile Fotografija { get; set; }
        public string KorisnikAplikacijeId { get; set; }

    }
}
