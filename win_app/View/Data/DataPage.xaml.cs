using LiveCharts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        }

        private async void btn_apply_click(object sender, RoutedEventArgs e)
        {
            var equipments = dg_equipment.ItemsSource as ObservableCollection<EquipmentsModel>;
            var selectedEquipments = equipments.Where(el => el.isSelected).ToList();

            string str_selectedEquipments = string.Join(",", selectedEquipments.Select(el => el.equipment_id));

            string startDate = $"{dp_startDate.Text} {tp_startTime.Text}";
            string endDate = $"{dp_endDate.Text} {tp_endTime.Text}";

            string str_params = tb_paramID.Text;

            btn_apply.IsEnabled = false;

            HttpResponseMessage response_getParamLog = await GetParamLog.GetParamLogAsync(str_selectedEquipments, str_params, startDate, endDate);
            ObservableCollection<ParamLogModel> content = new ObservableCollection<ParamLogModel>();

            // 설비 데이터를 DataGrid에 바인딩
            if (response_getParamLog != null && response_getParamLog.Content != null)
            {
                string str_content = await response_getParamLog.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<ParamLogModel>>(str_content);
                dg_equipmentData.ItemsSource = content;
            }

            // 설비 데이터를 param_id에 따라 분류
            Dictionary<string, List<ParamLogModel>> paramData = new Dictionary<string, List<ParamLogModel>>();

            foreach (ParamLogModel equipmentData_item in content)
            {
                if (paramData.ContainsKey(equipmentData_item.param))
                {
                    paramData[equipmentData_item.param].Add(equipmentData_item);
                }
                else
                {
                    paramData[equipmentData_item.param] = new List<ParamLogModel> { equipmentData_item };
                }
            }

            btn_apply.IsEnabled = true;
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
