using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VersInformer.Remote;

namespace VersInformer.Client
{
    /// <summary>
    /// Interaction logic for NotifyToast.xaml
    /// </summary>
    public partial class NotifyToast : Window
    {

        public RemoteMessage Message
        {
            set
            {
                lblMessage.Text = value.Message;
                lblFrom.Text = value.From;

                GradientStopCollection gradientColl = null;
                switch (value.Action)
                {
                    case "Will": 
                        gradientColl = new GradientStopCollection();
                        gradientColl.Add(new GradientStop(Colors.Coral, 0d));
                        gradientColl.Add(new GradientStop(Colors.Orange, 0.5d));
                        gradientColl.Add(new GradientStop(Colors.Yellow, 1d));

                        break;
                    case "Now":
                        gradientColl = new GradientStopCollection();
                        gradientColl.Add(new GradientStop(Colors.Firebrick, 0d));
                        gradientColl.Add(new GradientStop(Colors.Red, 0.5d));
                        gradientColl.Add(new GradientStop(Colors.Tomato, 1d));

                        break;
                    case "Past":
                        gradientColl = new GradientStopCollection();
                        gradientColl.Add(new GradientStop(Colors.Green, 0d));
                        gradientColl.Add(new GradientStop(Colors.Lime, 0.5d));
                        gradientColl.Add(new GradientStop(Colors.YellowGreen, 1d));

                        break;
                    case "Ready":
                        gradientColl = new GradientStopCollection();
                        gradientColl.Add(new GradientStop(Colors.RoyalBlue, 0d));
                        gradientColl.Add(new GradientStop(Colors.SkyBlue, 0.5d));
                        gradientColl.Add(new GradientStop(Colors.MediumTurquoise, 1d));

                        break;
                    default:
                        break;
                }
                if (gradientColl != null)
                {
                    var brush = new LinearGradientBrush(gradientColl, new Point(0, 0), new Point(0, 1));
                    notifyToast.Background = brush;
                }
            }
        }

        public NotifyToast()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
