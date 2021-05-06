using Company.ViewModels;
using Company.Views;
using System;
using System.Windows.Input;

namespace Company.Commands
{
    class ChangeViewCommand : ICommand
    {
        private readonly MainViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public ChangeViewCommand(MainViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Employee")
            {
                //_viewModel.SelectedViewModel = new EmployeeViewModel();
               EmployeeView employeeView = new EmployeeView();
               employeeView.Show();
            }
            if (parameter.ToString() == "Computer")
            {
                ComputerView computerView = new ComputerView();
                computerView.Show();
            }
            if (parameter.ToString() == "WorkTask")
            {
                WorkTaskView workTaskView = new WorkTaskView();
                workTaskView.Show();
            }
        }
    }
}
