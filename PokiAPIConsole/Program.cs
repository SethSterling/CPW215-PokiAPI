﻿using PokiAPICore;
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
                //Pokemon result = await client.GetPokemonByName("REGIGIGAS");
                Pokemon result = await client.GetPokemonById(578);
                Console.WriteLine($"Pokemon Id: {result.id} " +
                    $"\nName: {result.Name} " +
                    $"\nWeight: {result.Weight} " +
                    $"\nHeight: {result.Height}");
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
