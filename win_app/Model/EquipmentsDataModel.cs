using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class EquipmentsDataModel
    {
        public string Equipment_ID { get; set; }
        public string Equipment_Name { get; set; }
        public string LOT_ID { get; set; }
        public string Recipe_ID { get; set; }
        public string Param_ID { get; set; }
        public int Data_Value { get; set; }
        public DateTime Created_at { get; set; }

        public EquipmentsDataModel(string Equipment_ID, string Equipment_Name, string LOT_ID, string Recipe_ID, string Param_ID, int Data_Value, DateTime Created_at)
        {
            this.Equipment_ID = Equipment_ID;
            this.Equipment_Name = Equipment_Name;
            this.LOT_ID = LOT_ID;
            this.Recipe_ID = Recipe_ID;
            this.Param_ID = Param_ID;
            this.Data_Value = Data_Value;
            this.Created_at = Created_at;
        }
    }
}
