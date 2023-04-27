using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public class BrainResponse
        {
            public string cnt { get; set; }
        }
        static void Main(string[] args)
        {
            Console.Write("computer: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("sup?");


            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("me: ");
            Console.ForegroundColor = ConsoleColor.Green;

            FuncChat(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("press key for exit");
            Console.ReadKey();
        }

        private static void FuncChat(string message)
        {
            if (message.Contains("exit"))
                return;

            var client = new RestClient($"http://api.brainshop.ai/get?bid=172504&key=pa89bj8G5EzeFHjk&uid=12345&msg={message}");
            var request = new RestRequest();
            var response = client.Execute(request);
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var x = JsonSerializer.Deserialize<BrainResponse>(response.Content);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("computer: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(x.cnt);
            }


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("me: ");
            Console.ForegroundColor = ConsoleColor.Green;
            FuncChat(Console.ReadLine());

        } 
    }
}
