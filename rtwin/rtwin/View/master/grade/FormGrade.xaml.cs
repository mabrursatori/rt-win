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

namespace rtwin.View.master.grade
{
    /// <summary>
    /// Interaction logic for FormGrade.xaml
    /// </summary>
    public partial class FormGrade : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        generateJson js;
        koneksi con;
        string username, kodeGrade;
        public FormGrade(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kodeGrade, string username)
        {
            this.isInsert = isInsert;
            this.isSqlServer = isSqlServer;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            this.js = new generateJson(isSqlServer);
            this.kodeGrade = kodeGrade;
            InitializeComponent();
            if (isInsert)
            {
                gbTitel.Header = "Tambah Data Grade";
            }
            else
            {
                gbTitel.Header = "Edit Data Grade";
                setField();
            }
        }
        void setField()
        {
            try
            {
                List<string> data = con.getDataFromDatabase(queryGrid.getQueryGradeDetail(kodeGrade));
                if (data.Count > 0)
                {
                    txtKode.Text = data[0];
                    txtKode.IsEnabled = false;
                    txtNamaGrade.Text = data[1];
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
            status.Add(new statusForm { formTitel = "Kode Grade", formValue = txtKode.Text });
            status.Add(new statusForm { formTitel = "Nama Grade", formValue = txtNamaGrade.Text });
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
                    message = con.crudDatabase(queryGrid.getQueryInsertGrade(txtKode.Text, txtNamaGrade.Text), Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "12A1", txtKode.Text);
                        setEmpty();
                    }
                }
                else
                {
                    message = con.crudDatabase(queryGrid.getQueryUpdateGrade(txtKode.Text, txtNamaGrade.Text), Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "12A2", txtKode.Text);
                        reload();
                    }
                }

                dialogMessage(message);
            }
        }
        void setEmpty()
        {
            txtKode.Text = "";
            txtNamaGrade.Text = "";
        }

        private void TxtNamaGrade_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AriLib.numBersOnly(e);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
