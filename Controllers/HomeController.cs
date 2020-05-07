using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcPage.Models;
using Utilities;

namespace MvcPage.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.CountryJson = Country.GetCountries().ToJson();
            return View();
        }


        [HttpPost]
        public IActionResult Save([Bind("id")] Country country)
        {
            ViewBag.countryName = Country
                .GetCountries()
                .FirstOrDefault(x => x.id == country.id)
                ?.name;
            return View();
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
