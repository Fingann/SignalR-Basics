using Microsoft.AspNet.SignalR.Client;
using SignalRTests.Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.Hubs
{
    public class MessageHub: HubFinder
    {
        public MessageHub()
        {           
            base.Hub.On<ChatMessage>("recievChatMessage", hello => DisplayMessage(hello));
        }
  
        //messages to send
        public void SendMessage(ChatMessage message)
        {
            base.Hub.Invoke("sendMessage", message).Wait();
        }



        //Recieved Messeges


        private void DisplayMessage(ChatMessage hello)
        {
            Console.WriteLine(hello.FromUser + ": " + hello.Message);
        }


       
    }
}
