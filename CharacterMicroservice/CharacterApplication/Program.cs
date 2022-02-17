using CharacterApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CharacterApplication
{
    class Program
    {
        
        private static readonly HttpClient client = new HttpClient();
        public static async Task Main(string[] args)
        {
            //Creating a character to post it to the database
            Character character = new Character();
            character.Name = "Polyphemus";
            character.Power = "Giant";
            character.Description = "Polyphemus is a giant cyclop and is also the son of Poseidon in Greek Mythologies";
            character.Type = "Monster";
            character.Rank = 56;

            Console.WriteLine("Calling the Character API... ");
            Console.WriteLine();
            var response = client.GetAsync("http://localhost:5000/api/Character");
            var responseSingle = client.GetAsync("http://localhost:5000/api/Character/620d288c12e8e4de6f0ebf51");
            response.Wait();
            responseSingle.Wait();
            //running and returning individual characters
            try
            {
                if (response.IsCompleted)
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var allCharacters = result.Content.ReadAsStringAsync();
                        allCharacters.Wait();
                        Console.WriteLine("Printing All Character in a Single String...");
                        Console.WriteLine(allCharacters.Result);
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                if (responseSingle.IsCompleted)
                {
                    var result2 = response.Result;
                    if (result2.IsSuccessStatusCode)
                    {
                        var singleChar = result2.Content.ReadAsStringAsync();
                        singleChar.Wait();
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
