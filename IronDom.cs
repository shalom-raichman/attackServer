using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attackServer
{
    internal class IronDom
    {
        public string Name { get; set; }


        public static async Task Defens(Queue<Mssile> mssiles)
        {
            if (mssiles.Count <= 4)
            {
                await Task.Delay(1000);
                mssiles.Dequeue();
                Console.WriteLine("missile shut doun");
            } 
            else { Console.WriteLine("out of missiles"); }


        }
    }
}
