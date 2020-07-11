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
        public void ClientSay(string msg, string clientName)
        {
            throw new NotImplementedException();
        }

        public event AksClientsListHandler AkskingClientsList;
        public delegate void AksClientsListHandler(IClient clientChannel);
        public void AksClientsList()
        {
            IClient clientChannel = OperationContext.Current.GetCallbackChannel<IClient>();
            AkskingClientsList(clientChannel);
        }


        public event ClientRegisteredHandler ClientRegistered;
        public delegate void ClientRegisteredHandler(string clientName, IClient clientChannel);
        public void Register(string clientName)
        {
            IClient clientChannel = OperationContext.Current.GetCallbackChannel<IClient>();
            ClientRegistered(clientName, clientChannel);
        }

        public void AksUsersChatHistory(ChatUser a, ChatUser b)
        {
            throw new NotImplementedException();
        }

        public void ClientSay(string msg, ChatUser clientFrom, ChatUser clientTo)
        {
            throw new NotImplementedException();
        }
    }
}
