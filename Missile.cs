using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attackServer
{
    internal class Missile
    {
        public string name { get; set; }
        public double speed { get; set; }
        public double mass { get; set; }
        public Dictionary<string, int> origin {  get; set; }
        public Dictionary<string, int> angle { get; set; }
        public int time { get; set; }
        public double damage { get; set; }

        public override string ToString()
        {
            string result = $"[\nName: {name}, \nSpeed: {speed}, \nMass: {mass}, \nOrigin: \n\tx: {origin["x"]}, \n\ty: {origin["y"]}, \n\tz: {origin["z"]}, \nAngle: \n\tx: {angle["x"]}, \n\ty: {angle["y"]}, \n\tz: {angle["z"]}\nTime: {time}\n]";
            return result ;
        }
    }
}
