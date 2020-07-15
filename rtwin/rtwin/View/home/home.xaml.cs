﻿using System;
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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using rtwin.Model;
using Newtonsoft;
using Newtonsoft.Json;
using rtwin.lib;

namespace rtwin.View.home
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : UserControl
    {
        private generateJson gj;
        public string uriTheme;
        public home(bool sqlServer,string nip,string gradeID,string username,TextBlock breadcumb, string uriTheme)
        {

            int widhtScreen = Convert.ToInt32(System.Windows.SystemParameters.WorkArea.Width);
            int widhtSidebar = 300;
            float panelWidth = (widhtScreen - widhtSidebar) / 3;
            InitializeComponent();
            breadcumb.Text = "Dashboard";
            this.gj = new generateJson(sqlServer);
            cardIjinHari.Width = panelWidth-30;
            cardIjinJam.Width = panelWidth-30;
            cardLembur.Width = panelWidth-30;
            getDataNotifikasiIjin(username, gradeID);
            getDataGrafik(nip);

            this.uriTheme = uriTheme;
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri(uriTheme, UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);
        }
        private void getDataNotifikasiIjin(string username,string gridID) {
            string query = "exec proc_get_notifikasi_absen '" + username + "','" + gridID + "'";
            string json = gj.generateDataJson(query);
            var dataIjin = JsonConvert.DeserializeObject<List<dataNotifikasiIjin>>(json);
            if (dataIjin.Count > 0)
            {
                ijinHari.Text = dataIjin[0].tot_ijinharian;
                ijinPerjam.Text = dataIjin[0].tot_ijinperjam;
                lembur.Text = dataIjin[0].tot_lembur;
            }
            else
            {
                ijinHari.Text = "0";
                ijinPerjam.Text = "0";
                lembur.Text = "0";
            }
        }
        private void getDataKehadiran(string nip)
        {
            string query = "exec proc_get_notifikasi_kehadiran_individu '" + nip + "'";
            string json = gj.generateDataJson(query);
            var data = JsonConvert.DeserializeObject<List<dataNotifikasiKehadiranIndividu>>(json);
            int cepat = 0;
            int telatTemp = 0;
            if (data.Count > 0)
            {
                hadir.Values = new ChartValues<ObservableValue> { new ObservableValue(Int32.Parse(data[0].H)) };
                bak.Values= new ChartValues<ObservableValue> { new ObservableValue(Int32.Parse(data[0].BAK)) };
                cbs.Values= new ChartValues<ObservableValue> { new ObservableValue(Int32.Parse(data[0].CBS)) };
                cp.Values= new ChartValues<ObservableValue> { new ObservableValue(Int32.Parse(data[0].CP)) };
                ct.Values= new ChartValues<ObservableValue> { new ObservableValue(Int32.Parse(data[0].CT)) };
                dl.Values= new ChartValues<ObservableValue> { new ObservableValue(Int32.Parse(data[0].DL)) };
                pd.Values= new ChartValues<ObservableValue> { new ObservableValue(Int32.Parse(data[0].PD)) };
                sakit.Values= new ChartValues<ObservableValue> { new ObservableValue(Int32.Parse(data[0].S)) };
                sdr.Values= new ChartValues<ObservableValue> { new ObservableValue(Int32.Parse(data[0].SDR)) };
                if (data[0].CPTPLG != null)
                {
                    cepat = Convert.ToInt32(data[0].CPTPLG);
                }
                cptplg.Values= new ChartValues<ObservableValue> { new ObservableValue(cepat) };
                if (data[0].TELAT != null)
                {
                    telatTemp = Convert.ToInt32(data[0].TELAT);
                }
                telat.Values= new ChartValues<ObservableValue> { new ObservableValue(telatTemp) };
            }
           

        }
        private void getDataGrafik(string nip)
        {

            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
            getDataKehadiran(nip);
        }
        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
        
    }
}