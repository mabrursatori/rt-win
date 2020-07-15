﻿using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using rtwin.dataQuery;
using rtwin.lib;
using rtwin.Model;
using rtwin.View.customDialog;
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

namespace rtwin.View.transaksi.leaveAccrual
{
    /// <summary>
    /// Interaction logic for LeaveAccrual.xaml
    /// </summary>
    public partial class LeaveAccrual : UserControl
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
        string actionLog = "", gradeID, nip, uriTheme;
        bool dialogSearch;
        List<comboBoxTemplate> namaDeputi, namaBiro,kodeIjin;
        public LeaveAccrual(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, string gradeID, string nip, string uriTheme)
        {
            HeightScress = Convert.ToInt32(System.Windows.SystemParameters.WorkArea.Height);
            InitializeComponent();
            this.DataContext = new TextBoxSuggestionsViewModel(isSqlServer, username, gradeID);
            this.isSqlServer = isSqlServer;
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.breadcumb = bredcumb;
            this.dialogContent = dialogContent;
            this.username = username;
            this.gradeID = gradeID;
            this.nip = nip;
            bredcumb.Text = "Transaksi / Ijin Per Jam";
            if (HeightScress < 600)
            {
                dgLeaveAccrual.Height = 300;
            }
            else if (HeightScress > 600 && HeightScress < 700)
            {
                dgLeaveAccrual.Height = 380;
            }
            else if (HeightScress > 700 && HeightScress < 800)
            {
                dgLeaveAccrual.Height = 420;
            }
            else if (HeightScress > 800 && HeightScress < 900)
            {
                dgLeaveAccrual.Height = 520;
            }
            con = new koneksi(isSqlServer);
            js = new generateJson(isSqlServer);
            setTgl();
            if (Convert.ToInt32(gradeID) < 4)
            {
                generateComboBoxDeputi();
            }
            generateComboBoxJenisIjin();
            generateComboBoxSortItem();
            generateColumdgLeaveAccrual(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()));
            this.uriTheme = uriTheme;
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri(uriTheme, UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);

        }

        private void setTgl()
        {
            string tahun = DateTime.Now.AddYears(-4).ToString("dd/MM/yyyy");
            for(int i = 1; i <= 5; i++)
            {
                if (Convert.ToDateTime(tahun).AddYears(i).ToString("yyyy") == DateTime.Now.ToString("yyyy"))
                {
                    thn1.Items.Add(new ComboBoxItem { Content = Convert.ToDateTime(tahun).AddYears(i).ToString("yyyy"),IsSelected=true });
                    thn2.Items.Add(new ComboBoxItem { Content = Convert.ToDateTime(tahun).AddYears(i).ToString("yyyy"),IsSelected=true });
                }
                else
                {
                    thn1.Items.Add(new ComboBoxItem { Content = Convert.ToDateTime(tahun).AddYears(i).ToString("yyyy")});
                    thn2.Items.Add(new ComboBoxItem { Content = Convert.ToDateTime(tahun).AddYears(i).ToString("yyyy") });
                }
                
            }
        }
        private void generateComboBoxSortItem()
        {

            cmbSort.Items.Add(new ComboBoxItem { Content = "Nip ", Name = "NIP"});
            cmbSort.Items.Add(new ComboBoxItem { Content = "nama", Name = "NAMA" });
            cmbSort.Items.Add(new ComboBoxItem { Content = "nama", Name = "TMT", IsSelected = true });

        }
        private void generateColumdgLeaveAccrual(int page, int jumData)
        {

            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Nip", Binding = new Binding("NIP"), DisplayIndex = 0 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Nama", Binding = new Binding("NAMA"), DisplayIndex = 1 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "TMT", Binding = new Binding("TMT"), DisplayIndex = 2 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Masa Kerja", Binding = new Binding("LAMA_KERJA"), DisplayIndex = 3 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Tahun", Binding = new Binding("TGL_AKHIR"), DisplayIndex = 4 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Kode Ijin", Binding = new Binding("KODE_IJIN"), DisplayIndex = 5 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Jenis Ijin", Binding = new Binding("KET_IJIN"), DisplayIndex = 6 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Jatah Ijin", Binding = new Binding("JATAH_IJIN"), DisplayIndex = 7 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Tgl. Berlaku", Binding = new Binding("TGL_BERLAKU"), DisplayIndex = 8 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Expired", Binding = new Binding("EXPIRED"), DisplayIndex = 9 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Diambil", Binding = new Binding("DIAMBIL"), DisplayIndex = 10 });
            dgLeaveAccrual.Columns.Add(new DataGridTextColumn { Header = "Hangus", Binding = new Binding("TIDAK_DIAMBIL"), DisplayIndex = 11 });
            generateDatadgLeaveAccrual(page, jumData, (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }
        private void generateDatadgLeaveAccrual(int page, int jumData, string orderBy)
        {

            int pageTemp = (page * jumData) + 1;
            int rangePage = (page + 1) * jumData;
            int halaman = page + 1;
            string kodeDeputi = "", kodeBiro = "";
            string nip = "", statusIjin = "";
            string[] nipTemp;
            if (cmbKodeDeputi.SelectedIndex > 0)
            {
                kodeDeputi = namaDeputi.Find(x => x.content == (cmbKodeDeputi.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbKodeBiro.SelectedIndex > 0)
            {
                kodeBiro = namaBiro.Find(x => x.content == (cmbKodeBiro.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbKodeIjin.SelectedIndex > 0)
            {
                statusIjin = kodeIjin.Find(x => x.content == (cmbKodeIjin.SelectedItem as ComboBoxItem).Content.ToString()).name;
                
            }
            if (Convert.ToInt32(gradeID) < 4)
            {
                if (txtNip.Text != "")
                {
                    nipTemp = txtNip.Text.Split('-');
                    nip = nipTemp[1];
                }
            }
            else
            {
                nipTemp = lblNip.Text.Split('-');
                nip = nipTemp[1];
            }
            string filter = querySaldoCuti.filter((thn1.SelectedItem as ComboBoxItem).Content.ToString(),(thn2.SelectedItem as ComboBoxItem).Content.ToString(), nip, kodeDeputi, kodeBiro, statusIjin, username, gradeID);
            string queryTemp = querySaldoCuti.getQueryDataSaldoCuti(orderBy, AriLib.orderBy(false)) + filter;
            string queryCountTemp = querySaldoCuti.getQueryCountDataSaldoCuti + filter;
            dgLeaveAccrual.Items.Clear();
            List<string> jumlah = con.getDataFromDatabase(queryCountTemp);
            if (Int32.Parse(jumlah[0]) > 0)
            {
                string queryPaging = AriLib.createPaging(queryTemp, pageTemp, rangePage, jumData, isSqlServer);

                json = js.generateDataGridJson(queryPaging, jumlah[0]);

                var data = JsonConvert.DeserializeObject<dataSaldoCuti>(json);
                if (data.rows.Count > 0)
                {

                    for (int i = 0; i < data.rows.Count; i++)
                    {
                        
                        dgLeaveAccrual.Items.Add(new dataDetailSaldoCuti { NIP = data.rows[i].NIP, NAMA = data.rows[i].NAMA, TMT =Convert.ToDateTime(data.rows[i].TMT).ToString("dd/MM/yyyy"), LAMA_KERJA = data.rows[i].LAMA_KERJA, TGL_AKHIR = Convert.ToDateTime(data.rows[i].TGL_AKHIR).ToString("yyyy"), KODE_IJIN = data.rows[i].KODE_IJIN, KET_IJIN = data.rows[i].KET_IJIN, JATAH_IJIN = data.rows[i].JATAH_IJIN, TGL_BERLAKU =Convert.ToDateTime(data.rows[i].TGL_BERLAKU).ToString("dd/MM/yyyy"), EXPIRED = Convert.ToDateTime(data.rows[i].EXPIRED).ToString("dd/MM/yyyy"), DIAMBIL = data.rows[i].DIAMBIL,TIDAK_DIAMBIL= data.rows[i].TIDAK_DIAMBIL,SISA_IJIN= data.rows[i].SISA_IJIN,TGL_AWAL= data.rows[i].TGL_AWAL, PIN = data.rows[i].PIN });
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
                dgLeaveAccrual.Items.Clear();
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
            
        }

        
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            page = page + 1;
            generateDatadgLeaveAccrual(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            float tem = AllDataGrid / Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString());
            if (AllDataGrid % Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()) == 0)
            {
                tem = tem - 1;
            }

            generateDatadgLeaveAccrual(Convert.ToInt32(tem), Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = Convert.ToInt32(tem);
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (page != 0)
            {
                page = page - 1;
                generateDatadgLeaveAccrual(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            }

        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgLeaveAccrual(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = 0;
        }

        private void CmbJumData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                generateDatadgLeaveAccrual(page, Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
            generateDatadgLeaveAccrual(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
            string queryDeputi_ = queryDeputi.getQueryComboDeputi + queryDeputi.getQueryGRantDepartemenDeputi(gradeID, username);
            this.namaDeputi = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryDeputi_, true, combo, isSqlServer, false));


        }
        void generateComboBoxJenisIjin()
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbKodeIjin);
            string queryKodeIjin = querySaldoCuti.getQueryKodeIjinCuti;
            this.kodeIjin = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryKodeIjin, true, combo, true, false));
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

        private void BtnProcess_Click(object sender, RoutedEventArgs e)
        {
            if (cmbProses.SelectedIndex == 0)
            {
                lblKonfirmasi.Text = "Yakin akan mengupdate data Jatah Ijin?";
                dialogProsesKonfirmasi.IsOpen = true;
            }else if (cmbProses.SelectedIndex == 1)
            {
                lblInputParameter.Text = "Jumlah Jatah Ijin ditambah kan";
                dialogInputParameter.IsOpen = true;
            }else if (cmbProses.SelectedIndex == 4)
            {
                lblInputTgl.Text = "Tanggal Batas baru:	";
                dialogInputTgl.IsOpen = true;
            }else if (cmbProses.SelectedIndex == 2)
            {
                lblInputParameter.Text = "Jumlah jatah Ijin Dipotong";
                dialogInputParameter.IsOpen = true;
            }else if (cmbProses.SelectedIndex == 3)
            {
                lblInputParameter.Text = "jumlah Sisa Jatah Ijin setelah pemotongan";
                dialogInputParameter.IsOpen = true;
            }else if (cmbProses.SelectedIndex == 5)
            {
                lblInputParameter.Text = "Jumlah Bulan ditambahkan pada tanggal Batas";
                dialogInputParameter.IsOpen = true;
            }else if (cmbProses.SelectedIndex == 6)
            {
                lblKonfirmasi.Text = "Yakin akan menghanguskan Jatah Ijin tersisa?";
                dialogProsesKonfirmasi.IsOpen = true;
            }

        }
        private string getFilter()
        {
            string temp = "";
            string[] nip;
            if (txtNip.Text != "")
            {
                nip = txtNip.Text.Split('-');
                temp += " AND (taKaryawan.NIP=''" + nip[1] + "'')";
            }
            if(cmbKodeDeputi.SelectedIndex>0)
            {
                temp += " AND (taKaryawan.KODE_DEPUTI = ''" + namaDeputi.Find(x=>x.content==(cmbKodeDeputi.SelectedItem as ComboBoxItem).Content.ToString()).name.ToString() + "'')";
            }
            if(cmbKodeBiro.SelectedIndex>0)
            {
                temp += " AND (taKaryawan.KODE_BIRO = ''" + namaBiro.Find(x=>x.content==(cmbKodeBiro.SelectedItem as ComboBoxItem).Content.ToString()).name.ToString() + "'')";
            }
            return temp;
        }
        private void BtnProsesKonfirmasi_Click(object sender, RoutedEventArgs e)
        {
            string message = string.Empty;
            dialogProsesKonfirmasi.IsOpen = false;
            string kodeIjinTemp = kodeIjin.Find(x => x.content == (cmbKodeIjin.SelectedItem as ComboBoxItem).Content.ToString()).name.ToString();
            if (cmbProses.SelectedIndex == 0)
            {
                 message= con.crudDatabase(querySaldoCuti.getProcUpdateJatahIjin((thn1.SelectedItem as ComboBoxItem).Content.ToString(),kodeIjinTemp,getFilter()), "Proses Update Jatah Ijin berhasil", "Proses Update Jatah Ijin Gagal");
            }else if (cmbProses.SelectedIndex == 6)
            {
                message = con.crudDatabase(querySaldoCuti.getProc_HangusJatahIjin((thn1.SelectedItem as ComboBoxItem).Content.ToString(), kodeIjinTemp, getFilter()), "Proses Hangus Jatah Ijin Berhasil", "Proses Hangus Jatah Ijin gagal");
            }
            showDialog(message);
            
        }

        private void BtnDialogInputParameter_Click(object sender, RoutedEventArgs e)
        {
            string message = string.Empty;
            dialogProsesKonfirmasi.IsOpen = false;
            if (cmbProses.SelectedIndex == 1)
            {
                message = con.crudDatabase(querySaldoCuti.getProc_TambahJatahIjin((thn1.SelectedItem as ComboBoxItem).Content.ToString(), kodeIjin.Find(x => x.content == (cmbKodeIjin.SelectedItem as ComboBoxItem).Content.ToString()).name.ToString(), getFilter(),txtInputParameter.Text),"Tambah Jatah Ijin Berhasil", "Tambah Jatah Ijin Gagal");
            }else if (cmbProses.SelectedIndex == 2)
            {
                message = con.crudDatabase(querySaldoCuti.getProc_PotongJatahIjin((thn1.SelectedItem as ComboBoxItem).Content.ToString(), kodeIjin.Find(x => x.content == (cmbKodeIjin.SelectedItem as ComboBoxItem).Content.ToString()).name.ToString(), getFilter(),txtInputParameter.Text), "Potong Jatah Ijin Berhasil", "Potong Jatah Ijin gagal");
            }else if (cmbProses.SelectedIndex == 3)
            {
                message = con.crudDatabase(querySaldoCuti.getProc_PotongSisaJatahIjin((thn1.SelectedItem as ComboBoxItem).Content.ToString(), kodeIjin.Find(x => x.content == (cmbKodeIjin.SelectedItem as ComboBoxItem).Content.ToString()).name.ToString(), getFilter(), txtInputParameter.Text), "Potong Sisa Jatah Ijin Berhasil", "Potong Sisa Jatah Ijin Gagal");
            }else if (cmbProses.SelectedIndex == 5)
            {
                message = con.crudDatabase(querySaldoCuti.getProc_PerpanjangJatahIjin((thn1.SelectedItem as ComboBoxItem).Content.ToString(), kodeIjin.Find(x => x.content == (cmbKodeIjin.SelectedItem as ComboBoxItem).Content.ToString()).name.ToString(), getFilter(), txtInputParameter.Text), "Perpanjangan Jatah Ijin Berhasil", "Perpanjangan Jatah Ijin Gagal");
            }

            showDialog(message);
        }

        private void BtnDialogInput_Click(object sender, RoutedEventArgs e)
        {
            string message = string.Empty;
            if (cmbProses.SelectedIndex == 4)
            {
                message = con.crudDatabase(querySaldoCuti.getProc_SetExpiredJatahIjin((thn1.SelectedItem as ComboBoxItem).Content.ToString(), kodeIjin.Find(x => x.content == (cmbKodeIjin.SelectedItem as ComboBoxItem).Content.ToString()).name.ToString(), getFilter(), dpTgl.Text), "Set expire jatah Ijin Berhasil", "Set expire Jatah Ijin Gagal");
            }
        }

        private void BtnTampilkan_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgLeaveAccrual(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Name as string;
            if (text != null)
            {
                //MessageBox.Show(text);
                generateDatadgLeaveAccrual(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), text);

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
                frameContent.Content = new LeaveAccrual(isSqlServer, breadcumb, dialogHost, frameContent, LoadingContent, dialogContent, username, gradeID, nip, uriTheme);

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
