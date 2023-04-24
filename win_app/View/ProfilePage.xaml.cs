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

namespace SOM.View
{
    /// <summary>
    /// ProfilePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            DataContext = App.CurrentUser;
        }

        private async void Btn_Save_Change_Click(object sender, RoutedEventArgs e)
        {
            string uid = App.CurrentUser.UID;
            string email = App.CurrentUser.Email;
            string role = App.CurrentUser.Role;
            string displayName = Tb_Name.Text;
            string phoneNumber = Tb_PhoneNumber.Text;

            Btn_Save_Change.IsEnabled = false;

            UserRecordArgs args = new UserRecordArgs()
            {
                Uid = uid,
                Email = email,
                DisplayName = displayName
            };

            var customClaims = new Dictionary<string, object>()
            {
                { "Authority", role },
                { "PhoneNumber", phoneNumber }
            };

            UserRecord userRecord = await FirebaseAuth.DefaultInstance.UpdateUserAsync(args);
            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(uid, customClaims);

            App.CurrentUser = new Model.UsersModel(email, uid, displayName, role, phoneNumber);

            Btn_Save_Change.IsEnabled = true;
        }

        private void Btn_ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/ChangePasswordPage.xaml", UriKind.Relative));
        }

        private async void Btn_Delete_Account_Click(object sender, RoutedEventArgs e)
        {
            string uid = App.CurrentUser.UID;
            await FirebaseAuth.DefaultInstance.DeleteUserAsync(uid);

            var loginWindow = new LoginWindow();
            loginWindow.Show();

            var window = Window.GetWindow(this);
            window.Close();
        }
    }
}
