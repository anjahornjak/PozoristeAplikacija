using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PozoristeAplikacija.Data;
using PozoristeAplikacija.Models;
using PozoristeAplikacija.ViewModel;

namespace PozoristeAplikacija.Controllers
{
    public class NalogController : Controller
    {
        private readonly UserManager<KorisnikAplikacije> _userManager;
        private readonly SignInManager<KorisnikAplikacije> _signInManager;
        private readonly ApplicationDbContext _context;
        public NalogController(UserManager<KorisnikAplikacije> userManager, SignInManager<KorisnikAplikacije> signInManager, 
            ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager; 
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user != null)
            {
                // nasli smo korisnika
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Predstava");
                    }
                }
                //pogresna lozinka
                TempData["Error"] = "Prijavljivanje neuspešno. Molim vas, pokušajte ponovo.";
                return View(loginViewModel);
            }//korisnik nije pronadjen
            TempData["Error"] = "Prijavljivanje neuspešno. Molim vas, pokušajte ponovo.";
            return View(loginViewModel);

        }
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);
            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (user != null)
            {
                TempData["Error"] = "Unesena je postojeća email adresa! ";
                    return View(registerViewModel);
            }

            var newUser = new KorisnikAplikacije
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            }; 
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);
            if (newUserResponse.Succeeded) 
                await _userManager.AddToRoleAsync(newUser, UserRoles.Korisnik);
           
            return RedirectToAction("Index", "Predstava");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Predstava");
        }
    }
}
