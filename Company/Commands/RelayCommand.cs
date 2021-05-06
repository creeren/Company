using System;
using System.Windows.Input;

namespace Company.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        //private Action<object> execute;
        //private Func<object, bool> canExecute;
        private readonly Action doAction;
        public RelayCommand(Action doAction)
        {
            this.doAction = doAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //this.execute(parameter);
            doAction();
        }
    }
}
