using CharacterApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CharacterApplication
{
    public class Program
    {

        
        private static HttpClient client = new HttpClient();

        public static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("api/Character");
            //var responseSingle = client.GetAsync("http://localhost:5000/api/Character/620d288c12e8e4de6f0ebf51");
            //Creating a character to post it to the database
            //Character character = new Character();
            /*character.Name = "Polyphemus";
            character.Power = "Giant";
            character.Description = "Polyphemus is a giant cyclop and is also the son of Poseidon in Greek Mythologies";
            character.Type = "Monster";
            character.Rank = 56; */

            Console.WriteLine("Calling the Character API... ");
            Console.WriteLine();
            //running and returning individual characters
            try
            {
             if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<Character>();
                    var serData = JsonConvert.SerializeObject(data);
                    Console.WriteLine(serData.ToList());
                }
               
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
