﻿#pragma checksum "..\..\NieuweKlantscherm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3518B70B0E9DE972A8568B55AEB7DA29"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectFilm;
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


namespace ProjectFilm {
    
    
    /// <summary>
    /// NieuweKlantscherm
    /// </summary>
    public partial class NieuweKlantscherm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\NieuweKlantscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel MainContainer;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\NieuweKlantscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ContentContainer;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\NieuweKlantscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Navigation;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\NieuweKlantscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnnuleer;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\NieuweKlantscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBetalen;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectFilm;component/nieuweklantscherm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NieuweKlantscherm.xaml"
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
            this.MainContainer = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.ContentContainer = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.Navigation = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.btnAnnuleer = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\NieuweKlantscherm.xaml"
            this.btnAnnuleer.Click += new System.Windows.RoutedEventHandler(this.btnAnnuleer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnBetalen = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\NieuweKlantscherm.xaml"
            this.btnBetalen.Click += new System.Windows.RoutedEventHandler(this.btnBetalen_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

