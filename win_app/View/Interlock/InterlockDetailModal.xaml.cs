using LiveCharts.Wpf;
using LiveCharts;
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
using Firebase.Storage;
using SOM.Model;
using System.IO;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Net;

namespace SOM.View.Interlock
{
    /// <summary>
    /// InterlockDetailModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InterlockDetailModal : Window
    {
        public InterlockDetailModal()
        {
            InitializeComponent();
        }

        private void btn_show_click(object sender, RoutedEventArgs e)
        {
            string videoUrl = me_cctv.ToolTip.ToString();
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); ; // 임시 파일 경로
            string savePath = userPath + @"\Downloads\streaming.avi";

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(videoUrl, savePath);
            }

            me_cctv.Source = new Uri(savePath);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string url = e.Uri.AbsoluteUri;
            Process.Start(new ProcessStartInfo(url));
            e.Handled = true;
        }
    }
}
