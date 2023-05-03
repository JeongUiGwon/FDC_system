using Firebase.Auth;
using SOM.Model;
using SOM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SOM.View
{
    /// <summary>
    /// SignUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Login/LoginPage.xaml", UriKind.Relative));
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.Close();
        }

        private async void Btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            string userName = tb_userName.Text;
            string email = tb_Email.Text;
            string password = pwdBox_pwd.Password;
            string department = tb_Department.Text;
            string phoneNumber = tb_PhoneNumber.Text;

            btn_signUp.IsEnabled = false;

            try
            {
                FirebaseAuthModel firebaseAuth = new FirebaseAuthModel();
                var userCredential = await firebaseAuth.client.CreateUserWithEmailAndPasswordAsync(email, password, userName);

                var customClaims = new Dictionary<string, object>()
                {
                    { "Authority", "User" },
                    { "Department", department },
                    { "PhoneNumber", phoneNumber }
                };

                FirebaseAdminAuth firebase = new FirebaseAdminAuth();
                await firebase.auth.SetCustomUserClaimsAsync(userCredential.User.Uid, customClaims);

                NavigationService.Navigate(new Uri("/View/Login/LoginPage.xaml", UriKind.Relative));
            }
            catch (FirebaseAuthHttpException ex)
            {
                // Firebase 예외처리
                Tb_ErrorMsg.Text = ex.Reason.ToString();
            }
            finally
            {
                // SignUp 버튼 활성화
                btn_signUp.IsEnabled = true;
            }

        }

        private void pwdBox_pwd_passwordChanged(object sender, RoutedEventArgs e)
        {
            if (pwdBox_pwd.Password != string.Empty && pwdBox_pwd.Password.Length < 6)
            {
                tb_pwdError.Visibility = Visibility.Visible;
                tb_pwdError.Text = "6자 이상 입력해주세요.";
            }
            else
            {
                tb_pwdError.Visibility = Visibility.Collapsed;
                tb_pwdError.Text = "";
            }
        }

        private void pwdBox_confirmPwd_passwordChanged(object sender, RoutedEventArgs e)
        {
            if (pwdBox_pwd.Password != string.Empty && pwdBox_pwd.Password != pwdBox_confirmPwd.Password)
            {
                tb_confirmPwdError.Visibility = Visibility.Visible;
                tb_confirmPwdError.Text = "비밀번호가 동일하지 않습니다.";
            }
            else
            {
                tb_confirmPwdError.Visibility = Visibility.Collapsed;
                tb_confirmPwdError.Text = "";
            }
        }

        private void tb_email_textChanged(object sender, TextChangedEventArgs e)
        {
            if (EmailValidator.IsValidEmail(tb_Email.Text))
            {
                tb_emailError.Visibility = Visibility.Collapsed;
                tb_emailError.Text = "";
            }
            else
            {
                tb_emailError.Visibility = Visibility.Visible;
                tb_emailError.Text = "이메일 형식이 아닙니다.";
            }
        }        
    }
}
