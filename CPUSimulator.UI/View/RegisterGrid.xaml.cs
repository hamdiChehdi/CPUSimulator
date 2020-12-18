using CPUSimulator.UI.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPUSimulator.UI.View
{
    /// <summary>
    /// Interaction logic for RegisterGrid.xaml
    /// </summary>
    public partial class RegisterGrid : UserControl
    {
        public RegisterGrid()
        {
            DataContext = new RegisterGridViewModel();
            InitializeComponent();
        }
    }
}
