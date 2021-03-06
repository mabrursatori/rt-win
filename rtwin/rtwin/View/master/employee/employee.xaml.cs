﻿using System;
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
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using rtwin.dataQuery;
using rtwin.lib;
using rtwin.Model;
using rtwin.View.customDialog;
using rtwin.ViewModel;
namespace rtwin.View.master.employee
{
    /// <summary>
    /// Interaction logic for employee.xaml
    /// </summary>
    public partial class employee : UserControl
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
        string username,gradeID, uriTheme;
        string actionLog = "";
        bool dialogSearch;
        List<comboBoxTemplate> namaDeputi, namaBiro;
        public employee(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username,string gradeID, string uriTheme)
        {
            HeightScress = Convert.ToInt32(System.Windows.SystemParameters.WorkArea.Height);
            InitializeComponent();
            this.DataContext = new TextBoxSuggestionsViewModel(isSqlServer,username,gradeID);
            this.isSqlServer = isSqlServer;
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.breadcumb = bredcumb;
            this.dialogContent = dialogContent;
            this.username = username;
            this.gradeID = gradeID;
            bredcumb.Text = "Master / Karyawan";
            if (HeightScress < 600)
            {
                dgEmployee.Height = 300;
            }
            else if (HeightScress > 600 && HeightScress < 700)
            {
                dgEmployee.Height = 380;
            }
            else if (HeightScress > 700 && HeightScress < 800)
            {
                dgEmployee.Height = 420;
            }
            else if (HeightScress > 800 && HeightScress < 900)
            {
                dgEmployee.Height = 520;
            }
            con = new koneksi(isSqlServer);
            js = new generateJson(isSqlServer);
            generateComboBoxDeputi();
            generateComboBoxSortItem();
            generateColumdgEmployee(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()));
            if (gradeID != "1")
            {
                edit_header.Visibility = Visibility.Hidden;
                hapus_header.Visibility = Visibility.Hidden;
                btnAddData.Visibility = Visibility.Hidden;
            }
            this.uriTheme = uriTheme;
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri(uriTheme, UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);

        }
        private void generateComboBoxSortItem()
        {

            cmbSort.Items.Add(new ComboBoxItem { Content = "Nip ", Name = "NIP", IsSelected = true });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Pin", Name = "PIN" });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Nama", Name = "NAMA" });
            
        }
        private void generateColumdgEmployee(int page, int jumData)
        {

            dgEmployee.Columns.Add(new DataGridTextColumn { Header = "Nip", Binding = new Binding("NIP"), DisplayIndex = 0 });
            dgEmployee.Columns.Add(new DataGridTextColumn { Header = "Pin", Binding = new Binding("PIN"), DisplayIndex = 1 });
            dgEmployee.Columns.Add(new DataGridTextColumn { Header = "Nama", Binding = new Binding("NAMA"), DisplayIndex = 2 });
            dgEmployee.Columns.Add(new DataGridTextColumn { Header = "Jabatan", Binding = new Binding("NAMA_JABATAN"), DisplayIndex = 3 });
            dgEmployee.Columns.Add(new DataGridTextColumn { Header = "Golongan", Binding = new Binding("NAMA_GOLONGAN"), DisplayIndex = 4 });
            dgEmployee.Columns.Add(new DataGridTextColumn { Header = "Tgl \n Mulai \n Tugas", Binding = new Binding("TMT"), DisplayIndex = 5 });
            dgEmployee.Columns.Add(new DataGridTextColumn { Header = "Aktif \n Handprint", Binding = new Binding("AKTIF"), DisplayIndex = 6 });
            dgEmployee.Columns.Add(new DataGridTextColumn { Header = "Enroll", Binding = new Binding("ENROLL"), DisplayIndex = 7 });
            dgEmployee.Columns.Add(new DataGridTextColumn { Header = "No HP", Binding = new Binding("NO_TELP"), DisplayIndex = 8 });

            generateDatadgEmployee(page, jumData, (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }
        private void generateDatadgEmployee(int page, int jumData, string orderBy)
        {

            int pageTemp = (page * jumData) + 1;
            int rangePage = (page + 1) * jumData;
            int halaman = page + 1;
            string kodeDeputi = "", kodeBiro = "";
            string nip = "";
            string[] nipTemp;
            if (cmbKodeDeputi.SelectedIndex > 0)
            {
                kodeDeputi = namaDeputi.Find(x => x.content == (cmbKodeDeputi.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbKodeBiro.SelectedIndex > 0)
            {
                kodeBiro = namaBiro.Find(x => x.content == (cmbKodeBiro.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (txtNip.Text != "")
            {
                nipTemp = txtNip.Text.Split('-');
                nip = nipTemp[1];
            }
            string filter = queryKaryawan.filter( nip,kodeDeputi, kodeBiro,username,gradeID);
            string queryTemp = queryKaryawan.getQueryKaryawan(orderBy, AriLib.orderBy(asc)) +filter ;
            string queryCountTemp = queryKaryawan.getQueryCountKaryawan+filter;
            dgEmployee.Items.Clear();
            List<string> jumlah = con.getDataFromDatabase(queryCountTemp);
            if (Int32.Parse(jumlah[0]) > 0)
            {
                string queryPaging = AriLib.createPaging(queryTemp, pageTemp, rangePage, jumData, isSqlServer);

                json = js.generateDataGridJson(queryPaging, jumlah[0]);

                var data = JsonConvert.DeserializeObject<dataKaryawanAktif>(json);
                if (data.rows.Count > 0)
                {

                    for (int i = 0; i < data.rows.Count; i++)
                    {
                        dgEmployee.Items.Add(new dataDetailKaryawanAktif { NIP=data.rows[i].NIP, PIN=data.rows[i].PIN,NAMA= data.rows[i].NAMA ,NAMA_JABATAN= data.rows[i].NAMA_JABATAN,NAMA_GOLONGAN= data.rows[i].NAMA_GOLONGAN,TMT= Convert.ToDateTime(data.rows[i].TMT).ToString("dd/MM/yyyy"),AKTIF = Convert.ToDateTime(data.rows[i].AKTIF).ToString("dd/MM/yyyy"),ENROLL= data.rows[i].ENROLL,NO_TELP= data.rows[i].NO_TELP });


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
                dgEmployee.Items.Clear();
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
                string data = "";
               frameContent.Content = new FormEmployee(isSqlServer, true, reload, showDialog, data, username,HeightScress);

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
                dataDetailKaryawanAktif data = ((FrameworkElement)sender).DataContext as dataDetailKaryawanAktif;
                //frameContent.Content = new FormBagian(isSqlServer, false, reload, showDialog, data.KODE_BAGIAN, username);

            };
            worker.RunWorkerAsync();
        }

        private void Hapus_Click(object sender, RoutedEventArgs e)
        {
            dataDetailKaryawanAktif data = ((FrameworkElement)sender).DataContext as dataDetailKaryawanAktif;
            this.queryDelete = queryBagian.getQueryDeleteBagian(data.KODE_BAGIAN);
            this.actionLog = data.KODE_BAGIAN;
            dialogContent.Content = new alertDelete(hapus);
            dialogHost.IsOpen = true;
        }
        void hapus()
        {
            string message = con.crudDatabase(queryDelete, Message.MSG_DELETE_SUCCES, Message.MSG_DELETE_FAILED);
            if (message == Message.MSG_DELETE_SUCCES)
            {
                con.createLog("1263", username, actionLog);
            }
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
            reload();
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            page = page + 1;
            generateDatadgEmployee(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            float tem = AllDataGrid / Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString());
            if (AllDataGrid % Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()) == 0)
            {
                tem = tem - 1;
            }

            generateDatadgEmployee(Convert.ToInt32(tem), Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = Convert.ToInt32(tem);
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (page != 0)
            {
                page = page - 1;
                generateDatadgEmployee(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            }

        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgEmployee(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = 0;
        }

        private void CmbJumData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                generateDatadgEmployee(page, Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
            generateDatadgEmployee(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
            this.namaDeputi = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryDeputi.getQueryComboDeputi, true, combo, isSqlServer, false));


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
            generateDatadgEmployee(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Name as string;
            if (text != null)
            {
                //MessageBox.Show(text);
                generateDatadgEmployee(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), text);

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
                //frameContent.Content = new bagian(isSqlServer, breadcumb, dialogHost, frameContent, LoadingContent, dialogContent, username);

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
