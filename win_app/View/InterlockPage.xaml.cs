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
    /// InterlockPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InterlockPage : Page
    {
        public InterlockPage()
        {
            InitializeComponent();

            ObservableCollection<InterlockModel> interlocks = new ObservableCollection<InterlockModel>();

            interlocks.Add(new InterlockModel("abcd", "권취", "abcd", "권취", "sagwes", "dfkjas", "gddks", 1, 0, 100, 200, "Warning", "Warning", 120, DateTime.Now));
            interlocks.Add(new InterlockModel("gsdd", "권취", "gsdd", "권취", "gwdsd", "asdge", "bsdxds", 1, 0, 100, 200, "Mailing", "Mailing", 120, DateTime.Now));
            interlocks.Add(new InterlockModel("gswe", "권취", "gswe", "권취", "gswew", "gdxcd", "wefsd", 1, 0, 100, 200, "Interlock", "Interlock", 120, DateTime.Now));
            interlocks.Add(new InterlockModel("gdsw", "권취", "gdsw", "권취", "sagwes", "dfkjas", "gddks", 1, 0, 100, 200, "Warning", "Warning", 120, DateTime.Now));
            interlocks.Add(new InterlockModel("weds", "권취", "weds", "권취", "gsdfd", "wefds", "gdswd", 1, 0, 100, 200, "Warning", "Warning", 120, DateTime.Now));

            InterlockDatagrid.ItemsSource = interlocks;
        }
    }
}
