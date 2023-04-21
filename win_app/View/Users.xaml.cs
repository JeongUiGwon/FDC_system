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
    /// Users.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Users : Page
    {
        public Users()
        {
            InitializeComponent();

            var converter = new BrushConverter();
            ObservableCollection<SOM.Model.UsersModel> users = new ObservableCollection<SOM.Model.UsersModel>();

            //Create DataGrid Items Info
            users.Add(new SOM.Model.UsersModel { Number = "1", Character = "A", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "정의권", Position = "Guest", Email = "jek9412@naver.com", Phone = "010-9999-9999" });
            users.Add(new SOM.Model.UsersModel { Number = "2", Character = "B", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "채민기", Position = "Guest", Email = "jek9412@naver.com", Phone = "010-9999-9999" });
            users.Add(new SOM.Model.UsersModel { Number = "3", Character = "C", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "김지선", Position = "Guest", Email = "jek9412@naver.com", Phone = "010-9999-9999" });
            users.Add(new SOM.Model.UsersModel { Number = "4", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "임상빈", Position = "Guest", Email = "jek9412@naver.com", Phone = "010-9999-9999" });
            users.Add(new SOM.Model.UsersModel { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "조성환", Position = "Guest", Email = "jek9412@naver.com", Phone = "010-9999-9999" });
            users.Add(new SOM.Model.UsersModel { Number = "6", Character = "F", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "최명서", Position = "Guest", Email = "jek9412@naver.com", Phone = "010-9999-9999" });
            users.Add(new SOM.Model.UsersModel { Number = "7", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "장재현", Position = "Owner", Email = "jek9412@naver.com", Phone = "010-9999-9999" });
            users.Add(new SOM.Model.UsersModel { Number = "8", Character = "H", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "주해린", Position = "Owner", Email = "jek9412@naver.com", Phone = "010-9999-9999" });
            users.Add(new SOM.Model.UsersModel { Number = "9", Character = "I", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "박소정", Position = "Owner", Email = "jek9412@naver.com", Phone = "010-9999-9999" });
            users.Add(new SOM.Model.UsersModel { Number = "10", Character = "J", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "문성현", Position = "Owner", Email = "jek9412@naver.com", Phone = "010-9999-9999" });

            UsersDatagrid.ItemsSource = users;
        }
    }
}
