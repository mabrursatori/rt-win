using Newtonsoft.Json;
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

namespace rtwin.View.master.satker
{
    /// <summary>
    /// Interaction logic for FormBiro.xaml
    /// </summary>
    public partial class FormBiro : UserControl
    {
        bool isSqlServer, isInsert;
        Action reload;
        Action<string> dialogMessage;
        string kode, username;
        List<comboBoxTemplate> dataComboDeputi;
        koneksi con;

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
            status.Add(new statusForm { formTitel = "Kode Biro", formValue = txtKode.Text });
            status.Add(new statusForm { formTitel = "Nama Biro", formValue = txtNama.Text });
            status.Add(new statusForm { formTitel = "Nama Deputi", formValue = AriLib.CekEmptyComboBox(cmbDeputi, dataComboDeputi) });
            formValidate validating = new formValidate();
            string message=validating.validate(status);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                if (isInsert)
                {
                    //dialogMessage(txtNama.Text.ToString());
                    string query = queryBiro.getQueryInsertBiro(txtKode.Text, txtNama.Text, dataComboDeputi.Find(x => x.content == (cmbDeputi.SelectedItem as ComboBoxItem).Content.ToString()).name);
                    message = con.crudDatabase(query, Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "1251", txtKode.Text);
                        emptyForm();
                    }
                }
                else
                {
                    string query = queryBiro.getQueryUpdateBiro(txtKode.Text, txtNama.Text, dataComboDeputi.Find(x => x.content == (cmbDeputi.SelectedItem as ComboBoxItem).Content.ToString()).name);
                    message = con.crudDatabase(query, Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "1252", txtKode.Text);
                        reload();
                    }
                }
                dialogMessage(message);
            }
        }
        void emptyForm()
        {
            txtKode.Text = "";
            txtNama.Text = "";
            cmbDeputi.SelectedIndex = 0;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }

        public FormBiro(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kode, string username)
        {
            InitializeComponent();
            this.isSqlServer = isSqlServer;
            this.isInsert = isInsert;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.kode = kode;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            generateComboBoxDeputi();
            if (!isInsert)
            {
                setForm();
                gbTitel.Header = "Edit Biro";
            }
            else
            {
                gbTitel.Header = "Tambah Biro";
            }
        }
        void setForm()
        {
            List<string> data = con.getDataFromDatabase(queryBiro.getQueryDetilBiro(kode));
            txtKode.Text = data[0];
            txtKode.IsEnabled = false;
            txtNama.Text = data[1];
            cmbDeputi.SelectedIndex = dataComboDeputi.IndexOf(dataComboDeputi.Find(x => x.name == data[2]));

        }
        void generateComboBoxDeputi()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbDeputi);
            dataComboDeputi = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryDeputi.getQueryComboDeputi, true, combo, isSqlServer, false));
        }
    }
}
