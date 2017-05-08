using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHub.Models
{
    public class ChatMessage
    {
        public ChatMessage(string toUsername, string message)
        {
            ToUsername = toUsername;
            Message = message;
        }

        public string ToUsername { get; set; }
        public string Message { get; set; }
    }
}
