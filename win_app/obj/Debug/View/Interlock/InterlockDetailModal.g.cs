﻿#pragma checksum "..\..\..\..\View\Interlock\InterlockDetailModal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0A6A33BE4C37EABD62BFFE9AEC0D4A17C6753E630EB5679A082743378E54FD02"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
using SOM.View.Interlock;
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


namespace SOM.View.Interlock {
    
    
    /// <summary>
    /// InterlockDetailModal
    /// </summary>
    public partial class InterlockDetailModal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 125 "..\..\..\..\View\Interlock\InterlockDetailModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink Hyperlink_CCTVdownload;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\View\Interlock\InterlockDetailModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart cartesianChart_paramData;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\..\View\Interlock\InterlockDetailModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_equipmentData;
        
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
            System.Uri resourceLocater = new System.Uri("/SOM;component/view/interlock/interlockdetailmodal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Interlock\InterlockDetailModal.xaml"
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
            
            #line 119 "..\..\..\..\View\Interlock\InterlockDetailModal.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Hyperlink_CCTVdownload = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 125 "..\..\..\..\View\Interlock\InterlockDetailModal.xaml"
            this.Hyperlink_CCTVdownload.RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_ShowCCTV);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cartesianChart_paramData = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 4:
            this.dg_equipmentData = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

