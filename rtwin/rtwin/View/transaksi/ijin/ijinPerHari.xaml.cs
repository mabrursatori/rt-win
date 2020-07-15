﻿using MaterialDesignThemes.Wpf;
using rtwin.lib;
using rtwin.Model;
using rtwin.ViewModel;
using rtwin.dataQuery;
using Newtonsoft.Json;
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
using System.ComponentModel;
using System.Threading;
using rtwin.View.customDialog;

namespace rtwin.View.transaksi.ijin
{
    /// <summary>
    /// Interaction logic for ijinPerHari.xaml
    /// </summary>
    public partial class ijinPerHari : UserControl
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
        string actionLog = "",gradeID,nip, uriTheme;
        bool dialogSearch;
        List<comboBoxTemplate> namaDeputi, namaBiro;
        public ijinPerHari(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username,string gradeID,string nip, string uriTheme)
        {
            HeightScress = Convert.ToInt32(System.Windows.SystemParameters.WorkArea.Height);
            InitializeComponent();
            this.isSqlServer = isSqlServer;
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.breadcumb = bredcumb;
            this.dialogContent = dialogContent;
            this.username = username;
            this.gradeID = gradeID;
            this.nip = nip;

            this.DataContext = new TextBoxSuggestionsViewModel(isSqlServer, username, gradeID);
            bredcumb.Text = "Transaksi / Kehadiran Manual";
            if (HeightScress < 600)
            {
                dgIjinHari.Height = 300;
            }
            else if (HeightScress > 600 && HeightScress < 700)
            {
                dgIjinHari.Height = 380;
            }
            else if (HeightScress > 700 && HeightScress < 800)
            {
                dgIjinHari.Height = 420;
            }
            else if (HeightScress > 800 && HeightScress < 900)
            {
                dgIjinHari.Height = 520;
            }
            con = new koneksi(isSqlServer);
            js = new generateJson(isSqlServer);
            setTgl();
            if (Convert.ToInt32(gradeID) < 4)
            {
                generateComboBoxDeputi();
            }
            else
            {
                string queryGetNip = queryKaryawan.getAutoCompletekaryawan + " WHERE NIP='" + nip + "' ";
                List<string> dataNip = con.getDataFromDatabase(queryGetNip);
                if (dataNip.Count > 0)
                {
                    svNip.Visibility = Visibility.Hidden;
                    lblNip.Visibility = Visibility.Visible;
                    lblNip.Text = dataNip[0];
                    cmbKodeBiro.IsEnabled = false;
                    cmbKodeDeputi.IsEnabled = false;
                }
            }
            
            generateComboBoxSortItem();
            generateColumdgIjinHari(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()));
            this.uriTheme = uriTheme;
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri(uriTheme, UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);
        }
        private void setTgl()
        {
            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            dpTglAwal.Text = firstDayOfMonth.ToString("dd/MM/yyyy");
            dpTglAkhir.Text = lastDayOfMonth.ToString("dd/MM/yyyy");
        }
        private void generateComboBoxSortItem()
        {

            cmbSort.Items.Add(new ComboBoxItem { Content = "Nip ", Name = "NIP"});
            cmbSort.Items.Add(new ComboBoxItem { Content = "Tgl Awal", Name = "TGL_AWAL", IsSelected = true });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Tgl Akhir", Name = "TGL_AKHIR" });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Ket Ijin", Name = "KET_IJIn"});

        }
        private void generateColumdgIjinHari(int page, int jumData)
        {

            dgIjinHari.Columns.Add(new DataGridTextColumn { Header = "Nip", Binding = new Binding("NIP"), DisplayIndex = 0 });
            dgIjinHari.Columns.Add(new DataGridTextColumn { Header = "Nama", Binding = new Binding("NAMA"), DisplayIndex = 1 });
            dgIjinHari.Columns.Add(new DataGridTextColumn { Header = "Tanggal Awal", Binding = new Binding("TGL_AWAL"), DisplayIndex = 2 });
            dgIjinHari.Columns.Add(new DataGridTextColumn { Header = "Tanggal Akhir", Binding = new Binding("TGL_AKHIR"), DisplayIndex = 3 });
            dgIjinHari.Columns.Add(new DataGridTextColumn { Header = "Kode Status", Binding = new Binding("KODE_IJIN"), DisplayIndex = 4 });
            dgIjinHari.Columns.Add(new DataGridTextColumn { Header = "Ket Status Absen", Binding = new Binding("KET_IJIN"), DisplayIndex = 5 });    
            dgIjinHari.Columns.Add(new DataGridTextColumn { Header = "Jml Hari", Binding = new Binding("JML_HARI"), DisplayIndex = 6 });
            dgIjinHari.Columns.Add(new DataGridTextColumn { Header = "Dokumen Pendukung", Binding = new Binding("BUKTI_IJIN"), DisplayIndex = 7 });


            generateDatadgIjinHari(page, jumData, (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }
        private void generateDatadgIjinHari(int page, int jumData, string orderBy)
        {

            int pageTemp = (page * jumData) + 1;
            int rangePage = (page + 1) * jumData;
            int halaman = page + 1;
            string kodeDeputi = "", kodeBiro = "";
            string nip = "",statusIjin="";
            string[] nipTemp;
            if (cmbKodeDeputi.SelectedIndex > 0)
            {
                kodeDeputi = namaDeputi.Find(x => x.content == (cmbKodeDeputi.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbKodeBiro.SelectedIndex > 0)
            {
                kodeBiro = namaBiro.Find(x => x.content == (cmbKodeBiro.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbStatusIjin.SelectedIndex > 0)
            {
                statusIjin = (cmbStatusIjin.SelectedItem as ComboBoxItem).Content.ToString();
                if (statusIjin == "Diajukan")
                {
                    statusIjin = "0";
                }
                else
                {
                    statusIjin = "1";
                }
            }
            if(Convert.ToInt32(gradeID) < 4)
            {
                if (txtNip.Text != "")
                {
                    nipTemp = txtNip.Text.Split('-');
                    nip = nipTemp[1];
                }
            }else
            {
                nipTemp = lblNip.Text.Split('-');
                nip = nipTemp[1];
            }
            string filter = queryIjinHari.filter(DateTime.Parse(dpTglAwal.Text).ToString("yyyy-MM-dd"), DateTime.Parse(dpTglAkhir.Text).ToString("yyyy-MM-dd"), nip, kodeDeputi, kodeBiro,statusIjin,username,gradeID);
            string queryTemp = queryIjinHari.getDataIjinhari(orderBy, AriLib.orderBy(false)) + filter;
            string queryCountTemp = queryIjinHari.getQueryCountIjinHari + filter;
            dgIjinHari.Items.Clear();
            List<string> jumlah = con.getDataFromDatabase(queryCountTemp);
            if (Int32.Parse(jumlah[0]) > 0)
            {
                string queryPaging = AriLib.createPaging(queryTemp, pageTemp, rangePage, jumData, isSqlServer);

                json = js.generateDataGridJson(queryPaging, jumlah[0]);

                var data = JsonConvert.DeserializeObject<dataIjinHari>(json);
                if (data.rows.Count > 0)
                {

                    for (int i = 0; i < data.rows.Count; i++)
                    {
                        dgIjinHari.Items.Add(new dataDetailIjinHari { NIP = data.rows[i].NIP, PIN = data.rows[i].PIN, NAMA = data.rows[i].NAMA,TGL_AWAL= Convert.ToDateTime(data.rows[i].TGL_AWAL).ToString("dd/MM/yyyy"),TGL_AKHIR= Convert.ToDateTime(data.rows[i].TGL_AKHIR).ToString("dd/MM/yyyy"),KODE_IJIN=data.rows[i].KODE_IJIN,KET_IJIN= data.rows[i].KET_IJIN,JML_HARI= data.rows[i].JML_HARI,TGL_JATAH= Convert.ToDateTime(data.rows[i].TGL_JATAH).ToString("dd/MM/yyyy"),BUKTI_IJIN= data.rows[i].BUKTI_IJIN,STATUS_IJIN= data.rows[i].STATUS_IJIN,PERHITUNGAN= data.rows[i].PERHITUNGAN,LAMA_IJIN= data.rows[i].LAMA_IJIN });


                    }

                }
                AllDataGrid = Convert.ToInt32(jumlah[0]);
                dari.Text = pageTemp.ToString();
                sampai.Text = rangePage.ToString();
                total.Text = (Convert.ToInt32(jumlah[0].ToString()) - 1).ToString();
                cekbntPage(Convert.ToInt32(total.Text), jumData, halaman);
            }
            else
            {
                dgIjinHari.Items.Clear();
                AllDataGrid = 0;
                dari.Text = "0";
                sampai.Text = "0";
                total.Text = "0";
                cekbntPage(Convert.ToInt32(total.Text), jumData, halaman);
            }


        }

        private void cekbntPage(int totaldata, int jumData, int halaman)
        {
            if (totaldata != 0)
            {
                if (dari.Text == "1")
                {
                    firstPage.IsEnabled = false;
                    prevPage.IsEnabled = false;
                }
                else
                {
                    firstPage.IsEnabled = true;
                    prevPage.IsEnabled = true;
                }
                float tem = totaldata / jumData;
                if (totaldata % jumData > 0)
                {
                    tem += 1;
                }

                if (tem == halaman)
                {
                    nextPage.IsEnabled = false;
                    lastPage.IsEnabled = false;
                }
                else
                {
                    nextPage.IsEnabled = true;
                    lastPage.IsEnabled = true;
                }

            }
            else
            {
                nextPage.IsEnabled = false;
                lastPage.IsEnabled = false;
                firstPage.IsEnabled = false;
                prevPage.IsEnabled = false;
            }

        }
        private void BtnAddData_Click(object sender, RoutedEventArgs e)
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
                //List<dataDetailTimeCard> data=String.;
                string[] data = new string[4];
                frameContent.Content = new FormIjin(isSqlServer, true, reload, showDialog, data, username,gradeID,nip);

            };
            worker.RunWorkerAsync();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
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
                dataDetailIjinHari data = ((FrameworkElement)sender).DataContext as dataDetailIjinHari;
                string[] dataTemp = new string[2];
                dataTemp[0] = data.NIP;
                dataTemp[1] = Convert.ToDateTime(data.TGL_AWAL).ToString("dd/MM/yyyy");
               frameContent.Content = new FormIjin(isSqlServer, false, reload, showDialog, dataTemp, username,gradeID,nip);

            };
            worker.RunWorkerAsync();
        }

        private void Hapus_Click(object sender, RoutedEventArgs e)
        {
            dataDetailIjinHari data = ((FrameworkElement)sender).DataContext as dataDetailIjinHari;
            this.queryDelete = queryIjinHari.deleteIjinHari(data.NIP, Convert.ToDateTime(data.TGL_AWAL).ToString("yyyy-MM-dd"));
            this.actionLog = data.NAMA+"-"+ data.NIP + "," + Convert.ToDateTime(data.TGL_AWAL).ToString("dd/MM/yyyy");
            dialogContent.Content = new alertDelete(hapus);
            dialogHost.IsOpen = true;
        }
        void hapus()
        {
            string message = con.crudDatabase(queryDelete, Message.MSG_DELETE_SUCCES, Message.MSG_DELETE_FAILED);
            if (message == Message.MSG_DELETE_SUCCES)
            {
                con.createLog("2213", username, actionLog);
            }
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
            reload();
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            page = page + 1;
            generateDatadgIjinHari(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            float tem = AllDataGrid / Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString());
            if (AllDataGrid % Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()) == 0)
            {
                tem = tem - 1;
            }

            generateDatadgIjinHari(Convert.ToInt32(tem), Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = Convert.ToInt32(tem);
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (page != 0)
            {
                page = page - 1;
                generateDatadgIjinHari(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            }

        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgIjinHari(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = 0;
        }

        private void CmbJumData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                generateDatadgIjinHari(page, Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            }
            //MessageBox.Show(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString());
            // generateDatadgTimeCard(page, Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()));
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            //this.Content = new PackIcon { Kind = PackIconKind.ArrowDown };
            if (asc)
            {
                asc = false;
                btnSort.Content = new PackIcon { Kind = PackIconKind.ArrowDown };
            }
            else
            {
                asc = true;
                btnSort.Content = new PackIcon { Kind = PackIconKind.ArrowUp };
            }
            generateDatadgIjinHari(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            dialog.IsOpen = true;
            if (dialogSearch)
            {
                dialog.IsOpen = true;
                dialogSearch = false;
                btnSearch.Content = new PackIcon { Kind = PackIconKind.CloseBox };
            }
            else
            {
                dialog.IsOpen = false;
                dialogSearch = true;
                btnSearch.Content = new PackIcon { Kind = PackIconKind.Search };
                txtNip.Text = "";
                cmbKodeDeputi.SelectedIndex = 0;
                cmbKodeBiro.SelectedIndex = 0;
            }
        }
        void generateComboBoxDeputi()
        {

            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbKodeDeputi);
            this.namaDeputi = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryDeputi.getQueryComboDeputi+queryDeputi.getQueryGRantDepartemenDeputi(gradeID,username), true, combo, isSqlServer, false));


        }
        void generateComboBoxBiro(string kodeDeputi)
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbKodeBiro);
            if (kodeDeputi != "")
            {
                cmbKodeBiro.Items.Clear();
                this.namaBiro = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryBiro.queryComboBiroFilter(kodeDeputi), true, combo, isSqlServer, false));
            }

        }

        private void BtnTampilkan_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgIjinHari(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Name as string;
            if (text != null)
            {
                //MessageBox.Show(text);
                generateDatadgIjinHari(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), text);

            }
        }

        private void CmbKodeDeputi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;


            if (text != null)
            {
                generateComboBoxBiro(namaDeputi.Find(x => x.content == text).name);
            }
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
                //List<dataDetailTimeCard> data=String.;
                frameContent.Content = new ijinPerHari(isSqlServer, breadcumb, dialogHost, frameContent, LoadingContent, dialogContent, username,gradeID,nip, uriTheme);

            };
            worker.RunWorkerAsync();
        }
        void showDialog(string message)
        {
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
        }

    }
}
