using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformClient
{
    public partial class ClientForm : Form
    {
        Client client;
        ChatUser me;
        IServer chatServerProxy;
        private DuplexChannelFactory<IServer> channel;


        private Dictionary<string, ChatDetails[]> chatsData = new Dictionary<string, ChatDetails[]>();

        public ClientForm()
        {
            InitializeComponent();
            lstChat.DataSource = new ChatDetails[0];
        }

        public void UpdateUsersList(object[] _clientList)
        {
            List<ChatUser> clientList = new List<ChatUser>(_clientList as ChatUser[]);

            this.me = clientList.Find(u => u.UserAd == client.clientAD);
            clientList.Remove(me);

            lblWelcomeName.Text = "שלום " + me.UserHeb;
            lblWelcomeADName.Text = "Welcome " +  me.UserAd;

            lstUsers.DataSource = clientList.ToArray();
        }

        public void UpdateChatDataEventHanlder(ChatDetails[] chatHistory, ChatUser from)
        {
            //1. save history to some memory zone, make some chats manager
            if (chatsData.ContainsKey(from.UserAd) == false)
            {
                //2. if user from not in list, add him
                chatsData.Add(from.UserAd, chatHistory);
            }
            else
            {
                chatsData[from.UserAd] = chatHistory;
            }

            //3. update from user = select user
            ChatUser lstFromUser = lstUsers.Items.Cast<ChatUser>().FirstOrDefault(u => u.UserAd == from.UserAd);
            if (lstFromUser == null)
            {
                //lstUsers.Items.Add(lstFromUser);
                ChatUser[] dsUsers = lstUsers.DataSource as ChatUser[];
                dsUsers.ToList().Insert(0, lstFromUser);
                lstUsers.DataSource = dsUsers.ToArray();
            }
            lstUsers.SelectedItem = lstFromUser;

            //4. update the chat
            lstChat.DataSource = chatsData[from.UserAd];

            //5. if history has more recent item than in cache, make highlight
            btnTestFlash_Click(null, null);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            txtChatInput.KeyDown += TxtChatInput_KeyDown;

            //define delegates
            client = new Client(
                //msg => lstChat.Items.Add(msg),
                AddMsgToChat,
                data => lstChat.DataSource = data,
                UpdateUsersList,
                UpdateChatDataEventHanlder
            );

            lstUsers.Format += LstUsers_Format;
            lstChat.Format += LstChat_Format;

            ConnectToServer(client);

        }

        private void LstChat_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ChatDetails)
            {
                e.Value = ((ChatDetails)e.ListItem).odaa;
            }
        }

        private void AddMsgToChat(string msg)
        {
            List<ChatDetails> ds = (lstChat.DataSource as ChatDetails[]).ToList();
            ds.Add(new ChatDetails() { odaa = msg });
            lstChat.DataSource = ds.ToArray();
        }

        private void TxtChatInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Then Do your Thang
                chatServerProxy.ClientSay(txtChatInput.Text, me, lstUsers.SelectedItem as ChatUser);
                AddMsgToChat(me.UserHeb + " : " + txtChatInput.Text);
                txtChatInput.Text = string.Empty;
            }
        }

        private void LstUsers_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ChatUser)
            {
                e.Value = ((ChatUser)e.ListItem).UserHeb;
            }
            /*else
            {
               e.Value = "Unknown item added";
            }*/
        }

        private void ConnectToServer(Client client)
        {
            try
            {
                if (channel != null)
                {
                    channel.Close();
                }

                NetTcpBinding binding = new NetTcpBinding();
                EndpointAddress endpoint = new EndpointAddress(Names.Address);
                AddMsgToChat("connecting as " + client.clientAD + " to ChatServerEndPoint");
                channel = new DuplexChannelFactory<IServer>(
                        client,
                        binding,
                        endpoint + "/" + Names.Endpoint);

                chatServerProxy = channel.CreateChannel();
                //RecieveClientsUpdate called after register
                chatServerProxy.Register(client.clientAD);
                AddMsgToChat("CONNECTED TO SERVER");
            }
            catch (Exception ex)
            {
                AddMsgToChat("COULD NOT CONNECT TO SERVER");
                AddMsgToChat(ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bresleveloper.co.il");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bresleveloper.co.il");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bresleveloper.co.il");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer(client);
        }

        private void btnRefreshUsers_Click(object sender, EventArgs e)
        {
            chatServerProxy.AksClientsList();
        }

        private void btnMoshe_Click(object sender, EventArgs e)
        {
            client.clientAD = "user1";
            ConnectToServer(client);
        }

        private void btnRuth_Click(object sender, EventArgs e)
        {
            client.clientAD = "user4";
            ConnectToServer(client);
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChatUser selectedUser = lstUsers.SelectedItem as ChatUser;
            chatServerProxy.AksUsersChatHistory(me, selectedUser);
        }

        private void txtChatInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTestFlash_Click(object sender, EventArgs e)
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += delegate (object osender, EventArgs args)
            {
                //this.WindowState = FormWindowState.Normal;
                //this.Activate();
                FlashWindow.Flash(this);
                timer.Stop();
            };
            timer.Start();
        }
    }


    class Client : IClient
    {
        private sendMsg _sendMsg;
        private sendData updateChatList;
        private sendData updateUsersList;
        private recieveChatData updateChatData;

        public string clientAD = Environment.UserDomainName + "@" + Environment.UserName;

        public Client(sendMsg __msgDlg, 
            sendData updateChatListDlg, 
            sendData updateUsersListDlg,
            recieveChatData updateChatDataDlg)
        {
            _sendMsg = __msgDlg;
            updateChatList = updateChatListDlg;
            updateUsersList = updateUsersListDlg;
            updateChatData = updateChatDataDlg;
        }

        public void PrintBroadcastMessage(string msg)
        {
            _sendMsg(msg);
        }

        public void RecieveClientsList(ChatUser[] clientList)
        {
            _sendMsg("RecieveClientsList");
            //_sendMsg(string.Join(Environment.NewLine, clientList.Select(c=>c.UserHeb)));
            updateUsersList(clientList);
        }

        public void RecieveFromClient(string msg, ChatUser fromUser)
        {
            //_sendMsg(clientName + " says " + msg);
            _sendMsg(fromUser.UserHeb + " : " + msg);
        }

        public void RecieveUsersChatHistory(ChatDetails[] chatHistory, ChatUser from)
        {
            _sendMsg("updateChatData");
            updateChatData(chatHistory, from);
        }

    }
}
