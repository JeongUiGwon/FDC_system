using SOM.Model;
using System.Windows;
using System.Windows.Input;

namespace SOM.View.Equipment
{
    /// <summary>
    /// SearchEquipmentIDModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchEquipmentIDModal : Window
    {
        public string Result;
        public SearchEquipmentIDModal()
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

        private void DataGrid_Equipment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EquipmentsModel item = dg_Equipment.CurrentItem as EquipmentsModel;

            if (item != null)
            {
                Result = item.equipment_id;
                this.Close();
            }
        }
    }
}
