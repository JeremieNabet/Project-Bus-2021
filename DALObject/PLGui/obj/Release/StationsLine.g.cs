﻿#pragma checksum "..\..\StationsLine.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D7B308C331C193BB31F7878154C4F94D87432DBFF8EB8745E9A895FEBD55AA80"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLGui;
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


namespace PLGui {
    
    
    /// <summary>
    /// StationsLine
    /// </summary>
    public partial class StationsLine : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\StationsLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid myData;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\StationsLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox myStation;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\StationsLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Terminus;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\StationsLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Distance;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\StationsLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Time;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\StationsLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox next;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\StationsLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox myLine;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\StationsLine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StationCodetxtbox;
        
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
            System.Uri resourceLocater = new System.Uri("/PLGui;component/stationsline.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StationsLine.xaml"
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
            this.myData = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.myStation = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\StationsLine.xaml"
            this.myStation.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Changed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Terminus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Distance = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Time = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.next = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.myLine = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\StationsLine.xaml"
            this.myLine.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LineChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 23 "..\..\StationsLine.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 24 "..\..\StationsLine.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.StationCodetxtbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            
            #line 26 "..\..\StationsLine.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

