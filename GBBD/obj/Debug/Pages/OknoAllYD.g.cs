﻿#pragma checksum "..\..\..\Pages\OknoAllYD.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A15C5E9E4A1C6F1CD27A0291FBEABBDE3BDAEC586827A6739DEC60B441EB3976"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GBBD.Pages;
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


namespace GBBD.Pages {
    
    
    /// <summary>
    /// OknoAllYD
    /// </summary>
    public partial class OknoAllYD : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Pages\OknoAllYD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateStart;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\OknoAllYD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateEnd;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\OknoAllYD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ImportBtn;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\OknoAllYD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataVY;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\OknoAllYD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas graphCanvas;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\OknoAllYD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DateStartText;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\OknoAllYD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DateEndText;
        
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
            System.Uri resourceLocater = new System.Uri("/GBBD;component/pages/oknoallyd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\OknoAllYD.xaml"
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
            this.DateStart = ((System.Windows.Controls.DatePicker)(target));
            
            #line 22 "..\..\..\Pages\OknoAllYD.xaml"
            this.DateStart.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DateStart_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DateEnd = ((System.Windows.Controls.DatePicker)(target));
            
            #line 24 "..\..\..\Pages\OknoAllYD.xaml"
            this.DateEnd.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DateEnd_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ImportBtn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Pages\OknoAllYD.xaml"
            this.ImportBtn.Click += new System.Windows.RoutedEventHandler(this.ImportBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DataVY = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.graphCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.DateStartText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.DateEndText = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

