using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PozoristeAplikacija.Data;
using PozoristeAplikacija.Interfaces;
using PozoristeAplikacija.Models;
using PozoristeAplikacija.ViewModel;

namespace PozoristeAplikacija.Controllers
{
    public class PredstavaController : Controller
    {
        private readonly IPredstavaInterface _predstavaInterface;
        private readonly IPhotoUploadService _photoUploadService;
        private readonly IHttpContextAccessor _httpContextAccessor; 

        public PredstavaController(IPredstavaInterface predstavaInterface, IPhotoUploadService photoUploadService, IHttpContextAccessor httpContextAccessor)
        {
            _predstavaInterface = predstavaInterface;
            _photoUploadService = photoUploadService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task <IActionResult> Index()
        {
            IEnumerable<Predstava> predstave = await _predstavaInterface.GetAll();
            return View(predstave);
        }
        //HTTP getOne
        public async Task<IActionResult> Detail(int id)
        {
            Predstava predstava = await _predstavaInterface.GetByIdAsync(id);
            return View(predstava);
        }
        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createPredstavaViewModel = new CreatePredstavaViewModel { KorisnikAplikacijeId = curUserId };
            return View(createPredstavaViewModel); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePredstavaViewModel predstavaVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoUploadService.AddPhotoAsync(predstavaVM.Fotografija);
                var predstava = new Predstava
                {
                    Naziv = predstavaVM.Naziv,
                    Opis = predstavaVM.Opis,
                    Fotografija = result.Url.ToString(),
                    Tekst = predstavaVM.Tekst,
                    Rezija = predstavaVM.Rezija,
                    Trajanje = predstavaVM.Trajanje,
                    KorisnikAplikacijeId = predstavaVM.KorisnikAplikacijeId,
                    Pozoriste = new Pozoriste
                    {
                        Naziv = predstavaVM.Pozoriste.Naziv,
                        Opis = predstavaVM.Pozoriste.Opis,
                        Adresa = new Adresa
                        {
                            Ulica = predstavaVM.Pozoriste.Adresa.Ulica,
                            Grad = predstavaVM.Pozoriste.Adresa.Grad,
                        }
                    }
                };
                _predstavaInterface.Add(predstava);
                return RedirectToAction("Index");
                
            } else
            {
                ModelState.AddModelError("", "Neupešno uneta fotografija");
            }

                return View(predstavaVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var predstava = await _predstavaInterface.GetByIdAsync(id);
            if (predstava == null) return View("Error");
            var predstavaVM = new EditPredstavaViewModel
            {
                Naziv = predstava.Naziv,
                Opis = predstava.Opis,
                Tekst = predstava.Tekst,
                Rezija = predstava.Rezija, 
                Trajanje = predstava.Trajanje,
                PozoristeId = predstava.PozoristeId,
                Pozoriste = predstava.Pozoriste,
                URL = predstava.Fotografija,
                       
            };
            return View(predstavaVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPredstavaViewModel predstavaVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Neuspešna izmena predstave");
                return View("Edit", predstavaVM);
            }
            var userPredstava = await _predstavaInterface.GetByIdAsyncNoTracking(id);
            if (userPredstava != null)
            {
                try
                {
                    await _photoUploadService.DeletePhotoASync(userPredstava.Fotografija);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Nemoguće je izbrisati fotografiju");
                    return View(predstavaVM);
                }
                var photoResult = await _photoUploadService.AddPhotoAsync(predstavaVM.Fotografija);
                var predstava = new Predstava
                {
                    Id = id,
                    Naziv = predstavaVM.Naziv,
                    Opis = predstavaVM.Opis,
                    Tekst = predstavaVM.Tekst,
                    Rezija = predstavaVM.Rezija,
                    Trajanje = predstavaVM.Trajanje,
                    PozoristeId = predstavaVM.PozoristeId,
                    Pozoriste = predstavaVM.Pozoriste,
                    Fotografija = photoResult.Url.ToString(),
                 
                };

                _predstavaInterface.Update(predstava);

                return RedirectToAction("Index");
            }

            else
            {
                return View(predstavaVM);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var predstavaVise = await _predstavaInterface.GetByIdAsync(id);
            if (predstavaVise == null) return View("Error");
            return View(predstavaVise);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePozoriste(int id)
        {
            var predstavaVise = await _predstavaInterface.GetByIdAsync(id);
            if (predstavaVise == null) return View("Error");

            _predstavaInterface.Delete(predstavaVise);
            return RedirectToAction("Index");
        }
    }
}
