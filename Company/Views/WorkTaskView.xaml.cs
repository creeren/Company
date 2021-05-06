using Company.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Company.Views
{
    /// <summary>
    /// Interaction logic for WorkTask.xaml
    /// </summary>
    public partial class WorkTaskView : Window
    {
        //private EmployeeViewModel DataContext2;

        public WorkTaskView()
        {
            InitializeComponent();
            this.DataContext = new WorkTaskViewModel();
            //this.DataContext = new EmployeeViewModel();
        }
    }
}
