using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using PozoristeAplikacija.Data;
using PozoristeAplikacija.Interfaces;
using PozoristeAplikacija.Models;
using PozoristeAplikacija.ViewModel;

namespace PozoristeAplikacija.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardInterface _dashboardInterface;
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly IPhotoUploadService _photoUploadService;

        public DashboardController(IDashboardInterface dashboardInterface, IHttpContextAccessor httpContextAccessor, IPhotoUploadService photoUploadService)
        {
            _dashboardInterface = dashboardInterface;
            _httpContextAccesor = httpContextAccessor;
            _photoUploadService = photoUploadService;
        }
        private void MapUserEdit(KorisnikAplikacije user, EditUserDashboardViewModel editVM, ImageUploadResult photoResult)
        {
            user.Id = editVM.Id;
            user.Ime = editVM.Ime;
            user.Prezime = editVM.Prezime;
            user.Grad = editVM.Grad;
            user.ProfileImageUrl = photoResult.Url.ToString();
        }
        public async Task<IActionResult> Index()
        {
            var userPredstave = await _dashboardInterface.GetAllUserPredstave();
            var userPozorista = await _dashboardInterface.GetAllUserPozorista();
            var dashboardViewModel = new DashboardViewModel()
            {
                Pozorista = userPozorista,
                Predstave = userPredstave
            };
            return View(dashboardViewModel);
        }
        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpContextAccesor.HttpContext.User.GetUserId();
            var user = await _dashboardInterface.GetUserById(curUserId);
            if (user == null) return View("Error");
            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = curUserId,
                Ime = user.Ime,
                Prezime = user.Prezime,
                ProfileImageUrl = user.ProfileImageUrl,
                Grad = user.Grad
            };
            return View(editUserViewModel);
        }
        [HttpPost]

        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Neuspešan pokušaj izmene profila!");
                return View("EditUserProfile", editVM);
            }
            var user = await _dashboardInterface.GetByIdNoTracking(editVM.Id);
            if (user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            {
                var photoResult = await _photoUploadService.AddPhotoAsync(editVM.Fotografija);
                MapUserEdit(user, editVM, photoResult);

                _dashboardInterface.Update(user);
                return RedirectToAction("Index");
            }
            else
            {
                try
                {
                    await _photoUploadService.DeletePhotoASync(user.ProfileImageUrl);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(editVM);
                }
                var photoResult = await _photoUploadService.AddPhotoAsync(editVM.Fotografija);
                MapUserEdit(user, editVM, photoResult);

                _dashboardInterface.Update(user);
                return RedirectToAction("Index");
            }
        }
    }
}
