using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using VersInformer.Form.Server.VersInformerServiceRef;
using VersInformer.WPF.Controls;
using Message = VersInformer.Form.Server.VersInformerServiceRef.Message;

namespace VersInformer.Form.Server
{
    public partial class MainForm : System.Windows.Forms.Form, IVersInformerCallback
    {

        private VersInformerClient proxy = null;
        Client receiver = null;
        Client localClient = null;

        private delegate void FaultedInvoker();

        Dictionary<ClientItem, Client> OnlineClients = new Dictionary<ClientItem, Client>();

        public MainForm()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(52, 72, 92);

            headerPanel.BackColor = Color.FromArgb(50, 153, 214);
            leftSidePanel.BackColor = Color.FromArgb(52, 72, 92);
            btnConnect.BackColor = Color.FromArgb(25, 193, 127);
            btnConnect.FlatAppearance.BorderSize = 0;

            btnSend.BackColor = Color.FromArgb(52, 72, 92);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.FlatAppearance.BorderColor = Color.FromArgb(33, 33, 33);
            btnSend.FlatAppearance.BorderSize = 1;

            lblServerStatus.Text = "Disconnected";
            lblServerStatus.ForeColor = Color.FromArgb(200, 15, 50);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            if (proxy == null)
            {
                try
                {
                    localClient = new Client();
                    localClient.Name = txtUserName.Text.ToString();

                    InstanceContext context = new InstanceContext(this);
                    proxy = new VersInformerClient(context);


                    string servicePath = proxy.Endpoint.ListenUri.AbsolutePath;
                    string serviceListenPort = proxy.Endpoint.Address.Uri.Port.ToString();

                    proxy.Endpoint.Address =
                        new EndpointAddress("net.tcp://" + txtIp.Text.ToString() + ":" + serviceListenPort + servicePath);


                    proxy.Open();

                    proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);
                    proxy.InnerDuplexChannel.Opened += new EventHandler(InnerDuplexChannel_Opened);
                    proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);
                    proxy.ConnectAsync(localClient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ToggleConnectServerButton(proxy.State == CommunicationState.Opened);
                    ToggleConnectionStateLabel(proxy.State == CommunicationState.Opened);
                    ToggleConnectedControls(proxy.State == CommunicationState.Opened);
                    ToggleDisconnectedControls(proxy.State == CommunicationState.Opened);
                }
            }
        }

        private void ToggleConnectServerButton(bool isConnected)
        {
            if (isConnected)
            {
                btnConnect.Text = "Disconnect";
                btnConnect.BackColor = Color.FromArgb(200, 15, 50);
            }
            else
            {
                btnConnect.Text = "Connected";
                btnConnect.BackColor = Color.FromArgb(25, 193, 127);
            }
        }

        private void ToggleDisconnectedControls(bool isStarted)
        {
            if (isStarted)
            {
                txtIp.Enabled = false;
                txtUserName.Enabled = false;
            }
            else
            {
                txtIp.Enabled = true;
                txtUserName.Enabled = true;
            }
        }

        private void ToggleConnectionStateLabel(bool isConnected)
        {
            if (!isConnected)
            {
                lblServerStatus.Text = "Disconnected";
                lblServerStatus.ForeColor = Color.FromArgb(200, 15, 50);
            }
            else
            {
                lblServerStatus.Text = "Connected";
                lblServerStatus.ForeColor = Color.FromArgb(25, 193, 127);
            }
        }

        private void ToggleConnectedControls(bool isStarted)
        {
            if (isStarted)
            {
                txtMessage.Enabled = true;
                btnSend.Enabled = true;
            }
            else
            {
                txtMessage.Enabled = true;
                btnSend.Enabled = true;
            }
        }

        void InnerDuplexChannel_Closed(object sender, EventArgs e)
        {

        }

        void InnerDuplexChannel_Opened(object sender, EventArgs e)
        {

        }

        void InnerDuplexChannel_Faulted(object sender, EventArgs e)
        {
            Connect();
        }

        public void RefreshClients(Client[] clients)
        {
            lbCheckinStatus.Items.Clear();
            foreach (var client in clients)
            {
                lbCheckinStatus.Items.Add(client.Name);
            }
        }

        public void OnMessage(Message msg)
        {
            chatBox.AddMessage(new ChatMessage { Sender = msg.Sender, Content = msg.Content });
        }

        public void UserJoin(Client client)
        {

        }

        public void UserLeave(Client client)
        {
        }

        public void OnVersiyonAlinacak()
        {
        }

        public void OnVersiyonAliniyor()
        {
        }

        public void OnVersiyonTesteHazir()
        {
        }

        public void OnVersiyonAlindi()
        {
        }

        public void OnAciktikArtik()
        {
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Connect();
            proxy.SendMessage(new Message() { Sender = txtUserName.Text, Content = txtMessage.Text, Time = DateTime.Now });
            txtMessage.Text = string.Empty;
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnSend.PerformClick();
            //}
        }

        private void btnVersAliniyor_Click(object sender, EventArgs e)
        {
            if (proxy.InnerChannel.State == CommunicationState.Faulted)
            {
                Connect();
            }
            if (proxy.InnerChannel.State == CommunicationState.Opened)
            {
                proxy.VersiyonAliniyor();
            }
        }

        private void btnVersAlinacak_Click(object sender, EventArgs e)
        {
            if (proxy.InnerChannel.State == CommunicationState.Faulted)
            {
                Connect();
            }
            if (proxy.InnerChannel.State == CommunicationState.Opened)
            {
                proxy.VersiyonAlinacak();
            }
        }

        private void btnVersTesteHazir_Click(object sender, EventArgs e)
        {
            if (proxy.InnerChannel.State == CommunicationState.Faulted)
            {
                Connect();
            }
            if (proxy.InnerChannel.State == CommunicationState.Opened)
            {
                proxy.VersiyonTesteHazir();
            }
        }

        private void btnVersAlindi_Click(object sender, EventArgs e)
        {
            if (proxy.InnerChannel.State == CommunicationState.Faulted)
            {
                Connect();
            }
            if (proxy.InnerChannel.State == CommunicationState.Opened)
            {
                proxy.VersiyonAlindi();
            }
        }


    }
}
