using ConsoleServer;
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

namespace WinformServer
{
    public partial class Dashboard : Form
    {
        Server server;
        Manager mng;
        ServiceHost host;


        public Dashboard()
        {
            InitializeComponent();
            FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            host.Close();
        }

        private void btnServerStatus_Click(object sender, EventArgs e)
        {
            lstStatus.Items.Add("host State: " + host.State);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBroadcast.KeyDown += TxtBroadcast_KeyDown;
            sendMsg sm = ServerMsg => lstStatus.Items.Add(ServerMsg);

            lstStatus.Items.Add("Form1_Load, create Server");
            server = new Server();
            lstStatus.Items.Add("Form1_Load, create Manager");
            mng = new Manager(server, sm);
            lstStatus.Items.Add("Form1_Load, Hosting");
            Host();
        }

        private void TxtBroadcast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Then Do your Thang
                mng.Broadcast(txtBroadcast.Text);
                txtBroadcast.Text = string.Empty;

            }
        }

        private void Host()
        {
            /*using (host = new ServiceHost(server, new Uri[] {
                //Uri must be "net.pipe://***"
                new Uri(Names.Address)
            }))
            {*/
            host = new ServiceHost(server, new Uri[] { new Uri(Names.Address) });
            host.AddServiceEndpoint(typeof(IServer), new NetTcpBinding(), Names.Endpoint);
            host.Open();
            lstStatus.Items.Add("Service is available.");
            //}
        }

        private void btnListUsers_Click(object sender, EventArgs e)
        {
            lstStatus.Items.Add("");
            lstStatus.Items.Add("Listing Connected Clients");

            string[] clients = mng.ListClients();
            if (clients == null || clients.Length == 0)
            {
                lstStatus.Items.Add("no clients connected");
            }
            else
            {
                for (int i = 0; i < clients.Length; i++)
                {
                    lstStatus.Items.Add(clients[i]);
                }
            }
            lstStatus.Items.Add("");
        }

        private void lstStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bresleveloper.co.il");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bresleveloper.co.il");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bresleveloper.co.il");

        }

        private void lstStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstStatus.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDBUsers_Click(object sender, EventArgs e)
        {
            ChatUser[] dbusers = ChatDAL.GetUsersList();
            if (dbusers == null || dbusers.Length == 0)
            {
                lstStatus.Items.Add("no users in db");
                return;
            }
            for (int i = 0; i < dbusers.Length; i++)
            {
                lstStatus.Items.Add(dbusers[i].UserAd + " - " + dbusers[i].UserHeb);
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            lstStatus.Items.Add((DAL.TestConnection() ? "Successfully" : "NOT" ) + " Connected to DB");
        }
    }
}
