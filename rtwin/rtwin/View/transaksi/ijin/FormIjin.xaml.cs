using Newtonsoft.Json;
using rtwin.dataQuery;
using rtwin.lib;
using rtwin.Model;
using rtwin.ViewModel;
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

namespace rtwin.View.transaksi.ijin
{
    /// <summary>
    /// Interaction logic for FormIjin.xaml
    /// </summary>
    public partial class FormIjin : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        generateJson js;
        koneksi con;
        string username,gradeID,nip;
        string[] dataIjin;
        List<comboBoxTemplate> listJenisIjin;
        public FormIjin(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string[] dataIjin, string username,string gradeID,string nip)
        {
            this.isInsert = isInsert;
            this.isSqlServer = isSqlServer;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            this.js = new generateJson(isSqlServer);
            this.dataIjin = dataIjin;
            this.gradeID = gradeID;
            this.nip = nip;
            InitializeComponent();

            this.DataContext = new TextBoxSuggestionsViewModel(isSqlServer,username,gradeID);
            setComboIjin();
            setEmpty();
            if (isInsert)
            {
                gbTitel.Header = "Tambah Data Ijin";
                if (gradeID == "4")
                {
                    string queryGetNip = queryKaryawan.getAutoCompletekaryawan + " WHERE NIP='" + nip + "' ";
                    List<string> dataNip = con.getDataFromDatabase(queryGetNip);
                    if (dataNip.Count > 0)
                    {
                        svNip.Visibility = Visibility.Hidden;
                        lblNip.Visibility = Visibility.Visible;
                        lblNip.Text = dataNip[0];
                    }
                    
                }
                if (Convert.ToInt32(gradeID) >= 3)
                {
                    lblStatusIjin.Visibility = Visibility.Hidden;
                    chkDisetujui.Visibility = Visibility.Hidden;
                }
                
            }
            else
            {
                gbTitel.Header = "Edit Data Ijin";
                setField(dataIjin[0], Convert.ToDateTime(dataIjin[1]).ToString("yyyy-MM-dd"));
            }
        }
        void setComboIjin()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbJenisIjin);
            string jsonIjin= AriLib.generateComboBox(queryIjin.getDataIjinComboBox, true, combo, isSqlServer, false);
            listJenisIjin = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(jsonIjin);
        }
        void setField(string nip, string tglAwalTemp)
        {
            try
            {
                svNip.Visibility = Visibility.Hidden;
                // MessageBox.Show(queryManual.getDataDetailManual(dataIjin[0],Convert.ToDateTime(dataIjin[1]).ToString("yyyy-MM-dd")));
                List<string> data = con.getDataFromDatabase(queryIjinHari.getDataDetailIjinHari(nip, tglAwalTemp));
                string queryGetNip = queryKaryawan.getAutoCompletekaryawan + " WHERE NIP='" + nip + "' ";
                List<string> dataNip = con.getDataFromDatabase(queryGetNip);
                if (dataNip.Count > 0)
                {
                    //MessageBox.Show(dataNip[0]);
                    // txtNip.Text = nip;
                    lblNip.Visibility = Visibility.Visible;
                    lblNip.Text = dataNip[0];
                }
                if (data.Count > 0)
                {
                    tglAwal.Text = Convert.ToDateTime(data[2]).ToString("dd/MM/yyyy");
                    tglAkhir.Text = Convert.ToDateTime(data[3]).ToString("dd/MM/yyy");
                    cmbJenisIjin.SelectedIndex=listJenisIjin.IndexOf(listJenisIjin.Find(x=>x.name==data[4]));
                    dokPendukung.Text = data[8];
                    chkDisetujui.IsChecked = Convert.ToBoolean(data[10]);
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
            if (isInsert && gradeID=="1")
            {
                status.Add(new statusForm { formTitel = "Nip", formValue = txtNip.Text });
            }
            else
            {
                status.Add(new statusForm { formTitel = "Nip", formValue = lblNip.Text });
            }

            status.Add(new statusForm { formTitel = "Tgl Awal", formValue = tglAwal.Text });
            status.Add(new statusForm { formTitel = "Tgl Akhir", formValue = tglAkhir.Text });
            status.Add(new statusForm { formTitel = "Dokumen Pendukung", formValue = dokPendukung.Text });
            formValidate validate = new formValidate();
            string message = validate.validate(status);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                string kodeIjin = listJenisIjin.Find(x => x.content == (cmbJenisIjin.SelectedItem as ComboBoxItem).Content.ToString()).name;
                if (isInsert)
                {
                    string[] niptemp;
                    if (Convert.ToInt32(gradeID) < 4)
                    {
                        niptemp = txtNip.Text.Split('-');
                    }
                    else
                    {
                        niptemp = lblNip.Text.Split('-');
                    }
                    
                    message = con.crudDatabase(queryIjinHari.insertIjinHari(niptemp[1], Convert.ToDateTime(tglAwal.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(tglAkhir.Text).ToString("yyyy-MM-dd"), kodeIjin,dokPendukung.Text,chkDisetujui.IsChecked.Value), Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "2211", txtNip.Text + "," + kodeIjin+","+ Convert.ToDateTime(tglAwal.Text).ToString("yyyy-MM-dd"));
                        setEmpty();
                    }
                }
                else
                {
                    string[] niptemp = lblNip.Text.Split('-');
                    message = con.crudDatabase(queryIjinHari.updateIjinHari(Convert.ToDateTime(tglAkhir.Text).ToString("yyyy-MM-dd"),kodeIjin,dokPendukung.Text,chkDisetujui.IsChecked.Value,niptemp[1],Convert.ToDateTime(tglAwal.Text).ToString("yyyy-MM-dd")), Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "2212", lblNip.Text+ "," + kodeIjin+","+Convert.ToDateTime(tglAwal.Text).ToString("yyyy-MM-dd"));
                        reload();
                    }
                }

                dialogMessage(message);
            }
        }
        void setEmpty()
        {
            txtNip.Text = "";
            tglAwal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tglAkhir.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dokPendukung.Text ="" ;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
