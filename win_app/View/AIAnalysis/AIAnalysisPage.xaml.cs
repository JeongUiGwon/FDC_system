using SOM.Utils;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SOM.View.AIAnalysis
{
    /// <summary>
    /// AIAnalysisPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AIAnalysisPage : Page
    {
        public AIAnalysisPage()
        {
            InitializeComponent();
        }

        private void dg_AIAnalysis_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dg_AIAnalysis.SelectedItem == null) return;

            var modal = new AIAnalysisChartModal();
            modal.Show();
        }

        private void Btn_ExportCSV_Click(object sender, EventArgs e)
        {
            ExportFile.ExportCSV(dg_AIAnalysis);
        }
    }
}
