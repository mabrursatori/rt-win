using MaterialDesignThemes.Wpf;
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

namespace rtwin.View.transaksi.polajadwal
{
    /// <summary>
    /// Interaction logic for polaJadwalKolektif.xaml
    /// </summary>
    public partial class polaJadwalKolektif : UserControl
    {
        //List<ComboBoxItem> dataBulan =new List<ComboBoxItem>();
        public polaJadwalKolektif(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, string gradeID, string nip)
        {
            InitializeComponent();
            frameCalendar.Content = new calendar.calendar(isSqlServer);
            generateBulan();
        }
        void generateBulan()
        {
            cmbBulan.Items.Add(new ComboBoxItem { Content = "Januari", Name = "Januari" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "Februari", Name = "Februari" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "Maret", Name = "Maret" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "April", Name = "April" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "Mei", Name = "Mei" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "Juni", Name = "Juni" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "Juli", Name = "Juli" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "Agustus", Name = "Agustus" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "September", Name = "September" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "Oktober", Name = "Oktober" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "Novemver", Name = "November" });
            cmbBulan.Items.Add(new ComboBoxItem { Content = "Desember", Name = "Desember" });
            
            /*dataBulan.Add(new ComboBoxItem { Content = "Jan", Name = "Januari" });
            dataBulan.Add(new ComboBoxItem { Content = "Feb", Name = "Februari" });
            dataBulan.Add(new ComboBoxItem { Content = "Mar", Name = "Maret" });
            dataBulan.Add(new ComboBoxItem { Content = "Apr", Name = "April" });
            dataBulan.Add(new ComboBoxItem { Content = "May", Name = "Mei" });
            dataBulan.Add(new ComboBoxItem { Content = "Jun", Name = "Juni" });
            dataBulan.Add(new ComboBoxItem { Content = "Jul", Name = "Juli" });
            dataBulan.Add(new ComboBoxItem { Content = "Aug", Name = "Agustus" });
            dataBulan.Add(new ComboBoxItem { Content = "Sep", Name = "September" });
            dataBulan.Add(new ComboBoxItem { Content = "Oct", Name = "Oktober" });
            dataBulan.Add(new ComboBoxItem { Content = "Nov", Name = "November" });
            dataBulan.Add(new ComboBoxItem { Content = "Dec", Name = "Desember" });*/
            
           // cmbBulan.SelectedIndex(dataBulan.FindIndex(x=>x.Name==DateTime.Now.ToString("MMM")))
        }
    }
}
