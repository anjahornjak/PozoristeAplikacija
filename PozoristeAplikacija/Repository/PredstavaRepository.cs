using Microsoft.EntityFrameworkCore;
using PozoristeAplikacija.Data;
using PozoristeAplikacija.Interfaces;
using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.Repository
{
    public class PredstavaRepository : IPredstavaInterface
    {
        private readonly ApplicationDbContext _context;

        public PredstavaRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public bool Add(Predstava predstava)
        {
            _context.Add(predstava);
            return Save();
        }

        public bool Delete(Predstava predstava)
        {
            _context.Remove(predstava);
            return Save();
        }

        public async Task<IEnumerable<Predstava>> GetAll()
        {
            return await _context.Predstave.ToListAsync();
        }

        public async Task<Predstava?> GetByIdAsync(int id)
        {
            return await _context.Predstave.Include(i => i.Pozoriste).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Predstava> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Predstave.Include(i => i.Pozoriste).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Predstava>> GetPredstavaByPozoriste(string naziv)
        {
            return await _context.Predstave.Where(p => p.Pozoriste.Naziv.Contains(naziv)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Predstava predstava)
        {
            _context.Update(predstava);
            return Save(); 
        }
    }
}
