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
using rtwin.lib;
using rtwin.Model;
using rtwin.dataQuery;
using MaterialDesignThemes.Wpf;
using rtwin.View.customDialog;
using System.ComponentModel;
using System.Threading;

namespace rtwin.View.master.lembur
{
    /// <summary>
    /// Interaction logic for parameterLembur.xaml
    /// </summary>
    public partial class parameterLembur : UserControl
    {
        bool isSqlServer;
        TextBlock bredcumb;
        DialogHost dialogHost;
        Frame frameContent, dialogContent;
        Image LoadingContent;
        koneksi kon;
        string username;
        string gradeID;
        public parameterLembur(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, string gradeID)
        {
            this.isSqlServer = isSqlServer;
            this.bredcumb = bredcumb;
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.dialogContent = dialogContent;
            this.username = username;
            this.kon = new koneksi(isSqlServer);
            this.gradeID = gradeID;
            InitializeComponent();
            setForm();
            if (gradeID != "1")
            {
                btnsave.Visibility = Visibility.Hidden;
                jamMinimumLembur.IsEnabled = false;
                jamMaksimumLembur.IsEnabled = false;
                jamMinimumLemburHariLibur.IsEnabled = false;
                jamMaksimalLemburHariLibur.IsEnabled = false;
                jumMaksimumTotalLembur.IsEnabled = false;
                jumMaksimumTerimaUangMakan.IsEnabled = false;
                tarifUangMakanLembur.IsEnabled = false;
            }
        }
        void setForm()
        {
            List<string> data = kon.getDataFromDatabase(queryPaarameterLembur.getQueryVariabelLembur);
            jamMinimumLembur.Text = Convert.ToDateTime(data[0]).ToString("hh:mm");
            jamMaksimumLembur.Text = Convert.ToDateTime(data[1]).ToString("hh:mm");
            jamMinimumLemburHariLibur.Text = Convert.ToDateTime(data[2]).ToString("hh:mm");
            jamMaksimalLemburHariLibur.Text = Convert.ToDateTime(data[3]).ToString("hh:mm");
            jumMaksimumTotalLembur.Text = data[4];
            jumMaksimumTerimaUangMakan.Text = data[5];
            tarifUangMakanLembur.Text = data[6];
        }

        private void JumMaksimumTotalLembur_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AriLib.numBersOnly(e);
        }

        private void JumMaksimumTerimaUangMakan_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AriLib.numBersOnly(e);
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
            List<statusForm> status = new List<statusForm>();
            status.Add(new statusForm { formTitel = "Jam Minimum Lembur", formValue = jamMinimumLembur.Text.Replace("__:__", "") });
            status.Add(new statusForm { formTitel = "Jam Maksimal Lembur", formValue = jamMaksimumLembur.Text.Replace("__:__", "") });
            status.Add(new statusForm { formTitel = "Jam Minimal Lembur Hari Libur", formValue = jamMinimumLemburHariLibur.Text.Replace("__:__", "") });
            status.Add(new statusForm { formTitel = "Jam Maksimal Lembur Hari Libur", formValue = jamMaksimalLemburHariLibur.Text.Replace("__:__", "") });
            status.Add(new statusForm { formTitel = "Jumlah Maksimal Total Lembur", formValue = jumMaksimumTotalLembur.Text });
            status.Add(new statusForm { formTitel = "Jumlah Maksimal Terima Uang Makan", formValue = jumMaksimumTerimaUangMakan.Text });
            status.Add(new statusForm { formTitel = "Tarif Uang Makan Lembur", formValue = tarifUangMakanLembur.Text });
            formValidate validating = new formValidate();
            string message = validating.validate(status);
            if (message != "")
            {
               AriLib.showDialog(message,dialogContent,dialogHost);
            }
            else
            {
                string query = queryPaarameterLembur.getQueryUpdateVariabelLembur(jamMinimumLembur.Text, jamMaksimumLembur.Text, jamMinimumLemburHariLibur.Text, jamMaksimalLemburHariLibur.Text, jumMaksimumTotalLembur.Text, jumMaksimumTerimaUangMakan.Text, tarifUangMakanLembur.Text);
                message = kon.crudDatabase(query, Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                if (message == Message.MSG_UPDATE_SUCCES)
                {
                    AriLib.showDialog(message, dialogContent, dialogHost);
                    reload();
                }
            }
        }

        void reload()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    this.frameContent.Content = "";
                    this.LoadingContent.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                this.LoadingContent.Visibility = Visibility.Hidden;
                frameContent.Content = new parameterLembur(isSqlServer, bredcumb, dialogHost, frameContent, LoadingContent, dialogContent, username, gradeID);

            };
            worker.RunWorkerAsync();
        }
        private void TarifUangMakanLembur_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AriLib.numBersOnly(e);
        }

    }
}
