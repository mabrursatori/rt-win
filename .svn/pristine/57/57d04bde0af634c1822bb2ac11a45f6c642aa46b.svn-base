using rtwin.dataQuery;
using rtwin.lib;
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

namespace rtwin.View.transaksi.manual
{
    /// <summary>
    /// Interaction logic for FormManual.xaml
    /// </summary>
    public partial class FormManual : UserControl
    {
        bool isSqlServer;
        bool isInsert;
        Action reload;
        Action<string> dialogMessage;
        generateJson js;
        koneksi con;
        string username,gradeID;
        string[] dataManual;
        public FormManual(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string[] dataManual, string username,string gradeID)
        {
            this.isInsert = isInsert;
            this.isSqlServer = isSqlServer;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            this.js = new generateJson(isSqlServer);
            this.dataManual = dataManual;
            this.gradeID = gradeID;
            InitializeComponent();
            this.DataContext = new TextBoxSuggestionsViewModel(isSqlServer,username,gradeID);
            if (isInsert)
            {
                gbTitel.Header = "Tambah Data Manual";
            }
            else
            {
                gbTitel.Header = "Edit Data manual";
                setField(dataManual[0],Convert.ToDateTime(dataManual[1]).ToString("yyyy-MM-dd"));
            }
        }
        void setField(string nip,string tglMasuk_)
        {
            try
            {
                svNip.Visibility = Visibility.Hidden;
               // MessageBox.Show(queryManual.getDataDetailManual(dataManual[0],Convert.ToDateTime(dataManual[1]).ToString("yyyy-MM-dd")));
                List<string> data = con.getDataFromDatabase(queryManual.getDataDetailManual(nip,tglMasuk_));
                string queryGetNip = queryKaryawan.getAutoCompletekaryawan + " WHERE NIP='" + nip +  "' ";
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
                    
                    
                    tglMasuk.Text = data[3];
                    txtJamMasuk.Text = Convert.ToDateTime(data[5]).ToString("HH:mm");
                    txtJamKeluar.Text = Convert.ToDateTime(data[6]).ToString("HH:mm");
                    string TglJamMasuk = Convert.ToDateTime(data[5]).ToString("dd/MM/yyyy");
                    string TglJamKeluar = Convert.ToDateTime(data[6]).ToString("dd/MM/yyyy");
                    bool gantiHari = false;
                    if (Convert.ToDateTime(TglJamKeluar) > Convert.ToDateTime(TglJamMasuk))
                    {
                        gantiHari = true;
                    }
                    chkGantiHari.IsChecked = gantiHari;
                    //tglLibur.Text = Convert.ToDateTime(data[0]).ToString("dd/MM/yyyy");
                    //txtKeterangan.Text = data[1];
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
            if (isInsert)
            {
                status.Add(new statusForm { formTitel = "Nip", formValue = txtNip.Text });
            }
            else
            {
                status.Add(new statusForm { formTitel = "Nip", formValue = lblNip.Text });
            }
            
            status.Add(new statusForm { formTitel = "Tgl Masuk", formValue = tglMasuk.Text });
            status.Add(new statusForm { formTitel = "Jam Masuk", formValue = txtJamMasuk.Text.Replace("__:__", "") });
            status.Add(new statusForm { formTitel = "Jam keluar", formValue = txtJamKeluar.Text.Replace("__:__", "") });
            formValidate validate = new formValidate();
            string message = validate.validate(status);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                
                string jamMasuk_ = Convert.ToDateTime(tglMasuk.Text).ToString("yyyy-MM-dd") + " " + txtJamMasuk.Text.ToString() + ":00";
                string jamKeluar_ = "";
                if (chkGantiHari.IsChecked.Value)
                {
                    if (isInsert)
                    {
                        
                        jamKeluar_ = Convert.ToDateTime(tglMasuk.Text).AddDays(1).ToString("yyyy-MM-dd") + " " + txtJamKeluar.Text.ToString() + ":00";
                    }
                    else
                    {
                        
                        if (dataManual.Count() > 0)
                        {
                            if (Convert.ToDateTime(dataManual[3]) > Convert.ToDateTime(dataManual[2]))
                            {
                                jamKeluar_ = Convert.ToDateTime(tglMasuk.Text).ToString("yyyy-MM-dd") + " " + txtJamKeluar.Text.ToString() + ":00";
                            }
                            else
                            {
                                jamKeluar_ = Convert.ToDateTime(tglMasuk.Text).AddDays(1).ToString("yyyy-MM-dd") + " " + txtJamKeluar.Text.ToString() + ":00";
                            }
                        }
                        
                    }
                    
                }
                else
                {
                    jamKeluar_ = Convert.ToDateTime(tglMasuk.Text).ToString("yyyy-MM-dd") + " " + txtJamKeluar.Text.ToString() + ":00";
                }
                if (isInsert)
                {
                    string[] niptemp = txtNip.Text.Split('-');
                    message = con.crudDatabase(queryManual.insertDataManual(niptemp[1],Convert.ToDateTime(tglMasuk.Text).ToString("yyyy-MM-dd"),jamMasuk_,jamKeluar_,"Y"), Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "2101", txtNip.Text+","+tglMasuk.Text);
                        setEmpty();
                    }
                }
                else
                {
                    string[] niptemp = lblNip.Text.Split('-');
                    message = con.crudDatabase(queryManual.updateDataManual(jamMasuk_,jamKeluar_,niptemp[1],Convert.ToDateTime(tglMasuk.Text).ToString("yyyy-MM-dd")), Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "2102", txtNip.Text + "," + tglMasuk.Text);
                        reload();
                    }
                }

                dialogMessage(message);
            }
        }
        void setEmpty()
        {
            txtNip.Text = "";
            tglMasuk.Text = "";
            txtJamMasuk.Text = "";
            txtJamKeluar.Text = "";
            chkGantiHari.IsChecked = false;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
