using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for biro.xaml
    /// </summary>
    public partial class biro : UserControl
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
        List<comboBoxTemplate> namaDeputi;
        string gradeID, uriTheme;
        public biro(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, string gradeID, string uriTheme)
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
            bredcumb.Text = "Master / Unit Kerja / Satuan Kerja / Biro";
            if (HeightScress < 600)
            {
                dgBiro.Height = 300;
            }
            else if (HeightScress > 600 && HeightScress < 700)
            {
                dgBiro.Height = 380;
            }
            else if (HeightScress > 700 && HeightScress < 800)
            {
                dgBiro.Height = 420;
            }
            con = new koneksi(isSqlServer);
            js = new generateJson(isSqlServer);
            generateComboBoxSearch();
            generateComboBoxSortItem();
            generateColumdgBiro(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()));
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

            cmbSort.Items.Add(new ComboBoxItem { Content = "Kode ", Name = "KODE_BIRO", IsSelected = true });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Nama Biro", Name = "NAMA_BIRO" });
        }
        private void generateColumdgBiro(int page, int jumData)
        {

            dgBiro.Columns.Add(new DataGridTextColumn { Header = "Kode Biro", Binding = new Binding("KODE_BIRO"), DisplayIndex = 0 });
            dgBiro.Columns.Add(new DataGridTextColumn { Header = "Nama Biro", Binding = new Binding("NAMA_BIRO"), DisplayIndex = 1 });
            dgBiro.Columns.Add(new DataGridTextColumn { Header = "Nama Deputi", Binding = new Binding("NAMA_DEPUTI"), DisplayIndex = 2 });

            generateDatadgBiro(page, jumData, (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }
        private void generateDatadgBiro(int page, int jumData, string orderBy)
        {

            int pageTemp = (page * jumData) + 1;
            int rangePage = (page + 1) * jumData;
            int halaman = page + 1;
            string kodeDeputi = "";
            if (cmbKodeDeputi.SelectedIndex > 0)
            {
                kodeDeputi = namaDeputi.Find(x => x.content == (cmbKodeDeputi.SelectedItem as ComboBoxItem).Content.ToString()).name;
            }
            string filter = queryBiro.filter(kodeDeputi);
            string queryTemp = queryBiro.getQueryBiroView(orderBy, AriLib.orderBy(asc)) + filter; ;
            string queryCountTemp = queryBiro.queryCountBiro + filter;
            dgBiro.Items.Clear();
            List<string> jumlah = con.getDataFromDatabase(queryCountTemp);
            if (Int32.Parse(jumlah[0]) > 0)
            {
                string queryPaging = AriLib.createPaging(queryTemp, pageTemp, rangePage, jumData, isSqlServer);

                json = js.generateDataGridJson(queryPaging, jumlah[0]);

                var data = JsonConvert.DeserializeObject<dataBiro>(json);
                if (data.rows.Count > 0)
                {
                    
                    for (int i = 0; i < data.rows.Count; i++)
                    {
                        if (data.rows[i].KODE_BIRO != "0000")
                        {
                            dgBiro.Items.Add(new dataDetailBiroView { KODE_BIRO = data.rows[i].KODE_BIRO, NAMA_BIRO = data.rows[i].NAMA_BIRO, KODE_DEPUTI = data.rows[i].KODE_DEPUTI, NAMA_DEPUTI = data.rows[i].NAMA_DEPUTI, KODE_UNIT = data.rows[i].KODE_UNIT, NAMA_UNIT = data.rows[i].NAMA_UNIT, KODE_CABANG = data.rows[i].KODE_CABANG });
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
                dgBiro.Items.Clear();
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
                frameContent.Content = new FormBiro(isSqlServer, true, reload, showDialog, data, username);

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
                dataDetailBiroView data = ((FrameworkElement)sender).DataContext as dataDetailBiroView;
                frameContent.Content = new FormBiro(isSqlServer, false, reload, showDialog, data.KODE_BIRO, username);

            };
            worker.RunWorkerAsync();
        }

        private void Hapus_Click(object sender, RoutedEventArgs e)
        {
            dataDetailBiroView data = ((FrameworkElement)sender).DataContext as dataDetailBiroView;
            this.queryDelete = queryBiro.getQueryDeleteBiro(data.KODE_BIRO);
            this.actionLog = data.KODE_BIRO;
            dialogContent.Content = new alertDelete(hapus);
            dialogHost.IsOpen = true;
        }
        void hapus()
        {
            string message = con.crudDatabase(queryDelete, Message.MSG_DELETE_SUCCES, Message.MSG_DELETE_FAILED);
            if (message == Message.MSG_DELETE_SUCCES)
            {
                con.createLog("1253", username, actionLog);
            }
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
            reload();
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            page = page + 1;
            generateDatadgBiro(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            float tem = AllDataGrid / Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString());
            if (AllDataGrid % Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()) == 0)
            {
                tem = tem - 1;
            }

            generateDatadgBiro(Convert.ToInt32(tem), Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = Convert.ToInt32(tem);
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (page != 0)
            {
                page = page - 1;
                generateDatadgBiro(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            }

        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgBiro(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = 0;
        }

        private void CmbJumData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                generateDatadgBiro(page, Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
            generateDatadgBiro(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
        void generateComboBoxSearch()
        {

            List<ComboBox> combo = new List<ComboBox>();
            combo.Add(cmbKodeDeputi);
            this.namaDeputi = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryDeputi.getQueryComboDeputi,true, combo, isSqlServer, false));
        }

        private void BtnTampilkan_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgBiro(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Name as string;
            if (text != null)
            {
                //MessageBox.Show(text);
                generateDatadgBiro(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), text);

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
                frameContent.Content = new biro(isSqlServer, breadcumb, dialogHost, frameContent, LoadingContent, dialogContent, username, gradeID, uriTheme);

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
