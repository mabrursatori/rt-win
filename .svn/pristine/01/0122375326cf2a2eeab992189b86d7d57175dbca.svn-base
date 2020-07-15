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

namespace rtwin.View.master.lembur
{
    /// <summary>
    /// Interaction logic for lemburOtomatis.xaml
    /// </summary>
    public partial class lemburOtomatis : UserControl
    {
        bool isSqlServer;
        TextBlock bredcumb;
        DialogHost dialogHost;
        Frame frameContent, dialogContent;
        Image LoadingContent;
        koneksi kon;
        generateJson gj;
        string username;
        string gradeID;
        public lemburOtomatis(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, string gradeID)
        {
            this.isSqlServer = isSqlServer;
            this.bredcumb = bredcumb;
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.dialogContent = dialogContent;
            this.username = username;
            this.gradeID = gradeID;
            kon = new koneksi(isSqlServer);
            gj = new generateJson(isSqlServer);
            InitializeComponent();
            generateColumnLemburOtomatis();
            generateDataGridLemburOtomatis();
            if (gradeID != "1")
            {
                edit_header.Visibility = Visibility.Hidden;
            }
        }
        void generateColumnLemburOtomatis()
        {
            dgLemburOtomatis.Columns.Add(new DataGridTextColumn { Header = "Kode", Binding = new Binding("KODE_CABANG"), DisplayIndex = 0 });
            dgLemburOtomatis.Columns.Add(new DataGridTextColumn { Header = "Nama Cabang", Binding = new Binding("NAMA_CABANG"), DisplayIndex = 1 });
            dgLemburOtomatis.Columns.Add(new DataGridCheckBoxColumn { Header = "Lembur Otomatis", Binding = new Binding("LEMBUR_OTOMATIS"), DisplayIndex = 2 });
            dgLemburOtomatis.Columns.Add(new DataGridCheckBoxColumn { Header = "Lembur Libur", Binding = new Binding("LEMBUR_LIBUR"), DisplayIndex = 3 });
            dgLemburOtomatis.Columns.Add(new DataGridTextColumn { Header = "Perhitungan Lembur", Binding = new Binding("PERHITUNGAN_LEMBUR2"), DisplayIndex = 4 });
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
                taCabang data = ((FrameworkElement)sender).DataContext as taCabang;
                frameContent.Content = new FormLemburOtomatis(isSqlServer, false, reload, showDialog, data.KODE_CABANG, username);

            };
            worker.RunWorkerAsync();
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
                frameContent.Content = new lemburOtomatis(isSqlServer, bredcumb, dialogHost, frameContent, LoadingContent, dialogContent, username, gradeID);

            };
            worker.RunWorkerAsync();
        }
        void showDialog(string message)
        {
            dialogContent.Content = new alertDialog(message);
            dialogHost.IsOpen = true;
        }


        void generateDataGridLemburOtomatis()
        {
            List<string> dataJum = kon.getDataFromDatabase(queryCabang.getQueryCabang);

            string json = gj.generateDataGridJson(queryCabang.getQueryCabang, dataJum[0]);

            var dataJson = JsonConvert.DeserializeObject<dataCabang>(json);
            dgLemburOtomatis.Items.Clear();
            for (int i = 0; i < dataJson.rows.Count; i++)
            {
                dgLemburOtomatis.Items.Add(new taCabang{KODE_CABANG=dataJson.rows[i].KODE_CABANG,NAMA_CABANG=dataJson.rows[i].NAMA_CABANG,LEMBUR_OTOMATIS=dataJson.rows[i].LEMBUR_OTOMATIS,LEMBUR_LIBUR=dataJson.rows[i].LEMBUR_LIBUR,PERHITUNGAN_LEMBUR2=dataJson.rows[i].PERHITUNGAN_LEMBUR2 });
            }
        }

    }
}
