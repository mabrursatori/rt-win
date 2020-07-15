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
    /// Interaction logic for FormIjinJam.xaml
    /// </summary>
    public partial class FormIjinJam : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        generateJson js;
        koneksi con;
        string username, gradeID, nip, jamAkhirLengkap = "",jamAwalLengkap="";
        string[] dataIjin;
        List<comboBoxTemplate> listJenisIjin;
        
        public FormIjinJam(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string[] dataIjin, string username, string gradeID, string nip)
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
                gbTitel.Header = "Edit Data Ijin Per Jam";
                setField(dataIjin[0], Convert.ToDateTime(dataIjin[1]).ToString("yyyy-MM-dd"));
            }
        }
        void setComboIjin()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbIjin);
            string jsonIjin = AriLib.generateComboBox(queryIjinPerJam.getQueryComboJenisIjinPerJam, true, combo, isSqlServer, false);
            listJenisIjin = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(jsonIjin);
        }
        void setField(string nip, string tglAwalTemp)
        {
            try
            {
                svNip.Visibility = Visibility.Hidden;
                // MessageBox.Show(queryManual.getDataDetailManual(dataIjin[0],Convert.ToDateTime(dataIjin[1]).ToString("yyyy-MM-dd")));
                List<string> data = con.getDataFromDatabase(queryIjinPerJam.getQueryDataDetailIjinperJam(nip, tglAwalTemp));
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
                    tglIjin.Text = Convert.ToDateTime(data[2]).ToString("dd/MM/yyyy");
                    cmbIjin.SelectedIndex = listJenisIjin.IndexOf(listJenisIjin.Find(x => x.name == data[5]));
                    if ((data[3] != null || data[3]!="") && (data[4] != null|| data[4] !="")){
                        txtJamAwal.Text = Convert.ToDateTime(data[3]).ToString("HH:mm");
                        txtJamAkhir.Text = Convert.ToDateTime(data[4]).ToString("HH:mm");
                        jamAkhirLengkap = data[4];
                        jamAwalLengkap = data[3];

                    }
                    if (Convert.ToDateTime(Convert.ToDateTime(data[4]).ToString("dd/MM/yyyy")) > Convert.ToDateTime(Convert.ToDateTime(data[3]).ToString("dd/MM/yyyy")))
                    {
                        chkHariBerikutnya.IsChecked = true;
                    }
                    else
                    {
                        chkHariBerikutnya.IsChecked = false;
                    }
                    alasan.Text = data[7];
                    chkIjinDinas.IsChecked = Convert.ToBoolean(data[8]);
                    chkDisetujui.IsChecked = Convert.ToBoolean(data[9]);
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
            string kodeIjin = listJenisIjin.Find(x => x.content == (cmbIjin.SelectedItem as ComboBoxItem).Content.ToString()).name;
            List<statusForm> status = new List<statusForm>();
            if (isInsert && (gradeID == "1" || gradeID=="3"))
            {
                status.Add(new statusForm { formTitel = "Nip", formValue = txtNip.Text });
            }
            else
            {
                status.Add(new statusForm { formTitel = "Nip", formValue = lblNip.Text });
            }
            if (kodeIjin == "IJ")
            {
                status.Add(new statusForm { formTitel = "Jam Awal", formValue = txtJamAwal.Text.Replace("__:__", "") });
                status.Add(new statusForm { formTitel = "Jam Akhir", formValue = txtJamAkhir.Text.Replace("__:__", "") });
            }
            formValidate validate = new formValidate();
            string message = validate.validate(status);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                string jamAwal="",jamAkhir = "";
                if(txtJamAwal.Text!="__:__")
                {
                    jamAwal= Convert.ToDateTime(tglIjin.Text).ToString("yyyy-MM-dd") + " " + txtJamAwal.Text + ":00"; 
                }
                
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
                    if (txtJamAkhir.Text != "__:__")
                    {
                        if (chkHariBerikutnya.IsChecked.Value)
                        {
                            jamAkhir = Convert.ToDateTime(tglIjin.Text).AddDays(1).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                        }
                        else
                        {
                            jamAkhir = Convert.ToDateTime(tglIjin.Text).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                        }
                    }
                    message = con.crudDatabase(queryIjinPerJam.getQueryInsertDataIjinPerjam(niptemp[1], Convert.ToDateTime(tglIjin.Text).ToString("yyyy-MM-dd"),jamAwal,jamAkhir,kodeIjin,alasan.Text,chkIjinDinas.IsChecked.Value.ToString(),chkDisetujui.IsChecked.Value.ToString()), Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "2221", txtNip.Text + "," + kodeIjin + "," + Convert.ToDateTime(tglIjin.Text).ToString("yyyy-MM-dd"));
                        setEmpty();
                    }
                }
                else
                {
                    string[] niptemp = lblNip.Text.Split('-');
                    if(txtJamAkhir.Text!="__:__" || txtJamAkhir.Text != null)
                    {
                        if (chkHariBerikutnya.IsChecked.Value)
                        {
                            if(Convert.ToDateTime(Convert.ToDateTime(jamAkhirLengkap).ToString("dd/MM/yyyy")) > Convert.ToDateTime(Convert.ToDateTime(jamAwalLengkap).ToString("dd/MM/yyyy")))
                            {
                                jamAkhir = Convert.ToDateTime(jamAkhirLengkap).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                            }
                            else
                            {
                                jamAkhir = Convert.ToDateTime(jamAkhirLengkap).AddDays(1).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(Convert.ToDateTime(jamAkhirLengkap).ToString("dd/MM/yyyy")) > Convert.ToDateTime(Convert.ToDateTime(jamAwalLengkap).ToString("dd/MM/yyyy")))
                            {
                                jamAkhir = Convert.ToDateTime(jamAkhirLengkap).AddDays(-1).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                            }
                            else
                            {
                                jamAkhir = Convert.ToDateTime(jamAkhirLengkap).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                            }
                        }
                    }
                    
                    message = con.crudDatabase(queryIjinPerJam.getQueryUpdateDataIjinPerJam(jamAwal,jamAkhir,kodeIjin,alasan.Text,chkIjinDinas.IsChecked.Value.ToString(),chkDisetujui.IsChecked.Value.ToString(),niptemp[1],Convert.ToDateTime(tglIjin.Text).ToString("yyyy-MM-dd")), Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "2222", lblNip.Text + "," + kodeIjin + "," + Convert.ToDateTime(tglIjin.Text).ToString("yyyy-MM-dd"));
                        reload();
                    }
                }

                dialogMessage(message);
            }
        }

        private void CmbIjin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;

            if (text.Contains("IJ"))
            {
                txtJamAwal.IsEnabled = true;
                txtJamAkhir.IsEnabled = true;
            }
            else
            {
                txtJamAwal.IsEnabled = false;
                txtJamAkhir.IsEnabled = false;
            }
        }

        void setEmpty()
        {
            txtNip.Text = "";
            tglIjin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbIjin.SelectedIndex = 0;
            txtJamAwal.Text = "";
            txtJamAkhir.Text = "";
            chkHariBerikutnya.IsChecked = false;
            alasan.Text = "";
            chkIjinDinas.IsChecked = false;
            chkDisetujui.IsChecked = false;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
