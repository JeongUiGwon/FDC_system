using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class ParamHistoryModel
    {
        public int log_id { get; set; }
        public string action { get; set; }
        public Nullable<DateTime> created_at { get; set; }
        public string param_name { get; set; }
        public string param { get; set; }
        public ParamsModel old_value { get; set; }
        public ParamsModel new_value { get; set; }
        public string str_old_value { get; set; }
        public string str_new_value { get; set; }

        public ParamHistoryModel(int log_id, string action, Nullable<DateTime> created_at, string param_name, string param, ParamsModel old_value, ParamsModel new_value)
        {
            this.log_id = log_id;
            this.action = action;
            this.param_name = param_name;
            this.param = param;
            this.created_at = created_at;
            this.old_value = old_value;
            this.new_value = new_value;
            this.str_old_value = JsonConvert.SerializeObject(str_old_value);
            this.str_new_value = JsonConvert.SerializeObject(str_new_value);
        }
    }
}
