using PozoristeAplikacija.Models;
using System.Diagnostics.Contracts;

namespace PozoristeAplikacija.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Pozoriste> Pozorista { get; set; }
        public string Grad { get; set; }
    }
}
