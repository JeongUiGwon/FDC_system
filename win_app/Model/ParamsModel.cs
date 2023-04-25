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
        public string equipment { get; set; }
        public string param_name { get; set; }
        public string param_type { get; set; }
        public int param_state { get; set; }
        public int out_count { get; set; }
        public string creator_name { get; set; }
        public DateTime created_at { get; set; }
        public string modifier_name { get; set; }
        public DateTime updated_at { get; set; }

        public ParamsModel(string param_id, string equipment, string param_name, string param_type, int param_state, int out_count, string creator_name, DateTime created_at, string modifier_name, DateTime updated_at)
        {
            this.param_id = param_id;
            this.equipment = equipment;
            this.param_name = param_name;
            this.param_type = param_type;
            this.param_state = param_state;
            this.out_count = out_count;
            this.creator_name = creator_name;
            this.created_at = created_at;
            this.modifier_name = modifier_name;
            this.updated_at = updated_at;
        }
    }
}
