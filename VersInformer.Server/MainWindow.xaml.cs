using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
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
using VersInformer.Remote;
using VersInformer.Server.Properties;

namespace VersInformer.Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtNickName.Text = Settings.Default.NickName;
            lblIP.Content = string.Format(lblIP.Content.ToString(), CurrentIP);
            SetServerStatus();
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
                            NotifyMessage();
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

        private void NotifyMessage()
        {
            DestroyActiveNotify();
            NotifyToast notify = new NotifyToast();
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

        VIServer _server;

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                return;
            }
            _server.SendMessage(JsonConvert.SerializeObject(new { From = Settings.Default.NickName, Message = txtMessage.Text, Time = DateTime.Now }));
            txtMessage.Text = "";
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _server = new VIServer();
            _server.StartServer(1500);
            _server.MessageArrived += VIServer_MessageArrived;
            SetServerStatus();
            Settings.Default.NickName = txtNickName.Text;
            Settings.Default.Save();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (_server == null)
            {
                return;
            }
            _server.MessageArrived -= VIServer_MessageArrived;
            _server.StopServer();
            _server = null;
            SetServerStatus();
        }

        string CurrentIP
        {
            get
            {
                var a = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.FirstOrDefault(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                return a.ToString();
            }
        }

        private void txtMinutes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void SetServerStatus()
        {
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(1, 1);

            if (_server == null)
            {
                brush.GradientStops.Add(new GradientStop(Colors.Red, 0.1));
                brush.GradientStops.Add(new GradientStop(Colors.OrangeRed, 0.25));
                brush.GradientStops.Add(new GradientStop(Colors.OrangeRed, 0.75));
                brush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
                lblServerStatus.Content = "Server is not running";
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = false;
                txtNickName.IsEnabled = true;
                envTest.IsEnabled = false;
                envUAT.IsEnabled = false;
                envLive.IsEnabled = false;
                envTest.IsChecked = false;
                envUAT.IsChecked = false;
                envLive.IsChecked = false;
                txtMinutes.IsEnabled = false;
                txtMinutes.Text = string.Empty;
                txtMessage.IsEnabled = false;
                txtMessage.Text = string.Empty;
                btnSendMessage.IsEnabled = false;
                btnVerWill.IsEnabled = false;
                btnVerNow.IsEnabled = false;
                btnVerPast.IsEnabled = false;
                btnVerReady.IsEnabled = false;
            }
            else
            {
                brush.GradientStops.Add(new GradientStop(Colors.Green, 0.1));
                brush.GradientStops.Add(new GradientStop(Colors.SpringGreen, 0.25));
                brush.GradientStops.Add(new GradientStop(Colors.SpringGreen, 0.75));
                brush.GradientStops.Add(new GradientStop(Colors.Green, 1.0));
                lblServerStatus.Content = "Server is running";
                btnStart.IsEnabled = false;
                btnStop.IsEnabled = true;
                txtNickName.IsEnabled = false;
                envTest.IsEnabled = true;
                envUAT.IsEnabled = true;
                envLive.IsEnabled = true;
                envTest.IsChecked = false;
                envUAT.IsChecked = false;
                envLive.IsChecked = false;
                txtMinutes.IsEnabled = true;
                txtMinutes.Text = string.Empty;
                txtMessage.IsEnabled = true;
                txtMessage.Text = string.Empty;
                btnSendMessage.IsEnabled = true;
                btnVerWill.IsEnabled = true;
                btnVerNow.IsEnabled = true;
                btnVerPast.IsEnabled = true;
                btnVerReady.IsEnabled = true;
            }
            lblServerStatus.Background = brush;
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSendMessage_Click(null, null);
            }
        }

        string SelectedEnvironment
        {
            get
            {
                var retVal = "";

                if (envTest.IsChecked.HasValue && envTest.IsChecked.Value)
                {
                    retVal = envTest.Content.ToString();
                }

                if (envUAT.IsChecked.HasValue && envUAT.IsChecked.Value)
                {
                    retVal = envUAT.Content.ToString();
                }

                if (envLive.IsChecked.HasValue && envLive.IsChecked.Value)
                {
                    retVal = envLive.Content.ToString();
                }
                return retVal;
            }
        }

        void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }

        private void btnVerWill_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMinutes.Text))
            {
                ShowWarning("Kaç dakika sonra aksiyon alınacağını belirtmeniz gerekir."); return;
            }
            if (string.IsNullOrEmpty(SelectedEnvironment))
            {
                ShowWarning("Hangi ortam için aksiyon alınacağını belirtmeniz gerekir."); return;
            }
            var releaseAction = new RemoteMessage()
            {
                Type = "ReleaseAction",
                Action = "Will",
                From = Settings.Default.NickName,
                AfterMinutes = txtMinutes.Text,
                Environment = SelectedEnvironment,
                Message = string.Format("{0} dakika sonra {1} ortamına versiyon alınacaktır. Lütfen check-in islemlerinizi tamamlayıp haber veriniz.", txtMinutes.Text, SelectedEnvironment),
                Time = DateTime.Now.ToString()
            };

            _server.SendMessage(JsonConvert.SerializeObject(releaseAction));
            txtMinutes.Text = string.Empty;
            envTest.IsChecked = false;
            envUAT.IsChecked = false;
            envLive.IsChecked = false;

        }

        private void btnVerNow_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedEnvironment))
            {
                ShowWarning("Hangi ortam için aksiyon alınacağını belirtmeniz gerekir."); return;
            }
            var releaseAction = new RemoteMessage()
            {
                Type = "ReleaseAction",
                Action = "Now",
                From = Settings.Default.NickName,
                AfterMinutes = "",
                Environment = SelectedEnvironment,
                Message = string.Format("{0} ortamına versiyon alınınıyor. Check-in yasakları başlamıştır.", SelectedEnvironment),
                Time = DateTime.Now.ToString()
            };

            _server.SendMessage(JsonConvert.SerializeObject(releaseAction));
            txtMinutes.Text = string.Empty;
            envTest.IsChecked = false;
            envUAT.IsChecked = false;
            envLive.IsChecked = false;
        }

        private void btnVerPast_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedEnvironment))
            {
                ShowWarning("Hangi ortam için aksiyon alınacağını belirtmeniz gerekir."); return;
            }
            var releaseAction = new RemoteMessage()
            {
                Type = "ReleaseAction",
                Action = "Past",
                From = Settings.Default.NickName,
                AfterMinutes = "",
                Environment = SelectedEnvironment,
                Message = string.Format("{0} ortamına versiyon alınmıştır. Lütfen check-in'lemiş olduğunuz task'ların statuslerini TESTING'e çekiniz.", SelectedEnvironment),
                Time = DateTime.Now.ToString()
            };

            _server.SendMessage(JsonConvert.SerializeObject(releaseAction));
            txtMinutes.Text = string.Empty;
            envTest.IsChecked = false;
            envUAT.IsChecked = false;
            envLive.IsChecked = false;
        }

        private void btnVerReady_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedEnvironment))
            {
                ShowWarning("Hangi ortam için aksiyon alınacağını belirtmeniz gerekir."); return;
            }
            var releaseAction = new RemoteMessage()
            {
                Type = "ReleaseAction",
                Action = "Ready",
                From = Settings.Default.NickName,
                AfterMinutes = "",
                Environment = SelectedEnvironment,
                Message = string.Format("{0} ortamına versiyon alınmış ve task'lar TESTING statusüne çekilmiştir. TESTE başlanabilir.", SelectedEnvironment),
                Time = DateTime.Now.ToString()
            };

            _server.SendMessage(JsonConvert.SerializeObject(releaseAction));
            txtMinutes.Text = string.Empty;
            envTest.IsChecked = false;
            envUAT.IsChecked = false;
            envLive.IsChecked = false;
        }

    }
}
