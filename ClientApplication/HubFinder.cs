using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
    public class HubFinder
    {
        public HubFinder()
        {
            Hub = HubConnectionInstance.Instance.GetProxy(HubName);
        }
        public string ID => HubConnectionInstance.Instance.ID;

        public string HubName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public IHubProxy Hub;
    }
}
