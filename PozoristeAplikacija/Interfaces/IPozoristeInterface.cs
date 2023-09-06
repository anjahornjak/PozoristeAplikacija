using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.Interfaces
{
    public interface IPozoristeInterface
    {
        Task<IEnumerable<Pozoriste>> GetAll();
        Task<Pozoriste> GetByIdAsync(int id);
        Task<Pozoriste> GetByIdAsyncNoTracking(int id); 
        Task<IEnumerable<Pozoriste>> GetPozoristeByGrad(string grad);
        bool Add(Pozoriste pozoriste);

        bool Update(Pozoriste pozoriste);

        bool Delete(Pozoriste pozoriste);

        bool Save();
    }
}
