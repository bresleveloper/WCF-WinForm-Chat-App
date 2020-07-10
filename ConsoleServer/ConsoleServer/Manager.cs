using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    class Manager
    {
        Server server;
        private List<IClient> myClientsChannels = new List<IClient>();
        private List<ClientInstance> myClients = new List<ClientInstance>();
        private void verifyList()
        {
            myClients = myClients.Where(c => ((ICommunicationObject)c.client).State == CommunicationState.Opened).ToList();
        }

        public Manager(Server _server)
        {
            server = _server;
            server.ClientRegistered += Server_ClientRegistered;
            server.AkskingClientsList += Server_AkskingClientsList;
        }

        private void Server_AkskingClientsList(IClient clientChannel)
        {
            verifyList();
            //clientChannel.RecieveClientsList(myClients.Select(c=>c.name).ToArray());
        }

        private void Server_ClientRegistered(string clientName, IClient clientChannel)
        {
            myClients.Add(new ClientInstance()
            {
                client = clientChannel, name = clientName
            });
            Console.WriteLine("new guy - " + clientName);
        }

        public void Broadcast(string msg)
        {
            verifyList();
            foreach (ClientInstance client in myClients)
                client.client.PrintBroadcastMessage(msg);
        }

 
    }

    class ClientInstance
    {
        public IClient client { get; set; }
        public string name { get; set; }
    }
}
