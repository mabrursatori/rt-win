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
using Newtonsoft.Json;
using System.ComponentModel;
using System.Threading;
using rtwin.dataQuery;
namespace rtwin.View.master.shift
{
    /// <summary>
    /// Interaction logic for FormShiftMingguan.xaml
    /// </summary>
    public partial class FormShiftMingguan : UserControl
    {
        bool isSqlServer, isInsert;
        Action<string> dialogMessage;
        Action reload;
        string kodeShift, username;
        koneksi con;
        generateJson gj;
        List<comboBoxTemplate> jsonDropdownShift, jsonSatker;
        List<ComboBox> combo;
        public FormShiftMingguan(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kodeShift, string username)
        {
            this.isSqlServer = isSqlServer;
            this.isInsert = isInsert;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.kodeShift = kodeShift;
            this.username = username;
            con = new koneksi(isSqlServer);
            gj = new generateJson(isSqlServer);
            InitializeComponent();
            setCombo();
            if (!isInsert)
            {
                setFormUpdate();
            }
        }
        void setFormUpdate()
        {
            string query = "SELECT taPola.KODE_SHIFT, taPola.NAMA_GROUP, taPola.LIBUR_NASIONAL, CASE WHEN taPola.LIBUR_NASIONAL = 1 THEN 'Ya' ELSE 'Tidak' END AS KET_LIBUR, CASE WHEN taPola.KODE_DEPARTEMEN = '---' THEN 'GLOBAL' ELSE taCabang.NAMA_CABANG END AS NAMA_CABANG, SUBSTRING(taPola.FORMAT, 1, 2) AS Minggu, SUBSTRING(taPola.FORMAT, 3, 2) AS Senin, SUBSTRING(taPola.FORMAT, 5, 2) AS Selasa, SUBSTRING(taPola.FORMAT, 7, 2) AS Rabu, SUBSTRING(taPola.FORMAT, 9, 2) AS Kamis, SUBSTRING(taPola.FORMAT, 11, 2) AS Jumat, SUBSTRING(taPola.FORMAT, 13, 2) AS Sabtu, taPola.KODE_DEPARTEMEN FROM taPola LEFT OUTER JOIN taCabang ON taPola.KODE_DEPARTEMEN = taCabang.KODE_CABANG WHERE /*(SUBSTRING(taPola.KODE_SHIFT, 1, 1) = 'M')*/ KODE_SHIFT = '" + kodeShift + "'";
            List<string> data = new List<string>();
            data=con.getDataFromDatabase(query);
            txtKodeShift.Text = data[0];
            txtKodeShift.IsEnabled = false;
            txtnamaGrup.Text = data[1];
            if (Convert.ToBoolean(data[2]))
            {
                chkLiburNasional.IsChecked = true;
            }
            else
            {
                chkLiburNasional.IsChecked = false;
            }
            MessageBox.Show(data[4]);
            cmbSatker.SelectedValue = data[4];
            List<string> dataRange = new List<string>();
            dataRange = con.getDataFromDatabase(lib.query.queryShiftDropdown + " WHERE KODE_RANGE='" + data[5] + "'");
            cmbMinggu_.SelectedValue = dataRange[1];
            dataRange.Clear();

            dataRange = con.getDataFromDatabase(lib.query.queryShiftDropdown + "WHERE KODE_RANGE='" + data[6] + "'");
            cmbSenin.SelectedValue = dataRange[1];
            dataRange.Clear();

            dataRange = con.getDataFromDatabase(lib.query.queryShiftDropdown + "WHERE KODE_RANGE='" + data[7] + "'");
            cmbSelasa.SelectedValue = dataRange[1];
            dataRange.Clear();

            dataRange = con.getDataFromDatabase(lib.query.queryShiftDropdown + "WHERE KODE_RANGE='" + data[8] + "'");
            cmbRabu.SelectedValue = dataRange[1];
            dataRange.Clear();

            dataRange = con.getDataFromDatabase(lib.query.queryShiftDropdown + "WHERE KODE_RANGE='" + data[9] + "'");
            cmbKamis.SelectedValue = dataRange[1];
            dataRange.Clear();

            dataRange = con.getDataFromDatabase(lib.query.queryShiftDropdown + "WHERE KODE_RANGE='" + data[10] + "'");
            cmbJumat.SelectedValue = dataRange[1];
            dataRange.Clear();

            dataRange = con.getDataFromDatabase(lib.query.queryShiftDropdown + "WHERE KODE_RANGE='" + data[11] + "'");
            cmbSabtu.SelectedValue = dataRange[1];
            dataRange.Clear();
            
            
        }
        void setCombo()
        {
            combo = new List<ComboBox>();
            combo.Add(cmbMinggu_);
            combo.Add(cmbSenin);
            combo.Add(cmbSelasa);
            combo.Add(cmbRabu);
            combo.Add(cmbKamis);
            combo.Add(cmbJumat);
            combo.Add(cmbSabtu);
            this.jsonDropdownShift= JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(query.queryShiftDropdown, true, combo, isSqlServer,true));
            combo.Clear();
            combo.Add(cmbSatker);
            this.jsonSatker=JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(query.queryCabangForDropdown, false, combo, isSqlServer,false));
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
        void saving()
        {
            List<statusForm> status = new List<statusForm>();
            string kodeDepartemen = "";
            if (cmbSatker.SelectedIndex > 0)
            {
                kodeDepartemen = jsonSatker[cmbSatker.SelectedIndex].name;
            }
            status.Add(new statusForm { formTitel = "Grup Shift", formValue = txtKodeShift.Text });
            status.Add(new statusForm { formTitel = "Nama Grup", formValue = txtnamaGrup.Text });
            status.Add(new statusForm { formTitel = "Nama Satker", formValue = kodeDepartemen });
            formValidate validate = new formValidate();
            string message = validate.validate(status);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                string queryInsertUpdate = "";
                //MessageBox.Show(jsonDropdownShift[cmbMinggu.SelectedIndex].name);
                string format = jsonDropdownShift[cmbMinggu_.SelectedIndex].name + jsonDropdownShift[cmbSenin.SelectedIndex].name + jsonDropdownShift[cmbSelasa.SelectedIndex].name + jsonDropdownShift[cmbRabu.SelectedIndex].name + jsonDropdownShift[cmbKamis.SelectedIndex].name + jsonDropdownShift[cmbJumat.SelectedIndex].name + jsonDropdownShift[cmbSabtu.SelectedIndex].name;
                string kodeShift = "M" + txtKodeShift.Text;
                if (isInsert)
                {
                    queryInsertUpdate = Queryshift.getQUeryInsertShift(kodeShift,txtnamaGrup.Text,chkLiburNasional.IsChecked.Value,format,kodeDepartemen,"");
                    message = con.crudDatabase(queryInsertUpdate, Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    dialogMessage(message);
                    if(message== Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "1121", kodeShift);
                        emptyForm();
                    }
                }
                else
                {
                    queryInsertUpdate = Queryshift.getQueryUpdateShift(txtKodeShift.Text,txtnamaGrup.Text,chkLiburNasional.IsChecked.Value,format,kodeDepartemen,"");
                    message = con.crudDatabase(queryInsertUpdate, Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    dialogMessage(message);
                    if(message== Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "1122", txtKodeShift.Text);
                        reload();
                    }
                }
                
            }
        }
        void emptyForm()
        {
            txtKodeShift.Text = "";
            txtnamaGrup.Text = "";
            for(int i = 0; i < combo.Count; i++)
            {
                combo[i].SelectedIndex = 0;
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
    }
}
