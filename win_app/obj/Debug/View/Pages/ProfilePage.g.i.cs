﻿#pragma checksum "..\..\..\..\View\Pages\ProfilePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "623E38AF23E68F8420490C0000BBA756AF2FE1031F2C31444550A2852B06CA79"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.Sharp;
using LiveCharts.Wpf;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SOM.View;
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


namespace SOM.View {
    
    
    /// <summary>
    /// ProfilePage
    /// </summary>
    public partial class ProfilePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 62 "..\..\..\..\View\Pages\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Delete_Account;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\View\Pages\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_Name;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\View\Pages\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_Department;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\View\Pages\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tb_PhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\View\Pages\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Save_Change;
        
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
            System.Uri resourceLocater = new System.Uri("/SOM;component/view/pages/profilepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Pages\ProfilePage.xaml"
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
            
            #line 55 "..\..\..\..\View\Pages\ProfilePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_ChangePassword_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Btn_Delete_Account = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\View\Pages\ProfilePage.xaml"
            this.Btn_Delete_Account.Click += new System.Windows.RoutedEventHandler(this.Btn_Delete_Account_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Tb_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Tb_Department = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Tb_PhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Btn_Save_Change = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\..\View\Pages\ProfilePage.xaml"
            this.Btn_Save_Change.Click += new System.Windows.RoutedEventHandler(this.Btn_Save_Change_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

