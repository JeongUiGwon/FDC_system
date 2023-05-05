using Newtonsoft.Json;
using SOM.Model;
using SOM.Services;
using SOM.View.Param;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Google.Apis.Requests.BatchRequest;

namespace SOM.View.Data
{
    /// <summary>
    /// DataPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DataPage : Page
    {
        public DataPage()
        {
            InitializeComponent();

            // 조회기간 세팅
            dp_startDate.Text = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
            tp_startTime.Text = DateTime.Now.ToString("HH:mm");
            dp_endDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            tp_endTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private async void btn_apply_click(object sender, RoutedEventArgs e)
        {
            var equipments = dg_equipment.ItemsSource as ObservableCollection<EquipmentsModel>;
            var selectedEquipments = equipments.Where(el => el.isSelected).ToList();

            string str_selectedEquipments = string.Join(",", selectedEquipments.Select(el => el.equipment_id));

            string startDate = $"{dp_startDate.Text} {tp_startTime.Text}";
            string endDate = $"{dp_endDate.Text} {tp_endTime.Text}";

            string str_params = tb_paramID.Text;

            HttpResponseMessage response_getParamLog = await GetParamLog.GetParamLogAsync(str_selectedEquipments, str_params, startDate, endDate);
            ObservableCollection<ParamLogModel> content = new ObservableCollection<ParamLogModel>();

            if (response_getParamLog != null && response_getParamLog.Content != null)
            {
                string str_content = await response_getParamLog.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<ParamLogModel>>(str_content);
                dg_equipmentData.ItemsSource = content;
            }
            
        }

        private void dg_equipment_refresh(object sender, RoutedEventArgs e)
        {
            dg_equipment.Items.Refresh();
        }

        private void btn_SearchParams_click(object sender, RoutedEventArgs e)
        {
            var modal = new GetParamModal();
            modal.ShowDialog();

            if (modal.Result != null)
            {
                tb_paramID.Text = modal.Result.ToString();
            }
        }
    }
}
