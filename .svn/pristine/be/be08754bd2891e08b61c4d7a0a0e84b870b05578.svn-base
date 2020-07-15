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

namespace rtwin.View.connection
{
    /// <summary>
    /// Interaction logic for connection.xaml
    /// </summary>
    public partial class connection : UserControl
    {
        //Frame frmLogin;
        public connection()
        {
            InitializeComponent();
           
            cmbKoneksi.Name= "pg";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //frmLogin.Content = new LoginControl();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((cmbKoneksi.SelectedItem as ComboBoxItem).Name.ToString());
        }
    }
}
