using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using rtwin.lib;

namespace rtwin.View.customDialog
{
    /// <summary>
    /// Interaction logic for alertDelete.xaml
    /// </summary>
    public partial class alertDelete : UserControl
    {
        Action action;
        public alertDelete(Action action)
        {
            this.action=action;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            action();
            
        }
    }
}
