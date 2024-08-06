using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace attackServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //string res =  await GetDataAsync();
            //string resFile = await GetFileAsync("..\\..\\ExampleFile.txt");

            //Console.WriteLine(res);
            //Console.WriteLine(resFile);
            //Console.ReadLine();

            // Ex 3
            Task<string> TaskA = GetdataFromServisAAsync();
            Task<string> TaskB = GetdataFromServisBAsync();

            await Task.WhenAll(TaskA, TaskB);

            Console.WriteLine($"Task A result: {TaskA.Result}");
            Console.WriteLine($"Task B result: {TaskB.Result}");
            Console.ReadLine();
        }

        public static async Task<string> GetDataAsync()
        {
            await Task.Delay(2000);
            return "Mition acomplish";
        }

        public static async Task<string> GetFileAsync(string filePath)
        {
            string result = await Task.Run(() => File.ReadAllText(filePath));
            // File.ReadAllText
            // Task.Run
            return result;
        }

        public static async Task<string> GetdataFromServisAAsync()
        {
            await Task.Delay(1000);
            return "Data from servis A";
        }
        
        public static async Task<string> GetdataFromServisBAsync()
        {
            await Task.Delay(2000);
            return "Data from servis B";
        }
    }
}
