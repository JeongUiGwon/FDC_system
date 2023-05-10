using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class InterlockLogModel
    {
        public int log_id { get; set; }
        public string factory_id { get; set; }
        public string equipment_name { get; set; }
        public string cause_equip_id { get; set; }
        public string cause_equip_name { get; set; }
        public DateTime created_at { get; set; }
        public string interlock_type { get; set; }
        public int out_count { get; set; }
        public float lower_limit { get; set; }
        public float upper_limit { get; set; }
        public float data_value { get; set; }
        public string cctv_video_url { get; set; }
        public string equipment { get; set; }
        public string param { get; set; }
        public string param_name { get; set; }
        public string recipe { get; set; }
        public string recipe_name { get; set; }
        public string lot { get; set; }

        public InterlockLogModel(int log_id, string factory_id, string equipment_name, string cause_equip_id, string cause_equip_name, string interlock_type, 
            int out_count, float lower_limit, float upper_limit, float data_value, string cctv_video_url, string equipment, string param, string param_name, string recipe, string recipe_name,
            string lot, DateTime created_at)
        {
            this.log_id = log_id;
            this.factory_id = factory_id;
            this.equipment_name = equipment_name;
            this.cause_equip_id = cause_equip_id;
            this.cause_equip_name = cause_equip_name;
            this.interlock_type = interlock_type;
            this.out_count = out_count;
            this.lower_limit = lower_limit;
            this.upper_limit = upper_limit;
            this.data_value = data_value;
            this.cctv_video_url = cctv_video_url;
            this.created_at = created_at;
            this.equipment = equipment;
            this.param = param;
            this.param_name = param_name;
            this.recipe = recipe;
            this.recipe_name = recipe_name;
            this.lot = lot;
        }
    }
}
