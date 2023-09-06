using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.Interfaces
{
    public interface IDashboardInterface
    {
        Task<List<Predstava>> GetAllUserPredstave();
        Task<List<Pozoriste>> GetAllUserPozorista(); 
        Task<KorisnikAplikacije> GetUserById(string id);
        Task<KorisnikAplikacije> GetByIdNoTracking(string id);
        bool Update(KorisnikAplikacije user);
        bool Save(); 
    }
}
