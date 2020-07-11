using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public static class Names
    {
        //public static string Address = "net.tcp://localhost:21600/WeWillLearn";
        //public static string Endpoint = "WeShallPrevail";
        public static string Address = ConfigurationManager.AppSettings["myAddress"];
        public static string Endpoint = ConfigurationManager.AppSettings["myContractEndpoint"];

    }

    public delegate void sendMsg(string msg);
    public delegate void sendData(object[] data);
    public delegate void recieveChatData(ChatDetails[] chatHistory, ChatUser from);

}
