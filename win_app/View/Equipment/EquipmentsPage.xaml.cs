using SOM.Components;
using SOM.Model;
using SOM.Services;
using SOM.Utils;
using System.Windows;
using System.Windows.Controls;

namespace SOM.View.Equipment
{
    /// <summary>
    /// Equipments.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EquipmentsPage : Page
    {
        public EquipmentsPage()
        {
            InitializeComponent();

            // 유저 권한별 UI 세팅
            if (App.CurrentUser.Role == "User")
            {
                Btn_Add.IsEnabled = false;
                Dg_Action.Visibility = Visibility.Collapsed;
            }
            else if (App.CurrentUser.Role == "SuperUser")
            {
                Btn_Add.IsEnabled = true;
                Dg_Action.Visibility = Visibility.Visible;
            }
            else if (App.CurrentUser.Role == "Developer")
            {
                Btn_Add.IsEnabled = true;
                Dg_Action.Visibility = Visibility.Visible;
            }
            else if (App.CurrentUser.Role == "Admin")
            {
                Btn_Add.IsEnabled = true;
                Dg_Action.Visibility = Visibility.Visible;
            }
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var addModal = new AddEquipmentModal();
            addModal.ShowDialog();
            NavigationService.Refresh();
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            EquipmentsModel equipment = clickedButton.DataContext as EquipmentsModel;
            var editModal = new EditEquipmentModal();

            editModal.DataContext = equipment;
            editModal.ShowDialog();
            NavigationService.Refresh();
        }

        private async void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            EquipmentsModel equipment = clickedButton.DataContext as EquipmentsModel;
            string equip_id = equipment.equipment_id;
            var customMessageBox = new CustomMessageBox();
            CustomMessageBoxModel customMessage = new CustomMessageBoxModel("설비 제거", "등록된 설비 데이터를 삭제하시겠습니까?");
            customMessageBox.DataContext = customMessage;

            customMessageBox.ShowDialog();

            if (customMessageBox.Result == "OK")
            {
                await DeleteEquipmentID.DeleteEquipmentIDAsync(equip_id);
                NavigationService.Refresh();
            }
        }

        private void Btn_exportCSV_Click(object sender, RoutedEventArgs e)
        {
            ExportFile.ExportCSV(dg_equipments);
        }
    }
}