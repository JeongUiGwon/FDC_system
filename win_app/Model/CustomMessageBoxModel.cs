using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class CustomMessageBoxModel
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public CustomMessageBoxModel(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}
