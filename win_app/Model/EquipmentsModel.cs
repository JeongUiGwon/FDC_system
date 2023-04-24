using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SOM.Model
{
    public class EquipmentsModel
    {
        public string equipment_id { get; set; }
        public string equipment_name { get; set; }
        public string equipment_state { get; set; }
        public string creater_name { get; set; }

        public DateTime created_at { get; set; }
        public string modifier_name { get; set; }

        public DateTime updated_at { get; set; }
        public string interlock_id { get; set; }

        public EquipmentsModel(string ID, string Name, string State, string Interlock_ID, string Creator, DateTime Created_at, string Modifier, DateTime Updated_at) 
        {
            this.equipment_id = ID;
            this.equipment_name = Name;
            this.equipment_state = State;
            this.creater_name = Creator;
            this.created_at = Created_at;
            this.modifier_name = Modifier;
            this.updated_at = Updated_at;
            this.interlock_id = Interlock_ID;
        }
    }
}
