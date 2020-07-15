using MaterialDesignThemes.Wpf;
using Microsoft.Reporting.WinForms;
using rtwin.lib;
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

namespace rtwin.View.Report
{
    /// <summary>
    /// Interaction logic for dailyReport.xaml
    /// </summary>
    public partial class dailyReport : UserControl
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
        string actionLog = "";
        bool dialogSearch;
        Action reload;
        string filterdata = "";
        public dailyReport(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, Action reload, string filterdata)
        {
            HeightScress = Convert.ToInt32(System.Windows.SystemParameters.WorkArea.Height);
            this.js = new generateJson(isSqlServer);
            this.con = new koneksi(isSqlServer);
            this.isSqlServer = isSqlServer;
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.breadcumb = bredcumb;
            this.dialogContent = dialogContent;
            this.username = username;
            this.reload = reload;
            this.filterdata = filterdata;
            bredcumb.Text = "Laporan / Laporan Harian";
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //int p = filterlist.Count;
            data_report mrd = new data_report();

            try
            {

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dataDailyReport";
                reportDataSource.Value = mrd.dataDailyReport(filterdata);
                reportViewerDaily.LocalReport.ReportEmbeddedResource = "rtwin.reports.dailyReports.rdlc";
                reportViewerDaily.LocalReport.DataSources.Clear();
                reportViewerDaily.LocalReport.DataSources.Add(reportDataSource);
                reportViewerDaily.RefreshReport();
            }
            catch (ReportViewerException x)
            {
                MessageBox.Show(x.Message);
            }

        }
        private void ReportViewerDaily_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {

        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}
