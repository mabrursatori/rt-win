using rtwin.lib;
using rtwin.Model;
using rtwin.dataQuery;
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
using System.ComponentModel;
using System.Threading;

namespace rtwin.View.master.libur
{
    /// <summary>
    /// Interaction logic for FormLibur.xaml
    /// </summary>
    public partial class FormLibur : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        generateJson js;
        koneksi con;
        string username,TglLibur;
        
        public FormLibur(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string TglLibur, string username)
        {
            this.isInsert = isInsert;
            this.isSqlServer = isSqlServer;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            this.js = new generateJson(isSqlServer);
            this.TglLibur = TglLibur;
            InitializeComponent();
            if (isInsert)
            {
                gbTitel.Header = "Tambah Data Libur";
            }
            else
            {
                setField();
            }
        }
        void setField()
        {
            try
            {
                List<string> data = con.getDataFromDatabase(queryLibur.getQueryDetailDataLibur(Convert.ToDateTime(TglLibur).ToString("yyyy-MM-dd")));
                if (data.Count > 0)
                {
                    tglLibur.Text = Convert.ToDateTime(data[0]).ToString("dd/MM/yyyy");
                    txtKeterangan.Text = data[1];
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
            status.Add(new statusForm { formTitel = "Tanggal Libur", formValue = tglLibur.Text });
            status.Add(new statusForm { formTitel = "Keterangan Libur", formValue = txtKeterangan.Text });
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
                    message = con.crudDatabase(queryLibur.getQueryInputLibur(Convert.ToDateTime(tglLibur.Text).ToString("yyyy-MM-dd"), txtKeterangan.Text), Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "1131", tglLibur.Text);
                        setEmpty();
                    }
                }
                else
                {
                    message = con.crudDatabase(queryLibur.getQueryUpdateLibur(Convert.ToDateTime(tglLibur.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(TglLibur).ToString("yyyy-MM-dd"), txtKeterangan.Text),Message.MSG_UPDATE_SUCCES,Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "1132", tglLibur.Text);
                        reload();
                    }
                }
                
                dialogMessage(message);
            }
        }
        void setEmpty()
        {
            txtKeterangan.Text = "";
            tglLibur.Text = "";
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
