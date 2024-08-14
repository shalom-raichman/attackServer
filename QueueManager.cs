using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using System.Text.Json;
using System.Threading;
using System.Collections.Concurrent;

namespace attackServer
{
    internal class QueueManager
    {
        private readonly ConcurrentQueue<Missile> _missileQueue;
        private readonly WebSocketServer _wss  ;
        private readonly SemaphoreSlim _ironDomeSemphore;

        static int ironDomeAmount = 4;


        public QueueManager(ConcurrentQueue<Missile> missileQueue, WebSocketServer wss)
        {
            
            this._missileQueue = missileQueue;
            this._wss = wss;
            this._ironDomeSemphore = new SemaphoreSlim(ironDomeAmount);
        }

        public void Start()
        {
            int ironDomeAmount = 4;
            for (int i = 0; i < ironDomeAmount; i++)
            {
                var interceptorThread = new Thread(() => Interceptor(i.ToString()));
                interceptorThread.Start();
            }
        }

        public async void Interceptor(string name)
        {

            IronDome ironDome = new IronDome(name);
            while (true)
            {
                this._ironDomeSemphore.Wait();
                if (this._missileQueue.TryDequeue(out Missile missileToIntercept))
                {
                    bool result = await ironDome.handleMissile(missileToIntercept);
                    var message = new { intercepted = result, missileName = missileToIntercept.name };
                    var json = JsonSerializer.Serialize(message);
                    this._wss.WebSocketServices["/MissileHanlder"].Sessions.Broadcast(json);
                }
                this._ironDomeSemphore.Release();
            }
        }
        public void Stop() { }
    }
}
