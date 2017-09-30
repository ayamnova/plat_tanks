using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BomberTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void JoinGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Set HostIP from somewhere
            AsynchronousClient.HostIP = "10.70.1.1"; // InputIPTextBox.Text;

            // Set Data to send over when first connected
            AsynchronousClient.DATA = NameBox.Text + "<NAME>";

            // Create a new thread to run the communications in the background
            Thread joinGame = new Thread(AsynchronousClient.StartClient);
            joinGame.Start(); // Start thread

            // Signal to the communications thread to go ahead and send the data
            AsynchronousClient.SendNow.Set();

            // For demonstration purposes, we start up a timer to check ever .5 seconds
            // to see what the response is from the previous communication with the server
            // and then to send a new piece of data to the server
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.5) };
            timer.Start();
            timer.Tick += (senders, args) =>
            {
                //timer.Stop();
                // Look at the previous response and decide what to do with it
                string response = AsynchronousClient.Response;
                if (response.IndexOf("<#PLAYER>") > -1)
                {
                    textBlock.Text = response.Remove(response.Length - 9);
                }

                // put a new piece of data to send and fire the signal to have the
                // communications thread send it.
                AsynchronousClient.DATA = "<PING>";
                AsynchronousClient.SendNow.Set();
            };
        }

    }
}