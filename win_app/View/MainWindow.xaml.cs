using SOM.Model;
using SOM.View;
using System.Windows;
using System.Windows.Input;

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

        private void Btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            FirebaseAuth firebaseAuth = new FirebaseAuth();
            firebaseAuth.client.SignOut();

            var loginWindow  = new LoginWindow();
            loginWindow.Show();

            var window = Window.GetWindow(this);
            window.Close();
        }
    }
}
