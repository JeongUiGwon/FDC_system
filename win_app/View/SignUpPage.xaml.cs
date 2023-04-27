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
            NavigationService.Navigate(new Uri("/View/LoginPage.xaml", UriKind.Relative));
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

            FirebaseAuthModel firebaseAuth = new FirebaseAuthModel();
            var userCredential = await firebaseAuth.client.CreateUserWithEmailAndPasswordAsync(email, password, userName);

            var customClaims = new Dictionary<string, object>()
            {
                { "Authority", "User" },
                { "Department", department },
                { "PhoneNumber", phoneNumber }
            };

            FirebaseAdminAuth firebase =  new FirebaseAdminAuth();
            await firebase.auth.SetCustomUserClaimsAsync(userCredential.User.Uid, customClaims);
            
            NavigationService.Navigate(new Uri("/View/LoginPage.xaml", UriKind.Relative));
        }
    }
}
