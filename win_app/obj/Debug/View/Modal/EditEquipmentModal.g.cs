﻿#pragma checksum "..\..\..\..\View\Modal\EditEquipmentModal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "79D1AF367C594733FD5AD41DC2847ADCC642AE60C4C8BDA8357E768712B57E86"
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
    /// EditEquipmentModal
    /// </summary>
    public partial class EditEquipmentModal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_EquipID;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_EquipName;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Cb_EquipState;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_InterlockID;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_ModifierName;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Bdr_ErrorBox;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Tb_ErrorMsg;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Save;
        
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
            System.Uri resourceLocater = new System.Uri("/SOM;component/view/modal/editequipmentmodal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
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
            
            #line 14 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 18 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Close_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Tb_EquipID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Tb_EquipName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Cb_EquipState = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Tb_InterlockID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Tb_ModifierName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Bdr_ErrorBox = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.Tb_ErrorMsg = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.Btn_Save = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\..\View\Modal\EditEquipmentModal.xaml"
            this.Btn_Save.Click += new System.Windows.RoutedEventHandler(this.Btn_Save_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

