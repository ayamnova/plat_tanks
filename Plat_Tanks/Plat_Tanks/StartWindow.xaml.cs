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
using System.Net.Sockets;
using System.Threading;

namespace Plat_Tanks
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary/>

    public partial class StartWindow : Window
    {
        public static int[] HighScores = new int[3]; //store the high scores

        public StartWindow()
        {
            InitializeComponent();
        }

        //start a new hotseat match and hide this window
        private void hotSeatButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow hotSeatGame = new MainWindow();
            hotSeatGame.Show();
            hotSeatGame.Closed += GameWindow_Closed;
        }

        //catch when the Tanks Battle ends
        private void GameWindow_Closed(object sender, EventArgs e)
        {
            HomeGrid.Visibility = Visibility.Visible;
            this.Show();
        }

        //go to the instructions page
        private void instructionsButton_Click(object sender, RoutedEventArgs e)
        {
            instructionsText.Text = "Tanks is a two player game. The objective is destroy the other player. Move the tank by using the right and left arrow keys. Raise and lower the barrel with the up and down arrow keys. Shoot by pressing the Space key. The longer you hold it, the further the shot will go. Enjoy!";
            HomeGrid.Visibility = Visibility.Hidden;
            instructionsGrid.Visibility = Visibility.Visible;
        }

        //go back to the homegrid from the instructions grid
        private void instructionsBackButton_Click(object sender, RoutedEventArgs e)
        {
            instructionsGrid.Visibility = Visibility.Hidden;
            HomeGrid.Visibility = Visibility.Visible;
        }

        //go to the highscores page
        private void highScoresButton_Click(object sender, RoutedEventArgs e)
        {
            highestScoreText.Text = "Lowest Score: " + HighScores[0].ToString();
            secondHighestScoreText.Text = "2nd Lowest Score: " + HighScores[1].ToString();
            thirdHighestScoreText.Text = "3rd Lowest Score: " + HighScores[2].ToString();
            highScoresGrid.Visibility = Visibility.Visible;
            HomeGrid.Visibility = Visibility.Hidden;
        }

        //go back to the homeGrid from the highscores page
        private void highScoresBackButton_Click(object sender, RoutedEventArgs e)
        {
            highScoresGrid.Visibility = Visibility.Hidden;
            HomeGrid.Visibility = Visibility.Visible;
        }
        
        ///////// The following code is a work in progress to enable the internet features, DO NOT USE YET! :P
        
        //go the internet grid
        private void internetButton_Click(object sender, RoutedEventArgs e)
        {
            HomeGrid.Visibility = Visibility.Hidden;
            internetConnectGrid.Visibility = Visibility.Visible;
        }

        private void hostButton_Click(object sender, RoutedEventArgs e)
        {
            AsynchronousSocketListener serverHost = new AsynchronousSocketListener();            
            Thread serverThread = new Thread(serverHost.Main);
            serverThread.Start();
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            ipAddressTextBox.Visibility = Visibility.Visible;
            connectToIP.Visibility = Visibility.Visible;
        }

        private void connectToIP_Click(object sender, RoutedEventArgs e)
        {
            AsynchronousClient client = new AsynchronousClient();
            AsynchronousClient.IpToConnectTo = ipAddressTextBox.Text;          
            if (client.Main())
            {
                MainWindow gameWindow = new MainWindow(AsynchronousClient.IpToConnectTo, false, true);
                gameWindow.Show();
                gameWindow.Closed += GameWindow_Closed;
                this.Hide();
            }
            else
            {
                Console.WriteLine("I didnt find a host");
            }
            
        }

    }
}
