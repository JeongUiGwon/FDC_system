using Newtonsoft.Json;
using SOM.Model;
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
    /// EditParamModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditParamModal : Window
    {
        private ParamsModel _old_value;
        private ParamsModel _new_value;

        public EditParamModal()
        {
            InitializeComponent();

            Bdr_ErrorBox.Visibility = Visibility.Collapsed;
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            ParamsModel dataContext = DataContext as ParamsModel;
            _old_value = new ParamsModel(dataContext.param_id, dataContext.equipment, dataContext.param_name, dataContext.param_level, dataContext.param_state,
                dataContext.creator_name, dataContext.created_at, dataContext.modifier_name, dataContext.updated_at);
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

        private void Btn_SearchEquipment_Click(object sender, RoutedEventArgs e)
        {
            var Modal = new SearchEquipmentIDModal();
            Modal.ShowDialog();

            string equip_id = Modal.Result;
            Tb_EquipID.Text = equip_id;
        }

        private async void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string param_id = Tb_ParamID.Text;
            string param_name = Tb_ParamName.Text;
            string param_level = Cb_ParamLevel.Text;
            string param_state = Cb_ParamState.Text;
            string equipment = Tb_EquipID.Text;
            string modifier_name = App.CurrentUser.UserName;

            Btn_Save.IsEnabled = false;
            _new_value = DataContext as ParamsModel;

            // Patch Param API 호출
            HttpResponseMessage response = await PatchParamID.PatchParamIDAsync(param_id, param_name, param_level, param_state, modifier_name, equipment);

            if (!response.IsSuccessStatusCode)
            {
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Btn_Save.IsEnabled = true;
                Tb_ErrorMsg.Text = "항목 변경 실패";
                Console.WriteLine(response.ReasonPhrase);
                return;
            }

            // ParamModel을 string으로 변환
            string str_old_value = JsonConvert.SerializeObject(_old_value);
            string str_new_value = JsonConvert.SerializeObject(_new_value);

            // Post param_history API 요청
            HttpResponseMessage responseHistory = await PostParamHistory.PostParamHistoryAsync("생성", param_id, str_old_value, str_new_value);

            // Post param_history API 요청 실패
            if (!responseHistory.IsSuccessStatusCode)
            {
                Btn_Save.IsEnabled = true;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = "항목 변경 이력 기록 실패";
                Console.WriteLine(response.ReasonPhrase);
                return;
            }

            this.Close();
        }
    }
}
