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
        IServer chatServerProxy;
        private DuplexChannelFactory<IServer> channel;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            //define delegates
            client = new Client(
                msg => lstChat.Items.Add(msg),
                data => lstChat.DataSource = data,
                data => lstUsers.DataSource = data
            );

            lstUsers.Format += LstUsers_Format;

            ConnectToServer(client);

        }

        private void LstUsers_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ChatUser)
            {
                e.Value = ((ChatUser)e.ListItem).UserHeb;
            }
            else
            {
                e.Value = "Unknown item added";
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
                lstChat.Items.Add("connecting as " + client.clientAD + " to ChatServerEndPoint");
                channel = new DuplexChannelFactory<IServer>(
                        client,
                        binding,
                        endpoint + "/" + Names.Endpoint);

                chatServerProxy = channel.CreateChannel();
                //RecieveClientsUpdate called after register
                chatServerProxy.Register(client.clientAD);
                lstChat.Items.Add("CONNECTED TO SERVER");
            }
            catch (Exception ex)
            {
                lstChat.Items.Add("COULD NOT CONNECT TO SERVER");
                lstChat.Items.Add(ex.ToString());
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
    }


    class Client : IClient
    {
        private sendMsg _sendMsg;
        private sendData updateChatList;
        private sendData updateUsersList;

        public string clientAD = Environment.UserDomainName + "\\" + Environment.UserName;

        public Client(sendMsg __msgDlg, sendData updateChatListDlg, sendData updateUsersListDlg)
        {
            _sendMsg = __msgDlg;
            updateChatList = updateChatListDlg;
            updateUsersList = updateUsersListDlg;
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

        public void RecieveFromClient(string msg, string clientName)
        {
            _sendMsg(clientName + " says " + msg);
        }

    }
}
