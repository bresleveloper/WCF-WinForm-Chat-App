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
        sendMsg sendMsgToServer;
        //private List<IClient> adminClients = new List<IClient>();
        //private List<ClientInstance> myClients = new List<ClientInstance>();
        private Dictionary<string,ClientInstance> myClients = new Dictionary<string, ClientInstance>();

        private void verifyList()
        {
            //myClients = myClients.Where(c => ((ICommunicationObject)c.client).State == CommunicationState.Opened).ToList();
            
            Dictionary<string, ClientInstance> updated_myClients = new Dictionary<string, ClientInstance>();

            foreach (KeyValuePair<string, ClientInstance> cItem in myClients)
            {
                ICommunicationObject oComm = cItem.Value.client as ICommunicationObject;
                CommunicationState state = oComm.State;
                if (state == CommunicationState.Opened)
                {
                    updated_myClients.Add(cItem.Key, cItem.Value);
                }
            }
            myClients = updated_myClients;

           /* myClients = myClients
                .Where(c => ((ICommunicationObject)c.Value.client).State == CommunicationState.Opened)
                .ToDictionary(c => c.Key, c=> c.Value);*/
           //adminClients = adminClients.Where(c => ((ICommunicationObject)c).State == CommunicationState.Opened).ToList();
        }
        public string[] ListClients()
        {
            verifyList();
            //return myClients.Select(c => c.name).ToArray();
            return myClients.Keys.ToArray();
        }

        public Manager(Server _server, sendMsg _sendMsg)
        {
            sendMsgToServer = _sendMsg;
            server = _server;

            server.ClientRegistered += Server_ClientRegistered;
            server.AkskingClientsList += Server_AkskingClientsList;
            server.AksUsersChatHistoryEvent += Server_AksUsersChatHistoryEvent;
            server.ClientSayEvent += Server_ClientSayEvent;
        }

        private void Server_ClientSayEvent(string msg, ChatUser from, ChatUser to)
        {
            verifyList();
            if (IsChatClientsConnected(from, to) == false)
            {
                return;
            }

            ChatDetails chatItem = new ChatDetails()
            {
                dateAdd = DateTime.Now,
                FromNumOved = from.NumOved,
                FromUserAd = from.UserAd,
                FromUserHeb = from.UserHeb,
                odaa = msg,
                ReadOdaa = false,
                ToNumOved = to.NumOved,
                ToUserAd = to.UserAd,
                ToUserHeb = to.UserHeb
            };

            int id = DAL.insert<ChatDetails>("ChatDetail", chatItem);
            chatItem.id = id;

            myClients[to.UserAd].client.RecieveFromClient(msg, from);
        }

        private void Server_AksUsersChatHistoryEvent(ChatUser a, ChatUser b)
        {
            verifyList();
            if (IsChatClientsConnected(a,b) == false)
            {
                return;
            }

            //1. get history form db
            ChatDetails[] chatHistory = ChatDAL.GetChatDetailsForUsers(a, b);
            //2. send to clients
            myClients[a.UserAd].client.RecieveUsersChatHistory(chatHistory, b);
            myClients[b.UserAd].client.RecieveUsersChatHistory(chatHistory, a);
        }

        private bool IsChatClientsConnected(ChatUser a, ChatUser b)
        {
            verifyList();
            if (myClients.ContainsKey(a.UserAd) == true && myClients.ContainsKey(b.UserAd) == true)
            {
                return true;
            }
            else
            {
                if (myClients.ContainsKey(a.UserAd) == true)
                {
                    myClients[a.UserAd].client.RecieveClientsList(GetConnectedUsersList());
                }
                if (myClients.ContainsKey(b.UserAd) == true)
                {
                    myClients[b.UserAd].client.RecieveClientsList(GetConnectedUsersList());
                }
                return false;
            }
        }

        private void Server_AkskingClientsList(IClient clientChannel)
        {
            verifyList();
            clientChannel.RecieveClientsList(GetConnectedUsersList());
        }

        private void Server_ClientRegistered(string clientName, IClient clientChannel)
        {
            if (myClients.ContainsKey(clientName) == true)
            {
                myClients[clientName].client = clientChannel;
            }
            else
            {
                myClients.Add(clientName, new ClientInstance()
                {
                    client = clientChannel,
                    adName = clientName
                });
            }
            //Console.WriteLine("new guy - " + clientName);
            verifyList();
            ChatUser[] actuallConnectedUsers = GetConnectedUsersList();

            //foreach (ClientInstance client in myClients)
            foreach (KeyValuePair<string, ClientInstance> KVP in myClients)
                KVP.Value.client.RecieveClientsList(actuallConnectedUsers);

            sendMsgToServer(clientName + " registered at " + DateTime.Now);
        }

        public void Broadcast(string msg)
        {
            verifyList();
            foreach (KeyValuePair<string, ClientInstance> KVP in myClients)
                KVP.Value.client.PrintBroadcastMessage(msg);
        }

        public ChatUser[] GetConnectedUsersList()
        {
            ChatUser[] users = ChatDAL.GetUsersList();
            List<ChatUser> connectedChatUsers = new List<ChatUser>();

            foreach (ChatUser u in users)
            {
                if (myClients.ContainsKey(u.UserAd))
                {
                    connectedChatUsers.Add(u);
                }
            };
            return connectedChatUsers.ToArray();
        }

    }

    class ClientInstance
    {
        public IClient client { get; set; }
        public string adName { get; set; }

    }
}
