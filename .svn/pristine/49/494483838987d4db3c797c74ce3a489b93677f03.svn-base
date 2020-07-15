using MaterialDesignThemes.Wpf;
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

namespace rtwin.View.master.lembur
{
    /// <summary>
    /// Interaction logic for overtime_config.xaml
    /// </summary>
    public partial class overtime_config : UserControl
    {
        bool isSqlServer;
        TextBlock bredcumb;
        DialogHost dialogHost;
        Frame frameContent, dialogContent;
        Image LoadingContent;
        string json = String.Empty, queryDelete = String.Empty, actionLog = String.Empty, username = String.Empty;
        string gradeID;
        public overtime_config(bool isSqlServer, TextBlock bredcumb, DialogHost dialogHost, Frame frameContent, Image LoadingContent, Frame dialogContent, string username, string gradeID)
        {
            this.isSqlServer = isSqlServer;
            this.bredcumb = bredcumb;
            this.dialogHost = dialogHost;
            this.frameContent = frameContent;
            this.LoadingContent = LoadingContent;
            this.dialogContent = dialogContent;
            this.username = username;
            this.gradeID = gradeID;
            bredcumb.Text = "Master / tabel / Overtime Config";
            InitializeComponent();
            frameFpl.Content = new faktor_pengali_lembur(isSqlServer,bredcumb,dialogHost,frameFpl,LoadingContent,dialogContent,username, gradeID);
            frameLo.Content = new lemburOtomatis(isSqlServer, bredcumb, dialogHost, frameLo, LoadingContent, dialogContent, username, gradeID);
            framePl.Content = new parameterLembur(isSqlServer, bredcumb, dialogHost, framePl, LoadingContent, dialogContent, username, gradeID);
        }
    }
}
