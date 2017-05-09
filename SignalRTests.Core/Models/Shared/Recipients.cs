using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SignalRTests.Core.Models.Shared
{
    public  class Recipients
    {
        public Recipients(IEnumerable<string> toUsers, string fromUser)
        {
            FromUser = fromUser;
            ToUsers = toUsers;
        }

        public Recipients()
        {

        }

        public  string FromUser { get; set; }

        public IEnumerable<String> ToUsers { get; set; } = new List<string>();
    }
}
