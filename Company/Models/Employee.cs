using System.ComponentModel;

namespace Company.Models
{
    public class Employee
    {
        private int _employeeId;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int EmployeeId 
        {
            get { return _employeeId; }
            set { _employeeId = value; OnPropertyChanged("EmployeeId"); }
        }

        public string FirstName 
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); }
        }

        public string LastName 
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }

        public string PhoneNumber 
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged("PhoneNumber"); }
        }
    }
}
