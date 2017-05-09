using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Whats your username: ");
            string username = Console.ReadLine();

            //Instanciate the HubClient
            string url = "http://10.110.4.78:9676/";
            HubConnectionInstance.Instance.HubConnection = new HubConnection(url, new Dictionary<string, string>() { { "Username", username  } });
            HubConnectionInstance.Instance.Start();

            Client client = new Client(username);

            client.Run();


        }
    }

}
