﻿using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using rtwin.dataQuery;
using rtwin.lib;
using rtwin.Model;
using rtwin.View.customDialog;
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
    /// Interaction logic for subBagian.xaml
    /// </summary>
    public partial class subBagian : UserControl
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
        int AllDataGrid = 0;
        TextBlock breadcumb;
        string queryDelete = "";
        string username;
        string actionLog = "";
        bool dialogSearch;
        List<comboBoxTemplate> namaDeputi, namaBiro,namaBagian;
        string gradeID, uriTheme;
        public subBagian(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, string gradeID, string uriTheme)
        {
            int HeightScress = Convert.ToInt32(System.Windows.SystemParameters.WorkArea.Height);
            InitializeComponent();
            this.isSqlServer = isSqlServer;
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.breadcumb = bredcumb;
            this.dialogContent = dialogContent;
            this.username = username;
            bredcumb.Text = "Master / Unit Kerja / Satuan Kerja / Sub Bagian";
            if (HeightScress < 600)
            {
                dgSubBagian.Height = 300;
            }
            else if (HeightScress > 600 && HeightScress < 700)
            {
                dgSubBagian.Height = 380;
            }
            else if (HeightScress > 700 && HeightScress < 800)
            {
                dgSubBagian.Height = 420;
            }
            con = new koneksi(isSqlServer);
            js = new generateJson(isSqlServer);
            generateComboBoxDeputi();
            generateComboBoxSortItem();
            generateColumdgSubBagian(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()));
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

            cmbSort.Items.Add(new ComboBoxItem { Content = "Kode ", Name = "KODE_SUBBAGIAN", IsSelected = true });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Nama Sub Bagian", Name = "NAMA_SUBBAGIAN" });
        }
        private void generateColumdgSubBagian(int page, int jumData)
        {

            dgSubBagian.Columns.Add(new DataGridTextColumn { Header = "Kode Sub Bagian", Binding = new Binding("KODE_SUBBAGIAN"), DisplayIndex = 0 });
            dgSubBagian.Columns.Add(new DataGridTextColumn { Header = "Nama Sub Bagian", Binding = new Binding("NAMA_SUBBAGIAN"), DisplayIndex = 1 });
            dgSubBagian.Columns.Add(new DataGridTextColumn { Header = "Nama Bagian", Binding = new Binding("NAMA_BAGIAN"), DisplayIndex = 2 });

            generateDatadgSubBagian(page, jumData, (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }
        private void generateDatadgSubBagian(int page, int jumData, string orderBy)
        {

            int pageTemp = (page * jumData) + 1;
            int rangePage = (page + 1) * jumData;
            int halaman = page + 1;
            string kodeDeputi = "", kodeBiro = "",kodeBagian="";
            if (cmbKodeDeputi.SelectedIndex > 0)
            {
                kodeDeputi = namaDeputi.Find(x => x.content == (cmbKodeDeputi.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbKodeBiro.SelectedIndex > 0)
            {
                kodeBiro = namaBiro.Find(x => x.content == (cmbKodeBiro.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            if (cmbKodebagian.SelectedIndex > 0)
            {
                kodeBagian = namaBagian.Find(x => x.content == (cmbKodebagian.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            string filter = querySubBagian.filter(kodeDeputi, kodeBiro,kodeBagian);
            string queryTemp = querySubBagian.getQueryViewSubBagian(orderBy, AriLib.orderBy(asc)) + filter; ;
            string queryCountTemp = querySubBagian.getQueryCountViewSubBagian + filter;
            dgSubBagian.Items.Clear();
            List<string> jumlah = con.getDataFromDatabase(queryCountTemp);
            if (Int32.Parse(jumlah[0]) > 0)
            {
                string queryPaging = AriLib.createPaging(queryTemp, pageTemp, rangePage, jumData, isSqlServer);

                json = js.generateDataGridJson(queryPaging, jumlah[0]);

                var data = JsonConvert.DeserializeObject<dataSubBagian>(json);
                if (data.rows.Count > 0)
                {

                    for (int i = 0; i < data.rows.Count; i++)
                    {
                        if (data.rows[i].KODE_BAGIAN != "000000")
                        {
                            dgSubBagian.Items.Add(new dataDetailSubBagianView {KODE_SUBBAGIAN=data.rows[i].KODE_SUBBAGIAN,NAMA_SUBBAGIAN=data.rows[i].NAMA_SUBBAGIAN, KODE_BAGIAN = data.rows[i].KODE_BAGIAN, NAMA_BAGIAN = data.rows[i].NAMA_BAGIAN, KODE_BIRO = data.rows[i].KODE_BIRO,KODE_DEPUTI = data.rows[i].KODE_DEPUTI, KODE_UNIT = data.rows[i].KODE_UNIT, KODE_INSTANSI = data.rows[i].KODE_INSTANSI, KODE_CABANG = data.rows[i].KODE_CABANG });
                        }


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
                dgSubBagian.Items.Clear();
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
                frameContent.Content = new FormSubBagian(isSqlServer, true, reload, showDialog, data, username);

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
                dataDetailSubBagianView data = ((FrameworkElement)sender).DataContext as dataDetailSubBagianView;
                frameContent.Content = new FormSubBagian(isSqlServer, false, reload, showDialog, data.KODE_SUBBAGIAN, username);

            };
            worker.RunWorkerAsync();
        }

        private void Hapus_Click(object sender, RoutedEventArgs e)
        {
            dataDetailSubBagianView data = ((FrameworkElement)sender).DataContext as dataDetailSubBagianView;
            this.queryDelete = querySubBagian.getQueryDeleteSibBagian(data.KODE_SUBBAGIAN);
            this.actionLog = data.KODE_SUBBAGIAN;
            dialogContent.Content = new alertDelete(hapus);
            dialogHost.IsOpen = true;
        }
        void hapus()
        {
            string message = con.crudDatabase(queryDelete, Message.MSG_DELETE_SUCCES, Message.MSG_DELETE_FAILED);
            if (message == Message.MSG_DELETE_SUCCES)
            {
                con.createLog("1273", username, actionLog);
            }
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
            reload();
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            page = page + 1;
            generateDatadgSubBagian(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            float tem = AllDataGrid / Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString());
            if (AllDataGrid % Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()) == 0)
            {
                tem = tem - 1;
            }

            generateDatadgSubBagian(Convert.ToInt32(tem), Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = Convert.ToInt32(tem);
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (page != 0)
            {
                page = page - 1;
                generateDatadgSubBagian(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            }

        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgSubBagian(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = 0;
        }

        private void CmbJumData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                generateDatadgSubBagian(page, Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
            generateDatadgSubBagian(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
                string queryJson = queryBiro.queryComboBiroFilter(kodeDeputi);
                this.namaBiro = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryJson, true, combo, isSqlServer, false));
            }

        }
        void generateComboBoxBagian(string kodeBiro)
        {
            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbKodebagian);
            if (kodeBiro != "")
            {
                
                this.namaBagian = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryBagian.comboBagianFilter(kodeBiro), true, combo, isSqlServer, false));
            }
        }

        private void BtnTampilkan_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgSubBagian(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Name as string;
            if (text != null)
            {
                generateDatadgSubBagian(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), text);

            }
        }

        private void CmbKodeBiro_DropDownClosed(object sender, EventArgs e)
        {
            cmbKodebagian.Items.Clear();
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                generateComboBoxBagian(namaBiro.Find(x => x.content == text).name);
            }

        }

        private void CmbKodeDeputi_DropDownClosed(object sender, EventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;

            if (text != null)
            {
                string kodeDeputi = namaDeputi.Find(x => x.content == text).name;
                cmbKodeBiro.Items.Clear();
                cmbKodebagian.Items.Clear();
                generateComboBoxBiro(kodeDeputi);
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
                frameContent.Content = new subBagian(isSqlServer, breadcumb, dialogHost, frameContent, LoadingContent, dialogContent, username, gradeID, uriTheme);

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