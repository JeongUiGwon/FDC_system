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
        public float lsl { get; set; }
        public float usl { get; set; }
        public string lsl_interlock_action { get; set; }
        public string usl_interlock_action { get; set; }
        public string recipe_use { get; set; }
        public string creator_name { get; set; }
        public Nullable<DateTime> created_at { get; set; }
        public string modifier_name { get; set; }
        public Nullable<DateTime> updated_at { get; set; }
        public string equipment { get; set; }
        public string param { get; set; }

        public RecipeModel() { }

        public RecipeModel(string recipe_id, string recipe_name, float lsl, float usl, string lsl_interlock_action, string usl_interlock_action, string recipe_use, string creator_name, Nullable<DateTime> created_at, string modifier_name, Nullable<DateTime> updated_at, string equipment, string param)
        {
            this.recipe_id = recipe_id;
            this.recipe_name = recipe_name;
            this.lsl = lsl;
            this.usl = usl;
            this.lsl_interlock_action = lsl_interlock_action;
            this.usl_interlock_action = usl_interlock_action;
            this.recipe_use = recipe_use;
            this.creator_name = creator_name;
            this.created_at = created_at;
            this.modifier_name = modifier_name;
            this.updated_at = updated_at;
            this.equipment = equipment;
            this.param = param;
        }
    }
}
