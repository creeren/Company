using Company.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Company.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        public EmployeeView()
        {
            InitializeComponent();
            this.DataContext = new EmployeeViewModel();
        }
    }
}
