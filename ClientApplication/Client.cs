using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using SignalRTests.Core.Models.Shared;
using SignalRTests.Core.Service;
using ClientApplication.Hubs;

namespace ClientApplication
{
    class Client
    {
        public Client(string userName)
        {
            Username = userName;
        }
        public string Username { get; set; }

        public void Run()
        {

            MessageHub _messageHub = new MessageHub();


            while (true)
            {
                Console.WriteLine("Choose User to talk to:");
                string user = Console.ReadLine();
                var toList = new List<string>();
                toList.Add(user);
                if (user == "c") return;
                var Messege = new ChatMessage(toList, user);
                while (true)
                {
                    Console.Write("Message :");
                    string line = null;
                    while ((line = Console.ReadLine()) != null)
                    {
                        if (line == "b") break;

                        Messege.Message = line;
                        _messageHub.SendMessage(Messege);
                    }
                }
            }





            



            //IHubProxy _hub;
            //string url = "http://10.110.4.78:9676/";
            //var connection = new HubConnection(url, new Dictionary<string, string>() { { "Username", Username } });
            //_hub = connection.CreateHubProxy("TestHub");



            ////_hub.On("mess", new Action<string, string>((s, s1) => Console.WriteLine("From " + s + ": " + s1)));

            //_hub.On<ChatMessage>("recievChatMessage", hello => DisplayMessage(hello));

            //connection.Start().ContinueWith(task => {
            //    if (task.IsFaulted)
            //    {
            //        Console.WriteLine("There was an error opening the connection:{0}",
            //                          task.Exception.GetBaseException());
            //    }
            //    else
            //    {
            //        Console.WriteLine("Connected");
            //    }

            //}).Wait();

            //Console.WriteLine("enter c to quit program, b to exit Converstation");
            //while (true)
            //{
            //    Console.WriteLine("Choose User to talk to:");
            //    string user = Console.ReadLine();
            //    if (user == "c") return;
            //    var Messege = new ChatMessage() { FromUser = Username, ToUser = new List<string>(), };
            //    while (true)
            //    {
            //        Console.Write("Message :");
            //        string line = null;
            //        while ((line = Console.ReadLine()) != null)
            //        {
            //            if (line == "b") break;

            //            Messege.Message = line;
            //            _hub.Invoke("sendMessage", Messege).Wait();
            //        }
            //    }
            //}
        }


        public void DisplayMessage(ChatMessage message)
        {
            Console.WriteLine("From " + message.FromUser + ": " + message.Message);
        }

    }
   

 

}
