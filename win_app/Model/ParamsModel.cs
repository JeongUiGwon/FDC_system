using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class ParamsModel
    {
        public string param_id { get; set; }
        public string param_name { get; set; }
        public string param_level { get; set; }
        public string param_state { get; set; }
        public string creator_name { get; set; }
        public Nullable<DateTime> created_at { get; set; }
        public string modifier_name { get; set; }
        public Nullable<DateTime> updated_at { get; set; }
        public string equipment { get; set; }
        public bool is_autorange { get; set; }

        public ParamsModel() { }
        public ParamsModel(string param_id, string equipment, string param_name, string param_level, string param_state, string creator_name, Nullable<DateTime> created_at, string modifier_name, Nullable<DateTime> updated_at)
        {
            this.param_id = param_id;
            this.equipment = equipment;
            this.param_name = param_name;
            this.param_level = param_level;
            this.param_state = param_state;
            this.creator_name = creator_name;
            this.created_at = created_at;
            this.modifier_name = modifier_name;
            this.updated_at = updated_at;
        }
    }
}
