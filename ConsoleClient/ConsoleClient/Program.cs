using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            NetTcpBinding binding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(Names.Address);

            DuplexChannelFactory<IServer> channel = new DuplexChannelFactory<IServer>(
                    client,
                    binding,
                    endpoint + "/" + Names.Endpoint);

            IServer serverProxy = channel.CreateChannel();
            //serverProxy.Register(Environment.UserDomainName + "\\" + Environment.UserName);
            serverProxy.Register("ariel" + DateTime.Now.Minute + DateTime.Now.Millisecond);




            string msg = string.Empty;
            Console.WriteLine("Service is available. Press <exit> to exit.");
            Console.WriteLine();
            Console.WriteLine("for client names enter \"names\"");
            Console.WriteLine();

            while (msg != "exit")
            {
                if (msg == "names")
                {
                    Console.WriteLine();
                    Console.WriteLine("AksClientsList: ");
                    serverProxy.AksClientsList();
                    Console.WriteLine();
                }
                Console.WriteLine("msg to broadcast:");
                msg = Console.ReadLine();
                //mng.Broadcast(msg);
                Console.WriteLine();
            }

            Console.WriteLine("Press <Enter> to terminate the service.");
            Console.WriteLine();
            Console.ReadLine();
        }
    }

    class Client : IClient
    {
        public void PrintBroadcastMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public void RecieveClientsList(ChatUser[] clientList)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Update client list");
            Console.WriteLine(string.Join(Environment.NewLine, clientList.Select(c =>c.UserHeb)));
        }

        public void RecieveFromClient(string msg, string clientName)
        {
            Console.WriteLine(clientName + " says " + msg);
        }

        public void RecieveFromClient(string msg, ChatUser fromUser)
        {
            throw new NotImplementedException();
        }

        public void RecieveUsersChatHistory(ChatDetails[] chatHistory, ChatUser from)
        {
            throw new NotImplementedException();
        }
    }
}
