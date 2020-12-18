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
using System.Resources;
using System.Reflection;
using CPUSimulator.UI.Resources;
using CPUSimulator.UI.ViewModel;

namespace CPUSimulator.UI.View
{
    /// <summary>
    /// Interaction logic for Instructions.xaml
    /// </summary>
    public partial class Instructions : UserControl
    {
        public Instructions()
        {
            this.DataContext = new InstructionsViewModel();
            InitializeComponent();
        }
    }
}
