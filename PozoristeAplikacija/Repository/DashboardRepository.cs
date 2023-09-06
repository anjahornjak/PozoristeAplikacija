using Microsoft.EntityFrameworkCore;
using PozoristeAplikacija.Data;
using PozoristeAplikacija.Interfaces;
using PozoristeAplikacija.Models;

namespace PozoristeAplikacija.Repository
{
    public class DashboardRepository : IDashboardInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor; 

        }
        public async Task<List<Pozoriste>> GetAllUserPozorista()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userPozorista = _context.Pozorista.Where(r => r.KorisnikAplikacije.Id == curUser);
            return userPozorista.ToList();
        }

        public async Task<List<Predstava>> GetAllUserPredstave()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userPredstave = _context.Predstave.Where(r => r.KorisnikAplikacije.Id == curUser);
            return userPredstave.ToList(); 
        }
        public async Task<KorisnikAplikacije> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id); 
        }

        public async Task<KorisnikAplikacije> GetByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        public bool Update(KorisnikAplikacije user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
