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
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Login.xaml", UriKind.Relative));
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

            btn_signUp.IsEnabled = false;

            FirebaseAuth firebaseAuth = new FirebaseAuth();
            var userCredential = await firebaseAuth.client.CreateUserWithEmailAndPasswordAsync(email, password, userName);

            NavigationService.Navigate(new Uri("/View/Login.xaml", UriKind.Relative));
        }
    }
}
