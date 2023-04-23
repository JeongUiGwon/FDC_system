using Firebase.Auth;
using SOM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.ViewModel
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<UsersModel> _usersList;

        public UsersViewModel()
        {
            SetUsersList();
        }

        public ObservableCollection<UsersModel> UsersList
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersList));
            }
        }

        private async void SetUsersList()
        {
            FirebaseAdminAuth firebaseAdminAuth = new FirebaseAdminAuth();
            var users = await firebaseAdminAuth.GetUserList();
            UsersList = new ObservableCollection<UsersModel>(users);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
