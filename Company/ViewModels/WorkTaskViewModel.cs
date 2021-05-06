using System;
using Company.Commands;
using Company.Models;
using System.Windows;
using System.Collections.ObjectModel;

namespace Company.ViewModels
{
    /// <summary>
    /// Interaction logic for WorkTaskView.xaml
    /// </summary>
    public class WorkTaskViewModel : ViewModelBase
    {
        private readonly WorkTaskService _workTaskService;
        private WorkTask _currentWorkTask;
        private WorkTask _searchTitle;
        private readonly RelayCommand _saveCommand;
        private readonly RelayCommand _updateCommand;
        private readonly RelayCommand _deleteCommand;
        private readonly RelayCommand _searchCommand;
        private ObservableCollection<WorkTask> _workTasksList;
        private readonly EmployeeViewModel _employeeViewModel;
        private readonly ComputerViewModel _computerViewModel;

        public WorkTaskViewModel()
        {
            _workTaskService = new WorkTaskService();
            Display();
            _currentWorkTask = new WorkTask();
            _saveCommand = new RelayCommand(Save);
            _updateCommand = new RelayCommand(Update);
            _deleteCommand = new RelayCommand(Delete);
            _searchCommand = new RelayCommand(Search);
            _employeeViewModel = new EmployeeViewModel();
            _computerViewModel = new ComputerViewModel();
        }

        public WorkTask CurrentWorkTask
        {
            get { return _currentWorkTask; }
            set { _currentWorkTask = value; OnPropertyChanged("CurrentWorkTask");}
        }
        
        public WorkTask SearchTitle
        {
            get { return _searchTitle; }
            set { _searchTitle = value; OnPropertyChanged("SearchTitle"); }
        }

        public RelayCommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public RelayCommand UpdateCommand
        {
            get { return _updateCommand; }
        }

        public RelayCommand DeleteCommand
        {
            get { return _deleteCommand; }
        }

        public RelayCommand SearchCommand
        {
            get { return _searchCommand; }
        }

        public ObservableCollection<WorkTask> WorkTasksList
        {
            get { return _workTasksList; }
            set { _workTasksList = value; OnPropertyChanged("WorkTasksList"); }
        }

        public EmployeeViewModel EmployeeViewModel
        {
            get { return _employeeViewModel; }
        }

        public ObservableCollection<Employee> EmployeesList
        {
            get { return EmployeeViewModel.EmployeesList; }
        }

        public Employee CurrentEmployee
        {
            get { return EmployeeViewModel.CurrentEmployee; }
        }

        public ComputerViewModel ComputerViewModel
        {
            get { return _computerViewModel; }
        }

        public ObservableCollection<Computer> ComputersList
        {
            get { return ComputerViewModel.ComputersList; }
        }

        public Computer CurrentComputer
        {
            get { return ComputerViewModel.CurrentComputer; }
        }

        public void Save()
        {
            try
            {
                var IsSaved = _workTaskService.Save(CurrentWorkTask);
                if (IsSaved)
                {
                    Message = "Work Task successfully saved";
                    MessageBox.Show(Message);
                    Display();
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
                var IsUpdated = _workTaskService.Update(CurrentWorkTask);
                if (IsUpdated)
                {
                    Message = "Work Task successfully updated";
                    MessageBox.Show(Message);
                    Display();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void Delete()
        {
            try
            {
                var IsDeleted = _workTaskService.Delete(CurrentWorkTask.TaskId);
                if (IsDeleted)
                {
                    Message = "Work Task successfully deleted";
                    MessageBox.Show(Message);
                    Display();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void Search()
        {
            try
            {
                var workTask = _workTaskService.Search(CurrentWorkTask.SearchTitle);
                if(workTask != null)
                {
                    WorkTasksList = new ObservableCollection<WorkTask>(_workTaskService.Search(CurrentWorkTask.SearchTitle));
                }
                else
                {
                    Message = "Work task not found";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        private void Display()
        {
            WorkTasksList = new ObservableCollection<WorkTask>(_workTaskService.GetAll());
        }
    }
}
