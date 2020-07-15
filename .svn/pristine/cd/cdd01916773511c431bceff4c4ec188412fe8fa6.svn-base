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

namespace rtwin.View.transaksi.notice
{
    /// <summary>
    /// Interaction logic for FormNotice.xaml
    /// </summary>
    public partial class FormNotice : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        generateJson js;
        koneksi con;
        string username, gradeID, nip, jamAkhirLengkap = "", jamAwalLengkap = "";
        string[] dataLembur;
        List<comboBoxTemplate> listJenisIjin;
        public FormNotice(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string[] dataLembur, string username, string gradeID, string nip)
        {
            this.isInsert = isInsert;
            this.isSqlServer = isSqlServer;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            this.js = new generateJson(isSqlServer);
            this.dataLembur = dataLembur;
            this.gradeID = gradeID;
            this.nip = nip;
            InitializeComponent();
            this.DataContext = new TextBoxSuggestionsViewModel(isSqlServer, username, gradeID);
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
                gbTitel.Header = "Edit Data Lembur";
                setField(dataLembur[0], Convert.ToDateTime(dataLembur[1]).ToString("yyyy-MM-dd"));
            }
        }
       
        void setField(string nip, string tglAwalTemp)
        {
            try
            {
                svNip.Visibility = Visibility.Hidden;
                List<string> data = con.getDataFromDatabase(queryNotice.queryGetDataDetailNotice(nip, tglAwalTemp));
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
                    tglLembur.Text = Convert.ToDateTime(data[2]).ToString("dd/MM/yyyy");
                    txtJamAwal.Text = Convert.ToDateTime(data[3]).ToString("HH:mm");
                    txtJamAkhir.Text = Convert.ToDateTime(data[4]).ToString("HH:mm");
                    kegiatanLembur.Text = data[5];
                    chkDisetujui.IsChecked = Convert.ToBoolean(data[6]);
                    jamAwalLengkap = data[3];
                    jamAkhirLengkap = data[4];
                    if (Convert.ToDateTime(Convert.ToDateTime(data[4]).ToString("dd/MM/yyyy")) > Convert.ToDateTime(Convert.ToDateTime(data[3]).ToString("dd/MM/yyyy")))
                    {
                        chkHariBerikutnya.IsChecked = true;
                    }
                    else
                    {
                        chkHariBerikutnya.IsChecked = false;
                    }
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
            if (isInsert && gradeID == "1")
            {
                status.Add(new statusForm { formTitel = "Nip", formValue = txtNip.Text });
            }
            else
            {
                status.Add(new statusForm { formTitel = "Nip", formValue = lblNip.Text });
            }

            status.Add(new statusForm { formTitel = "Tgl Lembur", formValue = tglLembur.Text });
            status.Add(new statusForm { formTitel = "Jam Awal", formValue = txtJamAwal.Text });
            status.Add(new statusForm { formTitel = "Jam Akhir", formValue = txtJamAkhir.Text });
            status.Add(new statusForm { formTitel = "Kegiatan Lembur", formValue = kegiatanLembur.Text });
            formValidate validate = new formValidate();
            string message = validate.validate(status);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                string JamAwalTemp = "", jamAkhirTemp = "";
                if (txtJamAwal.Text != "__:__")
                {
                    JamAwalTemp = Convert.ToDateTime(tglLembur.Text).ToString("yyyy-MM-dd") + " " + txtJamAwal.Text + ":00";
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
                            jamAkhirTemp = Convert.ToDateTime(tglLembur.Text).AddDays(1).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                        }
                        else
                        {
                            jamAkhirTemp = Convert.ToDateTime(tglLembur.Text).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                        }
                    }
                    message = con.crudDatabase(queryNotice.queryInsertNotice(niptemp[1],Convert.ToDateTime(tglLembur.Text).ToString("yyyy-MM-dd"),JamAwalTemp,jamAkhirTemp,kegiatanLembur.Text,chkDisetujui.IsChecked.Value.ToString()), Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "2311", txtNip.Text + "," + niptemp[1] + "," + Convert.ToDateTime(tglLembur.Text).ToString("yyyy-MM-dd"));
                        setEmpty();
                    }
                }
                else
                {
                    string[] niptemp = lblNip.Text.Split('-');
                    if (txtJamAkhir.Text != "__:__" || txtJamAkhir.Text != null)
                    {
                        if (chkHariBerikutnya.IsChecked.Value)
                        {
                            if (Convert.ToDateTime(Convert.ToDateTime(jamAkhirLengkap).ToString("dd/MM/yyyy")) > Convert.ToDateTime(Convert.ToDateTime(jamAwalLengkap).ToString("dd/MM/yyyy")))
                            {
                                jamAkhirTemp = Convert.ToDateTime(jamAkhirLengkap).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                            }
                            else
                            {
                                jamAkhirTemp = Convert.ToDateTime(jamAkhirLengkap).AddDays(1).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(Convert.ToDateTime(jamAkhirLengkap).ToString("dd/MM/yyyy")) > Convert.ToDateTime(Convert.ToDateTime(jamAwalLengkap).ToString("dd/MM/yyyy")))
                            {
                                jamAkhirTemp = Convert.ToDateTime(jamAkhirLengkap).AddDays(-1).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                            }
                            else
                            {
                                jamAkhirTemp = Convert.ToDateTime(jamAkhirLengkap).ToString("yyyy-MM-dd") + " " + txtJamAkhir.Text + ":00";
                            }
                        }
                    }
                    string queryUpdate = queryNotice.queryUpdateNotice(niptemp[1], Convert.ToDateTime(tglLembur.Text).ToString("yyyy-MM-dd"), JamAwalTemp, jamAkhirTemp, kegiatanLembur.Text, chkDisetujui.IsChecked.Value.ToString());
                    message = con.crudDatabase(queryUpdate, Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "2312", lblNip.Text + "," + nip + "," + Convert.ToDateTime(tglLembur.Text).ToString("yyyy-MM-dd"));
                        reload();
                    }
                }

                dialogMessage(message);
            }
        }
        void setEmpty()
        {
            txtNip.Text = "";
            tglLembur.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtJamAwal.Text = "";
            txtJamAkhir.Text= "";
            kegiatanLembur.Text = "";
            chkHariBerikutnya.IsChecked = false;
            chkDisetujui.IsChecked = true;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
