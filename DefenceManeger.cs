using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attackServer
{


    internal class DefenceManeger
    {
        public static Queue<Missile> _missileQueue = new Queue<Missile>();


        public static async Task RunIronDom()
        {
            while (true)
            {
                if (_missileQueue.Count <= 4)
                {

                    if (_missileQueue.Count > 0)
                    {
                        await IronDome.Defens(_missileQueue.Dequeue());
                    }
                }
                else { Console.WriteLine("out of missiles"); }
            }
        }
    }
}

