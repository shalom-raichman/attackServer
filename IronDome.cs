using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace attackServer
{
    internal class IronDome
    {
        public string Name { get; set; }

        public IronDome(string name) {
            Name = name;
        }
        public async Task<bool> handleMissile(Missile missile)
        {
            Thread.Sleep(5000);

            Random random = new Random();
            bool intercepted = random.Next(0, 2) == 1;
            return intercepted;
        }


        public static async Task Defens(Missile mssile)
        {

            Console.WriteLine("");

            Random rnd = new Random();

            int seccess = rnd.Next(1);

            if (rnd.Next(2) == 0)
            {
                await Task.Delay(2000);
                Console.WriteLine($"missile: {mssile.name} --- shut doun --- !!!");
            }
            else
            {
                await Task.Delay(3000);
                Console.WriteLine("Mission failed !!! Missile reach the target :( ");
            }
                

            Console.WriteLine("*************************************");
            
        }
    }
}
