﻿using SOM.Model;
using SOM.View;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SOM
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = App.CurrentUser;

            // 유저 권한별 UI 세팅
            if (App.CurrentUser.Role == "User")
            {
                Btn_Users.Visibility = Visibility.Collapsed;
            }
            else if (App.CurrentUser.Role == "SuperUser")
            {
                Btn_Users.Visibility = Visibility.Collapsed;
            }
            else if (App.CurrentUser.Role == "Developer")
            {
                Btn_Users.Visibility = Visibility.Visible;
            }
            else if (App.CurrentUser.Role == "Admin")
            {
                Btn_Users.Visibility = Visibility.Visible;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Btn_Dashboard_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButtonActive"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            frame.Navigate(new Uri("/View/Dashboard/DashboardPage.xaml", UriKind.Relative));

        }

        private void Btn_Equipments_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButtonActive"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            frame.Navigate(new Uri("/View/Equipment/EquipmentsPage.xaml", UriKind.Relative));
        }

        private void Btn_EquipmentState_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButtonActive"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            frame.Navigate(new Uri("/View/EquipmentState/EquipmentStatePage.xaml", UriKind.Relative));
        }

        private void Btn_Params_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButtonActive"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            frame.Navigate(new Uri("/View/Param/ParamsPage.xaml", UriKind.Relative));
        }

        private void Btn_Recipe_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButtonActive"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            frame.Navigate(new Uri("/View/Recipe/RecipePage.xaml", UriKind.Relative));
        }

        private void Btn_Data_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButtonActive"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            frame.Navigate(new Uri("/View/Data/DataPage.xaml", UriKind.Relative));
        }

        private void Btn_Interlock_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButtonActive"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            frame.Navigate(new Uri("/View/Interlock/InterlockPage.xaml", UriKind.Relative));
        }

        private void Btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButtonActive"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            frame.Navigate(new Uri("/View/Profile/ProfilePage.xaml", UriKind.Relative));
        }

        private void Btn_AutoRange_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButtonActive"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            frame.Navigate(new Uri("/View/AutoRange/AutoRangePage.xaml", UriKind.Relative));
        }

        private void Btn_AIAnalysis_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButtonActive"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            frame.Navigate(new Uri("/View/AIAnalysis/AIAnalysisPage.xaml", UriKind.Relative));
        }

        private void Btn_Users_Click(object sender, RoutedEventArgs e)
        {
            Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_EquipmentState.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AutoRange.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_AIAnalysis.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Profile.Style = Application.Current.Resources["menuButton"] as Style;
            Btn_Users.Style = Application.Current.Resources["menuButtonActive"] as Style;

            frame.Navigate(new Uri("/View/Users/UsersPage.xaml", UriKind.Relative));
        }

        private void Btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            FirebaseAuthModel firebaseAuth = new FirebaseAuthModel();
            firebaseAuth.client.SignOut();

            var loginWindow  = new LoginWindow();
            loginWindow.Show();

            var window = Window.GetWindow(this);
            window.Close();
        }
    }
}
