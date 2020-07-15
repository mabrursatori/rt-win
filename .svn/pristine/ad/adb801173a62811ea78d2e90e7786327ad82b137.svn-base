using Newtonsoft.Json;
using rtwin.lib;
using rtwin.Model;
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
using rtwin.dataQuery;
using System.ComponentModel;
using System.Threading;

namespace rtwin.View.master.shift
{
    /// <summary>
    /// Interaction logic for FormShiftHarian.xaml
    /// </summary>
    public partial class FormShiftHarian : UserControl
    {
        bool isSqlServer,isInsert;
        Action<string> dialogMessage;
        Action reload;
        string kodeShift, username;
        koneksi con;
        generateJson gj;
        List<comboBoxTemplate> jsonDropdownShift, jsonSatker;
        List<ComboBox> combo,comboSatker;
        string gradeID;
        public FormShiftHarian(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kodeShift, string username,int heightScreen, string gradeID)
        {
            this.isSqlServer = isSqlServer;
            this.isInsert = isInsert;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.kodeShift = kodeShift;
            this.username = username;
            this.gradeID = gradeID;
            con = new koneksi(isSqlServer);
            gj = new generateJson(isSqlServer);
            InitializeComponent();
            if (heightScreen < 600)
            {
                svHarian.Height = 300;
            }
            else if (heightScreen > 600 && heightScreen < 700)
            {
                svHarian.Height = 380;
            }
            else if (heightScreen > 700 && heightScreen < 800)
            {
                svHarian.Height = 420;
            }
            else if (heightScreen > 800 && heightScreen < 900)
            {
                svHarian.Height = 550;
            }
            setCombo();
            if (!isInsert)
            {
                setFormUpdate();
            }
            if (gradeID != "1")
            {
                //btnClose.Visibility = Visibility.Hidden;
                btnsave.Visibility = Visibility.Hidden;
                txtKodeShift.IsEnabled = false;
                txtNamaGrup.IsEnabled = false;
                cmbNamaSatker.IsEnabled = false;
                chkLiburNasional.IsEnabled = false;
                tglBerlaku.IsEnabled = false;
            }
        }
        void setCombo()
        {
            combo = new List<ComboBox>();
            combo.Add(cmb1);
            combo.Add(cmb2);
            combo.Add(cmb3);
            combo.Add(cmb4);
            combo.Add(cmb5);
            combo.Add(cmb6);
            combo.Add(cmb7);
            combo.Add(cmb8);
            combo.Add(cmb9);
            combo.Add(cmb10);
            combo.Add(cmb11);
            combo.Add(cmb12);
            combo.Add(cmb13);
            combo.Add(cmb14);
            combo.Add(cmb15);
            combo.Add(cmb16);
            combo.Add(cmb17);
            combo.Add(cmb18);
            combo.Add(cmb19);
            combo.Add(cmb20);
            combo.Add(cmb21);
            combo.Add(cmb22);
            combo.Add(cmb23);
            combo.Add(cmb24);
            combo.Add(cmb25);
            combo.Add(cmb26);
            combo.Add(cmb27);
            combo.Add(cmb28);
            combo.Add(cmb29);
            combo.Add(cmb30);
            combo.Add(cmb31);
            this.jsonDropdownShift = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(query.queryShiftDropdown, false, combo, isSqlServer,true));
            comboSatker = new List<ComboBox>();
            comboSatker.Add(cmbNamaSatker);
            this.jsonSatker = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(query.queryCabangForDropdown, false, comboSatker, isSqlServer,false));
        }
        void emptyForm()
        {
            txtKodeShift.Text = "";
            txtNamaGrup.Text = "";
            tglBerlaku.Text = "";
            for (int i = 0; i < combo.Count; i++)
            {
                combo[i].SelectedIndex = 0;
            }
        }
        void setFormUpdate()
        {
            List<string> data = con.getDataFromDatabase(Queryshift.getQueryDataGridShiftHarianDetail(kodeShift));
            txtKodeShift.Text = data[0];
            txtNamaGrup.Text = data[2];
            tglBerlaku.Text = Convert.ToDateTime(data[1]).ToString("dd/MM/yyyy");
            if (Convert.ToBoolean(data[3]))
            {
                chkLiburNasional.IsChecked = true;
            }
            else
            {
                chkLiburNasional.IsChecked = false;
            }
            cmbNamaSatker.SelectedValue = data[5].ToString();
            List<string> dataRange = new List<string>();
            int a = 6;
            for(int i = 0; i < combo.Count; i++)
            {
                dataRange = con.getDataFromDatabase(Queryshift.queryShiftDropdown + " Where KODE_RANGE='" + data[a] + "'");
                if(dataRange.Count>0)
                    combo[i].SelectedValue = dataRange[1];
                dataRange.Clear();
                a++;
            }
            

            
        }

        void saving()
        {
            List<statusForm> status = new List<statusForm>();
            string kodeDepartemen = AriLib.CekEmptyComboBox(cmbNamaSatker,jsonSatker);
            
            status.Add(new statusForm { formTitel = "Grup Shift", formValue = txtKodeShift.Text });
            status.Add(new statusForm { formTitel = "Tanggal Berlaku", formValue = tglBerlaku.Text });
            status.Add(new statusForm { formTitel = "Nama Grup", formValue = txtNamaGrup.Text });
            status.Add(new statusForm { formTitel = "Nama Satker", formValue = kodeDepartemen });
            formValidate validate = new formValidate();
            string message = validate.validate(status);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                string format = AriLib.CekEmptyComboBox(cmb1,jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb2, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb3, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb4, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb5, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb6, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb7, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb8, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb9, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb10, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb11, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb12, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb13, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb14, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb15, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb16, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb17, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb18, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb19, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb20, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb21, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb22, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb23, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb24, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb25, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb26, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb27, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb28, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb29, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb30, jsonDropdownShift)+ AriLib.CekEmptyComboBox(cmb31, jsonDropdownShift);
                string tglBerlakuTemp = Convert.ToDateTime(tglBerlaku.Text).ToString("yyyy-MM-dd");
                if (isInsert)
                {

                    string kodeShift = "N" + txtKodeShift.Text;
                    message = con.crudDatabase(Queryshift.getQUeryInsertShift(kodeShift, txtNamaGrup.Text, chkLiburNasional.IsChecked.Value, format, kodeDepartemen, Convert.ToDateTime(tglBerlaku.Text).ToString("yyyy-MM-dd")), Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "1121", kodeShift);
                        emptyForm();
                    }
                }
                else
                {
                    message = con.crudDatabase(Queryshift.getQueryUpdateShift(txtKodeShift.Text, txtNamaGrup.Text, chkLiburNasional.IsChecked.Value, format, kodeDepartemen,Convert.ToDateTime(tglBerlaku.Text).ToString("yyyy-MM-dd")), Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "1122", txtKodeShift.Text);
                        reload();
                    }
                }
                dialogMessage(message);

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
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
