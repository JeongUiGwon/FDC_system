using LiveCharts.Wpf;
using LiveCharts;
using Newtonsoft.Json;
using SOM.Model;
using SOM.Services;
using SOM.View.Param;
using SOM.ViewModel;
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
using System.Diagnostics;

namespace SOM.View.Interlock
{
    /// <summary>
    /// InterlockPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InterlockPage : Page
    {
        public InterlockPage()
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

            HttpResponseMessage response_getInterlockLog = await GetInterlockLog.GetInterlockLogAsync(str_selectedEquipments, str_params, startDate, endDate);
            ObservableCollection<InterlockLogModel> content = new ObservableCollection<InterlockLogModel>();

            if (response_getInterlockLog != null && response_getInterlockLog.Content != null)
            {
                string str_content = await response_getInterlockLog.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<InterlockLogModel>>(str_content);
                dg_interlock.ItemsSource = content;
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

        private async void dg_interlock_mouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (dg_interlock.SelectedItem != null)
            {
                var modal = new InterlockDetailModal();
                InterlockDetailViewModel dataContext = new InterlockDetailViewModel();
                var selectedItem = dg_interlock.SelectedItem as InterlockLogModel;

                // Interlock 데이터 저장
                dataContext.InterlockData = selectedItem;

                // 조회기간 설정
                string startDate = selectedItem.created_at.AddMonths(-1).ToString("yyyy-MM-dd HH:mm");
                string endDate = selectedItem.created_at.AddMonths(1).ToString("yyyy-MM-dd HH:mm");

                HttpResponseMessage response_getParamLog = await GetParamLog.GetParamLogAsync(selectedItem.equipment, selectedItem.param, startDate, endDate, recipe_id: selectedItem.recipe);
                ObservableCollection<ParamLogModel> content = new ObservableCollection<ParamLogModel>();

                // 설비 데이터를 DataGrid에 바인딩
                if (response_getParamLog != null && response_getParamLog.Content != null)
                {
                    string str_content = await response_getParamLog.Content.ReadAsStringAsync();
                    content = JsonConvert.DeserializeObject<ObservableCollection<ParamLogModel>>(str_content);
                }

                string title = selectedItem.param_name;
                ChartValues<float> ChartData = new ChartValues<float>();
                List<string> ChartLabels = new List<string>();

                foreach (var paramLog in content)
                {
                    long timestamp = new DateTimeOffset(paramLog.created_at.ToUniversalTime()).ToUnixTimeSeconds();
                    ChartData.Add(paramLog.param_value);
                    ChartLabels.Add(paramLog.created_at.ToString());
                }

                SeriesCollection ChartSeries = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = title,
                        Values = ChartData
                    }
                };

                dataContext.ChartSeriesCollection = new CartesianChartModel(title, ChartSeries, ChartLabels);

                modal.DataContext = dataContext;
                modal.Show();
            }
        }
    }
}
