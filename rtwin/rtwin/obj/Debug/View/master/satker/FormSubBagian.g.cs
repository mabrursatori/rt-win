﻿#pragma checksum "..\..\..\..\..\View\master\satker\FormSubBagian.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9BFE9BDEC1A5FD22552BE8AA90B1CF8F1FF3CBD9C5E049F095896C9F0FE0513D"
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
using System.Windows.Forms.Integration;
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
using rtwin.View.master.satker;


namespace rtwin.View.master.satker {
    
    
    /// <summary>
    /// FormSubBagian
    /// </summary>
    public partial class FormSubBagian : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\View\master\satker\FormSubBagian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gbTitel;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\View\master\satker\FormSubBagian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKode;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\View\master\satker\FormSubBagian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNama;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\View\master\satker\FormSubBagian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBagian;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\View\master\satker\FormSubBagian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnsave;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\View\master\satker\FormSubBagian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\View\master\satker\FormSubBagian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel lodongSave;
        
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
            System.Uri resourceLocater = new System.Uri("/rtwin;component/view/master/satker/formsubbagian.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\master\satker\FormSubBagian.xaml"
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
            this.gbTitel = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 2:
            this.txtKode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtNama = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cmbBagian = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.btnsave = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\..\View\master\satker\FormSubBagian.xaml"
            this.btnsave.Click += new System.Windows.RoutedEventHandler(this.Btnsave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\..\View\master\satker\FormSubBagian.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.BtnClose_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lodongSave = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

