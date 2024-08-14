using System;
using System.Collections.Concurrent;
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

        // queue maneger
        // queue<Missile>
        // missile handler - enqueue the missile
        // iron dome
        // Missile class

        static async Task Main(string[] args)
        {

            ConcurrentQueue<Missile> missileQueue = new ConcurrentQueue<Missile>();

            Dictionary<string, int> damgeDict = new Dictionary<string, int>();

            damgeDict["KSAAM"] = 100;
            damgeDict["Qusaam"] = 150;
            damgeDict["Pajar"] = 200;
            damgeDict["Grade"] = 300;
            damgeDict["Qtusha"] = 700;

            string port = "3108";

            WebSocketServer wss = new WebSocketServer($"ws://localhost:{port}");

            wss.AddWebSocketService<MissileHandler>("/MissileHanlder", () => new MissileHandler(wss, missileQueue));

            QueueManager manager = new QueueManager(missileQueue , wss);

            manager.Start();

            wss.Start();
            
            //await DefenceManeger.RunIronDom();
            
            Console.WriteLine($"Web Socket server is listening on port: {port}...");
            
            Console.ReadLine();
            
            wss.Stop();


            //string filePath = "../../Mssiles";

            //List<Mssile> mssileList =  await GetJsonFileAsync(filePath);

            //Console.WriteLine(mssileList.First().ToString());

            //Queue<Mssile> mssiles = new Queue<Mssile>();
            //foreach (Mssile mssile in mssiles)
            //{
            //    mssiles.Enqueue(mssile);
            //}
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
        
        public static async Task<List<Missile>> GetJsonFileAsync(string filePath)
        {
            string fileName = "../../Mssiles.json";
            
            string jsonString = File.ReadAllText(fileName);



            FileStream openStream = File.OpenRead(fileName);
            List<Missile> mssiles =
                await JsonSerializer.DeserializeAsync<List<Missile>>(openStream);


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
