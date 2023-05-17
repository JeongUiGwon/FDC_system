using System;

namespace SOM.Model
{
    public class AutoRangeModel
    {
        public int id { get; set; }
        public float min_range { get; set; }
        public float max_range { get; set; }
        public float min_value { get; set; }
        public float max_value { get; set; }
        public int interval { get; set; }
        public int range { get; set; }
        public Nullable<float> prev_usl { get; set; }
        public Nullable<float> prev_lsl { get; set; }
        public string type { get; set; }

        public DateTime created_at { get; set; }
        public bool is_active { get; set; }
        public string task_id { get; set; }
        public string param { get; set; }
    }
}
