﻿using Newtonsoft.Json;
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
    /// Interaction logic for FormBagian.xaml
    /// </summary>
    public partial class FormBagian : UserControl
    {
        bool isSqlServer, isInsert;
        Action reload;
        Action<string> dialogMessage;
        string kode, username;
        List<comboBoxTemplate> dataComboBiro;
        koneksi con;
        public FormBagian(bool isSqlServer, bool isInsert, Action reload, Action<string> dialogMessage, string kode, string username)
        {
            InitializeComponent();
            this.isSqlServer = isSqlServer;
            this.isInsert = isInsert;
            this.reload = reload;
            this.dialogMessage = dialogMessage;
            this.kode = kode;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            generateComboBoxBiro();
            if (!isInsert)
            {
                setForm();
                gbTitel.Header = "Edit Bagian";
            }
            else
            {
                gbTitel.Header = "Tambah Bagian";
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
            List<statusForm> status = new List<statusForm>();
            status.Add(new statusForm { formTitel = "Kode Bagian", formValue = txtKode.Text });
            status.Add(new statusForm { formTitel = "Nama Bagian", formValue = txtNama.Text });
            status.Add(new statusForm { formTitel = "Nama Biro", formValue = AriLib.CekEmptyComboBox(cmbBiro, dataComboBiro) });
            formValidate validating = new formValidate();
            string message = validating.validate(status);
            if (message != "")
            {
                dialogMessage(message);
            }
            else
            {
                if (isInsert)
                {
                    //MessageBox.Show(dataComboBiro.Find(x => x.content == (cmbBiro.SelectedItem as ComboBoxItem).Content.ToString()).name);
                    string query = queryBagian.getQueryInsertBagian(txtKode.Text, txtNama.Text, dataComboBiro.Find(x => x.content == (cmbBiro.SelectedItem as ComboBoxItem).Content.ToString()).name);
                    message = con.crudDatabase(query, Message.MSG_SAVE_SUCCES, Message.MSG_SAVE_FAILED);
                    if (message == Message.MSG_SAVE_SUCCES)
                    {
                        con.createLog(username, "1261", txtKode.Text);
                        emptyForm();
                    }
                }
                else
                {
                    string query = queryBagian.getQueryUpdateBagian(txtKode.Text, txtNama.Text, dataComboBiro.Find(x => x.content == (cmbBiro.SelectedItem as ComboBoxItem).Content.ToString()).name);
                    message = con.crudDatabase(query, Message.MSG_UPDATE_SUCCES, Message.MSG_UPDATE_FAILED);
                    if (message == Message.MSG_UPDATE_SUCCES)
                    {
                        con.createLog(username, "1262", txtKode.Text);
                        reload();
                    }
                }
                dialogMessage(message);
            }
        }
        void emptyForm()
        {
            txtKode.Text = "";
            txtNama.Text = "";
            cmbBiro.SelectedIndex = 0;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
        void setForm()
        {
            List<string> data = con.getDataFromDatabase(queryBagian.getQueryDetailBagian(kode));
            txtKode.Text = data[0];
            txtKode.IsEnabled = false;
            txtNama.Text = data[1];
            cmbBiro.SelectedIndex = dataComboBiro.IndexOf(dataComboBiro.Find(x => x.name == data[2]));

        }
        void generateComboBoxBiro()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbBiro);
            dataComboBiro = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryBiro.queryComboBiro, true, combo, isSqlServer, false));
        }
    }
}
