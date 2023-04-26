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
        public EditParamModal()
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
            string param_id = Tb_ParamID.Text;
            string param_name = Tb_ParamName.Text;
            string param_level = Cb_ParamLevel.Text;
            string param_state = Cb_ParamState.Text;
            string equipment = Tb_EquipID.Text;
            string modifier_name = App.CurrentUser.UserName;

            // Patch Param API 호출
            HttpResponseMessage response = await PatchParamID.PatchParamIDAsync(param_id, param_name, param_level, param_state, modifier_name, equipment);

            if (response.IsSuccessStatusCode)
            {
                this.Close();
            }
            else
            {
                Tb_ErrorMsg.Text = response.ReasonPhrase;
                Bdr_ErrorBox.Visibility = Visibility.Visible;
            }
        }
    }
}
