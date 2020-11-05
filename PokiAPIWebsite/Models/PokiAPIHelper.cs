using PokiAPICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokiAPIWebsite.Models
{
    public static class PokiAPIHelper
    {
        /// <summary>
        /// Get a pokemon by id, moves  will be sorted in
        /// alphabetical order
        /// </summary>
        /// <param name="desiredId"></param>
        /// <returns></returns>
        public static async Task<Pokemon> GetById(int desiredId)
        {
            PokiApiClient client = new PokiApiClient();
            Pokemon results = await client.GetPokemonById(desiredId);

            // Sort moves by name alphabetically
            results.moves.OrderBy(m => m.move.name);

            return results;
        }

        public static PokeDexEntryViewModel GetPokedexEntryFromPokemon(Pokemon results)
        {
            PokeDexEntryViewModel entry = new PokeDexEntryViewModel()
            {
                Id = results.id,
                Name = results.Name,
                Height = results.Height.ToString(),
                Weight = results.Weight.ToString(),
                PokedexImageUrl = results.sprites.FrontDefault,
                //Add Moves
                MoveList = results.moves.OrderBy(m => m.move.name)
                                                    .Select(m => m.move.name)
                                                    .ToArray()
            };
            return entry;
        }
    }
}
