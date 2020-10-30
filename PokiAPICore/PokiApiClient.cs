using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokiAPICore
{
    /// <summary>
    /// Client class to consume PokeApi
    /// https://pokeapi.co/
    /// </summary>
    public class PokiApiClient
    {
        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Retrieve pokemon by name
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="ArgumentException">Thrown when pokemon is not found</exception>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Pokemon> GetPokemonByName(string name)
        {
            name = name.ToLower(); // Pokemon name must be lower.

            string url = $"https://pokeapi.co/api/v2/pokemon/{name}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Pokemon>(responseBody);
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"{name} does not exist");
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public void GetPokemonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
