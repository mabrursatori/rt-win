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
using System.Windows.Shapes;
using rtwin.View.connection;
using rtwin.View.customDialog;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Threading;

namespace rtwin
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private bool sqlServer;
        public string uriTheme;
        public string style = "/rtwin;component/style/Light.xaml";

        public Login()
        {
            InitializeComponent();
            this.sqlServer = true;

            uriTheme = style;
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri(uriTheme, UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var response = MessageBox.Show("Anda yakin Akan keluar dari Aplikasi Ini???", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            //if (response == MessageBoxResult.Yes)
            //{
            //    App.Current.Shutdown();
            //}
            contenSetting.Content = new dialogClose();
            dialogSetting.IsOpen = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //frmLogin.Content = new connection(frmLogin);
            contenSetting.Content = new connection();
            dialogSetting.IsOpen = true;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            setWorker();
            
        }
        private void setWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    lodong.Visibility = Visibility.Visible;
                    txtUsername.IsEnabled = false;
                    txtPassword.IsEnabled = false;
                    btnLogin.IsEnabled = false;

                }), null);
                Thread.Sleep(new TimeSpan(0, 0, 5));
                //Thread.Sleep(new TimeSpan(0, 0, 1));
            };
            worker.DoWork += (o, a) =>
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    lodong.Visibility = Visibility.Visible;
                    logginProses();
                }), null);
                Thread.Sleep(new TimeSpan(0, 0, 5));
                //Thread.Sleep(new TimeSpan(0, 0, 1));
            };
            worker.RunWorkerCompleted += (o, a) =>
            {
                lodong.Visibility = Visibility.Hidden;
                lodong.Opacity = 100;
                btnLogin.IsEnabled = true;
                txtUsername.IsEnabled = true;
                txtPassword.IsEnabled = true;
            };
            worker.RunWorkerAsync();
        }
        private void logginProses()
        {

            if (txtUsername.Text.ToString() != "" && txtPassword.Password != "")
            {
                Model.login login = new Model.login(txtUsername.Text.ToString(), txtPassword.Password,sqlServer);
                string log = login.getLogin();
                if (log != "Login gagal")
                {
                    var list = JsonConvert.DeserializeObject<List<Model.datakaryawan>>(log);
                    //MessageBox.Show(list[0].nip);
                    lodong.Visibility = Visibility.Hidden;
                    MainWindow mv = new MainWindow(list[0].nip, list[0].nama, list[0].namaCabang, list[0].username,list[0].gradeID,sqlServer, style);
                    mv.Show();
                    this.Close();

                }
                else
                {

                    lodong.Visibility = Visibility.Hidden;
                    //contenSetting.Content = new dialogClose();
                    contenSetting.Width = 250;
                    contenSetting.Content = new alertDialog(log.ToString());
                    dialogSetting.IsOpen = true;
                    //MessageBox.Show(log);
                }
            }
            else if(txtUsername.Text.ToString() == "" && txtPassword.Password == "")
            {
                contenSetting.Content = new alertDialog("Username dan Password Masih Kosong");
                dialogSetting.IsOpen = true;
                lodong.Visibility = Visibility.Hidden;
            }
            else if (txtUsername.Text.ToString() == "")
            {
                contenSetting.Content = new alertDialog("Username Masih Kosong");
                dialogSetting.IsOpen = true;
                //lodong.Visibility = Visibility.Hidden;
            }
            else if (txtPassword.Password.ToString() == "")
            {
                contenSetting.Content = new alertDialog("Password Masih Kosong");
                dialogSetting.IsOpen = true;
                //lodong.Visibility = Visibility.Hidden;
            }
            

        }

        private void TxtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            setWorker();
        }

        private void TxtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key != System.Windows.Input.Key.Enter) return;
            setWorker();
        }

        private void toogleChecked(object sender, RoutedEventArgs e)
        {
            style = "/rtwin;component/style/Dark.xaml";
            uriTheme = style;
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri(uriTheme, UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);
        }

        private void toogleUnchecked(object sender, RoutedEventArgs e)
        {
            style = "/rtwin;component/style/Light.xaml";
            uriTheme = style;
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri(uriTheme, UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);
        }
    }
}
