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
    /// EditRecipeModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditRecipeModal : Window
    {
        private RecipeModel _old_value;
        private RecipeModel _new_value;
        public EditRecipeModal()
        {
            InitializeComponent();

            Bdr_ErrorBox.Visibility = Visibility.Collapsed;
        }
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            RecipeModel dataContext = DataContext as RecipeModel;
            _old_value = new RecipeModel(dataContext.recipe_id, dataContext.recipe_name, dataContext.lsl, dataContext.usl, dataContext.lsl_interlock_action,
                dataContext.usl_interlock_action, dataContext.recipe_use, dataContext.creator_name, dataContext.created_at, dataContext.modifier_name, dataContext.updated_at,
                dataContext.equipment, dataContext.param);
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

        private async void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string recipe_id = Tb_RecipeID.Text;
            string recipe_name = Tb_RecipeName.Text;
            string str_lsl = Tb_Lsl.Text;
            string str_usl = Tb_Usl.Text;
            string lsl_action = Cb_LslAction.Text;
            string usl_action = Cb_UslAction.Text;
            string recipe_state = Cb_RecipeState.Text;
            string modifier_name = App.CurrentUser.UserName;
            string equip_id = Tb_EquipID.Text;
            string param_id = tb_paramID.Text;
            float lsl;
            float usl;

            // 버튼 비활성화
            Btn_Save.IsEnabled = false;
            _new_value = DataContext as RecipeModel;

            // LSL 숫자인지 확인
            if (!float.TryParse(str_lsl, out lsl))
            {
                Btn_Save.IsEnabled = true;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "LSL must be entered as a number.";
                return;
            }

            // USL 숫자인지 확인
            if (!float.TryParse(str_usl, out usl))
            {
                Btn_Save.IsEnabled = true;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "USL must be entered as a number.";
                return;
            }

            // Recipe 변경 API 호출
            HttpResponseMessage response = await PatchRecipeID.PatchRecipeIDAsync(recipe_id, recipe_name, lsl, usl, lsl_action, usl_action, recipe_state, modifier_name, equip_id, param_id);

            // Recipe 변경 API 요청 실패
            if (!response.IsSuccessStatusCode)
            {
                Btn_Save.IsEnabled = true;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "Failed to change recipe. " + response.ReasonPhrase;
                return;
            }

            // RecipeModel을 string으로 변환
            string str_old_value = JsonConvert.SerializeObject(_old_value);
            string str_new_value = JsonConvert.SerializeObject(_new_value);

            // Recipe 변경 이력 기록 API 호출
            HttpResponseMessage responseHistory = await PostRecipeHistory.PostRecipeHistoryAsync("UPDATE", recipe_id, str_old_value, str_new_value);

            // Recipe 변경 이력 기록 API 요청 실패
            if (!responseHistory.IsSuccessStatusCode)
            {
                Btn_Save.IsEnabled = true;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "Failed to record recipe history. " + responseHistory.ReasonPhrase;
                Console.WriteLine(response.ReasonPhrase);
                return;
            }

            Btn_Save.IsEnabled = true;
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
