using SOM.Services;
using SOM.ViewModel;
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

namespace SOM.View
{
    /// <summary>
    /// AddEquipmentWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddEquipmentModal : Window
    {
        public AddEquipmentModal()
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
            string equip_id = Tb_EquipID.Text;
            string equip_name = Tb_EquipName.Text;
            string equip_state = Cb_EquipState.Text;
            string interlock_id = Tb_InterlockID.Text;
            string creator_name = Tb_CreatorName.Text;

            // Post Equipment 실행
            HttpResponseMessage response = await PostEquipment.PostEquipmentAsync(equip_id, equip_name, equip_state, creator_name, interlock_id);

            // API 응답 성공 여부 체크
            if (response.IsSuccessStatusCode)
            {
                // 에러 메시지 숨기기
                Bdr_ErrorBox.Visibility= Visibility.Collapsed;                
                this.Close();
            }
            else
            {
                // 에러 메세지 보이기
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = response.ReasonPhrase;
            }
        }
    }
}
