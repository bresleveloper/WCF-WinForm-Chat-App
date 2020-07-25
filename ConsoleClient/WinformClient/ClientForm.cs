﻿using Interfaces;
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
        ChatUser[] allUsers = new ChatUser[0];
        List<ChatUser> talkingToMe = new List<ChatUser>();
        //ChatUser _selectedUser;
        IServer chatServerProxy;
        private DuplexChannelFactory<IServer> channel;
        private string selectedUserAdName = string.Empty;
        private int last_selectedUserIndex = -1;


        private Dictionary<string, ChatDetails[]> chatsData = new Dictionary<string, ChatDetails[]>();

        public ClientForm(bool devmode)
        {
            InitializeComponent();
            lstChat.DataSource = new ChatDetails[0];

            btnMoshe.Visible = devmode;
            btnRuth.Visible = devmode;
            btnConnectAharon.Visible = devmode;
            btnTestFlash.Visible = devmode;
        }

        public void UpdateUsersList(object[] _clientList)
        {
            allUsers = _clientList as ChatUser[];
            List<ChatUser> clientList = new List<ChatUser>(_clientList as ChatUser[]);

            this.me = clientList.Find(u => u.UserAd == client.clientAD);
            lblWelcomeName.Text = "שלום " + me.UserHeb;
            lblWelcomeADName.Text = "Welcome " +  me.UserAd;

            if (me.ArshaaAdmin == true)
            {
                lstUsers.DataSource = clientList.ToArray();
            }
            else
            {
                txtBroadcast.Visible = false;
                btnRefreshUsers.Visible = false;
                lstUsers.DataSource = talkingToMe.ToArray();
            }
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
                if (talkingToMe.FirstOrDefault(u => u.UserAd == from.UserAd) == null)
                {
                    talkingToMe.Add(from);
                }
                lstUsers.DataSource = talkingToMe.ToArray();
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
            txtBroadcast.KeyDown += TxtBroadcast_KeyDown;

            client = new Client(
                //sendMsg __msgDlg,
                AddMsgToChat,
                //sendData updateChatListDlg
                data => lstChat.DataSource = data,
                //sendData updateUsersListDlg,
                UpdateUsersList,
                //recieveChatData updateChatDataDlg
                UpdateChatDataEventHanlder
            );

            lstUsers.DrawMode = DrawMode.OwnerDrawVariable;
            lstUsers.DrawItem += LstUsers_DrawItem;
            lstUsers.SelectionMode = SelectionMode.One;

            lstChat.DrawMode = DrawMode.OwnerDrawVariable;
            lstChat.MeasureItem += LstChat_MeasureItem;
            lstChat.DrawItem += LstChat_DrawItem;

            ConnectToServer(client);
        }

        private void TxtBroadcast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Then Do your Thang
                chatServerProxy.Broadcast(txtBroadcast.Text);
                AddMsgToChat("Broadcast : " + txtBroadcast.Text);
                txtBroadcast.Text = string.Empty;
            }
        }

        private void LstChat_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string value = ((ChatDetails)lstChat.Items[e.Index]).odaa;
            e.DrawBackground();
            e.Graphics.DrawString(value, e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void LstChat_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            //e.ItemHeight = 150;
            //base is 19
            string value = ((ChatDetails)lstChat.Items[e.Index]).odaa;
            int x = Convert.ToInt32( Math.Ceiling(((double)value.Length / 200)) );
            e.ItemHeight = 19 * x;
        }

        private void LstUsers_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            //e.ItemHeight = (int)e.Graphics.MeasureString(lstUsers.Items[e.Index].ToString(), lstUsers.Font, lstUsers.Width).Height;
            e.ItemHeight = 150;
        }

        private void LstUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            if (e.Index == 0)
            {
                //AddMsgToChat("LstUsers_DrawItem");
            }

            ChatUser u = lstUsers.Items[e.Index] as ChatUser;

            // Draw the new background colour
            Graphics g = e.Graphics;
            //e.DrawBackground();
            Brush bgBrush = u.IsConnected ? Brushes.White : Brushes.DarkGray;
            Brush foreBrush = Brushes.Black;

            if (u.IsConnected && e.Index == lstUsers.SelectedIndex)
            {
                //_selectedUser = u;
                bgBrush = SystemBrushes.Highlight;
                foreBrush = Brushes.White;
            }

            if (last_selectedUserIndex != lstUsers.SelectedIndex &&
                u.IsConnected && e.Index == last_selectedUserIndex)
            {
                bgBrush = u.IsConnected ? Brushes.White : Brushes.DarkGray;
                foreBrush = Brushes.Black;
            }

            e.Graphics.FillRectangle(bgBrush, e.Bounds);

            string value = u.UserHeb;
            //debug
            //value += " - " + u.NumOved + " - " + e.Index + " - " + lstUsers.SelectedIndex;

            e.Graphics.DrawString(value, e.Font, foreBrush, e.Bounds);
            e.DrawFocusRectangle();
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
            /*
            ChatUser selectedUser = lstUsers.SelectedItem as ChatUser;
            AddMsgToChat("selected user changed to " + selectedUserAdName);
            
            if (selectedUserAdName != selectedUser.UserAd)
            {
                chatServerProxy.AksUsersChatHistory(me, selectedUser);
            }*/
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

        private void lstChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstUsers.Items.Count == 0)
            {
                return;
            }
            //last selected index
            
            this.last_selectedUserIndex = lstUsers.SelectedIndex;
            ChatUser selectedUser = lstUsers.SelectedItem as ChatUser;
            //AddMsgToChat("selected user changed to " + selectedUserAdName);
            lblChatWith.Text = "Chatting With " + selectedUser.UserHeb + "(" + selectedUser.UserAd + ")";
            if (selectedUserAdName != selectedUser.UserAd)
            {
                chatServerProxy.AksUsersChatHistory(me, selectedUser);
            }
            lstChat.DataSource = new ChatDetails[0];
        }

        private void txtBroadcast_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConnectAharon_Click(object sender, EventArgs e)
        {
            client.clientAD = "user5";
            ConnectToServer(client);
        }
    }


    class Client : IClient
    {
        private sendMsg _sendMsg;
        private sendData updateChatList;
        private sendData updateUsersList;
        private recieveChatData updateChatData;

        public string clientAD = Environment.UserName.ToLower() + "@" + Environment.UserDomainName.ToLower();

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
            updateUsersList(clientList);
        }

        public void RecieveFromClient(string msg, ChatUser fromUser)
        {
            _sendMsg(fromUser.UserHeb + " : " + msg);
        }

        public void RecieveUsersChatHistory(ChatDetails[] chatHistory, ChatUser from)
        {
            _sendMsg("updateChatData");
            updateChatData(chatHistory, from);
        }

    }
}
