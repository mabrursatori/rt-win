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
using MaterialDesignThemes.Wpf;
using rtwin.lib;
using rtwin.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Threading;
using rtwin.View.customDialog;

namespace rtwin.View.master.timecard
{
    /// <summary>
    /// Interaction logic for timecard_detail.xaml
    /// </summary>
    public partial class timecard_detail : UserControl
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
        List<comboBoxTemplate> dataSatker;
        TextBlock breadcumb;
        string queryDelete = "";
        string username;
        string actionLog = "";
        string gradeID, uriTheme;
        public timecard_detail(bool isSqlServer,TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent,string username, string gradeID, string uriTheme)
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
                dgTimeCardDetail.Height = 300;
            }
            else if (HeightScress > 600 && HeightScress < 700)
            {
                dgTimeCardDetail.Height = 380;
            }
            else if (HeightScress > 700 && HeightScress < 800)
            {
                dgTimeCardDetail.Height = 420;
            }
            con = new koneksi(isSqlServer);
            js = new generateJson(isSqlServer);
            generateComboBoxSortItem();
            generateComboBoxSearch();
            generateColumdgTimeCardDetail(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()));
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

            cmbSort.Items.Add(new ComboBoxItem { Content = "Kode Range", Name = "KODE_RANGE", IsSelected = true });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Nama Departemen", Name = "KODE_DEPARTEMEN" });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Detail", Name = "KET_RANGE" });
        }
        private void generateColumdgTimeCardDetail(int page, int jumData)
        {

            dgTimeCardDetail.Columns.Add(new DataGridTextColumn { Header = "Kode Range", Binding = new Binding("KODE_RANGE"), DisplayIndex = 0 });
            dgTimeCardDetail.Columns.Add(new DataGridTextColumn { Header = "Nama Departemen", Binding = new Binding("NAMA_DEPARTEMEN"), DisplayIndex = 1 });
            dgTimeCardDetail.Columns.Add(new DataGridTextColumn { Header = "Detail", Binding = new Binding("KET_RANGE"), DisplayIndex = 2 });
            
            generateDatadgTimeCardDetail(page, jumData, (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }
        private void generateDatadgTimeCardDetail(int page, int jumData, string orderBy)
        {

            int pageTemp = (page * jumData) + 1;
            int rangePage = (page + 1) * jumData;
            int halaman = page + 1;
            
            string queryTemp = "SELECT ROW_NUMBER() OVER(ORDER BY " + orderBy + " " + AriLib.orderBy(asc) + ") AS ROWID,  KODE_RANGE, KODE_DEPARTEMEN, KET_RANGE, CASE WHEN KODE_DEPARTEMEN = '---' THEN 'GLOBAL' ELSE NAMA_DEPARTEMEN END AS NAMA_DEPARTEMEN FROM q_RangeDetail ";
            string queryCountTemp = "select count(KODE_RANGE) from q_RangeDetail";

            string kodeDepartemen = "";
            string kodeRange = "";
            if (cmbSatker.SelectedIndex > 0 )
            {
                kodeDepartemen = dataSatker[cmbSatker.SelectedIndex].name.ToString();
            }
            if (cmbKodeRange.SelectedIndex > 0)
            {
                kodeRange = (cmbKodeRange.SelectedItem as ComboBoxItem).Content.ToString();
            }
            string query = filterQuery(queryTemp, kodeRange, kodeDepartemen);
            string queryCount = filterQuery(queryCountTemp, kodeRange, kodeDepartemen);
            List<string> jumlah = con.getDataFromDatabase(queryCount);
            // MessageBox.Show(jumlah[0]);
            if (Int32.Parse(jumlah[0]) > 0)
            {
                string queryPaging = AriLib.createPaging(query, pageTemp, rangePage, jumData,isSqlServer);

                json = js.generateDataGridJson(queryPaging, jumlah[0]);

                var data = JsonConvert.DeserializeObject<q_RangeDetail>(json);
                if (data.rows.Count > 0)
                {
                    dgTimeCardDetail.Items.Clear();
                    for (int i = 0; i < data.rows.Count; i++)
                    {
                        // MessageBox.Show(data.rows[i].KODE_RANGE.ToString());
                        dgTimeCardDetail.Items.Add(new dataQ_rangeDetail { KODE_RANGE = data.rows[i].KODE_RANGE, NAMA_DEPARTEMEN = data.rows[i].NAMA_DEPARTEMEN, KET_RANGE = data.rows[i].KET_RANGE });

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
                dgTimeCardDetail.Items.Clear();
                AllDataGrid = 0;
                dari.Text = "0";
                sampai.Text = "0";
                total.Text = "0";
                cekbntPage(Convert.ToInt32(total.Text), jumData, halaman);
            }
            

        }
        private string filterQuery(string query,string kodeRange,string kodeDepartemen)
        {
            if(kodeRange != "" )
            {
                if (query.Contains("Where"))
                {
                    query += " AND KODE_RANGE='" + kodeRange + "'";
                }
                else {
                    query += " Where KODE_RANGE='" + kodeRange + "'";
                }
                
            }
            if(kodeDepartemen != "" )
            {
                if (query.Contains("Where"))
                {
                    query += " AND KODE_DEPARTEMEN ='" + kodeDepartemen + "'";
                }
                else
                {
                    query += " Where KODE_DEPARTEMEN ='" + kodeDepartemen + "'";
                }
                
            }
            return query;
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
                frameContent.Content = new FormTimeCardDetail(isSqlServer, true,reload, showDialog,data,username);

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
                dataQ_rangeDetail data = ((FrameworkElement)sender).DataContext as dataQ_rangeDetail;
                frameContent.Content = new FormTimeCardDetail(isSqlServer, false, reload, showDialog, data.KODE_RANGE,username);

            };
            worker.RunWorkerAsync();
        }

        private void Hapus_Click(object sender, RoutedEventArgs e)
        {
            dataQ_rangeDetail data = ((FrameworkElement)sender).DataContext as dataQ_rangeDetail;
            this.queryDelete = "DELETE FROM taRangeDetail Where KODE_RANGE='" + data.KODE_RANGE + "'";
            this.actionLog = data.KODE_RANGE + "," + data.KODE_DEPARTEMEN;
            dialogContent.Content = new alertDelete(hapus);
            dialogHost.IsOpen = true;
        }
        void hapus()
        {
            string message = con.crudDatabase(queryDelete, "Data Berhasil Dihapus", "Data gagal Dihapus");
            if(message== "Data Berhasil Dihapus")
            {
                con.createLog("1153", username, actionLog);
            }
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
            reload();
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            page = page + 1;
            generateDatadgTimeCardDetail(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            float tem = AllDataGrid / Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString());
            if (AllDataGrid % Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()) == 0)
            {
                tem = tem - 1;
            }

            generateDatadgTimeCardDetail(Convert.ToInt32(tem), Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = Convert.ToInt32(tem);
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (page != 0)
            {
                page = page - 1;
                generateDatadgTimeCardDetail(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            }

        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgTimeCardDetail(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = 0;
        }

        private void CmbJumData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                generateDatadgTimeCardDetail(page, Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
            generateDatadgTimeCardDetail(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
                cmbKodeRange.SelectedValue = "";
                cmbSatker.SelectedValue = "";
            }
        }
        void generateComboBoxSearch()
        {
            List<string> dataKodeRange = con.getDataFromDatabase(query.queryKodeRange);
            cmbKodeRange.Items.Add(new ComboBoxItem { Content = "" });
            for(int i = 0; i < dataKodeRange.Count; i++)
            {
                cmbKodeRange.Items.Add(new ComboBoxItem { Content = dataKodeRange[i] });
            }
            string json = js.generateDataJson(query.queryCabangForDropdown);
            this.dataSatker = JsonConvert.DeserializeObject<List<comboBoxTemplate>>(json);
            if (dataSatker.Count > 0)
            {
                for (int i = 0; i < dataSatker.Count; i++)
                {
                    
                    cmbSatker.Items.Add(new ComboBoxItem { Content = dataSatker[i].content});
                }
            }

        }

        private void BtnTampilkan_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgTimeCardDetail(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Name as string;
            if (text != null)
            {
                //MessageBox.Show(text);
                generateDatadgTimeCardDetail(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), text);
                
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
                frameContent.Content = new timecard_detail(isSqlServer, breadcumb, dialogHost, frameContent, LoadingContent, dialogContent,username, gradeID, uriTheme);

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
