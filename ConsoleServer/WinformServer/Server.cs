using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                    ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Server : IServer
    {
        public event AksClientsListHandler AkskingClientsList;
        public delegate void AksClientsListHandler(string clientADName, IClient clientChannel);
        public void AksClientsList(string clientADName)
        {
            IClient clientChannel = OperationContext.Current.GetCallbackChannel<IClient>();
            AkskingClientsList(clientADName, clientChannel);
        }


        public event ClientRegisteredHandler ClientRegistered;
        public delegate void ClientRegisteredHandler(string clientName, IClient clientChannel);
        public void Register(string clientADName)
        {
            IClient clientChannel = OperationContext.Current.GetCallbackChannel<IClient>();
            ClientRegistered(clientADName, clientChannel);
        }

        public event UsersChatHistoryHandler AksUsersChatHistoryEvent;
        public delegate void UsersChatHistoryHandler(ChatUser a, ChatUser b);
        public void AksUsersChatHistory(ChatUser a, ChatUser b)
        {
            //they should both get the history and open a chat
            AksUsersChatHistoryEvent(a, b);
        }

        public event ClientSayHandler ClientSayEvent;
        public delegate void ClientSayHandler(string msg, ChatUser clientFrom, ChatUser clientTo);
        public void ClientSay(string msg, ChatUser clientFrom, ChatUser clientTo)
        {
            ClientSayEvent(msg, clientFrom, clientTo);
        }

        public event sendMsg BroadcastEvent;
        public void Broadcast(string msg)
        {
            BroadcastEvent(msg);
        }
    }
}
