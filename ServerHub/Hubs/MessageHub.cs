using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using ServerHub.Models;
using ServerHub.Service;

namespace ServerHub.Hubs
{
    [HubName("TestHub")]
    public class MessageHub : ExtetendedHub
    {
       
        public void Message(string message)
        {
            var RecivedMessage = Serializer<ChatMessage>.Deserialize(message);
           
            Console.WriteLine(UserRespetory.GetUser(Context.ConnectionId) + ": " + RecivedMessage.Message);
            Clients.Client(UserRespetory.GetId(RecivedMessage.ToUsername)).mess(UserRespetory.GetUser(Context.ConnectionId),RecivedMessage.Message);
            //Clients.All.ReceiveLength(RecivedMessage.ClientID + ": " + RecivedMessage.Message);
           
        }
    }
    

  
}

