using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.Interfaces
{
    public interface IPredstavaInterface
    {
        Task<IEnumerable<Predstava>> GetAll();
        Task<Predstava?> GetByIdAsync(int id);
        Task<Predstava> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Predstava>> GetPredstavaByPozoriste(string naziv);
        bool Add(Predstava predstava);

        bool Update(Predstava predstava);

        bool Delete(Predstava predstava);

        bool Save();
    }
}
