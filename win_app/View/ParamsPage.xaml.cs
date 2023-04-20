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
    /// ParamsPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ParamsPage : Page
    {
        public ParamsPage()
        {
            InitializeComponent();

            ObservableCollection<ParamsModel> paramsModel = new ObservableCollection<ParamsModel>();

            paramsModel.Add(new ParamsModel("abcd", "abcd", "param1", "S", 1, 0, "정의권", DateTime.Now, "정의권", DateTime.Now));
            paramsModel.Add(new ParamsModel("efgh", "efgh", "param2", "S", 1, 0, "채민기", DateTime.Now, "채민기", DateTime.Now));
            paramsModel.Add(new ParamsModel("ijkl", "ijkl", "param3", "S", 1, 0, "김지선", DateTime.Now, "김지선", DateTime.Now));
            paramsModel.Add(new ParamsModel("zxcv", "zxcv", "param4", "S", 1, 0, "임상빈", DateTime.Now, "임상빈", DateTime.Now));

            ParamsDatagrid.ItemsSource = paramsModel;
        }
    }
}
