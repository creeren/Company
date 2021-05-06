using Company.ViewModels;

namespace Company.Models
{
    public class WorkTask : ViewModelBase
    {
        private int _taskId;
        private string _taskTitle;
        private string _searchTitle;
        private string _taskDescription;
        private int _employeeId;
        private int _computerId;

        public int TaskId
        {
            get { return _taskId; }
            set { _taskId = value; OnPropertyChanged("TaskId"); }
        }

        public string TaskTitle
        {
            get { return _taskTitle; }
            set { _taskTitle = value; OnPropertyChanged("TaskTitle"); }
        }

        public string SearchTitle
        {
            get { return _searchTitle; }
            set { _searchTitle = value; OnPropertyChanged("SearchTitle");  }
        }

        public string TaskDescription
        {
            get { return _taskDescription; }
            set { _taskDescription = value; OnPropertyChanged("TaskDescription"); }
        }

        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; OnPropertyChanged("EmployeeId"); }
        }

        public int ComputerId
        {
            get { return _computerId; }
            set { _computerId = value; OnPropertyChanged("ComputerId"); }
        }
    }
}
