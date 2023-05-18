using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SOM.Components
{
    /// <summary>
    /// CustomMessageBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public string Result;
        public CustomMessageBox()
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

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_OK_Click(object sender, RoutedEventArgs e)
        {
            Result = "OK";
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Result = "Cancel";
            this.Close();
        }
    }
}
