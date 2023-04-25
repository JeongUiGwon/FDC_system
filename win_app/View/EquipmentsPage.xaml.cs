using SOM.Model;
using SOM.Services;
using SOM.View.Modal;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SOM.View
{
    /// <summary>
    /// Equipments.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EquipmentsPage : Page
    {
        public EquipmentsPage()
        {
            InitializeComponent();
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

            var result = MessageBox.Show("Are you sure you want to remove this equipment information?", "Remove Equipment", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                await DeleteEquipmentID.DeleteEquipmentIDAsync(equip_id);
                NavigationService.Refresh();
            }
        }
    }
}