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
using WPF.Bootstrap.Controls;

namespace rtwin.View.customDialog
{
    /// <summary>
    /// Interaction logic for dialogClose.xaml
    /// </summary>
    public partial class dialogClose : UserControl
    {
        
        public dialogClose()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
           
            App.Current.Shutdown();
            
        }
    }
}
