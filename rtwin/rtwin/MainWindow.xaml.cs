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
using rtwin.Model;
using rtwin.View.home;
using rtwin.View.master.timecard;
using rtwin.View.customDialog;
using rtwin.View.master.shift;
using rtwin.View.master.libur;
using System.Data.SqlClient;
using Npgsql;
using System.ComponentModel;
using System.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using rtwin.lib;
using MaterialDesignThemes.Wpf;
using rtwin.View.master.ijin;
using rtwin.View.master.lembur;
using rtwin.View.master.satker;
using rtwin.View.master.jabatan;
using rtwin.View.master.golongan;
using rtwin.View.master.grade;
using rtwin.View.master.eselon;
using rtwin.View.master.status_pegawai;
using rtwin.View.master;
using rtwin.View.master.employee;
using rtwin.View.Report;
using rtwin.View.transaksi.manual;
using rtwin.View.transaksi.ijin;
using rtwin.View.transaksi.leaveAccrual;
using rtwin.View.transaksi.notice;
using rtwin.View.transaksi.polajadwal;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace rtwin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private koneksi kon;
        private string nip,nama,username,gradeID;
        private bool sqlServer;
        public string uriTheme;
        public MainWindow(string nip,string nama,string namaCabang,string username,string gradeID,bool sqlServer, string uriTheme)
        {
            InitializeComponent();
            
            this.nip = nip;
            this.nama = nama;
            this.username = username;
            this.gradeID = gradeID;
            this.sqlServer = sqlServer;

            kon = new koneksi(sqlServer);
            
            nipKaryawan.Text = nip;
            namaKaryawan.Text = nama;
            Username.Text = username;
            jumSaldoCuti.Text = getSaldoCuti(nip).ToString();
            getDataKehadiran(nip);
            setDefaultPage();
            cardSideBar.Height = System.Windows.SystemParameters.WorkArea.Height-10;
            //heighContent.Height= System.Windows.SystemParameters.WorkArea.Height;
            //MessageBox.Show(System.Windows.SystemParameters.WorkArea.Height.ToString());
            //content.Content = new loginPage();

            this.uriTheme = uriTheme;
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri(uriTheme, UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);
        }
        private void setDefaultPage()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    lodong.Visibility = Visibility.Visible;
                    

                }), null);
                Thread.Sleep(new TimeSpan(0, 0, 5));
                //Thread.Sleep(new TimeSpan(0, 0, 1));
            };
            
            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new home(sqlServer, nip, gradeID, username,breadcumb, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }
        private int getSaldoCuti( string nip)
        {
            int temp=0;
            string query = "exec proc_get_notifikasi_sisa_cuti '" + nip + "'";
            List<string> data = kon.getDataFromDatabase(query);
            if (data.Count > 0)
            {
                temp = Int32.Parse(data[0]);
            }
            else
            {
                temp = 0;
            }
            return temp;
        }
        private void getDataKehadiran(string nip)
        {
            string query = "exec proc_get_notifikasi_kehadiran_individu '" + nip + "'";
            List<string> data = kon.getDataFromDatabase(query);
            if (data.Count > 0)
            {
                bak.Text = data[2].ToString();
                dl.Text = data[6];
                pd.Text = data[7];
                cp.Text = data[10];
            }
            else
            {
                bak.Text = "0";
                dl.Text = "0";
                pd.Text = "0";
                cp.Text = "0";
            }
            
        }
        

        private void WaktuKerja_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new timecard(sqlServer, breadcumb, dialogLogOut, frameConten,lodong,contenLogOut,username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void PolaJadwal_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new shift (sqlServer,breadcumb,dialogLogOut,frameConten,lodong,contenLogOut,username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Libur_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new holiday(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void StatusAbsen_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new leave(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void ParameterLembur_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new overtime_config(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Deputi_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new deputi(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username,gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Biro_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;
                    
                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new biro(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Bagian_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new bagian(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void SubBagian_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new subBagian(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Jabatan_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new jabatan(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Golngan_Click(object sender, RoutedEventArgs e)
        {   
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new golongan(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
            
        }

        private void Grade_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new grade(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Eselon_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new eselon(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new statusPegawai(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Pegawai_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new employee(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username,gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void WaktuKerjaDetail_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new timecard_detail(sqlServer,breadcumb, dialogLogOut, frameConten, lodong, contenLogOut,username, gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void LaporanBulanan_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new monthly(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username,gradeID);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void PerHAri_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new ijinPerHari(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username,gradeID,nip, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void PerJam_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new ijinPerJam(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, nip, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Saldo_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new LeaveAccrual(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, nip, uriTheme);
                //frameConten.Content = new LeaveAccrual();
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void Notice_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new notice(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID,nip, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void PolaKolektif_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new polaJadwalKolektif(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID, nip);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        


        private void LaporanHarian_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new daily(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username, gradeID); ;
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void LaporanTahunan_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new annual();
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }


        private void Home_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };
           
            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new home(sqlServer, nip, gradeID, username,breadcumb, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void ManualKehadiran_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    frameConten.Content = "";
                    lodong.Visibility = Visibility.Visible;


                }), null);
                //Thread.Sleep(new TimeSpan(0, 0, 5));
                Thread.Sleep(new TimeSpan(0, 0, 1));
            };

            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                frameConten.Content = new manual(sqlServer, breadcumb, dialogLogOut, frameConten, lodong, contenLogOut, username,gradeID, uriTheme);
                lodong.Opacity = 100;
            };
            worker.RunWorkerAsync();
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            //contenLogOut.Content = new dialogClose();
            //dialogLogOut.IsOpen = true;

            this.Hide();
            Login mabrur = new Login();
            mabrur.Show();

        }
        
        

        
    }
}
