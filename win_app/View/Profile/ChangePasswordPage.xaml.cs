using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SOM.View.Profile
{
    /// <summary>
    /// ChangePasswordPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChangePasswordPage : Page
    {
        public ChangePasswordPage()
        {
            InitializeComponent();

            DataContext = App.CurrentUser;
        }

        private void Btn_ChangeProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Profile/ProfilePage.xaml", UriKind.Relative));
        }

        private async void Btn_UpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = Pb_ConfirmPassword.Password;

            // Update Password 버튼 비활성화
            Btn_UpdatePassword.IsEnabled = false;

            // 비밀번호 정보 저장
            UserRecordArgs args = new UserRecordArgs()
            {
                Uid = App.CurrentUser.UID,
                Password = newPassword
            };

            // 비밀번호 변경
            UserRecord userRecord = await FirebaseAuth.DefaultInstance.UpdateUserAsync(args);

            // Update Password 버튼 활성화
            Btn_UpdatePassword.IsEnabled = true;

            // Profile 페이지로 이동
            NavigationService.Navigate(new Uri("/View/Profile/ProfilePage.xaml", UriKind.Relative));
        }
    }
}
