﻿#pragma checksum "..\..\..\..\View\setting\connection.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "191E9AA36891E3FD1C50CE48A68D41DDF5BD0CBC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using rtwin.View.setting;


namespace rtwin.View.connection {
    
    
    /// <summary>
    /// connection
    /// </summary>
    public partial class connection : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\View\setting\connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbKoneksi;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\View\setting\connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem ss;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\View\setting\connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem pg;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\setting\connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serverName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\View\setting\connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameServer;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\View\setting\connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordServer;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\View\setting\connection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConnect;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/rtwin;component/view/setting/connection.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\setting\connection.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cmbKoneksi = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.ss = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 3:
            this.pg = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 4:
            this.serverName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.UsernameServer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.passwordServer = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.btnConnect = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\View\setting\connection.xaml"
            this.btnConnect.Click += new System.Windows.RoutedEventHandler(this.BtnConnect_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 39 "..\..\..\..\View\setting\connection.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

