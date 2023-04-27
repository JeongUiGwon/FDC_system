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

namespace SOM.View.Pages
{
    /// <summary>
    /// ParamHistoryPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ParamHistoryPage : Page
    {
        public ParamHistoryPage()
        {
            InitializeComponent();
        }

        private void Btn_list_Click(object sender, RoutedEventArgs e)
        {
            // 항목 리스트 페이지로 이동
            // test
            NavigationService.Navigate(new Uri("/View/Pages/ParamsPage.xaml", UriKind.Relative));
        }
    }
}
