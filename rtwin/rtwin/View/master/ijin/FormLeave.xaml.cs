using rtwin.dataQuery;
using rtwin.lib;
using rtwin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace rtwin.View.master.ijin
{
    /// <summary>
    /// Interaction logic for FormLeave.xaml
    /// </summary>
    public partial class FormLeave : UserControl
    {
        bool isSqlServer, isInsert;
        Action<string> dialogMessage;
        Action reload;
        string kodeIjin, username;
        koneksi con;
        generateJson gj;
        public FormLeave(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kodeIjin, string username)
        {
            this.isSqlServer = isSqlServer;
            this.isInsert = isInsert;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.kodeIjin = kodeIjin;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            this.gj = new generateJson(isSqlServer);
            InitializeComponent();
            generateComboBox();
            if (!isInsert)
            {
                setForm();
                gbTitel.Header = "Edit Data Status Absen";
            }
            else
            {
                gbTitel.Header = "Tambah Data Status Absen";
            }
        }
        void setForm()
        {
            List<string> data = con.getDataFromDatabase(queryIjin.getQueryDetailDataIjin(kodeIjin));
            txtKodeIjin.Text = data[0].ToString();
            txtKetIjin.Text = data[1].ToString();
            cmbPerhitungan.SelectedIndex = Convert.ToInt32(data[2])-1;
            cmbKetentuan.SelectedIndex = Convert.ToInt32(data[3]) - 1;
            txtjatah.Text = data[4];
            cmbKetKredit.SelectedIndex = Convert.ToInt32(data[5]) + 1;
            txtBerlaku.Text = data[6];
            cmbKetDasar.SelectedIndex = Convert.ToInt32(data[7])+1;
            cmbBerlakuDiawal.SelectedIndex = Convert.ToInt32(data[8]);
            cmbKodeTidakHadir.SelectedIndex = Convert.ToInt32(data[9]);
            chkHitungHariKerja.IsChecked = Convert.ToBoolean(data[10]);
            chkPerhitunganJamKerja.IsChecked = Convert.ToBoolean(data[11]);
            txtPotongan.Text = data[12];
        }
        void generateComboBox()
        {
            cmbPerhitungan.Items.Add(new ComboBoxItem { Content = "1 - Hari Kalendar",IsSelected=true});
            cmbPerhitungan.Items.Add(new ComboBoxItem { Content = "2 - Hari Kerja" });
            cmbPerhitungan.Items.Add(new ComboBoxItem { Content = "3 - Paruh Hari" });

            cmbKetentuan.Items.Add(new ComboBoxItem { Content = "1 - Setiap Tahun",IsSelected=true });
            cmbKetentuan.Items.Add(new ComboBoxItem { Content = "2 - Setelah 6 Tahun" });
            cmbKetentuan.Items.Add(new ComboBoxItem { Content = "3 - Setelah 7 tahun" });
            cmbKetentuan.Items.Add(new ComboBoxItem { Content = "4 - 1 X Seumur Hidup" });
            cmbKetentuan.Items.Add(new ComboBoxItem { Content = "5 - Kebijaksanaan" });

            cmbKetKredit.Items.Add(new ComboBoxItem { Content = "",IsSelected=true });
            cmbKetKredit.Items.Add(new ComboBoxItem { Content = "0 - Manual", });
            cmbKetKredit.Items.Add(new ComboBoxItem { Content = "1 - Otomatis" });

            cmbKetDasar.Items.Add(new ComboBoxItem { Content = "",IsSelected=true });
            cmbKetDasar.Items.Add(new ComboBoxItem { Content = "0 - Tgl Masuk Kerja" });
            cmbKetDasar.Items.Add(new ComboBoxItem { Content = "1 - Awal Tahun" });

            cmbBerlakuDiawal.Items.Add(new ComboBoxItem { Content = "",IsSelected=true });
            cmbBerlakuDiawal.Items.Add(new ComboBoxItem { Content = "1 - Ya" });
            cmbBerlakuDiawal.Items.Add(new ComboBoxItem { Content = "2 - Tidak" });

            cmbKodeTidakHadir.Items.Add(new ComboBoxItem { Content = "0 - Tanpa Keterangan",IsSelected=true });
            cmbKodeTidakHadir.Items.Add(new ComboBoxItem { Content = "1 - Ijin/Cuti/Dinas/Sakit" });
            cmbKodeTidakHadir.Items.Add(new ComboBoxItem { Content = "2 - Terlambat" });
            cmbKodeTidakHadir.Items.Add(new ComboBoxItem { Content = "3 - Cepat Pulang" });
            cmbKodeTidakHadir.Items.Add(new ComboBoxItem { Content = "4 - Lambat & Cepat Pulang" });
            cmbKodeTidakHadir.Items.Add(new ComboBoxItem { Content = "5 - Paruh Hari" });
            cmbKodeTidakHadir.Items.Add(new ComboBoxItem { Content = "6 - Alpha/Mangkir" });
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }

        private void Btnsave_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    this.lodongSave.Visibility = Visibility.Visible;
                    btnsave.IsEnabled = false;
                }), null);
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {

                    saving();

                }), null);
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                this.lodongSave.Visibility = Visibility.Hidden;
                btnsave.IsEnabled = true;
                //reload();

            };
            worker.RunWorkerAsync();
        }
        void saving()
        {
            List<statusForm> statusForms = new List<statusForm>();
            statusForms.Add(new statusForm { formTitel = "Kode Ijin", formValue = txtKodeIjin.Text });
            statusForms.Add(new statusForm { formTitel = " Jenis Ijin", formValue = txtKetIjin.Text });
            formValidate validating = new formValidate();
            string message = validating.validate(statusForms);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                string[] perhitungan= (cmbPerhitungan.SelectedItem as ComboBoxItem).Content.ToString().Split('-');
                string[] ketentuan = (cmbKetentuan.SelectedItem as ComboBoxItem).Content.ToString().Split('-');
                string[] ketKredit = (cmbKetKredit.SelectedItem as ComboBoxItem).Content.ToString().Split('-');
                string[] ketDasar = (cmbKetDasar.SelectedItem as ComboBoxItem).Content.ToString().Split('-');
                string[] berlakuDiawal = (cmbBerlakuDiawal.SelectedItem as ComboBoxItem).Content.ToString().Split('-');
                string[] kodeTidakHadir = (cmbKodeTidakHadir.SelectedItem as ComboBoxItem).Content.ToString().Split('-');
                string query = String.Empty;
                if (isInsert)
                {
                    query = queryIjin.getQueryInsertDataIjin(txtKetIjin.Text, perhitungan[0].TrimEnd(), ketentuan[0].TrimEnd(), txtjatah.Text,ketKredit[0].TrimEnd() , txtBerlaku.Text, ketDasar[0].TrimEnd() ,berlakuDiawal[0].TrimEnd() ,kodeTidakHadir[0].TrimEnd() , chkHitungHariKerja.IsChecked.Value.ToString(), chkPerhitunganJamKerja.IsChecked.Value.ToString(), txtPotongan.Text, txtKodeIjin.Text);
                    message = con.crudDatabase(query, Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        setEmpty();
                        con.createLog(username, "1141", txtKodeIjin.Text);
                    }
                }
                else
                {
                    query = queryIjin.getQueryUpdateDataIjin(txtKetIjin.Text, perhitungan[0].TrimEnd(), ketentuan[0].TrimEnd(), txtjatah.Text, ketKredit[0].TrimEnd(), txtBerlaku.Text, ketDasar[0].TrimEnd(), berlakuDiawal[0].TrimEnd(), kodeTidakHadir[0].TrimEnd(), chkHitungHariKerja.IsChecked.Value.ToString(), chkPerhitunganJamKerja.IsChecked.Value.ToString(), txtPotongan.Text, txtKodeIjin.Text);
                    message = con.crudDatabase(query, Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "1142", txtKodeIjin.Text);
                        reload();
                    }

                }
                dialogMessage(message);
                
            }
        }
        void setEmpty()
        {

        }
    }
}
