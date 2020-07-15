using rtwin.dataQuery;
using rtwin.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace rtwin.View.master.lembur
{
    /// <summary>
    /// Interaction logic for FormFaktorPengali.xaml
    /// </summary>
    public partial class FormFaktorPengali : UserControl
    {
        bool isSqlServer, isInsert;
        Action reload;
        Action<string> dialogMessage;
        string kode, username;
        koneksi kon;
        
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

            status.Add(new statusForm { formTitel = "Faktor", formValue = txtFaktor.Text });
            formValidate validating = new formValidate();
            string message=validating.validate(status);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                message = kon.crudDatabase(queryPaarameterLembur.getQueryUpdateParameterLembur(txtFaktor.Text.Replace(',','.'), txtKode.Text),Message.MSG_SAVE_SUCCES,Message.MSG_SAVE_FAILED);
                if (message == Message.MSG_SAVE_SUCCES)
                {
                    kon.createLog(username, "1154", txtKode.Text);
                    reload();
                }
                dialogMessage(message);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }

        
        private void TxtFaktor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AriLib.numBersOnly(e);
        }

        public FormFaktorPengali(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kode, string username)
        {
            this.isSqlServer = isSqlServer;
            this.isInsert = isInsert;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.kode = kode;
            this.username = username;
            this.kon = new koneksi(isSqlServer);
            InitializeComponent();
            if (!isInsert)
            {
                setValueTOFOrm();
            }
        }
        void setValueTOFOrm()
        {
            List<string> data = kon.getDataFromDatabase(queryPaarameterLembur.getQueryDetailParameterLembur(kode));

            txtKode.Text = data[0];
            txtHariLembur.Text = data[1];
            txtFaktor.Text = data[2];
        }
    }
}
