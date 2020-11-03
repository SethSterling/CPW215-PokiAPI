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

        public async Task<IActionResult> Index()
        {
            PokiApiClient client = new PokiApiClient();
            Pokemon results = await client.GetPokemonById(1);
            
            List<string> relsultMoves = new List<string>();
            foreach (Move currMove in results.moves)
            {
                relsultMoves.Add(currMove.move.name);
            }

            relsultMoves.Sort();

            PokeDexEntryViewModel entry = new PokeDexEntryViewModel()
            {
                Id = results.id,
                Name = results.Name,
                Height = results.Height.ToString(),
                Weight = results.Weight.ToString(),
                PokedexImageUrl = results.sprites.FrontDefault,
                //Add Moves
                MoveList = relsultMoves
            };

            return View(entry);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
