using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class ChatModel
    {
        public string question { get; set; }
        public string answer { get; set; }

        public ChatModel(string question, string answer)
        {
            this.question = question;
            this.answer = answer;
        }
    }
}
