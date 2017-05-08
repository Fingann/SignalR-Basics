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
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();

            IHubProxy _hub;
            string url = @"http://localhost:8080/";
            var connection = new HubConnection(url,new Dictionary<string, string>() { {"Username", username } });
            _hub = connection.CreateHubProxy("TestHub");
            _hub.On("ReceiveLength", x => Console.WriteLine(x));

            _hub.On("mess",new Action<string,string>((s, s1) => Console.WriteLine(s +": "+s1)));
            connection.Start().Wait();

            string line = null;
            while ((line = Console.ReadLine()) != null)
            {
                Console.WriteLine("to user:");
                var toUser = Console.ReadLine();
                _hub.Invoke("Message", Serializer<ChatMessage>.Serialize(new ChatMessage(toUser,line))).Wait();
            }

            
        }

    }
    public static class Serializer<T> where T:class
    {
        public static string Serialize(T Object)
        {
            return JsonConvert.SerializeObject(Object);
        }

        public static T Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

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
