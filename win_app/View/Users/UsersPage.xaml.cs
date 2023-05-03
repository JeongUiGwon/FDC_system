using Firebase.Auth;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using SOM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SOM.View.Users
{
    /// <summary>
    /// UsersPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        private async void DG_UsersDatagrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var editedItem = e.Row.Item as UsersModel;
            var customClaims = new Dictionary<string, object>()
            {
                { "Authority", editedItem.Role },
                { "Department", editedItem.Department },
                { "PhoneNumber", editedItem.PhoneNumber }
            };

            FirebaseAdminAuth firebase = new FirebaseAdminAuth();
            await firebase.auth.SetCustomUserClaimsAsync(editedItem.UID, customClaims);

            if (App.CurrentUser.Role == "Developer" && (editedItem.Role == "Developer" || editedItem.Role == "Admin"))
            {
                MessageBox.Show("Developer 권한으로는 상대에게 Developer와 Admin 권한을 부여할 수 없습니다.");
                return;
            }

            customClaims = new Dictionary<string, object>()
            {
                { "Authority", editedItem.Role },
                { "Department", editedItem.Department },
                { "PhoneNumber", editedItem.PhoneNumber }
            };

            await firebase.auth.SetCustomUserClaimsAsync(editedItem.UID, customClaims);
        }
    }
}
