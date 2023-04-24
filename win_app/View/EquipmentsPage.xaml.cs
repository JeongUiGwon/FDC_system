using SOM.Model;
using SOM.Services;
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

        private async void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<EquipmentsModel> response = await GetEquipmentClass.GetEquipmentAsync();

            EquipmentsDatagrid.ItemsSource = response;
        }
    }
}