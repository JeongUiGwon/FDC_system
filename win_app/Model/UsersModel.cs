using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SOM.Model
{
    public class UsersModel
    {
        public string Email { get; set; }
        public string UID { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public ObservableCollection<string> Roles { get; set; }

        public UsersModel(string Email, string UID, string UserName,string Role)
        {
            this.Email = Email;
            this.UID = UID;
            this.UserName = UserName;
            this.Role = Role;
            this.Roles = new ObservableCollection<string> { "Guest", "Maintainer", "Owner" };
        }
    }
}
