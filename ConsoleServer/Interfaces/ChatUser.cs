using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    [DataContract]
    public class ChatUser
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int NumOved { get; set; }
        [DataMember]
        public string UserAd { get; set; }
        [DataMember]
        public string UserHeb { get; set; }
        [DataMember]
        public bool ArshaaAdmin { get; set; }

        [DataMember]
        public bool IsConnected { get; set; }
        [DataMember]
        public bool HasMessageForYou { get; set; }
    }
}
