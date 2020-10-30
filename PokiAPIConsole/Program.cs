using PokiAPICore;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokiAPIConsole
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                PokiApiClient client = new PokiApiClient();
                Pokemon result = await client.GetPokemonByName("REGIGIGAS");
                Console.WriteLine($"Pokemon Id: {result.id} " +
                    $"\nName: {result.name} " +
                    $"\nWeight: {result.weight} " +
                    $"\nHeight: {result.height}");
            }
            catch(ArgumentException)
            {
                Console.WriteLine("That pokemon does not exist");
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Try again later");
            }
            Console.ReadKey();
        }
    }
}
