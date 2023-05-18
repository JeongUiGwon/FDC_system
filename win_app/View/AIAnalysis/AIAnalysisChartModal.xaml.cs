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

namespace SOM.View.AIAnalysis
{
    /// <summary>
    /// AIAnalysisChartModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AIAnalysisChartModal : Window
    {
        public AIAnalysisChartModal()
        {
            InitializeComponent();
            LoadRemoteImage();
        }

        private void LoadRemoteImage()
        {
            string imageUrl = "https://firebasestorage.googleapis.com/v0/b/ssafy-a201.appspot.com/o/LSTM2.PNG?alt=media&token=8cff11ed-1a01-4b80-8e4f-960f28d4dd58";
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUrl, UriKind.Absolute);
            bitmapImage.EndInit();

            image_chart.Source = bitmapImage;
        }
    }
}
