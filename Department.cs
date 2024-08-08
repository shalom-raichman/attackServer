using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attackServer
{
    internal class Department
    {
        public Department(int age) {
            this.Age = age;
        }
        public int Age { get; set; }
        public List<string> Names { get; set; }


        public override string ToString() {
            return $"Department: {this.Age}, {string.Join(", ", this.Names)}";
        }
    }
}
