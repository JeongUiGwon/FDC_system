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
        public string equipment_name { get; set; }
        public string param_name { get; set; }
        public string recipe_name { get; set; }
        public bool is_interlock { get; set; }
        public DateTime created_at { get; set; }

        public ParamLogModel(int log_id, string factory_id, float param_value, string equipment, string param, string recipe, string equipment_name, string param_name, string recipe_name, bool is_interlock, DateTime Created_at)
        {
            this.log_id = log_id;
            this.factory_id = factory_id;
            this.param_value = param_value;
            this.equipment = equipment;
            this.equipment_name = equipment_name;
            this.param_name = param_name;
            this.recipe_name = recipe_name;
            this.created_at = Created_at;
            this.param = param;
            this.recipe = recipe;
            this.is_interlock = is_interlock;
        }
    }
}
