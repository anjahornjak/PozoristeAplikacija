namespace PozoristeAplikacija.ViewModel
{
    public class EditUserDashboardViewModel
    {
        public string Id { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Grad { get; set; }
        public IFormFile Fotografija { get; set; }
    }
}
