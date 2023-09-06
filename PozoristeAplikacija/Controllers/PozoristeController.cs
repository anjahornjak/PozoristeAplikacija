using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PozoristeAplikacija.Data;
using PozoristeAplikacija.Interfaces;
using PozoristeAplikacija.Models;
using PozoristeAplikacija.ViewModel;
using System.Diagnostics.Eventing.Reader;

namespace PozoristeAplikacija.Controllers
{
    public class PozoristeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPozoristeInterface _pozoristeInterface;
        private readonly IPhotoUploadService _photoUploadService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PozoristeController(IPozoristeInterface pozoristeInterface, IPhotoUploadService photoUploadService, IHttpContextAccessor httpContextAccessor)
        {
            _pozoristeInterface = pozoristeInterface;
            _photoUploadService = photoUploadService;
            _httpContextAccessor = httpContextAccessor; 
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Pozoriste> pozorista = await _pozoristeInterface.GetAll();
            return View(pozorista);
        }
        //HTTP getOne
        public async Task<IActionResult> Detail(int id)
        {
            Pozoriste pozoriste = await _pozoristeInterface.GetByIdAsync(id);
            return View(pozoriste);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createPozoristeViewModel = new CreatePozoristeViewModel
            {
                KorisnikAplikacijeId = curUserId
            };
           
            return View(createPozoristeViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreatePozoristeViewModel pozoristeVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoUploadService.AddPhotoAsync(pozoristeVM.Fotografija);
                var pozoriste = new Pozoriste
                {
                    Naziv = pozoristeVM.Naziv,
                    Opis = pozoristeVM.Opis,
                    Fotografija = result.Url.ToString(),
                    KorisnikAplikacijeId = pozoristeVM.KorisnikAplikacijeId,
                    Adresa = new Adresa
                    {
                        Ulica = pozoristeVM.Adresa.Ulica,
                        Grad = pozoristeVM.Adresa.Grad,
                    }
                };
                _pozoristeInterface.Add(pozoriste);
                return RedirectToAction("Index");
            }
            else {

                ModelState.AddModelError("", "Neuspesno dodavanje fotografije");
            }

            return View(pozoristeVM);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var pozoriste = await _pozoristeInterface.GetByIdAsync(id);
            if (pozoriste == null) return View("Error");
            var pozoristeVM = new EditPozoristeViewModel
            {
                Naziv = pozoriste.Naziv,
                Opis = pozoriste.Opis,
                AdresaId = pozoriste.AdresaId,
                Adresa = pozoriste.Adresa,
                URL = pozoriste.Fotografija,

            };
            return View(pozoristeVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPozoristeViewModel pozoristeVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Neuspešna izmena pozorišta");
                return View("Edit", pozoristeVM);
            }
            var userPozoriste = await _pozoristeInterface.GetByIdAsyncNoTracking(id);
            if (userPozoriste != null) {
                try
                {
                    await _photoUploadService.DeletePhotoASync(userPozoriste.Fotografija);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Nemoguće je izbrisati fotografiju");
                    return View(pozoristeVM);
                }
                var photoResult = await _photoUploadService.AddPhotoAsync(pozoristeVM.Fotografija);
                var pozoriste = new Pozoriste
                {
                    Id = id,
                    Naziv = pozoristeVM.Naziv,
                    Opis = pozoristeVM.Opis,
                    Fotografija = photoResult.Url.ToString(),
                    AdresaId = pozoristeVM.AdresaId,
                    Adresa = pozoristeVM.Adresa,
                };

                _pozoristeInterface.Update(pozoriste);

                return RedirectToAction("Index");
             }

            else
            {
                return View(pozoristeVM);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var pozoristeVise = await _pozoristeInterface.GetByIdAsync(id); 
            if (pozoristeVise == null) return View("Error");
            return View(pozoristeVise); 
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePozoriste(int id)
        {
            var pozoristeVise = await _pozoristeInterface.GetByIdAsync(id);
            if (pozoristeVise == null) return View("Error");

            _pozoristeInterface.Delete(pozoristeVise);
            return RedirectToAction("Index"); 
        }

    }
}
