using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    internal class ParamsModel
    {
        public string ID { get; set; }
        public string Equipment_ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int State { get; set; }
        public int Out_Count { get; set; }
        public string Creator { get; set; }
        public DateTime Created_at { get; set; }
        public string Modifier { get; set; }
        public DateTime Updated_at { get; set; }

        public ParamsModel(string ID, string Equipment_ID, string Name, string Type, int State, int Out_Count, string Creator, DateTime Created_at, string Modifier, DateTime Updated_at)
        {
            this.ID = ID;
            this.Equipment_ID = Equipment_ID;
            this.Name = Name;
            this.Type = Type;
            this.State = State;
            this.Out_Count = Out_Count;
            this.Creator = Creator;
            this.Created_at = Created_at;
            this.Modifier = Modifier;
            this.Updated_at = Updated_at;
        }
    }
}
