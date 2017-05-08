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
            UserRespetory.AddUser(Context.ConnectionId,Context.QueryString.Get("Username"));
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            UserRespetory.DeleteUser(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}
