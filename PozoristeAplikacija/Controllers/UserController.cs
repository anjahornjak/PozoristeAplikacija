using Microsoft.AspNetCore.Mvc;
using PozoristeAplikacija.Interfaces;
using PozoristeAplikacija.ViewModel;

namespace PozoristeAplikacija.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface) 
        {
            _userInterface = userInterface;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userInterface.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>(); 
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName =user.UserName,
                    Ime = user.Ime,
                    Prezime = user.Prezime,
                    ProfileImageUrl = user.ProfileImageUrl, 
                };
                result.Add(userViewModel);
              
            }
            return View(result);
        }
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userInterface.GetUserId(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Ime = user.Ime,
                Prezime = user.Prezime,
            };
            return View(userDetailViewModel);
        }
    }
}
