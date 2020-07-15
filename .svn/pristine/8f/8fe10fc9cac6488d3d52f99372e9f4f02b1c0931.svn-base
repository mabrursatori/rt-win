using rtwin.dataQuery;
using rtwin.lib;
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

namespace rtwin.View.master.status_pegawai
{
    /// <summary>
    /// Interaction logic for FormStatusPegawai.xaml
    /// </summary>
    public partial class FormStatusPegawai : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        generateJson js;
        koneksi con;
        string username, kodeStatusPegawai;
        public FormStatusPegawai(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kodeStatusPegawai, string username)
        {
            InitializeComponent();
            this.isInsert = isInsert;
            this.isSqlServer = isSqlServer;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            this.js = new generateJson(isSqlServer);
            this.kodeStatusPegawai = kodeStatusPegawai;
            if (isInsert)
            {
                gbTitel.Header = "Tambah Data Status Pegawai";
            }
            else
            {
                gbTitel.Header = "Edit Data Statius Pegawai";
                setField();
            }
        }
        void setField()
        {
            try
            {
                List<string> data = con.getDataFromDatabase(queryStatusPegawai.getQueryStatusPegawaiDetail(kodeStatusPegawai));
                if (data.Count > 0)
                {
                    txtKode.Text = data[0];
                    txtKode.IsEnabled = false;
                    txtNama.Text = data[1];

                }
            }
            catch (Exception x)
            {
                dialogMessage(x.Message);
            }



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

                    saving();

                }), null);
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                this.lodongSave.Visibility = Visibility.Hidden;
                //reload();

            };
            worker.RunWorkerAsync();

        }
        void saving()
        {
            List<statusForm> status = new List<statusForm>();
            status.Add(new statusForm { formTitel = "Kode Status Pegawai", formValue = txtKode.Text });
            status.Add(new statusForm { formTitel = "Nama Status Pegawai", formValue = txtNama.Text });

            formValidate validate = new formValidate();
            string message = validate.validate(status);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                if (isInsert)
                {
                    message = con.crudDatabase(queryStatusPegawai.getQueryInsertStatusPegawai(txtKode.Text, txtNama.Text), Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "12C1", txtKode.Text);
                        setEmpty();
                    }
                }
                else
                {
                    message = con.crudDatabase(queryStatusPegawai.getQueryUpdateStatusPegawai(txtKode.Text, txtNama.Text), Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "12C2", txtKode.Text);
                        reload();
                    }
                }

                dialogMessage(message);
            }
        }
        void setEmpty()
        {
            txtKode.Text = "";
            txtNama.Text = "";

        }


        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
