using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class InterlockModel
    {
        public string Equipment_ID { get; set; }
        public string Equipment_Name { get; set; }
        public string Interlock_ID { get; set; }
        public string Interlock_Name { get; set; }
        public string Param_ID { get; set; }
        public string Recipe_ID { get; set; }
        public string LOT_ID { get; set; }
        public int Type { get; set; }
        public int Out_Count { get; set; }
        public int LSL { get; set; }
        public int USL { get; set; }
        public string LSL_Action { get; set; }
        public string USL_Action { get; set; }
        public int Data_Value { get; set; }
        public DateTime Created_at { get; set; }

        public InterlockModel(string Equipment_ID, string Equipment_Name, string Interlock_ID, string Interlock_Name, string Param_ID, string Recipe_ID, string LOT_ID, int Type, int Out_Count, int LSL, int USL, string LSL_Action, string USL_Action, int Data_Value, DateTime Created_at)
        {
            this.Equipment_ID = Equipment_ID;
            this.Equipment_Name = Equipment_Name;
            this.Interlock_ID = Interlock_ID;
            this.Interlock_Name = Interlock_Name;
            this.Param_ID = Param_ID;
            this.Recipe_ID = Recipe_ID;
            this.LOT_ID = LOT_ID;
            this.Type = Type;
            this.Out_Count = Out_Count;
            this.LSL = LSL;
            this.USL = USL;
            this.LSL_Action = LSL_Action;
            this.USL_Action = USL_Action;
            this.Data_Value = Data_Value;
            this.Created_at = Created_at;
        }
    }
}
