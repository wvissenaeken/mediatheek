﻿#pragma checksum "..\..\LeesKaartscherm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "00FD9C2F334C5BFB2A277FBA1A7C414E"
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
    /// LeesKaartscherm
    /// </summary>
    public partial class LeesKaartscherm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel KaartLayout;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgphoto;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGeslacht;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblVoornaam;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNaam;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblStraat;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblZipCode;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblStad;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGeboorteDatum;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGeboortePlaats;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRR;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\LeesKaartscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblKaartNummer;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectFilm;component/leeskaartscherm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LeesKaartscherm.xaml"
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
            this.KaartLayout = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            
            #line 13 "..\..\LeesKaartscherm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_LeesKaart_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.imgphoto = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.lblGeslacht = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblVoornaam = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblNaam = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblStraat = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblZipCode = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblStad = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lblGeboorteDatum = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.lblGeboortePlaats = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.lblRR = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.lblKaartNummer = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

