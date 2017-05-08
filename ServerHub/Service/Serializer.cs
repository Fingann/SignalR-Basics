using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServerHub.Service
{
    public static class Serializer<T> where T : class
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
}
