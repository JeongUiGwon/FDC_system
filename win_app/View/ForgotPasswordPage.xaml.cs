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
    /// ForgotPassword.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ForgotPasswordPage : Page
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void Btn_SendEmail_Click(object sender, RoutedEventArgs e)
        {
            string email = tb_email.Text;

            btn_send_email.IsEnabled = false;

            FirebaseAuthModel firebaseAuth = new FirebaseAuthModel();
            await firebaseAuth.client.ResetEmailPasswordAsync(email);

            NavigationService.Navigate(new Uri("/View/LoginPage.xaml", UriKind.Relative));
        }

        private void Btn_LoginNow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/LoginPage.xaml", UriKind.Relative));
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.Close();
        }
    }
}
