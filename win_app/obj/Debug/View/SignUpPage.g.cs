﻿#pragma checksum "..\..\..\View\SignUpPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8E751565AD2D479EF042F84FF0A47D60DD7AC2FA44043026A8C6CFAC33B7FD93"
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
    /// SignUpPage
    /// </summary>
    public partial class SignUpPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 195 "..\..\..\View\SignUpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_userName;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\..\View\SignUpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Email;
        
        #line default
        #line hidden
        
        
        #line 212 "..\..\..\View\SignUpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwdBox_pwd;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\..\View\SignUpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_signUp;
        
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
            System.Uri resourceLocater = new System.Uri("/SOM;component/view/signuppage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\SignUpPage.xaml"
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
            
            #line 187 "..\..\..\View\SignUpPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Close_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tb_userName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tb_Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.pwdBox_pwd = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.btn_signUp = ((System.Windows.Controls.Button)(target));
            
            #line 235 "..\..\..\View\SignUpPage.xaml"
            this.btn_signUp.Click += new System.Windows.RoutedEventHandler(this.Btn_SignUp_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 245 "..\..\..\View\SignUpPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Login_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

