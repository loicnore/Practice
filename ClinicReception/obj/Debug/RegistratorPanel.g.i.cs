﻿#pragma checksum "..\..\RegistratorPanel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0712BB24991FF1F1EFC136F8EE986B4D4454B3C4AD49D81C5A0589211F1AE6D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ClinicReception;
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


namespace ClinicReception {
    
    
    /// <summary>
    /// RegistratorPanel
    /// </summary>
    public partial class RegistratorPanel : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\RegistratorPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock loginTxt;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\RegistratorPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCat;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\RegistratorPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button recBtn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\RegistratorPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PatBtn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\RegistratorPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SchedBtn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\RegistratorPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RepBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/ClinicReception;component/registratorpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegistratorPanel.xaml"
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
            this.loginTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.btnCat = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\RegistratorPanel.xaml"
            this.btnCat.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.recBtn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\RegistratorPanel.xaml"
            this.recBtn.Click += new System.Windows.RoutedEventHandler(this.recBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PatBtn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\RegistratorPanel.xaml"
            this.PatBtn.Click += new System.Windows.RoutedEventHandler(this.PatBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SchedBtn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\RegistratorPanel.xaml"
            this.SchedBtn.Click += new System.Windows.RoutedEventHandler(this.SchedBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RepBtn = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\RegistratorPanel.xaml"
            this.RepBtn.Click += new System.Windows.RoutedEventHandler(this.RepBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

