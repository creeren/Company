using Company.Commands;
using Company.Models;
using System;
using System.Windows;
using System.Collections.ObjectModel;

namespace Company.ViewModels
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly EmployeeService _employeeService;
        private Employee _currentEmployee;
        private readonly RelayCommand _saveCommand;
        private readonly RelayCommand _updateCommand;
        private ObservableCollection<Employee> _employeeList;

        public EmployeeViewModel()
        {
            _employeeService = new EmployeeService();
            Display();
            _currentEmployee = new Employee();
            _saveCommand = new RelayCommand(Save);
            _updateCommand = new RelayCommand(Update);
        }

        public Employee CurrentEmployee
        {
            get { return _currentEmployee; }
            set { _currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        public RelayCommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public RelayCommand UpdateCommand
        {
            get { return _updateCommand; }
        }

        public ObservableCollection<Employee> EmployeesList
        {
            get { return _employeeList; }
            set { _employeeList = value; OnPropertyChanged("EmployeesList"); }
        }
        
        public void Save()
        {
            try
            {
                var IsSaved = _employeeService.Save(CurrentEmployee);
                if (IsSaved)
                {
                    Message = "Employee successfully saved";
                    MessageBox.Show(Message);
                    Display();
                }
                else
                {
                    Message = "Save has failed to complete";
                    MessageBox.Show(Message);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void Update()
        {
            try
            {
                var IsUpdated = _employeeService.Update(CurrentEmployee);
                if (IsUpdated)
                {
                    Message = "Employee successfully updated";
                    MessageBox.Show(Message);
                    Display();
                }
                else
                {
                    Message = "Update has failed to complete";
                    MessageBox.Show(Message);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private void Display()
        {
            EmployeesList = new ObservableCollection<Employee>(_employeeService.GetAll());
        }
    }
}
