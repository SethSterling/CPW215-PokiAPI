using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokiAPICore;
using PokiAPIWebsite.Models;

namespace PokiAPIWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? id)
        {
            int desiredId = id ?? 1;
            ViewData["Id"] = desiredId;

            Pokemon results = await PokiAPIHelper.GetById(desiredId);
            PokeDexEntryViewModel entry = PokiAPIHelper.GetPokedexEntryFromPokemon(results);

            return View(entry);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
