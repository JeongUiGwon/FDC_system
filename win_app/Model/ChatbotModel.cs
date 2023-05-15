using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class ChatbotModel
    {
        public string query { get; set; }
        public string result { get; set; }
        public string answer { get; set; }
        public ChatbotModel(string query, string result, string answer)
        {
            this.query = query;
            this.result = result;
            this.answer = answer;
        }
    }
}
