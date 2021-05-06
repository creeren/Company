using System.ComponentModel;

namespace Company.Models
{
    public class Computer
    {
        private int _computerId;
        private string _computerName;
        private string _notes;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int ComputerId
        {
            get { return _computerId; }
            set { _computerId = value; OnPropertyChanged("EmployeeId"); }
        }

        public string ComputerName
        {
            get { return _computerName; }
            set { _computerName = value; OnPropertyChanged("ComputerName"); }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; OnPropertyChanged("Notes"); }
        }
    }
}
