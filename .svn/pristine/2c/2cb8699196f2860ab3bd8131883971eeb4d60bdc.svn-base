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

namespace rtwin.View.master.eselon
{
    /// <summary>
    /// Interaction logic for FormEselon.xaml
    /// </summary>
    public partial class FormEselon : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        generateJson js;
        koneksi con;
        string username, kodeEselon;
        public FormEselon(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kodeEselon, string username)
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
            if (isInsert)
            {
                gbTitel.Header = "Tambah Data Eselon";
            }
            else
            {
                gbTitel.Header = "Edit Data Eselon";
                setField();
            }
        }
        void setField()
        {
            try
            {
                List<string> data = con.getDataFromDatabase(queryEselon.getQueryEselonDetail(kodeEselon));
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
            status.Add(new statusForm { formTitel = "Kode Eselon", formValue = txtKode.Text });
            status.Add(new statusForm { formTitel = "Nama Eselon", formValue = txtNama.Text });
           
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
                    message = con.crudDatabase(queryEselon.getqueryInsertEselon(txtKode.Text, txtNama.Text), Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "12B1", txtKode.Text);
                        setEmpty();
                    }
                }
                else
                {
                    message = con.crudDatabase(queryEselon.getQueryUpdateEselon(txtKode.Text, txtNama.Text), Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "12B2", txtKode.Text);
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
