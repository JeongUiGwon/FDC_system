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

namespace SOM.View
{
    /// <summary>
    /// Equipments.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Equipments : Page
    {
        public Equipments()
        {
            InitializeComponent();

            ObservableCollection<EquipmentsModel> equipments = new ObservableCollection<EquipmentsModel>();

            equipments.Add(new EquipmentsModel("abcd", "Equip1", 1, "abcd", "정의권", DateTime.Now, "정의권", DateTime.Now));
            equipments.Add(new EquipmentsModel("efgh", "Equip2", 1, "efgh", "채민기", DateTime.Now, "채민기", DateTime.Now));
            equipments.Add(new EquipmentsModel("higk", "Equip2", 1, "higk", "김지선", DateTime.Now, "김지선", DateTime.Now));

            EquipmentsDatagrid.ItemsSource = equipments;
        }
    }
}
