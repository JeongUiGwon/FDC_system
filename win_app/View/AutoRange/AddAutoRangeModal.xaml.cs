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

namespace SOM.View.AutoRange
{
    /// <summary>
    /// AddAutoRangeModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddAutoRangeModal : Window
    {
        public AddAutoRangeModal()
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
            float sigmaMinus = float.Parse(Tb_SigamMinus.Text);
            float sigmaPlus = float.Parse(Tb_SigamMinus.Text);
            string autoRangeType = Cb_AutoRangeType.Text;
            string paramID = Tb_ParamID.Text;
            float minRange = float.Parse(Tb_MinRange.Text);
            float maxRange = float.Parse(Tb_MaxRange.Text);
            int range = int.Parse(Tb_CalRange.Text);
            int interval = int.Parse(Tb_CalInterval.Text);
            string is_activate = Cb_AutoRangeUse.Text;

            // Post Equipment 실행
            HttpResponseMessage response = await PostAutornage.PostAutorangeAsync(sigmaMinus, sigmaPlus, minRange, maxRange, interval, range, autoRangeType, is_activate, paramID);

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

        private void Btn_SearchParams_Click(object sender, EventArgs e)
        {
            var Modal = new SearchParamIDModal();
            Modal.ShowDialog();

            string param_id = Modal.Result;
            Tb_ParamID.Text = param_id;
        }
    }
}
