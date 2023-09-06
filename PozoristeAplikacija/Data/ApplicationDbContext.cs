using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PozoristeAplikacija.Models;
using System.Diagnostics;

namespace PozoristeAplikacija.Data
{
    public class ApplicationDbContext : IdentityDbContext<KorisnikAplikacije>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Predstava> Predstave { get; set; }
        public DbSet<Pozoriste> Pozorista { get; set; }
        public DbSet<Adresa> Adrese { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
    }

    
}
