using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace attackServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //string filePath = "../../Mssiles";

            //List<Mssile> mssileList =  await GetJsonFileAsync(filePath);

            //Console.WriteLine(mssileList.First().ToString());

            //Queue<Mssile> mssiles = new Queue<Mssile>();
            //foreach (Mssile mssile in mssiles)
            //{
            //    mssiles.Enqueue(mssile);
            //}

            Dictionary<string, int> damgeDict = new Dictionary<string, int>();

            damgeDict["KSAAM"] = 100;
            damgeDict["Qusaam"] = 150;
            damgeDict["Pajar"] = 200;
            damgeDict["Grade"] = 300;
            damgeDict["Qtusha"] = 700;
            

            WebSocketServer wss = new WebSocketServer("ws://localhost:3108");
            wss.AddWebSocketService<MissileHandler>("/MissileHandler", () => new MissileHandler(wss));
            wss.Start();
            Console.WriteLine("Backend server is running. Press Enter to exit...");
            Console.ReadLine();
            wss.Stop();

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
        
        public static async Task<List<Mssile>> GetJsonFileAsync(string filePath)
        {
            string fileName = "../../Mssiles.json";
            
            string jsonString = File.ReadAllText(fileName);



            FileStream openStream = File.OpenRead(fileName);
            List<Mssile> mssiles =
                await JsonSerializer.DeserializeAsync<List<Mssile>>(openStream);


            return mssiles;
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
