using SOM.Model;
using SOM.View.Param;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        private void btn_apply_click(object sender, RoutedEventArgs e)
        {
            var equipments = dg_equipment.ItemsSource as ObservableCollection<EquipmentsModel>;
            var selectedEquipments = equipments.Where(el => el.isSelected).ToList();

            string startDate = dp_startDate.Text;
            string startTime = tp_startTime.Text;
            string endDate = dp_endDate.Text;
            string endTime = tp_endTime.Text;

            Console.WriteLine("hello");
        }

        private void btn_SearchParams_click(object sender, RoutedEventArgs e)
        {
            var modal = new GetParamModal();
            modal.ShowDialog();
        }
    }
}
