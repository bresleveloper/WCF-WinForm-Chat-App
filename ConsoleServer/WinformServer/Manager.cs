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
            server.BroadcastEvent += Broadcast;
        }

        private void Server_ClientSayEvent(string msg, ChatUser from, ChatUser to)
        {
            verifyList();
            /*if (IsChatClientsConnected(from, to) == false)
            {
                return;
            }*/

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

            if (IsChatClientsConnected(from, to) == true)
            {
                myClients[to.UserAd].client.RecieveFromClient(msg, from);
            }

            ChatDAL.UpdateUserChatDetailsToRead(from, to);
        }

        private void Server_AksUsersChatHistoryEvent(ChatUser askingUser, ChatUser targetUser)
        {
            verifyList();
            /*if (IsChatClientsConnected(a,b) == false)
            {
                return;
            }*/

            //0. update that the asking user has read the chat, although he is going to read in a few seconds
            ChatDAL.UpdateUserChatDetailsToRead(askingUser, targetUser);

            //1. get history form db
            ChatDetails[] chatHistory = ChatDAL.GetChatDetailsForUsers(askingUser, targetUser);
            //2. send to clients
            if (myClients.ContainsKey(askingUser.UserAd) == false) 
            {
                return;//should only happen with debug when acting as local user after opening another dev station
                //the new station is again local user and then connect as leaving only "as" user
            }
            myClients[askingUser.UserAd].client.RecieveUsersChatHistory(chatHistory, targetUser);
            if (IsChatClientsConnected(askingUser, targetUser) == true)
            {
                myClients[targetUser.UserAd].client.RecieveUsersChatHistory(chatHistory, askingUser);
            }
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
                //causes endless loop if user ad not in db table
                /*if (myClients.ContainsKey(a.UserAd) == true)
                {
                    myClients[a.UserAd].client.RecieveClientsList(GetConnectedUsersList());
                }
                if (myClients.ContainsKey(b.UserAd) == true)
                {
                    myClients[b.UserAd].client.RecieveClientsList(GetConnectedUsersList());
                }*/
                return false;
            }
        }

        private void Server_AkskingClientsList(string clientADName, IClient clientChannel)
        {
            verifyList();
            clientChannel.RecieveClientsList(GetConnectedUsersList(clientADName));
        }

        private void Server_ClientRegistered(string clientADName, IClient clientChannel)
        {
            if (myClients.ContainsKey(clientADName) == true)
            {
                myClients[clientADName].client = clientChannel;
            }
            else
            {
                myClients.Add(clientADName, new ClientInstance()
                {
                    client = clientChannel,
                    adName = clientADName
                });
            }
            //Console.WriteLine("new guy - " + clientName);
            verifyList();
            ChatUser[] actuallConnectedUsers = GetConnectedUsersList(clientADName);

            //foreach (ClientInstance client in myClients)
            foreach (KeyValuePair<string, ClientInstance> KVP in myClients)
                KVP.Value.client.RecieveClientsList(actuallConnectedUsers);

            sendMsgToServer(clientADName + " registered at " + DateTime.Now);
        }

        public void Broadcast(string msg)
        {
            verifyList();
            foreach (KeyValuePair<string, ClientInstance> KVP in myClients)
                KVP.Value.client.PrintBroadcastMessage("Broadcast : " + msg);
        }

        public ChatUser[] GetConnectedUsersList(string asking_clientADName)
        {
            ChatUser[] users = ChatDAL.GetUsersList();
            //List<ChatUser> connectedChatUsers = new List<ChatUser>();
            string[] namesWithMsgs = ChatDAL.UsersADNamesThatHasUnreadMessagesForMe(asking_clientADName);

            foreach (ChatUser u in users)
            {
                /*if (myClients.ContainsKey(u.UserAd))
                {
                    connectedChatUsers.Add(u);
                }*/
                u.IsConnected = myClients.ContainsKey(u.UserAd);
                u.HasMessageForYou = namesWithMsgs.Contains(u.UserAd);
            };
            //return connectedChatUsers.ToArray();
            return users;
        }

    }

    class ClientInstance
    {
        public IClient client { get; set; }
        public string adName { get; set; }

    }
}
