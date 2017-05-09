using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

using ServerHub.Service;
using SignalRTests.Core.Models.Shared;

namespace ServerHub.Hubs
{
    [HubName("MessageHub")]
    public class MessageHub : ExtetendedHub
    {
       
        public void sendMessage(ChatMessage message)
        {
            //var RecivedMessage = Serializer<ChatMessage>.Deserialize(message);
           
            Console.WriteLine(message.FromUser+ " -> " + message.ToUsers.Aggregate((a,b) => a+ ", " +b) + " : " + message.Message);

            List<string> userIDs = new List<string>();
            foreach (var user in message.ToUsers)
            {
                userIDs.Add(UserRespetory.GetId(user));
            }
            Clients.Clients(userIDs).recievChatMessage(message);
           
        }
    }
    

  
}

