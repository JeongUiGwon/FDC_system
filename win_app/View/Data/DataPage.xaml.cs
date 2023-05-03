using SOM.Model;
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

            ObservableCollection<EquipmentsDataModel> equipmentsDatas = new ObservableCollection<EquipmentsDataModel>();

            equipmentsDatas.Add(new EquipmentsDataModel("abcd", "Equip 1", "LOT1", "Recipe1", "Param1", 100, DateTime.Now));
            equipmentsDatas.Add(new EquipmentsDataModel("bsdw", "Equip 2", "LOT2", "Recipe2", "Param2", 80, DateTime.Now));
            equipmentsDatas.Add(new EquipmentsDataModel("asgs", "Equip 3", "LOT3", "Recipe3", "Param3", 70, DateTime.Now));
            equipmentsDatas.Add(new EquipmentsDataModel("fsdw", "Equip 4", "LOT4", "Recipe4", "Param4", 60, DateTime.Now));

            DataDatagrid.ItemsSource = equipmentsDatas;
        }
    }
}
