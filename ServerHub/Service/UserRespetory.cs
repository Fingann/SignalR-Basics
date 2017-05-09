using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHub.Service
{
    public static class UserRespetory
    {
        public static ConcurrentDictionary<string,string> Users = new ConcurrentDictionary<string, string>();

        public static string GetUser(string id)
        {
            var user = string.Empty;
            Users.TryGetValue(id, out user);
            return user;
        }

        public static string GetId(string userName)
        {
            var id = Users.Where(x => x.Value == userName).Select(x => x.Key).First();

            return id;
        }

        public static void AddUser(string id, string username)
        {
            Users.TryAdd(id,username);
        }

        public static void DeleteUser(string id)
        {
            string id2;
            Users.TryRemove(id, out id2);
        }
    }
}
