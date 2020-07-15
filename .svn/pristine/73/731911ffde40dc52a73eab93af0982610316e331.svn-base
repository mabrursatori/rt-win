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
using rtwin.Model;
using Newtonsoft.Json;
using MaterialDesignThemes.Wpf;
using rtwin.lib;
using System.Data;
using rtwin.View.customDialog;
using System.ComponentModel;
using System.Threading;

namespace rtwin.View.master.timecard
{
    /// <summary>
    /// Interaction logic for timecard.xaml
    /// </summary>
    public partial class timecard : UserControl
    {
        //wajib
        bool isSqlServer;
        generateJson js;
        koneksi con;
        int page = 0;
        int AllDataGrid = 0;
        string json = String.Empty;
        bool asc = true;
        DialogHost dialogHost;
        Frame frameContent,dialogContent;
        Image LoadingContent;
        TextBlock breadcumb;
        string queryDelete = String.Empty;
        string username;
        string kodeRangeDelete = String.Empty;
        string gradeID, uriTheme;

        public timecard(bool isSqlServer, TextBlock breadcumb, DialogHost dialogHost, Frame frameContent,Image LoadingContent,Frame dialogContent,string username, string gradeID, string uriTheme)
        {
            int HeightScress = Convert.ToInt32(System.Windows.SystemParameters.WorkArea.Height);
            InitializeComponent();
            this.breadcumb = breadcumb;
            breadcumb.Text = "Master / Tabel / Waktu Kerja";
            this.isSqlServer = isSqlServer;
            js = new generateJson(isSqlServer);
            con = new koneksi(isSqlServer);
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.dialogContent = dialogContent;
            this.username = username;
            this.gradeID = gradeID;
            generateComboBoxSortItem();
            generateColumdgTimeCard(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()));
            //MessageBox.Show(HeightScress.ToString());
            if (HeightScress < 600)
            {
                dgTimeCard.Height = 300;
            }else if(HeightScress>600 && HeightScress < 700)
            {
                dgTimeCard.Height = 380;
            }else if(HeightScress>700 && HeightScress<800){
                dgTimeCard.Height = 420;
            }
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
        private void generateColumdgTimeCard(int page, int jumData)
        {

            dgTimeCard.Columns.Add(new DataGridTextColumn { Header = "Kode Range", Binding = new Binding("KODE_RANGE"), DisplayIndex = 0 });
            dgTimeCard.Columns.Add(new DataGridTextColumn { Header = "Jam Masuk", Binding = new Binding("JAM_AWAL"), DisplayIndex = 1 });
            dgTimeCard.Columns.Add(new DataGridTextColumn { Header = "Jam Pulang", Binding = new Binding("JAM_AKHIR"), DisplayIndex = 2 });
            dgTimeCard.Columns.Add(new DataGridTextColumn { Header = "Toleransi telat", Binding = new Binding("TOL_MASUK"), DisplayIndex = 3 });
            dgTimeCard.Columns.Add(new DataGridTextColumn { Header = "Limit Awal", Binding = new Binding("LIMIT_AWAL"), DisplayIndex = 4 });
            dgTimeCard.Columns.Add(new DataGridTextColumn { Header = "Limit Akhir", Binding = new Binding("LIMIT_AKHIR"), DisplayIndex = 5 });
            dgTimeCard.Columns.Add(new DataGridTextColumn { Header = "Jam Kerja", Binding = new Binding("JAM_KERJA"), DisplayIndex = 6 });
            dgTimeCard.Columns.Add(new DataGridTextColumn { Header = "Jam Istirahat", Binding = new Binding("JAM_ISTIRAHAT"), DisplayIndex = 7 });
            dgTimeCard.Columns.Add(new DataGridTextColumn { Header = "Waktu Flexi", Binding = new Binding("WAKTU_FLEXI"), DisplayIndex = 8 });
            generateDatadgTimeCard(page, jumData, (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }
        private void generateComboBoxSortItem()
        {

            cmbSort.Items.Add(new ComboBoxItem { Content = "Kode Range", Name = "KODE_RANGE", IsSelected = true });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Jam Awal", Name = "JAM_AWAL" });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Jam Akhir", Name = "JAM_AKHIR" });
        }
        private void generateDatadgTimeCard(int page, int jumData, string orderBy)
        {

            int pageTemp = (page * jumData) + 1;
            int rangePage = (page + 1) * jumData;
            int halaman = page + 1;
            string query = "SELECT ROW_NUMBER() OVER(ORDER BY " + orderBy + " " + AriLib.orderBy(asc) + ") AS ROWID, KODE_RANGE, KODE_ABSEN, JAM_AWAL, JAM_AKHIR, TOL_MASUK, TOL_PULANG, LIMIT_AWAL,LIMIT_AKHIR, JAM_KERJA, JAM_ISTIRAHAT, WAKTU_FLEXI FROM taRange WHERE KODE_RANGE <> '00' ";
            string queryCount = "select count(KODE_RANGE) from taRange";
            List<string> jumlah = con.getDataFromDatabase(queryCount);
            if (Int32.Parse(jumlah[0]) > 0)
            {
                string queryPaging = AriLib.createPaging(query, pageTemp, rangePage, jumData,isSqlServer);

                json = js.generateDataGridJson(queryPaging, jumlah[0]);

                var data = JsonConvert.DeserializeObject<dataTimeCard>(json);
                if (data.rows.Count > 0)
                {
                    dgTimeCard.Items.Clear();
                    for (int i = 0; i < data.rows.Count; i++)
                    {
                        // MessageBox.Show(data.rows[i].KODE_RANGE.ToString());
                        dgTimeCard.Items.Add(new dataDetailTimeCard { KODE_RANGE = data.rows[i].KODE_RANGE, JAM_AWAL = Convert.ToDateTime(data.rows[i].JAM_AWAL).ToString("HH:mm"), JAM_AKHIR = Convert.ToDateTime(data.rows[i].JAM_AKHIR).ToString("HH:mm"), TOL_MASUK = data.rows[i].TOL_MASUK, TOL_PULANG = data.rows[i].TOL_PULANG, LIMIT_AWAL = Convert.ToDateTime(data.rows[i].LIMIT_AWAL).ToString("HH:mm"), LIMIT_AKHIR = Convert.ToDateTime(data.rows[i].LIMIT_AKHIR).ToString("HH:mm"), JAM_KERJA = Convert.ToDateTime(data.rows[i].JAM_KERJA).ToString("HH:mm"), JAM_ISTIRAHAT = Convert.ToDateTime(data.rows[i].JAM_ISTIRAHAT).ToString("HH:mm"), WAKTU_FLEXI = data.rows[i].WAKTU_FLEXI });

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
                dgTimeCard.Items.Clear();
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
                firstPage.IsEnabled = false;
                prevPage.IsEnabled = false;
                nextPage.IsEnabled = false;
                lastPage.IsEnabled = false;
            }
            
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            page = page + 1;
            generateDatadgTimeCard(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            float tem = AllDataGrid / Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString());
            if (AllDataGrid % Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()) == 0)
            {
                tem = tem - 1;
            }
            

            generateDatadgTimeCard(Convert.ToInt32(tem), Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = Convert.ToInt32(tem);

        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (page != 0)
            {
                page = page - 1;
                generateDatadgTimeCard(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            }

        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgTimeCard(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = 0;
        }

        private void CmbJumData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                generateDatadgTimeCard(page, Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
            generateDatadgTimeCard(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Name as string;
            if (text != null)
            {
                //MessageBox.Show(text);
                generateDatadgTimeCard(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), text);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataDetailTimeCard data = ((FrameworkElement)sender).DataContext as dataDetailTimeCard;
                List<string> dataTem = new List<string>();
                dataTem.Add(data.KODE_RANGE);
                dataTem.Add(data.JAM_AWAL);
                dataTem.Add(data.JAM_AKHIR);
                dataTem.Add(data.TOL_MASUK);
                dataTem.Add(data.TOL_PULANG);
                dataTem.Add(data.LIMIT_AWAL);
                dataTem.Add(data.LIMIT_AKHIR);
                dataTem.Add(data.JAM_KERJA);
                dataTem.Add(data.JAM_ISTIRAHAT);
                //MessageBox.Show(data.KODE_RANGE);
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
                    frameContent.Content = new FormEditDataTimeCard(isSqlServer,reload,showDialog,dataTem,username);

                };
                worker.RunWorkerAsync();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
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
                frameContent.Content = new FormAddDataTimecard(isSqlServer,breadcumb,dialogHost,frameContent,LoadingContent,dialogContent,username, gradeID, uriTheme);
                
            };
            worker.RunWorkerAsync();
            
            //dialogHost.IsOpen = true;
        }

        private void Hapus_Click(object sender, RoutedEventArgs e)
        {
            dataDetailTimeCard data = ((FrameworkElement)sender).DataContext as dataDetailTimeCard;
            this.queryDelete= "DELETE FROM taRange Where KODE_RANGE='" + data.KODE_RANGE + "'";
            kodeRangeDelete = data.KODE_RANGE;
            dialogContent.Content= new alertDelete(hapus);
            dialogHost.IsOpen = true;
        }
        void hapus()
        {
            string message = con.crudDatabase(queryDelete, "Data Berhasil Dihapus", "Data gagal Dihapus");
            if (message == "Data Berhasil Dihapus")
            {
                con.createLog(username, "1113", kodeRangeDelete);
            }
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
            reload();
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
                frameContent.Content = new timecard(isSqlServer, breadcumb, dialogHost, frameContent, LoadingContent, dialogContent,username, gradeID, uriTheme);

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

