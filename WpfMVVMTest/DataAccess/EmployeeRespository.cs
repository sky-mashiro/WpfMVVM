using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMTest.Model;

namespace WpfMVVMTest.DataAccess
{
    public class EmployeeRespository
    {
        readonly List<Employee> _employees;
        public EmployeeRespository()
        {
            if (_employees == null)
            {
                _employees = new List<Employee>();
            }
            _employees.Add(new Employee() { Age = "12", Name = "Tom" });
            _employees.Add(new Employee() { Age = "16", Name = "Marry" });
            _employees.Add(new Employee() { Age = "17", Name = "Alex" });
        }
        public List<Employee> GetEmployeeRespository()
        {
            return _employees;
        }
    }
}
