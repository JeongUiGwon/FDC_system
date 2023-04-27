﻿using Newtonsoft.Json;
using SOM.Model;
using SOM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SOM.View.Modal
{
    /// <summary>
    /// AddParamModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddParamModal : Window
    {
        public AddParamModal()
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
            string param_id = Tb_ParamID.Text;
            string param_name = Tb_ParamName.Text;
            string param_level = Cb_ParamLevel.Text;
            string param_state = Cb_ParamState.Text;
            string equipment = Tb_EquipID.Text;
            string creator_name = App.CurrentUser.UserName;

            Btn_Register.IsEnabled = false;

            // Post Params API 요청
            HttpResponseMessage response = await PostParam.PostParamAsync(param_id, param_name, param_level, param_state, creator_name, equipment);

            // Post Params API 요청 실패
            if (!response.IsSuccessStatusCode)
            {
                Btn_Register.IsEnabled = true;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = response.ReasonPhrase;
                return;
            }

            // Get Params API 요청
            HttpResponseMessage responseGet = await GetParamID.GetParamIDAsync(param_id);

            // Get Params API 요청 실패
            if (!responseGet.IsSuccessStatusCode)
            {
                Btn_Register.IsEnabled = true;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = response.ReasonPhrase;
                return;
            }

            // 입력한 데이터 JSON화
            ParamsModel new_content = await responseGet.Content.ReadAsAsync<ParamsModel>();
            string jsonNewData = JsonConvert.SerializeObject(new_content);

            // Post param_history API 요청
            HttpResponseMessage responseHistory = await PostParamHistory.PostParamHistoryAsync("생성", param_id, new_value: jsonNewData);

            // Post param_history API 요청 실패
            if (!responseHistory.IsSuccessStatusCode)
            {
                Btn_Register.IsEnabled = true;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
                Tb_ErrorMsg.Text = response.ReasonPhrase;
                return;
            }

            this.Close();
        }
    }
}
