using System.ComponentModel.DataAnnotations;

namespace PozoristeAplikacija.Models
{
    public class Adresa
    {
        [Key]
        public int Id { get; set; }
        public string Ulica { get; set; }
        public string Grad { get; set; }
    }
}
