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
    /// RecipePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RecipePage : Page
    {
        public RecipePage()
        {
            InitializeComponent();

            // 유저 권한별 UI 세팅
            if (App.CurrentUser.Role == "User")
            {
                Btn_Add.IsEnabled = false;
                Dg_Action.Visibility = Visibility.Collapsed;
            }
            else if (App.CurrentUser.Role == "SuperUser")
            {
                Btn_Add.IsEnabled = true;
                Dg_Action.Visibility = Visibility.Visible;
            }
            else if (App.CurrentUser.Role == "Developer")
            {
                Btn_Add.IsEnabled = true;
                Dg_Action.Visibility = Visibility.Visible;
            }
            else if (App.CurrentUser.Role == "Admin")
            {
                Btn_Add.IsEnabled = true;
                Dg_Action.Visibility = Visibility.Visible;
            }
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var addModal = new AddRecipeModal();
            addModal.ShowDialog();

            NavigationService.Refresh();
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            RecipeModel dataContext = clickedButton.DataContext as RecipeModel;
            var editModal = new EditRecipeModal();

            editModal.DataContext = dataContext;
            editModal.ShowDialog();
            NavigationService.Refresh();
        }

        private async void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            RecipeModel dataContext = clickedButton.DataContext as RecipeModel;
            string recipe_id = dataContext.recipe_id;

            // 삭제 확인 다이얼로그 실행
            var result = MessageBox.Show("Are you sure you want to remove this param information?", "Remove Param", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Delete Param/param_id API 호출
                HttpResponseMessage response = await DeleteRecipeID.DeleteRecipeIDAsync(recipe_id);

                // Parmas page 새로고침
                NavigationService.Refresh();
            }
        }
    }
}
