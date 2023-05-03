using Firebase.Auth;
using SOM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SOM.ViewModel
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        public UsersViewModel()
        {
            SetUsersList();
        }

        private ObservableCollection<UsersModel> _usersList;
        public ObservableCollection<UsersModel> UsersList
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersList));
            }
        }

        private ObservableCollection<UsersModel> _filteredUserList;
        public ObservableCollection<UsersModel> FilteredUserList
        {
            get { return _filteredUserList; }
            set
            {
                _filteredUserList = value;
                OnPropertyChanged(nameof(FilteredUserList));
            }
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));
                FilterUserList();
            }
        }

        private async void SetUsersList()
        {
            FirebaseAdminAuth firebaseAdminAuth = new FirebaseAdminAuth();
            var users = await firebaseAdminAuth.GetUserList();
            UsersList = new ObservableCollection<UsersModel>(users);
            FilterUserList();
        }

        private void FilterUserList()
        {
            if (UsersList != null && UsersList.Any() && !string.IsNullOrWhiteSpace(SearchTerm))
            {
                FilteredUserList = new ObservableCollection<UsersModel>(UsersList.Where(e => e.Email.Contains(SearchTerm) || e.UserName.Contains(SearchTerm)
                || e.Role.Contains(SearchTerm) || e.Department.Contains(SearchTerm) || e.PhoneNumber.Contains(SearchTerm))); ;
            }
            else
            {
                FilteredUserList = UsersList;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
