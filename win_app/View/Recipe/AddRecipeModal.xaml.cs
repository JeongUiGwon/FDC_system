using Newtonsoft.Json;
using SOM.Model;
using SOM.Services;
using SOM.View.Equipment;
using SOM.View.Param;
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

namespace SOM.View.Recipe
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
            string param_id = tb_paramID.Text;
            float lsl;
            float usl;

            // LSL 숫자인지 확인
            if (!float.TryParse(str_lsl, out lsl))
            {
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "LSL must be entered as a number.";
                return;
            }

            // USL 숫자인지 확인
            if (!float.TryParse(str_usl, out usl))
            {
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "USL must be entered as a number.";
                return;
            }

            // Recipe 등록 API 호출
            HttpResponseMessage response = await PostRecipe.PostRecipeAsync(recipe_id, recipe_name, lsl, usl, lsl_action, usl_action, recipe_state, creator_name, equip_id, param_id);

            // Recipe 등록 요청 실패
            if (!response.IsSuccessStatusCode)
            {
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "Recipe registration failed. " + response.ReasonPhrase;
                return;
            }

            // Recipe 조회 API 호출
            HttpResponseMessage responseGet = await GetRecipeID.GetRecipeIDAsync(recipe_id);

            // Recipe 조회 API 요청 실패
            if (!responseGet.IsSuccessStatusCode)
            {
                Btn_Register.IsEnabled = true;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "Recipe lookup failed. " + response.ReasonPhrase;
                return;
            }

            // 입력한 데이터 JSON화
            string str_content = await responseGet.Content.ReadAsStringAsync();
            RecipeModel new_content = JsonConvert.DeserializeObject<RecipeModel>(str_content);
            string jsonNewData = JsonConvert.SerializeObject(new_content);

            // Recipe 이력 기록 API 호출
            HttpResponseMessage response_history = await PostRecipeHistory.PostRecipeHistoryAsync("CREATE", recipe_id, new_value: jsonNewData);

            // Recipe 이력 기록 API 요청 실패
            if (!response_history.IsSuccessStatusCode)
            {
                Btn_Register.IsEnabled = true;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "Recipe history recording failed. " + response.ReasonPhrase;
                return;
            }

            this.Close();
        }

        private void Btn_SearchEquipment_Click(object sender, EventArgs e)
        {
            var Modal = new SearchEquipmentIDModal();
            Modal.ShowDialog();

            string equip_id = Modal.Result;
            Tb_EquipID.Text = equip_id;
        }

        private void Btn_SearchParams_Click(object sender, EventArgs e)
        {
            var Modal = new SearchParamIDModal();
            Modal.ShowDialog();

            string param_id = Modal.Result;
            tb_paramID.Text = param_id;
        }
    }
}
