using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using SOM.Components;
using SOM.Model;
using SOM.Services;
using SOM.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace SOM.View.AutoRange
{
    /// <summary>
    /// AutoRangePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AutoRangePage : Page
    {
        public AutoRangePage()
        {
            InitializeComponent();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var addModal = new AddAutoRangeModal();
            addModal.ShowDialog();
            NavigationService.Refresh();
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            AutoRangeModel autoRangeModel = clickedButton.DataContext as AutoRangeModel;
            var editModal = new EditAutoRangeModal();

            editModal.DataContext = autoRangeModel;
            editModal.ShowDialog();
            NavigationService.Refresh();
        }

        private async void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            AutoRangeModel autoRangeModel = clickedButton.DataContext as AutoRangeModel;
            int autoRange_id = autoRangeModel.id;
            var customMessageBox = new CustomMessageBox();
            CustomMessageBoxModel customMessage = new CustomMessageBoxModel("Auto Range 제거", "등록된 Auto Range 데이터를 삭제하시겠습니까?");
            customMessageBox.DataContext = customMessage;

            customMessageBox.ShowDialog();

            if (customMessageBox.Result == "OK")
            {
                await DeleteAutorangeID.DeleteAutorangeIDAsync(autoRange_id);
                NavigationService.Refresh();
            }
        }

        private async void dg_AutoRange_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dg_AutoRange.SelectedItem == null) return;

            var modal = new AutoRangeChartModal();
            var selectedItem = dg_AutoRange.SelectedItem as AutoRangeModel;

            // 조회기간 설정
            string startDate = DateTime.Now.AddHours(-3).ToString("yyyy-MM-dd HH:mm");
            string endDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            // equipment id 찾기
            HttpResponseMessage response_getParam = await GetParamID.GetParamIDAsync(selectedItem.param);
            ParamsModel params_content = new ParamsModel();

            if (response_getParam != null && response_getParam.Content != null)
            {
                string str_content = await response_getParam.Content.ReadAsStringAsync();
                params_content = JsonConvert.DeserializeObject<ParamsModel>(str_content);
            }
            else return;

            // 설비 Raw 데이터 찾기
            HttpResponseMessage response_getParamLog = await GetParamLog.GetParamLogAsync(equipment_id: params_content.equipment, param_id: selectedItem.param, start_date: startDate, end_date: endDate);
            ObservableCollection<ParamLogModel> paramLog_content = new ObservableCollection<ParamLogModel>();

            // 설비 데이터를 DataGrid에 바인딩
            if (response_getParamLog != null && response_getParamLog.Content != null)
            {
                string str_content = await response_getParamLog.Content.ReadAsStringAsync();
                paramLog_content = JsonConvert.DeserializeObject<ObservableCollection<ParamLogModel>>(str_content);
            }

            if (paramLog_content.Count == 0)
            {
                modal.Show();
                return;
            }

            HttpResponseMessage response_getRecipe = await GetRecipeID.GetRecipeIDAsync(paramLog_content[0].recipe);
            RecipeModel recipe_content = new RecipeModel();

            // 설비 데이터를 DataGrid에 바인딩
            if (response_getRecipe != null && response_getRecipe.Content != null)
            {
                string str_content = await response_getRecipe.Content.ReadAsStringAsync();
                recipe_content = JsonConvert.DeserializeObject<RecipeModel>(str_content);
            }

            string title = selectedItem.param;
            ChartValues<float> ChartData = new ChartValues<float>();
            ChartValues<float> uslData = new ChartValues<float>();
            ChartValues<float> lslData = new ChartValues<float>();
            ChartValues<float> prevUslData = new ChartValues<float>();
            ChartValues<float> prevLslData = new ChartValues<float>();
            List<string> ChartLabels = new List<string>();

            foreach (var paramLog in paramLog_content)
            {
                ChartData.Add(paramLog.param_value);
                uslData.Add(recipe_content.usl);
                lslData.Add(recipe_content.lsl);
                prevUslData.Add(selectedItem.prev_usl.Value);
                prevLslData.Add(selectedItem.prev_lsl.Value);
                ChartLabels.Add(paramLog.created_at.ToString());
            }

            SeriesCollection ChartSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Title = title,
                    Values = ChartData
                },
                new LineSeries
                {
                    Title = "LSL",
                    Values = lslData,
                    Stroke  = Brushes.Red,
                    PointGeometry = null,
                    Fill = Brushes.Transparent
                },
                new LineSeries
                {
                    Title = "USL",
                    Values = uslData,
                    Stroke  = Brushes.Red,
                    PointGeometry = null,
                    Fill = Brushes.Transparent
                },
                new LineSeries
                {
                    Title = "Previous LSL",
                    Values = prevLslData,
                    Stroke  = Brushes.Gray,
                    PointGeometry = null,
                    Fill = Brushes.Transparent
                },
                new LineSeries
                {
                    Title = "Previous USL",
                    Values = prevUslData,
                    Stroke  = Brushes.Gray,
                    PointGeometry = null,
                    Fill = Brushes.Transparent
                }
            };

            CartesianChartModel dataContext = new CartesianChartModel(title, ChartSeries, ChartLabels);
            modal.DataContext = dataContext;
            modal.Show();
        }

        private void Btn_ExportCSV_Click(object sender, EventArgs e)
        {
            ExportFile.ExportCSV(dg_AutoRange);
        }
    }
}
