﻿using MaterialDesignThemes.Wpf;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using rtwin.dataQuery;
using rtwin.lib;
using rtwin.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for monthlyReport.xaml
    /// </summary>
    public partial class monthlyReport : UserControl
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
        //List<statusForm> filterlist = null;
        public monthlyReport(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, Action reload, string filterdata)
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
            bredcumb.Text = "Laporan / Laporan Bulanan";
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //int p = filterlist.Count;
            //data_report mrd = new data_report();

            try
            {

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "q_AbsenHarianDetil";
                //reportDataSource.Value = mrd.dataMonthlyReport(filterdata);
                //reportViewerMonthly.LocalReport.ReportPath = @"~/reports/monthlyReport.rdlc";
                reportViewerMonthly.LocalReport.ReportEmbeddedResource = "rtwin.reports.monthlyReports.rdlc";
                reportViewerMonthly.LocalReport.DataSources.Clear();
                reportViewerMonthly.LocalReport.DataSources.Add(reportDataSource);
                reportViewerMonthly.RefreshReport();
            }
            catch (ReportViewerException x)
            {
                MessageBox.Show(x.Message);
            }

        }
        private void ReportViewerMonthly_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {

        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            reload();
        }
    }
}