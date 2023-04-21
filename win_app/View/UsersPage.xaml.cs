using Firebase.Auth;
using FirebaseAdmin.Auth;
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

namespace SOM.View
{
    /// <summary>
    /// UsersPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();

            SetUsersList();

            DataContext = new RoleModel();
        }

        private static ObservableCollection<UsersModel> users;
        public enum RoleList { Guest, Maintainer, Admin };

        private async void SetUsersList()
        {
            FirebaseAdminAuth firebaseAdminAuth = new FirebaseAdminAuth();

            users = await firebaseAdminAuth.GetUserList();
            UsersDatagrid.ItemsSource = users;
        }
    }
}
