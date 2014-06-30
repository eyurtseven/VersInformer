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
using System.Windows.Forms.VisualStyles;
using VersInformer.Forms.Controls;
using Message = VersInformer.Form.Client.VersInformerServiceRef.Message;

namespace VersInformer.Form.Client
{
    public partial class MainForm : System.Windows.Forms.Form, VersInformerServiceRef.IVersInformerCallback
    {

        private VersInformerServiceRef.VersInformerClient proxy = null;
        VersInformerServiceRef.Client receiver = null;
        VersInformerServiceRef.Client localClient = null;

        private delegate void FaultedInvoker();

        Dictionary<ClientItem, VersInformerServiceRef.Client> OnlineClients = new Dictionary<ClientItem, VersInformerServiceRef.Client>();

        public MainForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(52, 72, 92);

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
                    this.localClient = new VersInformerServiceRef.Client();
                    this.localClient.Name = txtUserName.Text.ToString();

                    InstanceContext context = new InstanceContext(this);
                    proxy = new VersInformerServiceRef.VersInformerClient(context);


                    string servicePath = proxy.Endpoint.ListenUri.AbsolutePath;
                    string serviceListenPort = proxy.Endpoint.Address.Uri.Port.ToString();

                    proxy.Endpoint.Address =
                        new EndpointAddress("net.tcp://" + txtIp.Text.ToString() + ":" + serviceListenPort + servicePath);


                    proxy.Open();

                    proxy.InnerDuplexChannel.Faulted += new EventHandler(InnerDuplexChannel_Faulted);
                    proxy.InnerDuplexChannel.Opened += new EventHandler(InnerDuplexChannel_Opened);
                    proxy.InnerDuplexChannel.Closed += new EventHandler(InnerDuplexChannel_Closed);
                    proxy.ConnectAsync(this.localClient);
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
                lbMessage.Enabled = true;
                btnSend.Enabled = true;
            }
            else
            {
                txtMessage.Enabled = true;
                lbMessage.Enabled = true;
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
            proxy = null;
            Connect();
        }

        public void RefreshClients(VersInformerServiceRef.Client[] clients)
        {
            var _clients = clients.Aggregate("", (current, client) => current + (Environment.NewLine + client.Name));
            MessageBox.Show(_clients, "Client");
        }

        public void OnMessage(Message msg)
        {
            lbMessage.Items.Add(msg.Content);
        }

        public void UserJoin(VersInformerServiceRef.Client client)
        {
            MessageBox.Show("Kullanıcı geldi : " + client.Name);
        }

        public void UserLeave(VersInformerServiceRef.Client client)
        {
            MessageBox.Show("Kullanıcı gitti : " + client.Name);
        }

        public void OnVersiyonAlinacak()
        {
            ShowNotify("Versiyon Alınacak", "Şimdi versiyon alınacak dikkat");
        }

        public void OnVersiyonAliniyor()
        {
            ShowNotify("Versiyon Alınacak", "Şimdi versiyon alınıyor dikkat");
        }

        public void OnVersiyonTesteHazir()
        {
            ShowNotify("Versiyon Alınacak", "Şimdi versiyon teste hazır dikkat");
        }

        public void OnVersiyonAlindi()
        {
            ShowNotify("Versiyon Alınacak", "Şimdi versiyon alındı dikkat");
        }

        public void OnAciktikArtik()
        {
            ShowNotify("Versiyon Alınacak", "Şimdi yemek zamanı dikkat");
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                notify.Visible = true;
                notify.ShowBalloonTip(250, "VersInformer çalışmaya devam ediyor", "Program ile ilgili işlem yapmak için sağ tıklayınız.", ToolTipIcon.Info);
                Visible = false;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void miOpenProgram_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Visible = true;
        }

        private void miExitProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            WindowState = FormWindowState.Minimized;
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    Visible = true;
                    WindowState = FormWindowState.Normal;

                    break;
                case FormWindowState.Normal:
                    Visible = false;
                    WindowState = FormWindowState.Minimized;

                    break;

            }
        }

        private void ShowNotify(string title, string message)
        {
            var notifyForm = new UserNotifyForm(title, message);
            notifyForm.SetDimensions(200, 100);
            notifyForm.Notify();
        }

    }
}
