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

namespace rtwin.View.master.golongan
{
    /// <summary>
    /// Interaction logic for FormGolongan.xaml
    /// </summary>
    public partial class FormGolongan : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        generateJson js;
        koneksi con;
        string username, kodeGolongan, uriTheme;
        public FormGolongan(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kodeGolongan, string username, string uriTheme)
        {
            this.isInsert = isInsert;
            this.isSqlServer = isSqlServer;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            this.js = new generateJson(isSqlServer);
            this.kodeGolongan = kodeGolongan;
            InitializeComponent();
            if (isInsert)
            {
                gbTitel.Header = "Tambah Data Jabatan";
            }
            else
            {
                gbTitel.Header = "Edit Data Jabatan";
                setField();
            }

            this.uriTheme = uriTheme;
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri(uriTheme, UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);
        }
        void setField()
        {
            try
            {
                List<string> data = con.getDataFromDatabase(queryGolongan.getQueryGolonganDetail(kodeGolongan));
                if (data.Count > 0)
                {
                    txtKode.Text = data[0];
                    txtKode.IsEnabled = false;
                    txtNama.Text = data[1];
                    txtTarifMakan.Text = data[2];
                    txtTarifLembur.Text = data[3];
                    txtTarifUangMakanLembur.Text = data[4];
                    txtPajakGolongan.Text = data[5];
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
            status.Add(new statusForm { formTitel = "Kode Golongan", formValue = txtKode.Text });
            status.Add(new statusForm { formTitel = "Nama Golongan", formValue = txtNama.Text });
            status.Add(new statusForm { formTitel = "Tarif Makan", formValue = txtTarifLembur.Text });
            status.Add(new statusForm { formTitel = "Tarif Lembur", formValue = txtTarifLembur.Text });
            status.Add(new statusForm { formTitel = "Tarif Uang Makan Lembur", formValue = txtTarifUangMakanLembur.Text });
            status.Add(new statusForm { formTitel = "Pajak Golongan", formValue = txtPajakGolongan.Text });

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
                    message = con.crudDatabase(queryGolongan.getQueryInsertGolongan(txtKode.Text, txtNama.Text,txtTarifMakan.Text,txtTarifLembur.Text,txtTarifUangMakanLembur.Text,txtPajakGolongan.Text), Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "1291", txtKode.Text);
                        setEmpty();
                    }
                }
                else
                {
                    message = con.crudDatabase(queryGolongan.getQueryUpdateGolongan(txtKode.Text, txtNama.Text, txtTarifMakan.Text, txtTarifLembur.Text, txtTarifUangMakanLembur.Text, txtPajakGolongan.Text), Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "1292", txtKode.Text);
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
            txtPajakGolongan.Text = "";
            txtTarifMakan.Text = "";
            txtTarifLembur.Text = "";
            txtTarifUangMakanLembur.Text = "";
        }

        private void TxtTarifMakan_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AriLib.numBersOnly(e);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
