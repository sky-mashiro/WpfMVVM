using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMTest.Model
{
    public class Employee
    {
        public static Employee CreateEmployee(string name, string age)
        {
            return new Employee() { Name = name, Age = age };
        }

        public string Name { get; set; }
        public string Age { get; set; }
    }
}
