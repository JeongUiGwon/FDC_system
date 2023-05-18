using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class FullPatternModel
    {
        public int id { get; set; }
        public float min_error { get; set; }
        public float max_error { get; set; }
        public float min_range { get; set; }
        public float max_range { get; set; }
        public int pattern_range { get; set; }
        public string type { get; set; }
        public DateTime created_at { get; set; }
        public bool is_active { get; set; }
        public string param { get; set; }

        public FullPatternModel() { }

        public FullPatternModel(int id, float min_error, float max_error, float min_range, float max_range, int pattern_range, string type, DateTime created_at, bool is_active, string param)
        {
            this.id = id;
            this.min_error = min_error;
            this.max_error = max_error;
            this.min_range = min_range;
            this.max_range = max_range;
            this.pattern_range = pattern_range;
            this.type = type;
            this.created_at = created_at;
            this.is_active = is_active;
            this.param = param;
        }
    }
}
