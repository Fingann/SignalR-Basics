using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace ServerHub
{
    public class Program
    {
        public static void Main(string[] args)
        {


            string url = @"http://"+ GetLocalIPAddress()+":9676/";
            using (var server = WebApp.Start<Startup>(url))
            {

                Console.WriteLine(string.Format("Server running at {0}", url));
                 
                Console.ReadLine();
            }
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
        public static string GetLocalFQDN()
        {
            var props = IPGlobalProperties.GetIPGlobalProperties();
            return props.HostName + (string.IsNullOrWhiteSpace(props.DomainName) ? "" : "." + props.DomainName);
        }


    }
}