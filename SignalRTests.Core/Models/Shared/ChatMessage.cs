using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTests.Core.Models.Shared
{
    public class ChatMessage : Recipients
    {
        public ChatMessage(List<string> ToUsers, string fromUser): base(ToUsers,fromUser)
        {
           
        }
      
        public ChatMessage()
        {

        }
        public string Message { get; set; }

       
    }
}
