﻿using SOM.Services;
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
    /// EditEquipmentModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditEquipmentModal : Window
    {
        public EditEquipmentModal()
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

        private async void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string equip_id = Tb_EquipID.Text;
            string equip_name = Tb_EquipName.Text;
            string equip_state = Cb_EquipState.Text;
            string interlock_id = Tb_InterlockID.Text;
            string modifier_name = App.CurrentUser.UserName;
            
            // Patch Equipment 실행
            HttpResponseMessage response = await PatchEquipmentID.PatchEquipmentIDAsync(equip_id, equip_name, equip_state, modifier_name, interlock_id);

            // API 응답 성공 여부 체크
            if (response.IsSuccessStatusCode)
            {
                // 에러 메시지 숨기기
                Bdr_ErrorBox.Visibility = Visibility.Collapsed;
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
