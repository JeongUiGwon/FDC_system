using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class ParamLogModel
    {
        public int log_id { get; set; }
        public string factory_id { get; set; }
        public float param_value { get; set; }
        public string equipment { get; set; }
        public string param { get; set; }
        public string recipe { get; set; }
        public Nullable<DateTime> created_at { get; set; }

        public ParamLogModel(int log_id, string factory_id, float param_value, string equipment, string param, string recipe, Nullable<DateTime> Created_at)
        {
            this.log_id = log_id;
            this.factory_id = factory_id;
            this.param_value = param_value;
            this.equipment = equipment;
            this.created_at = Created_at;
            this.param = param;
            this.recipe = recipe;
        }
    }
}
