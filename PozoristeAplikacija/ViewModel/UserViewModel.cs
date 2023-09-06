using System.Globalization;

namespace PozoristeAplikacija.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }

        public string ProfileImageUrl { get; set; }
    }
}
