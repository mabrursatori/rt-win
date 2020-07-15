﻿using MaterialDesignThemes.Wpf;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using rtwin.dataQuery;
using rtwin.lib;
using rtwin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Data;
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
using System.Globalization;
using rtwin.ViewModel;

namespace rtwin.View.Report
{
    /// <summary>
    /// Interaction logic for monthly.xaml
    /// </summary>
    public partial class monthly : UserControl
    {
        bool isSqlServer;
        DialogHost dialogHost;
        Frame frameContent, dialogContent;
        Image LoadingContent;
        koneksi con;
        generateJson js;
        string json = String.Empty;
        bool asc = true;
        int page = 0;
        int AllDataGrid = 0, HeightScress;
        TextBlock breadcumb;
        string queryDelete = "";
        string username;
        string actionLog = "";
        bool dialogSearch;
        string gradeID = "";
        List<comboBoxTemplate> namaDeputi, namaBiro, namaBagian, namaSubbagian, namaJabatan, namaGolongan, namaGrade, namaEselon, namaStatus, namaJenisLap, namaBulan, namaTahun;
        DateTime dt = DateTime.Today;
        List<filterBulan> lbulan;



        private void ReportViewerMonthly_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {

        }

        public monthly(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username,string gradeID)
        {
            HeightScress = Convert.ToInt32(System.Windows.SystemParameters.WorkArea.Height);
            this.js = new generateJson(isSqlServer);
            this.con = new koneksi(isSqlServer);
            this.isSqlServer = isSqlServer;
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.breadcumb = bredcumb;
            this.dialogContent = dialogContent;
            this.username = username;
            this.gradeID = gradeID;
            bredcumb.Text = "Laporan / Laporan Bulanan";
            InitializeComponent();
            cmbBiro.IsEnabled = false;
            cmbBagian.IsEnabled = false;
            cmbSubbagian.IsEnabled = false;

            generateComboboxBln();
            generateComboboxThn();
            generateComboboxJenisLaporan();
            generateComboBoxDeputi();
            generateComboBoxJabatan();
            generateComboBoxGolongan();
            generateComboBoxGrade();
            generateComboBoxEselon();
            generateComboBoxStatus();
            this.DataContext = new TextBoxSuggestionsViewModel(isSqlServer, username, gradeID);
            
        }

        private void generateComboboxJenisLaporan()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbJenisLap);
            this.namaJenisLap = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryJenisLaporan.getQueryComboJenisLaporan(gradeID), true, combo, isSqlServer, false));
        }

        private void generateComboBoxStatus()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbStatus);
            this.namaStatus = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryStatusPegawai.getQueryComboStatus, true, combo, isSqlServer, false));
        }

        private void generateComboBoxEselon()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbEselon);
            this.namaEselon = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryEselon.getQueryComboEselon, true, combo, isSqlServer, false));
        }

        private void generateComboBoxGrade()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbGrade);
            this.namaGrade = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryGrid.getQueryComboGrade, true, combo, isSqlServer, false));
        }

        private void generateComboBoxGolongan()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbGolongan);
            this.namaGolongan = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryGolongan.getQueryComboGolongan, true, combo, isSqlServer, false));
        }

        private void generateComboBoxJabatan()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbJabatan);
            this.namaJabatan = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryJabatan.getQueryComboJabatan, true, combo, isSqlServer, false));
        }

        private void generateComboboxBln()
        {
            lbulan = new List<filterBulan>();
            lbulan.Add(new filterBulan { angkaBulan = "01", namaBulan = "Januari", jumlahHari = "31" });
            lbulan.Add(new filterBulan { angkaBulan = "02", namaBulan = "Februari", jumlahHari = "30" });
            lbulan.Add(new filterBulan { angkaBulan = "03", namaBulan = "Maret", jumlahHari = "31" });
            lbulan.Add(new filterBulan { angkaBulan = "04", namaBulan = "April", jumlahHari = "30" });
            lbulan.Add(new filterBulan { angkaBulan = "05", namaBulan = "Mei", jumlahHari = "31" });
            lbulan.Add(new filterBulan { angkaBulan = "06", namaBulan = "Juni", jumlahHari = "30" });
            lbulan.Add(new filterBulan { angkaBulan = "07", namaBulan = "Juli", jumlahHari = "31" });
            lbulan.Add(new filterBulan { angkaBulan = "08", namaBulan = "Agustus", jumlahHari = "31" });
            lbulan.Add(new filterBulan { angkaBulan = "09", namaBulan = "September", jumlahHari = "30" });
            lbulan.Add(new filterBulan { angkaBulan = "10", namaBulan = "Oktober", jumlahHari = "31" });
            lbulan.Add(new filterBulan { angkaBulan = "11", namaBulan = "November", jumlahHari = "30" });
            lbulan.Add(new filterBulan { angkaBulan = "12", namaBulan = "Desember", jumlahHari = "31" });

            string month = dt.ToString("MM");
            int j = lbulan.Count;
            for (int i=0; i<j; i++)
            {
                cmbBulan.Items.Add(new ComboBoxItem { Content = lbulan[i].namaBulan });
                if (month == lbulan[i].angkaBulan)
                    cmbBulan.Text = lbulan[i].namaBulan;
            }
        }

        private void generateComboboxThn()
        {
            string year = dt.ToString("yyyy");
            int th = Convert.ToInt32(year);
            cmbTahun.Items.Add(new ComboBoxItem { Content = th - 1 });
            cmbTahun.Items.Add(new ComboBoxItem { Content = th, IsSelected = true });
            cmbTahun.Items.Add(new ComboBoxItem { Content = th + 1 });
        }
        private void generateComboBoxDeputi()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbDeputi);
            this.namaDeputi = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryDeputi.getQueryComboDeputi, true, combo, isSqlServer, false));
        }
        private void cmbDeputi_DropDownClosed(object sender, EventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                cmbBiro.IsEnabled = true;
                cmbBagian.IsEnabled = false;
                cmbSubbagian.IsEnabled = false;
                cmbBiro.Items.Clear();
                cmbBagian.Items.Clear();
                cmbSubbagian.Items.Clear();
                generateComboBoxBiro(namaDeputi.Find(x => x.content == text).name);
            }
        }       
        private void generateComboBoxBiro(string kodeDeputi)
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbBiro);
            if (kodeDeputi != "")
            {
                this.namaBiro = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryBiro.queryComboBiroFilter(kodeDeputi), true, combo, isSqlServer, false));
            }
        }
        private void cmbBiro_DropDownClosed(object sender, EventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                cmbBiro.IsEnabled = true;
                cmbBagian.IsEnabled = true;
                cmbSubbagian.IsEnabled = false;
                cmbBagian.Items.Clear();
                cmbSubbagian.Items.Clear();
                generateComboBoxBagian(namaBiro.Find(x => x.content == text).name);
            }
        }
        private void generateComboBoxBagian(string kodeBiro)
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbBagian);
            if (kodeBiro != "")
            {
                this.namaBagian = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryBagian.comboBagianFilter(kodeBiro), true, combo, isSqlServer, false));
            }
        }
        private void cmbBagian_DropDownClosed(object sender, EventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                cmbBiro.IsEnabled = true;
                cmbBagian.IsEnabled = true;
                cmbSubbagian.IsEnabled = true;
                cmbSubbagian.Items.Clear();
                generateComboBoxSubbagian(namaBagian.Find(x => x.content == text).name);
            }
        }

        private void generateComboBoxSubbagian(string kodeBagian)
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbSubbagian);
            if (kodeBagian != "")
            {
                this.namaSubbagian = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(querySubBagian.comboSubbagianFilter(kodeBagian), true, combo, isSqlServer, false));
            }
        }

        private void BtnTampilkan_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    this.frameContent.Content = "";
                    this.LoadingContent.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                this.LoadingContent.Visibility = Visibility.Hidden;
                tampil_laporan();
            };
            worker.RunWorkerAsync();
        }

        void tampil_laporan()
        {
            string[] niptemp;
            string nip = "";
            string kodeDeputi = "", kodeBiro = "", kodeBagian = "", kodeSubbagian = "", kodeJabatan = "", kodeGolongan = "", kodeGrade = "", kodeEselon = "", kodeStatus = "";

            int bln = cmbBulan.SelectedIndex + 1;
            if (txtNip.Text != "")
            {
                niptemp = txtNip.Text.Split('-');
                nip = niptemp[1];
            }
            if (cmbDeputi.SelectedIndex > 0)
            {
                kodeDeputi = namaDeputi.Find(x => x.content == (cmbDeputi.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbBiro.SelectedIndex > 0)
            {
                kodeBiro = namaBiro.Find(x => x.content == (cmbBiro.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbBagian.SelectedIndex > 0)
            {
                kodeBagian = namaBagian.Find(x => x.content == (cmbBagian.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbSubbagian.SelectedIndex > 0)
            {
                kodeSubbagian = namaSubbagian.Find(x => x.content == (cmbSubbagian.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbJabatan.SelectedIndex > 0)
            {
                kodeJabatan = namaJabatan.Find(x => x.content == (cmbJabatan.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbGolongan.SelectedIndex > 0)
            {
                kodeGolongan = namaGolongan.Find(x => x.content == (cmbGolongan.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbGrade.SelectedIndex > 0)
            {
                kodeGrade = namaGrade.Find(x => x.content == (cmbGrade.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbEselon.SelectedIndex > 0)
            {
                kodeEselon = namaEselon.Find(x => x.content == (cmbEselon.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbStatus.SelectedIndex > 0)
            {
                kodeStatus = namaStatus.Find(x => x.content == (cmbStatus.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }

            string angbulan = lbulan.Find(x => x.namaBulan == (cmbBulan.SelectedItem as ComboBoxItem).Content.ToString()).angkaBulan;

            //MessageBox.Show(angbulan);
            DateTime date = Convert.ToDateTime(cmbTahun.Text + "-" + angbulan + "-01");
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            //MessageBox.Show(lastDayOfMonth.ToString("yyyy-MM-dd"));
            
            List<statusForm> filterLap = new List<statusForm>();
            filterLap.Add(new statusForm { formTitel = "first", formValue = firstDayOfMonth.ToString("yyyy-MM-dd") });
            filterLap.Add(new statusForm { formTitel = "last", formValue = lastDayOfMonth.ToString("yyyy-MM-dd") });
            //filterLap.Add(new statusForm { formTitel = "jenis", formValue = cmbJenisLap.Text });
            filterLap.Add(new statusForm { formTitel = "NIP", formValue = nip });
            filterLap.Add(new statusForm { formTitel = "KODE_DEPUTI", formValue = kodeDeputi });
            filterLap.Add(new statusForm { formTitel = "KODE_BIRO", formValue = kodeBiro });
            filterLap.Add(new statusForm { formTitel = "KODE_BAGIAN", formValue = kodeBagian });
            filterLap.Add(new statusForm { formTitel = "KODE_SUBBAGIAN", formValue = kodeSubbagian });
            filterLap.Add(new statusForm { formTitel = "KODE_JABATAN", formValue = kodeJabatan });
            filterLap.Add(new statusForm { formTitel = "KODE_GOLONGAN", formValue = kodeGolongan });
            filterLap.Add(new statusForm { formTitel = "KODE_GRADE", formValue = kodeGrade });
            filterLap.Add(new statusForm { formTitel = "KODE_ESELON", formValue = kodeEselon });
            filterLap.Add(new statusForm { formTitel = "KODE_STATUS_PEGAWAI", formValue = kodeStatus });
            string filterdata ="";
            foreach ( var isi in filterLap) 
            {
                if (isi.formTitel == "first")
                    filterdata = filterdata + " AND TGL_MASUK >= '" + isi.formValue + "'";
                else if (isi.formTitel == "last")
                    filterdata = filterdata + " AND TGL_MASUK <= '" + isi.formValue + "'";
                else if (isi.formValue != "" && isi.formTitel != "first" && isi.formTitel != "last")
                    filterdata = filterdata + " AND " + isi.formTitel + " = '" + isi.formValue + "'"; 
            }
            //MessageBox.Show(filterdata);
            frameContent.Content = new monthlyReport(isSqlServer, breadcumb, dialogHost, frameContent, LoadingContent, dialogContent, username, reload, filterdata);
        }

        void reload()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    this.frameContent.Content = "";
                    this.LoadingContent.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                this.LoadingContent.Visibility = Visibility.Hidden;
                frameContent.Content = new monthly(isSqlServer, breadcumb, dialogHost, frameContent, LoadingContent, dialogContent, username,gradeID);

            };
            worker.RunWorkerAsync();
        }

    }
}