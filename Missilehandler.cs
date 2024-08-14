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


        private readonly WebSocketServer _wss;
        private readonly ConcurrentQueue<Missile> _missileQueue;

        internal MissileHandler(WebSocketServer wss, ConcurrentQueue<Missile> missileQueue)
        {
            this._wss = wss;
            this._missileQueue = missileQueue;
        }


        protected override async void OnMessage(MessageEventArgs e)
        {
            //Console.WriteLine("data got is: " + e.Data);

            Missile missile = JsonSerializer.Deserialize<Missile>(e.Data);
            
            Console.WriteLine("*************************************");
            
            Console.WriteLine($"Missile -- {missile.name} -- hes been detected ");

            this._missileQueue.Enqueue(missile);

            //Task task = new Task(IronDom.Defens(_missileQueue));

        }

        public void BroadcastStatus(string message)
        {
            this._wss.WebSocketServices["/MissileHandler"].Sessions.Broadcast(message);
        }
    }
}
