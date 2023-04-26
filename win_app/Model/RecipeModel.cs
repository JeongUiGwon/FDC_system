using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class RecipeModel
    {
        public string recipe_id { get; set; }
        public string recipe_name { get; set; }
        public int lsl { get; set; }
        public int usl { get; set; }
        public string lsl_action { get; set; }
        public string usl_action { get; set; }
        public string recipe_state { get; set; }
        public string creator_name { get; set; }
        public Nullable<DateTime> created_at { get; set; }
        public string modifier_name { get; set; }
        public Nullable<DateTime> updated_at { get; set; }
        public string equipment { get; set; }
        public string param { get; set; }

        public RecipeModel(string recipe_id, string recipe_name, int lsl, int usl, string lsl_action, string usl_action, string recipe_state, string creator_name, Nullable<DateTime> created_at, string modifier_name, Nullable<DateTime> updated_at, string equipment, string param)
        {
            this.recipe_id = recipe_id;
            this.recipe_name = recipe_name;
            this.lsl = lsl;
            this.usl = usl;
            this.lsl_action = lsl_action;
            this.usl_action = usl_action;
            this.recipe_state = recipe_state;
            this.creator_name = creator_name;
            this.created_at = created_at;
            this.modifier_name = modifier_name;
            this.updated_at = updated_at;
            this.equipment = equipment;
            this.param = param;
        }
    }
}
