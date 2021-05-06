using System.ComponentModel;

namespace Company.ViewModels
{
    /// <summary>
    /// Base class for ViewModels
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {      
        public event PropertyChangedEventHandler PropertyChanged;
        public string message;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
    }
}
