using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;


namespace ServerHub
{
    class Program
    {
        static void Main(string[] args)
        {


            string url = @"http://localhost:8080/";
            using (var server = WebApp.Start<Startup>(url))
            {

                Console.WriteLine(string.Format("Server running at {0}", url));
                Console.ReadLine();
            }
        }


    }
}