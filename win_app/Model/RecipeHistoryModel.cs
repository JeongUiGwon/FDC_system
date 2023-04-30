using Newtonsoft.Json;
using System;

namespace SOM.Model
{
    public class RecipeHistoryModel
    {
        public int log_id { get; set; }
        public string action { get; set; }
        public Nullable<DateTime> created_at { get; set; }
        public string recipe { get; set; }
        public ParamsModel old_value { get; set; }
        public ParamsModel new_value { get; set; }
        public string str_old_value { get; set; }
        public string str_new_value { get; set; }

        public RecipeHistoryModel(int log_id, string action, Nullable<DateTime> created_at, string recipe, ParamsModel old_value, ParamsModel new_value)
        {
            this.log_id = log_id;
            this.action = action;
            this.recipe = recipe;
            this.created_at = created_at;
            this.old_value = old_value;
            this.new_value = new_value;
            this.str_old_value = JsonConvert.SerializeObject(old_value);
            this.str_new_value = JsonConvert.SerializeObject(new_value);
        }
    }
}
