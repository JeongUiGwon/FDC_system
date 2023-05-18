using SOM.Model;
using SOM.View.Equipment;
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
using System.Windows.Shapes;

namespace SOM.View.Param
{
    /// <summary>
    /// GetParamModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GetParamModal : Window
    {
        public string Result;
        public GetParamModal()
        {
            InitializeComponent();
        }

        private void Btn_SearchEquipment_Click(object sender, EventArgs e)
        {
            var Modal = new SearchEquipmentIDModal();
            Modal.ShowDialog();

            string equip_id = Modal.Result;
            Tb_EquipID.Text = equip_id;
        }

        private void btn_addItems_click(object sender, EventArgs e)
        {
            var filteredItems = dg_params.ItemsSource as ObservableCollection<ParamsModel>;

            if (filteredItems != null)
            {
                foreach (var item in filteredItems)
                {
                    dg_selectedParams.Items.Add(item);
                }
            }
        }

        private void btn_deleteItems_click(object sender, EventArgs e)
        {
            dg_selectedParams.Items.Clear();
        }

        private void btn_addItem_click(object sender, EventArgs e)
        {
            ParamsModel selectedItem = dg_params.SelectedItem as ParamsModel;
            if (selectedItem != null)
            {
                dg_selectedParams.Items.Add(selectedItem);
            }
        }

        private void btn_deleteItem_click(object sender, EventArgs e)
        {
            ParamsModel selectedItem = dg_selectedParams.SelectedItem as ParamsModel;

            if (selectedItem != null)
            {
                dg_selectedParams.Items.Remove(selectedItem);
            }
        }

        private void btn_apply_click(object sender, EventArgs e)
        {
            var selectedItems = dg_selectedParams.Items;

            foreach (ParamsModel item in selectedItems)
            {
                Result += item.param_id.ToString() + ',';
            }
            this.Close();
        }

        private void btn_cancel_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
