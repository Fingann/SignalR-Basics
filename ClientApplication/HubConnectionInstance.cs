using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
  
    public sealed class HubConnectionInstance
    {
        private static readonly HubConnectionInstance instance = new HubConnectionInstance();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static HubConnectionInstance()
        {
            
        }

        private HubConnectionInstance()
        {
          
        }

        public static HubConnectionInstance Instance
        {
            get
            {
                return instance;
            }
        }

        public void Start()
        {
            string nspace = "ClientApplication.Hubs";

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace
                    select t;
            foreach (var hub in q)
            {
                Proxys.Add(hub.Name, HubConnection.CreateHubProxy(hub.Name));
            }
            HubConnection.Start().ContinueWith(task => {
                    if (task.IsFaulted)
                    {
                        Console.WriteLine("There was an error opening the connection:{0}",
                                          task.Exception.GetBaseException());
                    }
                    else
                    {
                        Console.WriteLine("Connected");
                    }

                }).Wait();

            }

        public string URL { get; set; }
        public string ID { get
            {
                return HubConnection.ConnectionId;
            }
        } 

        public HubConnection HubConnection { get; set; }

        public Dictionary<string, IHubProxy> Proxys = new Dictionary<string, IHubProxy>();

        public IHubProxy GetProxy (string proxy)
        {
            return Proxys[proxy];
        }

    }
}
