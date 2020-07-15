using MaterialDesignThemes.Wpf;
using rtwin.lib;
using rtwin.View.customDialog;
using rtwin.dataQuery;
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
using Newtonsoft.Json;
using rtwin.Model;

namespace rtwin.View.master.ijin
{
    /// <summary>
    /// Interaction logic for leave.xaml
    /// </summary>
    public partial class leave : UserControl
    {
        bool isSqlServer;
        TextBlock bredcumb;
        DialogHost dialogHost;
        Frame frameContent, dialogContent;
        Image LoadingContent;
        bool asc = true;
        int page = 0;
        int AllDataGrid = 0;
        string json = String.Empty, queryDelete = String.Empty, actionLog = String.Empty, username = String.Empty;
        koneksi con;
        generateJson js;
        string gradeID, uriTheme;
        public leave(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, string gradeID, string uriTheme)
        {
            int HeightScress = Convert.ToInt32(System.Windows.SystemParameters.WorkArea.Height);
            this.isSqlServer = isSqlServer;
            this.bredcumb = bredcumb;
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.dialogContent = dialogContent;
            this.username = username;
            this.con = new koneksi(isSqlServer);
            this.js = new generateJson(isSqlServer);
            bredcumb.Text = "Master / Tabel / Status Absen";
            this.gradeID = gradeID;
            InitializeComponent();
            if (HeightScress < 600)
            {
                dgLeave.Height = 290;
            }
            else if (HeightScress > 600 && HeightScress < 700)
            {
                dgLeave.Height = 370;
            }
            else if (HeightScress > 700 && HeightScress < 800)
            {
                dgLeave.Height = 410;
            }
            else if (HeightScress > 800 && HeightScress < 900)
            {
                dgLeave.Height = 510;
            }
            generateComboBoxSortItem();
            generateColumdgLeave(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()));
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

            cmbSort.Items.Add(new ComboBoxItem { Content = "Kode Ijin", Name = "KODE_IJIN", IsSelected = true });
            cmbSort.Items.Add(new ComboBoxItem { Content = "Ket Ijin", Name = "KET_IJIN" });
        }
        private void generateColumdgLeave(int page, int jumData)
        {

            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Kode", Binding = new Binding("KODE_IJIN"), DisplayIndex = 0 });
            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Keterangan \n Ijin", Binding = new Binding("KET_IJIN"), DisplayIndex = 1 });
            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Perhitungan", Binding = new Binding("NAMA_PERHITUNGAN"), DisplayIndex = 2 });
            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Ketentuan", Binding = new Binding("NAMA_KETENTUAN"), DisplayIndex = 3 });
            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Jatah", Binding = new Binding("JATAH_IJIN"), DisplayIndex = 4 });
            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Ket \n Kredit", Binding = new Binding("NAMA_KREDIT"), DisplayIndex = 5 });
            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Berlaku \n (Bln)", Binding = new Binding("BERLAKU"), DisplayIndex = 6 });
            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Ket \n Dasar", Binding = new Binding("NAMA_DASAR"), DisplayIndex = 7 });
            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Berlaku \n Di Awal", Binding = new Binding("NAMA_PROSES_DI_AWAL"), DisplayIndex = 8 });
            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Keterangan", Binding = new Binding("NAMA_KODE_TIDAK_HADIR"), DisplayIndex = 9 });
            dgLeave.Columns.Add(new DataGridCheckBoxColumn { Header = "Perhitungan \n Hari \n Kerja", Binding = new Binding("HITUNG_HARI_KERJA"), DisplayIndex = 10 });
            dgLeave.Columns.Add(new DataGridTextColumn { Header = "Potongan \n TKK", Binding = new Binding("POTONGAN_TKK"), DisplayIndex = 11 });
            generateDatadgLeave(page, jumData, (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());

        }
        private void generateDatadgLeave(int page, int jumData, string orderBy)
        {

            int pageTemp = (page * jumData) + 1;
            int rangePage = (page + 1) * jumData;
            int halaman = page + 1;

            string queryTemp = queryIjin.getQueryDataIjin(orderBy, AriLib.orderBy(asc));
            string queryCountTemp = queryIjin.getQueryCountDataIjin;
            List<string> jumlah = con.getDataFromDatabase(queryCountTemp);
            if (Int32.Parse(jumlah[0]) > 0)
            {
                string queryPaging = AriLib.createPaging(queryTemp, pageTemp, rangePage, jumData, isSqlServer);

                json = js.generateDataGridJson(queryPaging, jumlah[0]);

                var data = JsonConvert.DeserializeObject<dataIjin>(json);
                if (data.rows.Count > 0)
                {
                    dgLeave.Items.Clear();
                    for (int i = 0; i < data.rows.Count; i++)
                    {
                        dgLeave.Items.Add(new dataDetailIjin { KODE_IJIN=data.rows[i].KODE_IJIN,KET_IJIN= data.rows[i].KET_IJIN,PERHITUNGAN= data.rows[i].PERHITUNGAN,KETENTUAN= data.rows[i].KETENTUAN,JATAH_IJIN= data.rows[i].JATAH_IJIN,KREDIT= data.rows[i].KREDIT,BERLAKU= data.rows[i].BERLAKU,DASAR= data.rows[i].DASAR,PROSES_DI_AWAL= data.rows[i].PROSES_DI_AWAL,KODE_TIDAK_HADIR= data.rows[i].KODE_TIDAK_HADIR,HITUNG_HARI_KERJA= data.rows[i].HITUNG_HARI_KERJA,HITUNG_JAM_KERJA= data.rows[i].HITUNG_JAM_KERJA,POTONGAN_TKK= data.rows[i].POTONGAN_TKK,NAMA_PERHITUNGAN= data.rows[i].NAMA_PERHITUNGAN,NAMA_KETENTUAN= data.rows[i].NAMA_KETENTUAN,NAMA_KREDIT= data.rows[i].NAMA_KREDIT,NAMA_DASAR= data.rows[i].NAMA_DASAR,NAMA_PROSES_DI_AWAL= data.rows[i].NAMA_PROSES_DI_AWAL,NAMA_KODE_TIDAK_HADIR= data.rows[i].NAMA_KODE_TIDAK_HADIR });

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
                dgLeave.Items.Clear();
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
                frameContent.Content = new FormLeave(isSqlServer, true, reload, showDialog, data, username);

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
                dataDetailIjin data = ((FrameworkElement)sender).DataContext as dataDetailIjin;
                frameContent.Content = new FormLeave(isSqlServer, false, reload, showDialog, data.KODE_IJIN, username);

            };
            worker.RunWorkerAsync();
        }

        private void Hapus_Click(object sender, RoutedEventArgs e)
        {
            dataDetailIjin data = ((FrameworkElement)sender).DataContext as dataDetailIjin;
            this.queryDelete = queryIjin.getQueryDeleteDataIjin(data.KODE_IJIN);
            this.actionLog = data.KODE_IJIN;
            dialogContent.Content = new alertDelete(hapus);
            dialogHost.IsOpen = true;
        }
        void hapus()
        {
            string message = con.crudDatabase(queryDelete, Message.MSG_DELETE_SUCCES, Message.MSG_DELETE_FAILED);
            if (message == Message.MSG_DELETE_SUCCES)
            {
                con.createLog(username, "1143", actionLog);
            }
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
            reload();
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            page = page + 1;
            generateDatadgLeave(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Name as string;
            if (text != null)
            {
                //MessageBox.Show(text);
                generateDatadgLeave(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), text);

            }
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            float tem = AllDataGrid / Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString());

            if (AllDataGrid % Convert.ToInt32((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()) == 0)
            {
                tem = tem - 1;
            }

            generateDatadgLeave(Convert.ToInt32(tem), Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = Convert.ToInt32(tem);
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (page != 0)
            {
                page = page - 1;
                generateDatadgLeave(page, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            }

        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            generateDatadgLeave(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
            page = 0;
        }

        private void CmbJumData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text != null)
            {
                generateDatadgLeave(page, Int32.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
            generateDatadgLeave(0, Int32.Parse((cmbJumData.SelectedItem as ComboBoxItem).Content.ToString()), (cmbSort.SelectedItem as ComboBoxItem).Name.ToString());
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
                frameContent.Content = new leave(isSqlServer, bredcumb, dialogHost, frameContent, LoadingContent, dialogContent, username, gradeID, uriTheme);

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
