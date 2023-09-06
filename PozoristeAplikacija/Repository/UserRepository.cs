using Microsoft.EntityFrameworkCore;
using PozoristeAplikacija.Data;
using PozoristeAplikacija.Interfaces;
using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public bool Add(KorisnikAplikacije korisnik)
        {
            throw new NotImplementedException();
        }

        public bool Delete(KorisnikAplikacije korisnik)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<KorisnikAplikacije>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<KorisnikAplikacije> GetUserId(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(KorisnikAplikacije korisnik)
        {
            _context.Update(korisnik);
            return Save();
        }
    }
}
