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
using rtwin.Model;
using rtwin.lib;
using System.Globalization;
using System.ComponentModel;
using System.Threading;

namespace rtwin.View.master.timecard
{
    /// <summary>
    /// Interaction logic for FormEditDataTimeCard.xaml
    /// </summary>
    public partial class FormEditDataTimeCard : UserControl
    {
        bool isSqlServer;
        Action<string> dialogMessage;
        Action reload;
        koneksi kon;
        List<string> data;
        string username;
        public FormEditDataTimeCard(bool isSqlServer,Action reload,Action<string> dialogMessage,List<string> data,string username)
        {
            this.isSqlServer = isSqlServer;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.kon = new koneksi(isSqlServer);
            this.data = data;
            this.username=username;
            InitializeComponent();
            setDataToComponent();
        }
        void setDataToComponent()
        {
            kodeRange.Text = data[0].ToString();
            kodeRange.IsEnabled = true;
            jamMasuk.Text = data[1].ToString();
            jamPulang.Text = data[2].ToString();
            tolTelat.Text = data[3].ToString();
            tolPulang.Text = data[4].ToString();
            limitAwal.Text = data[5].ToString();
            limitAkhir.Text = data[6].ToString();
            jamKerja.Text = data[7].ToString();
        }
        private void Btnsave_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    this.lodongSave.Visibility = Visibility.Visible;

                }), null);
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    editProcess();

                }), null);
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                this.lodongSave.Visibility = Visibility.Hidden;
                reload();

            };
            worker.RunWorkerAsync();
            

        }
        void editProcess()
        {
            List<statusForm> statusForms = new List<statusForm>();
            statusForms.Add(new statusForm { formTitel = "Kode Range", formValue = kodeRange.Text });
            statusForms.Add(new statusForm { formTitel = "Jam Masuk", formValue = jamMasuk.Text.Replace("__:__", "") });
            statusForms.Add(new statusForm { formTitel = "Jam Pulang", formValue = jamPulang.Text.Replace("__:__", "") });
            statusForms.Add(new statusForm { formTitel = "Toleransi Telat", formValue = tolTelat.Text });
            statusForms.Add(new statusForm { formTitel = "Toleransi Pulang", formValue = tolPulang.Text });
            statusForms.Add(new statusForm { formTitel = "Limit Awal", formValue = limitAwal.Text.Replace("__:__", "") });
            statusForms.Add(new statusForm { formTitel = "Limit Akhir", formValue = limitAkhir.Text.Replace("__:__", "") });
            statusForms.Add(new statusForm { formTitel = "Jam Kerja", formValue = jamKerja.Text.Replace("__:__", "") });
            formValidate cek = new formValidate();
            string status = cek.validate(statusForms);
            if (status != "")
            {

                dialogMessage(status);
            }
            else
            {
                try
                {
                    DateTime dt1 = DateTime.ParseExact(jamPulang.Text, "HH:mm", new DateTimeFormatInfo());
                    DateTime dt2 = DateTime.ParseExact(jamMasuk.Text, "HH:mm", new DateTimeFormatInfo());
                    DateTime dt3 = DateTime.ParseExact(jamKerja.Text, "HH:mm", new DateTimeFormatInfo());
                    TimeSpan ts = dt1.Subtract(dt2);
                    TimeSpan JamIstirahat = ts.Subtract(dt3.TimeOfDay);

                    string query = "UPDATE taRange set JAM_AWAL='1900-01-01 " + jamMasuk.Text + ":00', JAM_AKHIR='1900-01-01 " + jamPulang.Text + ":00', TOL_MASUK='" + tolTelat.Text + "', TOL_PULANG='" + tolPulang.Text + "', LIMIT_AWAL='1900-01-01 " + limitAwal.Text + ":00', LIMIT_AKHIR='1900-01-01 " + limitAkhir.Text + ":00', JAM_KERJA='1900-01-01 " + jamKerja.Text + ":00', JAM_ISTIRAHAT='1900-01-01 " + JamIstirahat + "' where KODE_RANGE='" + kodeRange.Text + "'";

                    string message = kon.crudDatabase(query, "Data Berhasil Diedit", "Data Gagal Diedit");
                    if (message == "Data Berhasil Diedit")
                    {
                        kon.createLog(username, "1112", kodeRange.Text);
                    }
                    dialogMessage(message);

                }
                catch (Exception exc)
                {
                    dialogMessage(exc.Message);
                }
                

            }
        }
        void emptyForm()
        {
            kodeRange.Text = "";
            jamMasuk.Text = "";
            jamPulang.Text = "";
            jamKerja.Text = "";
            jamIstirahat.Text = "";
            tolPulang.Text = "";
            tolTelat.Text = "";
            limitAwal.Text = "";
            limitAkhir.Text = "";
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
