using Newtonsoft.Json;
using rtwin.dataQuery;
using rtwin.lib;
using rtwin.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace rtwin.View.calendar
{
    /// <summary>
    /// Interaction logic for calendar.xaml
    /// </summary>
    public partial class calendar : UserControl
    {
        List<ComboBox> cmb;
        List<TextBlock> txt;
        List<string> dayName;
        int tanda = 0;
        bool isSqlServer;
        public calendar(bool isSqlServer)
        {
            InitializeComponent();
            //MessageBox.Show(firstDayOfMonth.DayOfWeek.ToString()+","+days.ToString()+","+firstDayOfMonth.ToString("MMMM")+","+DateTime.Now.AddDays(-1).DayOfWeek.ToString());
            this.isSqlServer = isSqlServer;
            setcomboKalender();
            setTextBlock();
            setDayname();
            generateCalender();
            //monday,Tuesday
        }
        void generateCalender()
        {

            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            //int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int days = DateTime.DaysInMonth(firstDayOfMonth.AddMonths(tanda).Year, firstDayOfMonth.AddMonths(tanda).Month);
            int indexHari=0;
            if (tanda != 0)
            {
                indexHari = dayName.IndexOf(firstDayOfMonth.AddMonths(tanda).DayOfWeek.ToString());
            }
            else
            {
                indexHari = dayName.IndexOf(firstDayOfMonth.DayOfWeek.ToString());
            }
           // MessageBox.Show(indexHari.ToString()+","+days);
            NamaBulan.Text = firstDayOfMonth.AddMonths(tanda).ToString("MMMM");
            int a = 1;
            int daysBefore = DateTime.DaysInMonth(firstDayOfMonth.AddMonths(-1).Year, firstDayOfMonth.AddMonths(-1).Month);
            int indexHariTemp = indexHari;
            //MessageBox.Show(txt.Count.ToString());
            for (int i = 0; i <= txt.Count; i++)
            {
                
                if (i >= indexHari && a <= days)
                {
                    txt[i].Text = a.ToString();
                    //MessageBox.Show(a.ToString());
                    cmb[i].Visibility = Visibility.Visible;
                    a++;
                }else
                {
                    if (i < txt.Count)
                    {
                        txt[i].Text = "";
                        cmb[i].Visibility = Visibility.Hidden;
                    }
                }
               
            }
        }
        void setcomboKalender()
        {
            cmb = new List<ComboBox>();
            cmb.Add(cmb1);cmb.Add(cmb2);cmb.Add(cmb3);cmb.Add(cmb4);cmb.Add(cmb5);cmb.Add(cmb6);cmb.Add(cmb7);cmb.Add(cmb8);cmb.Add(cmb9);cmb.Add(cmb10);cmb.Add(cmb11);cmb.Add(cmb12);cmb.Add(cmb13);cmb.Add(cmb14);cmb.Add(cmb15);cmb.Add(cmb16);cmb.Add(cmb17);cmb.Add(cmb18);cmb.Add(cmb19);cmb.Add(cmb20);cmb.Add(cmb21);cmb.Add(cmb22);cmb.Add(cmb23);cmb.Add(cmb24);cmb.Add(cmb25);cmb.Add(cmb26);cmb.Add(cmb27);cmb.Add(cmb28);cmb.Add(cmb29);cmb.Add(cmb30);cmb.Add(cmb31);cmb.Add(cmb32);cmb.Add(cmb33);cmb.Add(cmb34);cmb.Add(cmb35);cmb.Add(cmb36);cmb.Add(cmb37);cmb.Add(cmb38);cmb.Add(cmb39);cmb.Add(cmb40);cmb.Add(cmb41);cmb.Add(cmb42);

            JsonConvert.DeserializeObject<List<comboBoxTemplate>>(AriLib.generateComboBox(queryPolaKolektif.comboPola, true, cmb, isSqlServer, false));

            //cmb[1].Items.Add(ComboBoxItem{ conte})
        }
        void setTextBlock()
        {
            txt = new List<TextBlock>();
            txt.Add(tgl1);txt.Add(tgl2);txt.Add(tgl3);txt.Add(tgl4);txt.Add(tgl5);txt.Add(tgl6);txt.Add(tgl7);txt.Add(tgl8);txt.Add(tgl9);txt.Add(tgl10);txt.Add(tgl11);txt.Add(tgl12);txt.Add(tgl13); txt.Add(tgl14);txt.Add(tgl15);txt.Add(tgl16);txt.Add(tgl17);txt.Add(tgl18);txt.Add(tgl19);txt.Add(tgl20);txt.Add(tgl21);txt.Add(tgl22);txt.Add(tgl23);txt.Add(tgl24);txt.Add(tgl25);txt.Add(tgl26);txt.Add(tgl27);txt.Add(tgl28);txt.Add(tgl29);txt.Add(tgl30);txt.Add(tgl31);txt.Add(tgl32);txt.Add(tgl33);txt.Add(tgl34);txt.Add(tgl35);txt.Add(tgl36);txt.Add(tgl37);txt.Add(tgl38);txt.Add(tgl39);txt.Add(tgl40);txt.Add(tgl41);txt.Add(tgl42);
        }
        void setDayname()
        {
            dayName = new List<string>();
            dayName.Add("Sunday");dayName.Add("Monday");dayName.Add("Tuesday");dayName.Add("wednesday");dayName.Add("Thursday");dayName.Add("Friday");dayName.Add("Saturday");
        }
        private void PrevMont_Click(object sender, RoutedEventArgs e)
        {
            this.tanda--;
            generateCalender();
        }

        private void NextMonth_Click(object sender, RoutedEventArgs e)
        {
            this.tanda++;
            generateCalender();
        }
    }
}
