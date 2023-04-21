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
    /// RecipePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RecipePage : Page
    {
        public RecipePage()
        {
            InitializeComponent();

            ObservableCollection<RecipeModel> recipes = new ObservableCollection<RecipeModel>();

            recipes.Add(new RecipeModel("abcd", "abcd", "abcd", "Recipe1", 100, 200, "Action1", "Action2", 1, "정의권", DateTime.Now, "정의권", DateTime.Now));
            recipes.Add(new RecipeModel("dfad", "dfad", "dfad", "Recipe2", 200, 300, "Action3", "Action4", 1, "채민기", DateTime.Now, "채민기", DateTime.Now));
            recipes.Add(new RecipeModel("asdfb", "asdfb", "asdfb", "Recipe3", 150, 200, "Action5", "Action6", 1, "김지선", DateTime.Now, "김지선", DateTime.Now));
            recipes.Add(new RecipeModel("asbdw", "asbdw", "asbdw", "Recipe4", 10, 200, "Action7", "Action8", 1, "임상빈", DateTime.Now, "임상빈", DateTime.Now));
            recipes.Add(new RecipeModel("herd", "herd", "herd", "Recipe5", 10, 250, "Action9", "Action10", 1, "조성환", DateTime.Now, "조성환", DateTime.Now));

            RecipeDatagrid.ItemsSource = recipes;
        }
    }
}
