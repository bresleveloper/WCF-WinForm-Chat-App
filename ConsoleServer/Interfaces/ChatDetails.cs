using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    [DataContract]
    public class ChatDetails
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int FromNumOved { get; set; }
        [DataMember]
        public int ToNumOved { get; set; }
        [DataMember]
        public string FromUserAd { get; set; }
        [DataMember]
        public string ToUserAd { get; set; }
        [DataMember]
        public string FromUserHeb { get; set; }
        [DataMember]
        public string ToUserHeb { get; set; }

        [DataMember]
        public string odaa { get; set; }
        [DataMember]
        public bool ReadOdaa { get; set; }
        [DataMember]
        public DateTime dateAdd { get; set; }
        [DataMember]
        public DateTime? dateRead { get; set; }
    }
}
