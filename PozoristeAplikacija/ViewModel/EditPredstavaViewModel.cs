using PozoristeAplikacija.Data.Enum;
using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.ViewModel
{
    public class EditPredstavaViewModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Tekst { get; set; }
        public string Rezija { get; set; }
        public string Trajanje { get; set; }
        public IFormFile Fotografija { get; set; }
        public string? URL { get; set; }
        public VrstaPredstave VrstaPredstave { get; set; }
        public int? PozoristeId { get; set; }
        public Pozoriste Pozoriste { get; set; }
    }
}
