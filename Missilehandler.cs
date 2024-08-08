using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace attackServer
{

    public class MissileHandler : WebSocketBehavior
    {
        Queue<Mssile> _missileQueue = new Queue<Mssile>();
        
        private readonly WebSocketServer _wss;
        public MissileHandler(WebSocketServer wss)
        {
            _wss = wss;
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("data got is: " + e.Data);

            Mssile mssile = new Mssile();

            Mssile missile =  JsonSerializer.Deserialize<Mssile>(e.Data);

            _missileQueue.Enqueue(missile);

            IronDom.Defens(_missileQueue);

        }
    }
}






