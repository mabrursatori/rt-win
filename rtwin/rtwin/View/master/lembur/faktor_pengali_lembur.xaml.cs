using MaterialDesignThemes.Wpf;
using rtwin.dataQuery;
using rtwin.lib;
using rtwin.Model;
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
using Newtonsoft.Json;
using System.ComponentModel;
using System.Threading;
using rtwin.View.customDialog;

namespace rtwin.View.master.lembur
{
    /// <summary>
    /// Interaction logic for faktor_pengali_lembur.xaml
    /// </summary>
    /// Author Achmad Januar Sidiq S.T
    
    public partial class faktor_pengali_lembur : UserControl
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
        public faktor_pengali_lembur(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, string gradeID)
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
            generateColumnFaktorPengali();
            generateDataGridFaktorPengali();
            if (gradeID != "1")
            {
                edit_header.Visibility = Visibility.Hidden;
            }
        }
        void generateColumnFaktorPengali()
        {
            dgPengaliLibur.Columns.Add(new DataGridTextColumn { Header = "Kode", Binding = new Binding("KODE_LEMBUR"), DisplayIndex = 0 });
            dgPengaliLibur.Columns.Add(new DataGridTextColumn { Header = "Hari Lembur", Binding = new Binding("HARI_LEMBUR"), DisplayIndex = 1 });
            dgPengaliLibur.Columns.Add(new DataGridTextColumn { Header = "Faktor", Binding = new Binding("FAKTOR"), DisplayIndex = 2 });
        }
        void generateDataGridFaktorPengali()
        {
            List<string> dataJum = kon.getDataFromDatabase(queryPaarameterLembur.getQueryCountParameterLembur);

            string json = gj.generateDataGridJson(queryPaarameterLembur.getQueryParameterLembur(), dataJum[0]);

            var dataJson = JsonConvert.DeserializeObject<dataFaktorPengali>(json);
            dgPengaliLibur.Items.Clear();
            for(int i = 0; i < dataJson.rows.Count; i++)
            {
                dgPengaliLibur.Items.Add(new dataDetailFaktorPengali { KODE_LEMBUR = dataJson.rows[i].KODE_LEMBUR, HARI_LEMBUR = dataJson.rows[i].HARI_LEMBUR, FAKTOR = dataJson.rows[i].FAKTOR });
            }
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
                dataDetailFaktorPengali data = ((FrameworkElement)sender).DataContext as dataDetailFaktorPengali;
                frameContent.Content = new FormFaktorPengali(isSqlServer, false, reload, showDialog, data.KODE_LEMBUR, username);

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
                frameContent.Content = new faktor_pengali_lembur(isSqlServer,bredcumb,dialogHost,frameContent,LoadingContent,dialogContent,username, gradeID);

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
