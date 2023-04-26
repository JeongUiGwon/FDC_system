using SOM.Services;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SOM.View.Modal
{
    /// <summary>
    /// AddRecipeModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddRecipeModal : Window
    {
        public AddRecipeModal()
        {
            InitializeComponent();

            Bdr_ErrorBox.Visibility = Visibility.Collapsed;
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

        private async void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            string recipe_id = Tb_RecipeID.Text;
            string recipe_name = Tb_RecipeName.Text;
            string str_lsl = Tb_Lsl.Text;
            string str_usl = Tb_Usl.Text;
            string lsl_action = Cb_LslAction.Text;
            string usl_action = Cb_UslAction.Text;
            string recipe_state = Cb_RecipeState.Text;
            string creator_name = App.CurrentUser.UserName;
            string equip_id = Tb_EquipID.Text;
            string param_id = Tb_ParamID.Text;
            int lsl;
            int usl;

            // LSL 숫자인지 확인
            if (!int.TryParse(str_lsl, out lsl))
            {
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "LSL must be entered as a number.";
                return;
            }

            // USL 숫자인지 확인
            if (!int.TryParse(str_usl, out usl))
            {
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "USL must be entered as a number.";
                return;
            }

            HttpResponseMessage response = await PostRecipe.PostRecipeAsync(recipe_id, recipe_name, lsl, usl, lsl_action, usl_action, recipe_state, creator_name, equip_id, param_id);

            if (response.IsSuccessStatusCode)
            {
                this.Close();
            }
            else
            {
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = response.ReasonPhrase;
            }
        }
    }
}
