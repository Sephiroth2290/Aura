﻿#pragma checksum "..\..\WindowSettings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "19E20FFE5638B395DA6CE3CF6E0A5694"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Aura;
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


namespace Aura {
    
    
    /// <summary>
    /// WindowSettings
    /// </summary>
    public partial class WindowSettings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\WindowSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Data.XmlDataProvider DASettings;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\WindowSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DAPath;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\WindowSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Darkages_Path;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\WindowSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrowse;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\WindowSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DAFolder;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\WindowSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DarkagesFolder;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\WindowSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrowse_Directory;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\WindowSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button settingsCancel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\WindowSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button settingsSave;
        
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
            System.Uri resourceLocater = new System.Uri("/Aura;component/windowsettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowSettings.xaml"
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
            
            #line 9 "..\..\WindowSettings.xaml"
            ((Aura.WindowSettings)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.settings_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DASettings = ((System.Windows.Data.XmlDataProvider)(target));
            return;
            case 3:
            this.DAPath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Darkages_Path = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.btnBrowse = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\WindowSettings.xaml"
            this.btnBrowse.Click += new System.Windows.RoutedEventHandler(this.btnBrowse_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DAFolder = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.DarkagesFolder = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.btnBrowse_Directory = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\WindowSettings.xaml"
            this.btnBrowse_Directory.Click += new System.Windows.RoutedEventHandler(this.btnBrowse_Directory_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.settingsCancel = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\WindowSettings.xaml"
            this.settingsCancel.Click += new System.Windows.RoutedEventHandler(this.settingsCancel_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.settingsSave = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\WindowSettings.xaml"
            this.settingsSave.Click += new System.Windows.RoutedEventHandler(this.settingsSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
