using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attackServer
{
    internal class HonorQueue : Queue<Department>
    {
        public void Enqueue(Dictionary<string, int> people)
        {
            foreach (var person in people)
            {
                string name = person.Key;
                int age = person.Value;

                var department = this.FirstOrDefault(depr => depr.Age == age);
                if (department != null)
                {
                    department.Names.Add(name);
                }
                else
                {
                    department = new Department(age);
                    department.Names.Add(name);
                    // then insert the department in order
                }
            }
        }

        public void InsertInOrder(Department department)
        {
            List<Department> list = this.ToList();
            list.Add(department);

            list = list
                .OrderByDescending(de => de.Age)
                .ToList();
            this.Clear();

            foreach (Department depar in list)
            {
                base.Enqueue(depar);
            }
        }
    }
}
