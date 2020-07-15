using rtwin.lib;
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

namespace rtwin.View.master.employee
{
    /// <summary>
    /// Interaction logic for FormEmployee.xaml
    /// </summary>
    public partial class FormEmployee : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        generateJson js;
        koneksi con;
        string username, kodeEselon;
        public FormEmployee(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kodeEselon, string username,int  HeightScress)
        {
            this.isInsert = isInsert;
            this.isSqlServer = isSqlServer;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            this.js = new generateJson(isSqlServer);
            this.kodeEselon = kodeEselon;
            InitializeComponent();
            if (HeightScress < 600)
            {
                svGb.Height = 300;
            }
            else if (HeightScress > 600 && HeightScress < 700)
            {
                svGb.Height = 380;
            }
            else if (HeightScress > 700 && HeightScress < 800)
            {
                svGb.Height = 420;
            }
            else if (HeightScress > 800 && HeightScress < 900)
            {
                svGb.Height = 520;
            }
            if (isInsert)
            {
                gbTitel.Header = "Tambah Data Karyawan";
            }
            else
            {
                gbTitel.Header = "Edit Data Karyawan";
                //setField();
            }
        }

        private void Btnsave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
