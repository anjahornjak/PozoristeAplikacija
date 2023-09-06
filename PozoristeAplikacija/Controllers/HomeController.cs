using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using PozoristeAplikacija.Interfaces;
using PozoristeAplikacija.Models;
using PozoristeAplikacija.ViewModel;
using RunGroopWebApp.Helpers;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace PozoristeAplikacija.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPozoristeInterface _pozoristeInterface;

        public HomeController(ILogger<HomeController> logger, IPozoristeInterface pozoristeInterface)
        {
            _logger = logger;
            _pozoristeInterface = pozoristeInterface; 
        }

        public async Task<IActionResult> Index()
        {
            var ipInfo = new IPInfo();
            var homeViewModel = new HomeViewModel(); 
            try
            {
                string url = "https://ipinfo.io?token=13174c3d7474f6";
                var info = new WebClient().DownloadString(url);
                ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
                homeViewModel.Grad = ipInfo.City; 
                if(homeViewModel.Grad != null)
                {
                    homeViewModel.Pozorista = await _pozoristeInterface.GetPozoristeByGrad(homeViewModel.Grad);
                }
                else
                {
                    homeViewModel.Pozorista = null;
                }
                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                homeViewModel.Pozorista = null; 
            }
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}