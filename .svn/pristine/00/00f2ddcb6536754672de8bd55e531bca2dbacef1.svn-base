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
namespace rtwin.View.master.shift
{
    /// <summary>
    /// Interaction logic for shift.xaml
    /// </summary>
    public partial class shift : UserControl
    {
        //bool isSqlServer;
        //TextBlock bredcumb;
        //DialogHost dialogHost;
        //Frame frameContent,dialogContent;
        //Image LoadingContent;
        string uriTheme;

        public shift(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent,string username, string gradeID, string uriTheme)
        {
            InitializeComponent();
            this.uriTheme = uriTheme;
            bredcumb.Text = "Master / Tabel / Pola Jadwal";
            int HeightScress = Convert.ToInt32(System.Windows.SystemParameters.WorkArea.Height);
            frameHarian.Content = new shiftHarian(isSqlServer, bredcumb, dialogHost, frameHarian, LoadingContent, dialogContent, username, HeightScress, gradeID, uriTheme);
            frameMingguan.Content = new shftMingguan(isSqlServer,bredcumb,dialogHost,frameMingguan,LoadingContent,dialogContent, username,HeightScress, gradeID, uriTheme);
            //MessageBox.Show(HeightScress.ToString());
            
        }
    }
}
