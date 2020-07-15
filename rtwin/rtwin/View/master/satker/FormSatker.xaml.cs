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
    /// Interaction logic for FormSatker.xaml
    /// </summary>
    public partial class FormSatker : UserControl
    {
        bool isSqlServer, isInsert;
        Action reload;
        Action<string> dialogMessage;
        string kode, username;
        List<comboBoxTemplate> dataComboUnit;
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
             
            formValidate validating = new formValidate();
            List<statusForm> data = new List<statusForm>();
            data.Add(new statusForm { formTitel = "kode Deputi", formValue = txtKode.Text });
            data.Add(new statusForm { formTitel = "Nama Deputi", formValue = txtNamaDeputi.Text });
            data.Add(new statusForm { formTitel = "Nama Unit", formValue = AriLib.CekEmptyComboBox(cmbUnit, dataComboUnit) });
            string message = validating.validate(data);
            if (message != "")
            {
                dialogMessage(message);

            }
            else
            {
                string kodeUnit = dataComboUnit.Find(x => x.content == (cmbUnit.SelectedItem as ComboBoxItem).Content.ToString()).name;
                if (isInsert)
                {
                    string query = queryDeputi.getQueryInsertDeputi(txtKode.Text, txtNamaDeputi.Text, kodeUnit);
                    message = con.crudDatabase(query, Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        emptyForm();
                        con.createLog(username, "1241", txtKode.Text);
                    }
                }
                else
                {
                    string query = queryDeputi.getQueryUpdateDeputi(txtKode.Text, txtNamaDeputi.Text, kodeUnit);
                    message = con.crudDatabase(query, Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "1242", txtKode.Text);
                        reload();
                    }
                }
                dialogMessage(message);
            }
        }
        void emptyForm()
        {
            txtKode.Text = "";
            txtNamaDeputi.Text = "";
            cmbUnit.SelectedIndex = 0;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }

        public FormSatker(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kode, string username)
        {
            this.isSqlServer = isSqlServer;
            this.isInsert = isInsert;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.kode = kode;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            InitializeComponent();
            generateComboBoxUnit();
            if (!isInsert)
            {
                setForm();
            }
        }
        void setForm()
        {
            List<string> data = con.getDataFromDatabase(queryDeputi.getQueryDetailDeputi(kode));
            if (data.Count > 0)
            {
                txtKode.Text = data[0];
                txtKode.IsEnabled = false;
                txtNamaDeputi.Text = data[1];
                cmbUnit.SelectedIndex = dataComboUnit.IndexOf(dataComboUnit.Find(x=>x.name==data[2]));
            }
        }
        void generateComboBoxUnit()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbUnit);
            string query= queryUnit.getQueryComboBoxUnit;
            dataComboUnit = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(query, true, combo, isSqlServer, false));
            
        }
    }
}
