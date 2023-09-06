using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.Interfaces
{
    public interface IUserInterface
    {
        Task<IEnumerable<KorisnikAplikacije>> GetAllUsers();
        Task<KorisnikAplikacije> GetUserId(string id);
        bool Add(KorisnikAplikacije korisnik);
        bool Update(KorisnikAplikacije korisnik);
        bool Delete(KorisnikAplikacije korisnik);
        bool Save(); 
    }
}
