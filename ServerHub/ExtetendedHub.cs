using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using ServerHub.Service;

namespace ServerHub
{
    public abstract class ExtetendedHub: Hub
    {
        public override Task OnConnected()
        {
            var user = Context.QueryString.Get("Username");
            UserRespetory.AddUser(Context.ConnectionId, user);
            Console.WriteLine(DateTime.Now + " - " + user + " Connected.");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var user = Context.QueryString.Get("Username");
            UserRespetory.DeleteUser(Context.ConnectionId);
            Console.WriteLine(DateTime.Now + " - " + user + " Disconnected.");
            return base.OnDisconnected(stopCalled);
        }
    }
}
