using SOM.Model;
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
            this.Btn_Dashboard.Style = Application.Current.Resources["menuButtonActive"] as Style;
            this.Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            this.frame.Navigate(new Uri("/View/Dashboard.xaml", UriKind.Relative));

        }

        private void Btn_Equipments_Click(object sender, RoutedEventArgs e)
        {
            this.Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Equipments.Style = Application.Current.Resources["menuButtonActive"] as Style;
            this.Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            this.frame.Navigate(new Uri("/View/Equipments.xaml", UriKind.Relative));
        }


        private void Btn_Params_Click(object sender, RoutedEventArgs e)
        {
            this.Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Params.Style = Application.Current.Resources["menuButtonActive"] as Style;
            this.Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            this.frame.Navigate(new Uri("/View/ParamsPage.xaml", UriKind.Relative));
        }

        private void Btn_Recipe_Click(object sender, RoutedEventArgs e)
        {
            this.Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Recipe.Style = Application.Current.Resources["menuButtonActive"] as Style;
            this.Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            this.frame.Navigate(new Uri("/View/RecipePage.xaml", UriKind.Relative));
        }

        private void Btn_Data_Click(object sender, RoutedEventArgs e)
        {
            this.Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Datas.Style = Application.Current.Resources["menuButtonActive"] as Style;
            this.Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            this.frame.Navigate(new Uri("/View/DataPage.xaml", UriKind.Relative));
        }

        private void Btn_Interlock_Click(object sender, RoutedEventArgs e)
        {
            this.Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Interlock.Style = Application.Current.Resources["menuButtonActive"] as Style;
            this.Btn_Users.Style = Application.Current.Resources["menuButton"] as Style;

            this.frame.Navigate(new Uri("/View/InterlockPage.xaml", UriKind.Relative));
        }

        private void Btn_Users_Click(object sender, RoutedEventArgs e)
        {
            this.Btn_Dashboard.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Equipments.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Params.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Recipe.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Datas.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Interlock.Style = Application.Current.Resources["menuButton"] as Style;
            this.Btn_Users.Style = Application.Current.Resources["menuButtonActive"] as Style;

            this.frame.Navigate(new Uri("/View/UsersPage.xaml", UriKind.Relative));
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
