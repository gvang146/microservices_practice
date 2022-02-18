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

        public static void Main(string[] args)
        {
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
            var response = client.GetAsync("http://localhost:5000/api/Character");
            response.Wait();
            List<Character> characters = new List<Character>();
            var result = response.Result;
            //retrieve all data from collection - Character in the database using the Web API
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsStringAsync();
                characters = JsonConvert.DeserializeObject<List<Character>>(data.Result);
                foreach (var c in characters)
                {
                    Console.WriteLine("Name: " + c.Name + "\nPower: " + c.Power + "\nType: " + c.Type);
                    Console.WriteLine();
                }
                
            }
           
            Console.ReadKey();
        } 
    }
}
