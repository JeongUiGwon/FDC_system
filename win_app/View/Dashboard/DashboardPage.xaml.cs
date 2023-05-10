using FirebaseAdmin;
using SOM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
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
    /// Dashboard.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();

            // 스트리밍할 Firebase Storage의 영상 URL
            string videoUrl = "https://firebasestorage.googleapis.com/v0/b/ssafy-a201.appspot.com/o/HO3IXOQV%2F2023_05_10_11_26.avi?alt=media&token=fe97a14c-cb2b-40e1-a581-4652363d9ae5";
            string temp = @"C:\Temp\test.avi";


            using (WebClient client = new WebClient())
            {
                client.DownloadFile(videoUrl, temp);
            }

            mediaElement.Source = new Uri(temp);

        }
    }
}
