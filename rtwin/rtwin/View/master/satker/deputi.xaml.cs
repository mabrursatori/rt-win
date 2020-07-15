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
    /// Interaction logic for deputi.xaml
    /// </summary>
    public partial class deputi : UserControl
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
        bool dialogSearch = true;
        TextBlock breadcumb;
        string queryDelete = "";
        string username;
        string actionLog = "";
        string gradeID, uriTheme;
        public deputi(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username,string gradeID, string uriTheme)
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
            this.gradeID = gradeID;
            bredcumb.Text = "Master / Tabel / Waktu Kerja Detail";
            if (HeightScress < 600)
            {
                dgDeputi.Height = 300;
            }
            else if (HeightScress > 600 && HeightScress < 700)
            {
                dgDeputi.Height = 380;
            }
            else if (HeightScress > 700 && HeightScress < 800)
            {
                dgDeputi.Height = 420;
            }
            this.con = new koneksi(isSqlServer);
            this.js = new generateJson(isSqlServer);
            generateComboBoxSortItem();
            generateColumdgDeputi(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()));
            //showDialog(gradeID);
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

            cmbSort.Items.Add(new ComboBoxItem { Content = "Kode", Name = "KODE_DEPUTI", IsSelected = true });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Nama Deputi", Name = "NAMA_DEPUTI" });
            
        }
        private void generateColumdgDeputi(int page, int jumData)
        {

            dgDeputi.Columns.Add(new DataGridTextColumn { Header = "Kode", Binding = new Binding("KODE_DEPUTI"), DisplayIndex = 0 });
            dgDeputi.Columns.Add(new DataGridTextColumn { Header = "Nama Deputi", Binding = new Binding("NAMA_DEPUTI"), DisplayIndex = 1 });

            generateDatadgDeputi(page, jumData, (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }
        private void generateDatadgDeputi(int page, int jumData, string orderBy)
        {

            int pageTemp = (page * jumData) + 1;
            int rangePage = (page + 1) * jumData;
            int halaman = page + 1;

            string queryTemp = queryDeputi.getQueryDataGridDeputi(orderBy, AriLib.orderBy(asc));
            string queryCountTemp = queryDeputi.getQueryCountDeputi;

            List<string> jumlah = con.getDataFromDatabase(queryCountTemp);
            // MessageBox.Show(jumlah[0]);
            if (Int32.Parse(jumlah[0]) > 0)
            {
                string queryPaging = AriLib.createPaging(queryTemp, pageTemp, rangePage, jumData, isSqlServer);

                json = js.generateDataGridJson(queryPaging, jumlah[0]);

                var data = JsonConvert.DeserializeObject<dataDeputi>(json);
                if (data.rows.Count > 0)
                {
                    dgDeputi.Items.Clear();
                    for (int i = 0; i < data.rows.Count; i++)
                    {
                        // MessageBox.Show(data.rows[i].KODE_RANGE.ToString());
                        dgDeputi.Items.Add(new dataDetailDeputiView { KODE_CABANG=data.rows[i].KODE_CABANG,NAMA_DEPUTI=data.rows[i].NAMA_DEPUTI,KODE_DEPUTI=data.rows[i].KODE_DEPUTI,KODE_INSTANSI=data.rows[i].KODE_INSTANSI,KODE_UNIT=data.rows[i].KODE_UNIT });

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
                dgDeputi.Items.Clear();
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
                frameContent.Content = new FormSatker(isSqlServer, true, reload, showDialog, data, username);

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
                dataDetailDeputiView data = ((FrameworkElement)sender).DataContext as dataDetailDeputiView;
                frameContent.Content = new FormSatker(isSqlServer, false, reload, showDialog, data.KODE_DEPUTI, username);

            };
            worker.RunWorkerAsync();
        }

        private void Hapus_Click(object sender, RoutedEventArgs e)
        {
            dataDetailDeputiView data = ((FrameworkElement)sender).DataContext as dataDetailDeputiView;
            this.queryDelete = queryDeputi.getQueryDeleteDeputi(data.KODE_DEPUTI);
            this.actionLog = data.KODE_DEPUTI;
            dialogContent.Content = new alertDelete(hapus);
            dialogHost.IsOpen = true;
        }
        void hapus()
        {
            string message = con.crudDatabase(queryDelete, Message.MSG_DELETE_SUCCES, Message.MSG_DELETE_FAILED);
            if (message == Message.MSG_DELETE_SUCCES)
            {
                con.createLog("1243", username, actionLog);
            }
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
            reload();
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            page = page + 1;
            generateDatadgDeputi(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            float tem = AllDataGrid / Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString());
            if (AllDataGrid % Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()) == 0)
            {
                tem = tem - 1;
            }

            generateDatadgDeputi(Convert.ToInt32(tem), Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = Convert.ToInt32(tem);
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (page != 0)
            {
                page = page - 1;
                generateDatadgDeputi(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            }

        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgDeputi(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = 0;
        }

        private void CmbJumData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                generateDatadgDeputi(page, Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
            generateDatadgDeputi(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Name as string;
            if (text != null)
            {
                //MessageBox.Show(text);
                generateDatadgDeputi(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), text);

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
                frameContent.Content = new deputi(isSqlServer, breadcumb, dialogHost, frameContent, LoadingContent, dialogContent, username, gradeID, uriTheme);

            };
            worker.RunWorkerAsync();
        }
        void showDialog(string message)
        {
            AriLib.showDialog(message, dialogContent, dialogHost);
        }
    }
}
