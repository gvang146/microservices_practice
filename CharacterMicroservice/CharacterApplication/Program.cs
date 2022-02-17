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
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Calling the Character API... ");
            Console.WriteLine();
            var response = client.GetAsync("http://localhost:5000/api/Character");
            response.Wait();
            if (response.IsCompleted)
            {
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var contents = result.Content.ReadAsStringAsync();
                    contents.Wait();
                    Console.WriteLine("Data from web API: " + contents.Result);
                    Console.ReadKey();
                }
            }
        }
    }
}
