using SOM.Model;
using SOM.Services;
using SOM.View.Modal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
    /// ParamsPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ParamsPage : Page
    {
        public ParamsPage()
        {
            InitializeComponent();
        }


        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            // Modal 창 열기
            var modal = new AddParamModal();
            modal.ShowDialog();

            // Params Page 새로고침
            NavigationService.Refresh();
        }

        private async void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            ParamsModel dataContext = clickedButton.DataContext as ParamsModel;
            string param_id = dataContext.param_id;
            
            // Delete Param/param_id API 호출
            HttpResponseMessage response = await DeleteParamID.DeleteParamIDAsync(param_id);

            if (response.IsSuccessStatusCode)
            {
                // API 성공시
                Console.WriteLine("Success Delete Param");
            }
            else
            {
                // API 실패시
                Console.WriteLine(response.ReasonPhrase);
            }

            // Parmas 페이지 새로고침
            NavigationService.Refresh();
        }
    }
}
