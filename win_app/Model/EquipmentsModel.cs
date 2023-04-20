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
        public string ID { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public string Interlock_ID { get; set; }
        public string Creator { get; set; }

        public DateTime Created_at { get; set; }
        public string Modifier { get; set; }

        public DateTime Updated_at { get; set; }

        public EquipmentsModel(string ID, string Name, int State, string Interlock_ID, string Creator, DateTime Created_at, string Modifier, DateTime Updated_at) 
        {
            this.ID = ID;
            this.Name = Name;
            this.State = State;
            this.Interlock_ID = Interlock_ID;
            this.Creator = Creator;
            this.Created_at = Created_at;
            this.Modifier = Modifier;
            this.Updated_at = Updated_at;
        }
    }
}
