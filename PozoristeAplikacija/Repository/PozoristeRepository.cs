using Microsoft.EntityFrameworkCore;
using PozoristeAplikacija.Data;
using PozoristeAplikacija.Data.Enum;
using PozoristeAplikacija.Interfaces;
using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.Repository
{
    public class PozoristeRepository : IPozoristeInterface
        
    {
        private readonly ApplicationDbContext _context;
        public PozoristeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Pozoriste pozoriste)
        {
            _context.Add(pozoriste);
            return Save();
        }

        public bool Delete(Pozoriste pozoriste)
        {
            _context.Remove(pozoriste);
            return Save();
        }

        public async Task<IEnumerable<Pozoriste>> GetAll()
        {
            return await _context.Pozorista.ToListAsync();
        }

        public async Task<Pozoriste?> GetByIdAsync(int id)
        {
            return await _context.Pozorista.Include(i => i.Adresa).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Pozoriste> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Pozorista.Include(i => i.Adresa).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Pozoriste>> GetPozoristeByGrad(string grad)
        {
            return await _context.Pozorista.Where(p => p.Adresa.Grad.Contains(grad)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 
        }

        public bool Update(Pozoriste pozoriste)
        {
            _context.Update(pozoriste);
            return Save();
        }
    }
}
