using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class RoleModel
    {
        public List<string> Roles { get; set; } = new List<string>()
        {
            "Guest",
            "Maintainer",
            "Admin"
        };
    }
}
