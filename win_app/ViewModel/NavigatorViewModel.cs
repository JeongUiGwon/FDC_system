using SOM.Model;
using SOM.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SOM.ViewModel
{
    public class NavigatorViewModel : INotifyPropertyChanged
    {
        public NavigatorViewModel()
        {
            _userName = App.CurrentUser.UserName;
            _role = App.CurrentUser.Role;

            ChangeLanguageCommand = new RelayCommand(ExecuteChangeLanguageCommand);
            SetLanguage();
        }

        private string _frameSource = "/View/Dashboard/DashboardPage.xaml";
        public string FrameSource
        {
            get { return _frameSource; }
            set
            {
                _frameSource = value;
                OnPropertyChanged(nameof(FrameSource));
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string _role;
        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        private string _dashBoardMenu;
        public string DashBoardMenu
        {
            get { return _dashBoardMenu; }
            set 
            { 
                _dashBoardMenu = value;
                OnPropertyChanged(nameof(DashBoardMenu));
            }
        }

        private string _equipmentMenu;
        public string EquipmentMenu
        {
            get { return _equipmentMenu; }
            set 
            { 
                _equipmentMenu = value;
                OnPropertyChanged(nameof(EquipmentMenu));
            }
        }

        private string _equipmentStateMenu;
        public string EquipmentStateMenu
        {
            get { return _equipmentStateMenu; }
            set
            {
                _equipmentStateMenu = value;
                OnPropertyChanged(nameof(EquipmentStateMenu));
            }
        }

        private string _paramMenu;
        public string ParamMenu
        {
            get { return _paramMenu; }
            set
            {
                _paramMenu = value;
                OnPropertyChanged(nameof(ParamMenu));
            }
        }

        private string _recipeMenu;
        public string RecipeMenu
        {
            get { return _recipeMenu; }
            set
            {
                _recipeMenu = value;
                OnPropertyChanged(nameof(RecipeMenu));
            }
        }

        private string _dataMenu;
        public string DataMenu
        {
            get { return _dataMenu; }
            set
            {
                _dataMenu = value;
                OnPropertyChanged(nameof(DataMenu));
            }
        }

        private string _interlockMenu;
        public string InterlockMenu
        {
            get { return _interlockMenu; }
            set
            {
                _interlockMenu = value;
                OnPropertyChanged(nameof(InterlockMenu));
            }
        }

        private string _autoRangeMenu;
        public string AutoRangeMenu
        {
            get { return _autoRangeMenu; }
            set
            {
                _autoRangeMenu = value;
                OnPropertyChanged(nameof(AutoRangeMenu));
            }
        }

        private string _fullPatternMenu;
        public string FullPatternMenu
        {
            get { return _fullPatternMenu; }
            set
            {
                _fullPatternMenu = value;
                OnPropertyChanged(nameof(FullPatternMenu));
            }
        }

        private string _profileMenu;
        public string ProfileMenu
        {
            get { return _profileMenu; }
            set
            {
                _profileMenu = value;
                OnPropertyChanged(nameof(ProfileMenu));
            }
        }

        private string _usersMenu;
        public string UsersMenu
        {
            get { return _usersMenu; }
            set
            {
                _usersMenu = value;
                OnPropertyChanged(nameof(UsersMenu));
            }
        }

        private string _logoutMenu;
        public string LogoutMenu
        {
            get { return _logoutMenu; }
            set
            {
                _logoutMenu = value;
                OnPropertyChanged(nameof(LogoutMenu));
            }
        }

        private string _changeLanguage;
        public string ChangeLanguage
        {
            get { return _changeLanguage; }
            set
            {
                _changeLanguage = value;
                OnPropertyChanged(nameof(ChangeLanguage));
            }
        }
        public ICommand ChangeLanguageCommand { get; private set; }

        private void SetLanguage()
        {
            if (Settings.Default.Language == "Eng")
            {
                DashBoardMenu = "DashBoard";
                EquipmentMenu = "Equipment";
                EquipmentStateMenu = "Equipment State";
                ParamMenu = "Param";
                RecipeMenu = "Recipe";
                DataMenu = "Data";
                InterlockMenu = "Interlock";
                AutoRangeMenu = "AutoRange";
                FullPatternMenu = "Full Pattern";
                ProfileMenu = "Profile";
                UsersMenu = "Users";
                LogoutMenu = "Logout";
                ChangeLanguage = "한국어";
            }
            else if (Settings.Default.Language == "Kor")
            {
                DashBoardMenu = "대쉬보드";
                EquipmentMenu = "장비";
                EquipmentStateMenu = "장비 상태";
                ParamMenu = "항목";
                RecipeMenu = "레시피";
                DataMenu = "데이터";
                InterlockMenu = "인터락";
                AutoRangeMenu = "AutoRange 설정";
                FullPatternMenu = "풀 패턴";
                ProfileMenu = "프로필";
                UsersMenu = "유저 관리";
                LogoutMenu = "로그아웃";
                ChangeLanguage = "English";
            }
        }

        private void ExecuteChangeLanguageCommand()
        {
            if (Settings.Default.Language == "Eng")
            {
                Settings.Default.Language = "Kor";
                Settings.Default.Save();
                Settings.Default.Save();
            }
            else if (Settings.Default.Language == "Kor")
            {
                Settings.Default.Language = "Eng";
                Settings.Default.Save();
            }
            SetLanguage();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
