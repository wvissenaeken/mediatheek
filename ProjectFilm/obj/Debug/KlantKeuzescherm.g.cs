﻿#pragma checksum "..\..\KlantKeuzescherm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A89BF9D3EEDE5422A277EDB07624286B"
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
    /// KlantKeuzescherm
    /// </summary>
    public partial class KlantKeuzescherm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\KlantKeuzescherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel MainContainer;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\KlantKeuzescherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel KlantKeuze;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\KlantKeuzescherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNieuweKlant;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\KlantKeuzescherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBestaandeKlant;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\KlantKeuzescherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel VoerKaartIn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\KlantKeuzescherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblInsertEID;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectFilm;component/klantkeuzescherm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\KlantKeuzescherm.xaml"
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
            this.KlantKeuze = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.btnNieuweKlant = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\KlantKeuzescherm.xaml"
            this.btnNieuweKlant.Click += new System.Windows.RoutedEventHandler(this.btnNieuweKlant_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnBestaandeKlant = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\KlantKeuzescherm.xaml"
            this.btnBestaandeKlant.Click += new System.Windows.RoutedEventHandler(this.btnBestaandeKlant_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.VoerKaartIn = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.lblInsertEID = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

