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
using System.ComponentModel;
using System.Threading;

namespace rtwin.View.master.lembur
{
    /// <summary>
    /// Interaction logic for FormLemburOtomatis.xaml
    /// </summary>
    ///  Author Achmad Januar Sidiq S.T
    public partial class FormLemburOtomatis : UserControl
    {
        bool isSqlServer, isInsert;
        Action reload;
        Action<string> dialogMessage;
        string kode, username;
        List<comboBoxTemplate> perhitungan;
        koneksi con;
        public FormLemburOtomatis(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kode, string username)
        {
            this.isSqlServer = isSqlServer;
            this.isInsert = isInsert;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.kode = kode;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            InitializeComponent();

            perhitungan = new List<comboBoxTemplate>();
            perhitungan.Add(new comboBoxTemplate { content = "Lembur Awal", name = "1" });
            perhitungan.Add(new comboBoxTemplate { content = "Lembur Akhir", name = "2" });
            perhitungan.Add(new comboBoxTemplate { content = "Lembur Awal & Akhir", name = "3" });

            generateComboPerhitungan();
            if (!isInsert)
            {
                setForm();
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
            string query = queryCabang.getQueryUpdateCabang(chkLemburOtomatis.IsChecked.Value.ToString(), chkLemburLibur.IsChecked.Value.ToString(),perhitungan.Find(x=>x.content== (cmbPerhitungan.SelectedItem as ComboBoxItem).Content.ToString()).name , txtKode.Text);
            string message = con.crudDatabase(query, Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
            if (message == Message.MSG_UPDATE_SUCCES)
            {

                //belum ada log;
                reload();
            }
            dialogMessage(message);
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }

        void setForm()
        {
            List<string> data = con.getDataFromDatabase(queryCabang.getQueryDetailCabang(kode));
            txtKode.Text = data[0];
            txtNamaSatker.Text = data[1];
            chkLemburOtomatis.IsChecked = Convert.ToBoolean(data[2]);
            chkLemburLibur.IsChecked = Convert.ToBoolean(data[3]);
            cmbPerhitungan.SelectedValue = perhitungan.Find(x => x.name.ToString() == data[5]).content;
            
        }
        void generateComboPerhitungan()
        {
            for(int i = 0; i < perhitungan.Count; i++)
            {
                cmbPerhitungan.Items.Add(new ComboBoxItem { Content = perhitungan[i].content });
            }
        }

    }
}
