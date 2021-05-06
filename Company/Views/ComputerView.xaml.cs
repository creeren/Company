using System;
using System.Windows;
using Company.ViewModels;

namespace Company.Views
{
    /// <summary>
    /// Interaction logic for ComputerView.xaml
    /// </summary>
    public partial class ComputerView : Window
    {
        public ComputerView()
        {
            InitializeComponent();
            this.DataContext = new ComputerViewModel();
        }
    }
}
