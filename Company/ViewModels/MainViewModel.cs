using Company.Commands;
using System.Windows.Input;

namespace Company.ViewModels
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand ChangeViewCommand { get; set; }
        public MainViewModel()
        {
            ChangeViewCommand = new ChangeViewCommand(this);
        }
    }
}
