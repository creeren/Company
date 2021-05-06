using Company.Commands;
using System;
using System.Windows;
using Company.Models;
using System.Collections.ObjectModel;

namespace Company.ViewModels
{
    /// <summary>
    /// Interaction logic for ComputerView.xaml
    /// </summary>
    public class ComputerViewModel : ViewModelBase
    {
        private readonly ComputerService _computerService;
        private Computer _currentComputer;
        private readonly RelayCommand _saveCommand;
        private readonly RelayCommand _updateCommand;
        private ObservableCollection<Computer> _computersList;
       

        public ComputerViewModel()
        {
            _computerService = new ComputerService();
            Display();
            _currentComputer = new Computer();
            _saveCommand = new RelayCommand(Save);
            _updateCommand = new RelayCommand(Update);
        }

        public Computer CurrentComputer
        {
            get { return _currentComputer; }
            set { _currentComputer = value; OnPropertyChanged("CurrentComputer"); }
        }

        public RelayCommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public RelayCommand UpdateCommand
        {
            get { return _updateCommand; }
        }

        public ObservableCollection<Computer> ComputersList
        {
            get { return _computersList; }
            set { _computersList = value; OnPropertyChanged("ComputersList"); }
        }

        public void Save()
        {
            try
            {
                var IsSaved = _computerService.Save(CurrentComputer);
                if (IsSaved)
                {
                    Message = "Computer successfully saved";
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
                var IsUpdated = _computerService.Update(CurrentComputer);
                if (IsUpdated)
                {
                    Message = "Computer successfully updated";
                    MessageBox.Show(Message);
                    Display();
                }
                else
                {
                    Message = "Update has failed to complete";
                    MessageBox.Show(Message);
                }
            }
            catch(Exception ex)
            {
                Message = ex.Message;
            }            
        }

        private void Display()
        {
            ComputersList = new ObservableCollection<Computer>(_computerService.GetAll());
        }
    }
}
