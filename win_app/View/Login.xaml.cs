using Firebase.Auth;
using FirebaseAdmin.Auth;
using SOM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using Firebase.Auth.Providers;
using System.Security.Cryptography;

namespace SOM.View
{
    /// <summary>
    /// Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();

            tb_email.Text = Properties.Settings.Default.Email;
            pwdBox_pwd.Password = Properties.Settings.Default.Password;
            chk_Remember.IsChecked = Properties.Settings.Default.IsRememberLogin;
        }

        private void Btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/SignUp.xaml", UriKind.Relative));
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.Close();
        }

        private async void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            string email = tb_email.Text;
            string password = pwdBox_pwd.Password;

            btn_login.IsEnabled = false;

            try
            {
                // Firebase 연결
                FirebaseAuthModel firebaseAuth = new FirebaseAuthModel();
                var userCredential = await firebaseAuth.client.SignInWithEmailAndPasswordAsync(email, password);

                // User 권한 조회
                FirebaseAdminAuth firebaseAdminAuth = new FirebaseAdminAuth();
                var user = await firebaseAdminAuth.auth.GetUserAsync(userCredential.User.Uid);
                Dictionary<string, object> claims = user.CustomClaims as Dictionary<string, object>;
                var authority = claims["Authority"];

                // 이메일, 비밀번호 정보 저장
                if (chk_Remember.IsChecked == true)
                {
                    Properties.Settings.Default.Email = tb_email.Text;
                    Properties.Settings.Default.Password = pwdBox_pwd.Password.ToString();
                    Properties.Settings.Default.IsRememberLogin = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Email = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.IsRememberLogin = false;
                    Properties.Settings.Default.Save();
                }

                // 권한 접근
                if (authority.ToString() == "Guest") 
                {
                    Tb_ErrorMsg.Text = "Authoriztion Error";
                }
                else
                {
                    // 메인 화면 열기
                    var mainWindow = new MainWindow();
                    mainWindow.Show();

                    // 로그인 창 닫기
                    var window = Window.GetWindow(this);
                    window.Close();
                }
            }
            catch (FirebaseAuthHttpException ex)
            {
                // Firebase 예외처리
                Tb_ErrorMsg.Text = ex.Reason.ToString();
            }
            finally { 
                tb_email.Focus();
                btn_login.IsEnabled = true;
            }
        }
    }
}
