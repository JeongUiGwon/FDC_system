﻿#pragma checksum "..\..\..\..\View\Modal\AddParamModal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0139AE0282FF75395A523A3DBC515D705DC7C8945C9934B9DFAF45FE766287EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SOM.View.Modal;
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


namespace SOM.View.Modal {
    
    
    /// <summary>
    /// AddParamModal
    /// </summary>
    public partial class AddParamModal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\View\Modal\AddParamModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_ParamID;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\View\Modal\AddParamModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_ParamName;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\View\Modal\AddParamModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Cb_ParamLevel;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\View\Modal\AddParamModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Cb_ParamState;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\View\Modal\AddParamModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_EquipID;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\View\Modal\AddParamModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Bdr_ErrorBox;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\View\Modal\AddParamModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Tb_ErrorMsg;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\View\Modal\AddParamModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Register;
        
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
            System.Uri resourceLocater = new System.Uri("/SOM;component/view/modal/addparammodal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Modal\AddParamModal.xaml"
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
            
            #line 13 "..\..\..\..\View\Modal\AddParamModal.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\..\..\View\Modal\AddParamModal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Close_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Tb_ParamID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Tb_ParamName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Cb_ParamLevel = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Cb_ParamState = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Tb_EquipID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 92 "..\..\..\..\View\Modal\AddParamModal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_SearchEquipment_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Bdr_ErrorBox = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.Tb_ErrorMsg = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.Btn_Register = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\..\View\Modal\AddParamModal.xaml"
            this.Btn_Register.Click += new System.Windows.RoutedEventHandler(this.Btn_Register_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

