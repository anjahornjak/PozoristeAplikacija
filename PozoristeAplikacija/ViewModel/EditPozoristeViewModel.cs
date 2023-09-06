using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.ViewModel
{
    public class EditPozoristeViewModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public IFormFile Fotografija { get; set; }
        public string? URL { get; set; }
        public int? AdresaId { get; set; }
        public Adresa Adresa { get; set; } 
    }
}
