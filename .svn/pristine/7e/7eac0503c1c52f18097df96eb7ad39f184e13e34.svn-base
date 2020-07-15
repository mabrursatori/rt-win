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
using Newtonsoft.Json;
using rtwin.lib;
using rtwin.Model;
namespace rtwin.View.master.timecard
{
    /// <summary>
    /// Interaction logic for FormTimeCardDetail.xaml
    /// </summary>
    public partial class FormTimeCardDetail : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        List<comboBoxTemplate> dataSatker;
        generateJson js;
        koneksi con;
        string username;
        public FormTimeCardDetail(bool isSqlServer,bool isInsert, Action reload, Action<string> dialogMessage, string kodeRange,string username)
        {
            InitializeComponent();
            this.isSqlServer = isSqlServer;
            this.isInsert = isInsert;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.username = username;
            js = new generateJson(isSqlServer);
            con = new koneksi(isSqlServer);
            generateComboBox();
            if (!isInsert)
            {
                string query = "select * from q_RangeDetail Where KODE_RANGE='" + kodeRange + "'";
                List<string> data = con.getDataFromDatabase(query);
                cmbKodeRange.SelectedValue = data[0];
                cmbKodeRange.IsEnabled = false;
                cmbKodeDepartemen.SelectedValue = data[3];
                detail.Text = data[2];
                gbTitel.Header = "Edit Data Waktu Kerja Detail";
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

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
        void generateComboBox()
        {
            
            List<string> dataKodeRange = con.getDataFromDatabase(query.queryKodeRange);
            cmbKodeRange.Items.Add(new ComboBoxItem { Content = "" });
            for (int i = 0; i < dataKodeRange.Count; i++)
            {
                cmbKodeRange.Items.Add(new ComboBoxItem { Content = dataKodeRange[i] });
            }
            string json = js.generateDataJson(query.queryCabangForDropdown);
            this.dataSatker = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(json);
            if (dataSatker.Count > 0)
            {
                for (int i = 0; i < dataSatker.Count; i++)
                {

                    cmbKodeDepartemen.Items.Add(new ComboBoxItem { Content = dataSatker[i].content });
                }
            }

        }
        void saving()
        {
            List<statusForm> status = new List<statusForm>();
            string kodeDepartemen = "";
            string kodeRange = "";
            if (cmbKodeDepartemen.SelectedIndex > 0)
            {
                kodeDepartemen= dataSatker[cmbKodeDepartemen.SelectedIndex].name;
            }
            if (cmbKodeRange.SelectedIndex > 0)
            {
                kodeRange = (cmbKodeRange.SelectedItem as ComboBoxItem).Content.ToString();
            }
            //MessageBox.Show(kodeDepartemen + "," + kodeRange);
            status.Add(new statusForm { formTitel = "Kode Range", formValue = kodeRange});
            status.Add(new statusForm { formTitel = "Nama Departemen", formValue = kodeDepartemen });
            status.Add(new statusForm { formTitel = "Detail", formValue = detail.Text.ToString() });

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
                    string query = "INSERT INTO taRangeDetail (KODE_RANGE,KODE_DEPARTEMEN,KET_RANGE) VALUES('" + (cmbKodeRange.SelectedItem as ComboBoxItem).Content.ToString() + "','" + kodeDepartemen + "','" + detail.Text + "')";
                    message = con.crudDatabase(query, "Data Berhasil Disimpan !!!", "Data Gagal Disimpan !!!");
                    if(message== "Data Berhasil Disimpan !!!")
                    {
                        con.createLog(username, "1151", (cmbKodeRange.SelectedItem as ComboBoxItem).Content.ToString() + "," + kodeDepartemen);
                    }
                    dialogMessage(message);
                    empty();
                }
                else
                {
                    string query = "UPDATE taRangeDetail SET KODE_DEPARTEMEN='" + kodeDepartemen + "',KET_RANGE='" + detail.Text + "' WHERE KODE_RANGE='" + (cmbKodeRange.SelectedItem as ComboBoxItem).Content.ToString() + "'";
                    message = con.crudDatabase(query, "Data Berhasil Diedit !!!", "Data Gagal Diedit !!!");
                    if(message== "Data Berhasil Diedit !!!")
                    {
                        con.createLog(username, "1152", (cmbKodeRange.SelectedItem as ComboBoxItem).Content.ToString() + "," + kodeDepartemen);
                    }
                    dialogMessage(message);
                    reload();
                }
                
            }
        }
        void empty()
        {
            cmbKodeDepartemen.SelectedValue = "";
            cmbKodeRange.SelectedValue = "";
            detail.Text = "";
        }
    }
}
