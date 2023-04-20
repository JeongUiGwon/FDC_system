using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class RecipeModel
    {
        public string ID { get; set; }
        public string Equipment_ID { get; set; }
        public string Param_ID { get; set; }
        public string Name { get; set; }
        public int LSL { get; set; }
        public int USL { get; set; }
        public string LSL_Action { get; set; }
        public string USL_Action { get; set; }
        public int State { get; set; }
        public string Creator { get; set; }
        public DateTime Created_at { get; set; }
        public string Modifier { get; set; }
        public DateTime Updated_at { get; set; }

        public RecipeModel(string ID, string Equipment_ID, string Param_ID, string Name, int LSL, int USL, string LSL_Action, string USL_Action, int State, string Creator, DateTime Created_at, string Modifier, DateTime Updated_at)
        {
            this.ID = ID;
            this.Equipment_ID = Equipment_ID;
            this.Param_ID = Param_ID;
            this.Name = Name;
            this.LSL = LSL;
            this.USL = USL;
            this.LSL_Action = LSL_Action;
            this.USL_Action = USL_Action;
            this.State = State;
            this.Creator = Creator;
            this.Created_at = Created_at;
            this.Modifier = Modifier;
            this.Updated_at = Updated_at;
        }
    }
}
