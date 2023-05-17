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

namespace SOM.View.AutoRange
{
    /// <summary>
    /// EditAutoRangeModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditAutoRangeModal : Window
    {
        public EditAutoRangeModal()
        {
            InitializeComponent();
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
            AutoRangeModel autoRangeModel = new AutoRangeModel();
            autoRangeModel = DataContext as AutoRangeModel;

            int autorangeId = autoRangeModel.id;
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
            HttpResponseMessage response = await PatchAutorange.PatchAutorangeAsync(autorangeId, sigmaMinus, sigmaPlus, minRange, maxRange, interval, range, autoRangeType, is_activate);

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
