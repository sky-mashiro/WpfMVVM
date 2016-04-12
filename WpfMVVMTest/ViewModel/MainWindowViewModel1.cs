using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

using WpfMVVMTest.Model;
using WpfMVVMTest.DataAccess;
using WpfMVVMTest.Command;

namespace WpfMVVMTest.ViewModel
{
    class MainWindowViewModel1:ViewModelBase
    {
        private ICommand _removeCommand;
        private ICommand _addCommand;
        private Employee _newEmployee;

        public ObservableCollection<Employee> AllEmployees { get; set; }
        
        public Employee SelectEmployee { get; set; }
        public Employee NewEmployee { get { return _newEmployee; } set { _newEmployee = value;} }
        public ICommand RemoveCommand
        {
            get { return _removeCommand = new CommandBase(RemoveExecute, RemoveCanExecute); }
        }
        public ICommand AddCommand
        {
            get { return _removeCommand = new CommandBase(AddExecute, AddCanExecute); }
        }
        public MainWindowViewModel1()
        {
            if (AllEmployees == null)
            {
                AllEmployees = new ObservableCollection<Employee>(new EmployeeRespository().GetEmployeeRespository());
            }

            _newEmployee = new Employee();
        }
        void RemoveExecute(object param)
        {
            AllEmployees.Remove(SelectEmployee);
        }
        bool RemoveCanExecute(object param)
        {
            if (SelectEmployee != null)
            {
                return true;
            }

            return false;
        }

        void AddExecute(object param)
        {
            AllEmployees.Add(Employee.CreateEmployee(NewEmployee.Name, NewEmployee.Age));
        }
        bool AddCanExecute(object param)
        {
            if (NewEmployee.Name != null && NewEmployee.Age != null)
            {
                foreach (var item in AllEmployees)
                {
                    if (item.Name.Trim() == NewEmployee.Name.Trim())
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
