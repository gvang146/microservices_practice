using CharacterApplication.Models;
using Newtonsoft.Json;
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
            /*character.Name = "Polyphemus";
            character.Power = "Giant";
            character.Description = "Polyphemus is a giant cyclop and is also the son of Poseidon in Greek Mythologies";
            character.Type = "Monster";
            character.Rank = 56; */

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
                        Character chara = JsonConvert.DeserializeObject<Character>(Convert.ToString(result));
                        Console.WriteLine("Id: " + chara.ID + "\tName: " + chara.Name + "\tPower: " + chara.Power);
                        Console.ReadKey();
                    }
                }
                Console.WriteLine();
                /*if (responseSingle.IsCompleted)
                {
                    var result2 = responseSingle.Result;
                    if (result2.IsSuccessStatusCode)
                    {
                        var singleChar = result2.Content.ReadAsStringAsync();
                        singleChar.Wait();
                        Console.WriteLine("Printing a Character in a Single String...");
                        Console.WriteLine(singleChar.Result);
                        Console.WriteLine();
                    }
                }*/
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
