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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace Valet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Socket sck = null;
        private EndPoint epLocal = null;
        private EndPoint epRemote = null;
        private byte[] buffer;
        private string valetiP = GetLocalIP();
        private string residentIp = GetLocalIP();
        private string valetPort = "11001";
        private string residentPort = "11000";
        string receivedMessage;
        
        public List<string> Builiding = new List<string> { "A", "B", "C", "D" };
        public List<string> Number = new List<string> { "1", "2", "3", "4", "5", "6" };
        public List<string> Message = new List<string> { "Trash was not bagged", "Hazardous Material", "Exceeded weight limit" };
        public string resident;
        string message;
        string building;
        string number;

        public MainWindow()
        {
            InitializeComponent();
            buildingComboBox.ItemsSource = Builiding;
            numberComboBox.ItemsSource = Number;
            noPickUpBox.ItemsSource = Message;
            residentBox.Text = message;

        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(valetiP), int.Parse(valetPort));
                sck.Bind(epLocal);

                epRemote = new IPEndPoint(IPAddress.Parse(residentIp), int.Parse(residentPort));
                sck.Connect(epRemote);

                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);

                if (size > 0)
                {
                    byte[] receivedData = new byte[1500];

                    receivedData = (byte[])aResult.AsyncState;

                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    receivedMessage = eEncoding.GetString(receivedData);

                }

                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

            if (receivedMessage == "A1Y" ) 
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "A2Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "A3Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "A4Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "A5Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "A6Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "B1Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "B2Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "B3Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "B4Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "B5Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "B6Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "C1Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "C2Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "C3Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "C4Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "C5Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "C6Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "D1Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "D2Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "D3Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "D4Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "D5Y")
            {
                a1Box.Background = Brushes.Green;
            }
            if (receivedMessage == "D6Y")
            {
                a1Box.Background = Brushes.Green;
            }


        }

        private void buildingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            building = buildingComboBox.SelectedItem as string;
            if (buildingComboBox.SelectedItem != null)
            {
                resident = building + number;
            }
            residentBox.Text = resident;

        }

        private void numberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            number = numberComboBox.SelectedItem as string;
            if (numberComboBox.SelectedItem != null)
            {
                resident = building + number;
            }
            residentBox.Text = resident;
            if (buildingComboBox.SelectedItem != null && number != null) 
            {
                yesButton.IsEnabled = true;
                NoButton.IsEnabled = true;
            }
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            submitButton.IsEnabled = true;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            noPickUpBox.IsEnabled = true;
        }
        private void noPickUpBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            message = noPickUpBox.SelectedItem as string;
            if (noPickUpBox.SelectedItem != null) 
            {
                submitButton.IsEnabled=true;
            }

        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (noPickUpBox == null) 
            {
                try
                {
                    ASCIIEncoding enc = new ASCIIEncoding();
                    byte[] msg = new byte[1500];
                    msg = enc.GetBytes("You're trash has been picked up, Thank you!");

                    sck.Send(msg);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (noPickUpBox != null)
            {
                try
                {
                    ASCIIEncoding enc = new ASCIIEncoding();
                    byte[] msg = new byte[1500];
                    msg = enc.GetBytes("Your trash was not picked up because " + message);

                    sck.Send(msg);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }

    }
}
