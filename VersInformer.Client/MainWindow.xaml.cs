using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using VersInformer.Client.Properties;
using VersInformer.Remote;

namespace VersInformer.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeChannel();
        }

        private void InitializeChannel()
        {
            _clientFormatterProvider = new BinaryClientFormatterSinkProvider();
            _serverFormatterProvider = new BinaryServerFormatterSinkProvider();
            _serverFormatterProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            _viServer = new VersInformerProxy();
            _viServer.MessageArrived += VIServer_MessageArrived;

            var p = new Hashtable();
            p["name"] = "remoteClient";
            p["port"] = 0;

            _tcpChannel = new TcpChannel(p, _clientFormatterProvider, _serverFormatterProvider);

            if (string.IsNullOrEmpty(IpAddress) || string.IsNullOrWhiteSpace(IpAddress))
            {
                return;
            }

            ChannelServices.RegisterChannel(_tcpChannel);

            RemotingConfiguration.RegisterWellKnownClientType(new WellKnownClientTypeEntry(typeof(IRemoteObject), ServerUri));


            txtNickName.Text = Settings.Default.NickName;
            txtServerIP.Text = Settings.Default.ServerIPAddress;
            SetConnectionStatus();
        }

        void VIServer_MessageArrived(string message)
        {
            MessageToUI(JsonConvert.DeserializeObject<RemoteMessage>(message));
        }

        void MessageToUI(RemoteMessage message)
        {
            SynchronizationContext.Current.Post(
                new SendOrPostCallback(
                    new Action<object>(o =>
                        {
                            if (message.Type == "ReleaseAction" && message.From != Settings.Default.NickName)
                            {
                                NotifyMessage(message);
                                return;
                            }
                            if (message.Type != "ReleaseAction")
                            {
                                lbMessage.Items.Add(message);
                                lbMessage.ScrollIntoView(lbMessage.Items[lbMessage.Items.Count - 1]);
                            }
                        })),
                        null);
        }

        private void NotifyMessage(RemoteMessage message)
        {
            DestroyActiveNotify();
            NotifyToast notify = new NotifyToast();
            notify.Message = message;
            notify.Topmost = true;
            notify.ShowInTaskbar = false;
            notify.Left = System.Windows.SystemParameters.PrimaryScreenWidth - (notify.Width + 50);
            notify.Top = System.Windows.SystemParameters.PrimaryScreenHeight - (notify.Height + 50);
            notify.Show();

        }

        private void DestroyActiveNotify()
        {
            foreach (var window in Application.Current.Windows)
            {
                if (window is NotifyToast)
                {
                    (window as NotifyToast).Close();
                }
            }
        }

        IRemoteObject _remoteObject;
        VersInformerProxy _viServer;
        TcpChannel _tcpChannel;

        BinaryClientFormatterSinkProvider _clientFormatterProvider;
        BinaryServerFormatterSinkProvider _serverFormatterProvider;

        bool _isConnected = false;

        private string IpAddress
        {
            get { return string.IsNullOrEmpty(txtServerIP.Text.Trim()) ? Settings.Default.ServerIPAddress : txtServerIP.Text; }
        }

        private string ServerUri
        {
            get
            {
                return string.Format("tcp://{0}:1500/versInformer.VI", IpAddress);
            }
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            if (!_isConnected)
            {
                return;
            }
            _remoteObject.MessageArrived -= _viServer.HandleMessageArrived;
            var ch = ChannelServices.GetChannel(_tcpChannel.ChannelName);
            if (ch != null) { ChannelServices.UnregisterChannel(_tcpChannel); }
            _isConnected = false;
            SetConnectionStatus();
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (!_isConnected || string.IsNullOrEmpty(txtMessage.Text))
            {
                return;
            }

            _remoteObject.SendMessage(JsonConvert.SerializeObject(new { From = Settings.Default.NickName, Message = txtMessage.Text, Time = DateTime.Now }));
            txtMessage.Text = "";
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {

            Settings.Default.NickName = txtNickName.Text;

            if (_isConnected || string.IsNullOrEmpty(IpAddress) || string.IsNullOrWhiteSpace(IpAddress))
            {
                return;
            }

            try
            {
                _remoteObject = (IRemoteObject)Activator.GetObject(typeof(IRemoteObject), ServerUri);
                _remoteObject.SendMessage(JsonConvert.SerializeObject(new { From = "Information", Message = string.Format("{0} connected", txtNickName.Text), Time = DateTime.Now }));

                _remoteObject.MessageArrived += new MessageArrivedEvent(_viServer.HandleMessageArrived);
                _isConnected = true;

                Settings.Default.ServerIPAddress = IpAddress;

            }
            catch (Exception ex)
            {
                _isConnected = false;
                ShowError("Could not connect to server");
            }

            SetConnectionStatus();

            Settings.Default.Save();

        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }

        private void SetConnectionStatus()
        {
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(1, 1);

            if (!_isConnected)
            {
                brush.GradientStops.Add(new GradientStop(Colors.Red, 0.1));
                brush.GradientStops.Add(new GradientStop(Colors.OrangeRed, 0.25));
                brush.GradientStops.Add(new GradientStop(Colors.OrangeRed, 0.75));
                brush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
                lblConnectionStatus.Content = "Disconnected";

                txtNickName.IsEnabled = true;
                txtServerIP.IsEnabled = true;
                txtMessage.IsEnabled = false;
                btnConnect.IsEnabled = true;
                btnDisconnect.IsEnabled = false;
                btnSendMessage.IsEnabled = false;

            }
            else
            {
                brush.GradientStops.Add(new GradientStop(Colors.Green, 0.1));
                brush.GradientStops.Add(new GradientStop(Colors.SpringGreen, 0.25));
                brush.GradientStops.Add(new GradientStop(Colors.SpringGreen, 0.75));
                brush.GradientStops.Add(new GradientStop(Colors.Green, 1.0));
                lblConnectionStatus.Content = "Connected";

                txtNickName.IsEnabled = false;
                txtServerIP.IsEnabled = false;
                txtMessage.IsEnabled = true;
                btnConnect.IsEnabled = false;
                btnDisconnect.IsEnabled = true;
                btnSendMessage.IsEnabled = true;

            }
            lblConnectionStatus.Background = brush;
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSendMessage_Click(null, null);
            }
        }

    }
}
