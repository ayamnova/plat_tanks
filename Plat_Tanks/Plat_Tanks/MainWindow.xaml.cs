using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
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
using System.Net;
using System.Threading;

namespace Plat_Tanks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //this class is used to run the main game
        //currently it supports playing on one computer
        //but code exists to implement online play at a later date
        
        //these are the main program flags
        bool gameOver = false;
        bool isPlayerOneTurn = false;
        bool shotFired = false;
        bool isBetweenTurns = true;
        //only for online play
        private bool isPlayer1 = true; //stores whether this computer controls Player1 or Player2

        //these properties are used only for the missile after it has been fired
        double horizontalComponent = 0;
        double verticalComponent = 0;
        double missileAngle = 0;
        TranslateTransform missileTranslation = new TranslateTransform();
        DateTime startTime;
        DispatcherTimer missileTimer = new DispatcherTimer();

        //this is for the clock that runs during turns
        DateTime turnStartTime;
        DispatcherTimer turnClock = new DispatcherTimer();

        public Tank Player1;
        public Tank Player2;

        public GameMode Mode = GameMode.hotSeat;

        public enum GameMode
        {
            hotSeat,
            online
        }

        public MainWindow(string IpAddressToConnectTo = "", bool hosting = false, bool isOnline = false)
        {
            InitializeComponent();
            bool isHosting = hosting;

            if (!isOnline) //playing on the same computer
            {
                Mode = GameMode.hotSeat;
                Player1 = new Tank(tank1Body, tank1Gun, tank1Missile, true);
                Player2 = new Tank(tank2Body, tank2Gun, tank2Missile, false);
            }
            else if (isOnline)
            {
                Mode = GameMode.online;
                if (isHosting == true) //server running on this computer
                {
                    Player1 = new Tank(tank1Body, tank1Gun, tank1Missile, true);
                    Player2 = new Tank(tank2Body, tank2Gun, tank2Missile, false);
                }
                else //server running on the other computer
                {
                    Player1 = new Tank(tank1Body, tank1Gun, tank1Missile, true);
                    Player2 = new Tank(tank2Body, tank2Gun, tank2Missile, false);
                }
                
            }

            missileTimer.Tick += MissileTimer_Tick;
            missileTimer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            turnClock.Tick += TurnClock_Tick;
            turnClock.Interval = new TimeSpan(0, 0, 0, 0, 10);
            endTurn("Player 2");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Mode == GameMode.hotSeat)
            {
                if (isBetweenTurns)
                {
                    //turn OFF the between-turns display
                    BetweenTurnsDisplay(1); 
                }
                if (!shotFired)
                {
                    //update the tank position based on which key pressed 
                    //and whose turn it is
                    if (isPlayerOneTurn)
                    {
                        Player1.Update(e.Key);
                    }
                    else if (!isPlayerOneTurn)
                    {
                        Player2.Update(e.Key);
                    }
                    if (e.Key != Key.Space)
                    {
                        Update();
                    }
                }
                if (gameOver)
                {
                    //game finished -> close this window
                    this.Close();
                }
            }
            else if (Mode == GameMode.online)
            {
                if (isPlayer1 && isPlayerOneTurn) 
                {
                    if (isBetweenTurns)
                    {
                        BetweenTurnsDisplay(1);
                    }
                    if (!shotFired && isPlayerOneTurn)
                    {
                        Player1.Update(e.Key);
                    }
                }
                else if (!isPlayer1 && !isPlayerOneTurn)
                {
                    if (isBetweenTurns)
                    {
                        BetweenTurnsDisplay(1);
                    }
                    if (!shotFired && !isPlayerOneTurn)
                    {
                        Player2.Update(e.Key);
                    }
                }
                if (gameOver)
                {
                    this.Close();
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && !shotFired)
            {
                //fire the missile when the Space Bar is pressed
                //and determine who shot based on whose turn it is
                if (Mode == GameMode.hotSeat)
                {
                    if (isPlayerOneTurn)
                    {
                        FireMissile(Player1);
                    }
                    else if (!isPlayerOneTurn)
                    {
                        FireMissile(Player2);

                    }
                }
                else if (Mode == GameMode.online)
                {
                    if (isPlayer1 && isPlayerOneTurn)
                    {
                        FireMissile(Player1);
                    }
                    else if (!isPlayer1 && !isPlayerOneTurn)
                    {
                        FireMissile(Player2);
                    }
                }
                
            }

        }

        //every tick check to see if the turn has lasted longer than 10 seconds
        private void TurnClock_Tick(object sender, EventArgs e)
        {
            TimeSpan timeInterval = DateTime.Now.Subtract(turnStartTime);
            double seconds = 10 - (timeInterval.Seconds + timeInterval.Milliseconds * (1/1000));
            timeDisplay.Text = "Time Left: " + seconds.ToString();
            if (!shotFired)
            {
                if (seconds < 0)
                {
                    if (isPlayerOneTurn)
                    {
                        endTurn("Player 1");
                    }
                    else if (!isPlayerOneTurn)
                    {
                        endTurn("Player 2");
                    }
                    turnClock.Stop();
                }
            }
            else if (shotFired)
            {
                turnClock.Stop();
            }
        }

        //Update renders the layout transforms according to the updated player positions
        private void Update()
        {
            RotateTransform rotation = new RotateTransform();
            TranslateTransform translation = new TranslateTransform();
            TransformGroup gunTransform = new TransformGroup();

            if (isPlayerOneTurn)
            {
                //update rotation
                rotation.Angle = Player1.Angle;
                gunTransform.Children.Add(rotation);

                //update translation
                translation.X = Player1.Position.X;
                gunTransform.Children.Add(translation);

                //render transformations
                tank1Gun.RenderTransform = gunTransform;
                tank1Body.RenderTransform = translation;
            }
            else if (!isPlayerOneTurn)
            {
                //make the gun rotate from the bottom right corner
                tank2Gun.RenderTransformOrigin = new Point(1, 1);

                //update rotation
                rotation.Angle = Player2.Angle;
                gunTransform.Children.Add(rotation);

                //update translation
                translation.X = Player2.Position.X;
                gunTransform.Children.Add(translation);

                //render transformations
                tank2Gun.RenderTransform = gunTransform;
                tank2Body.RenderTransform = translation;
            }

        }

        //turns on and off the in between turn display
        private void BetweenTurnsDisplay(int num, string player="")
        {
            switch (num)
            {
                case 0:
                    //turn over screen On --> Turn has ended
                    isBetweenTurns = true;
                    screenRectangle.Visibility = Visibility.Visible;
                    Display.Text = player + " Turn";
                    Display.Visibility = Visibility.Visible;
                    subDisplay.Visibility = Visibility.Visible;
                    break;
                case 1:
                    //turn over screen Off --> Turn has begun
                    screenRectangle.Visibility = Visibility.Hidden;
                    Display.Visibility = Visibility.Hidden;
                    subDisplay.Visibility = Visibility.Hidden;
                    turnStartTime = DateTime.Now;
                    turnClock.Start();
                    isBetweenTurns = false;
                    shotFired = false;
                    break;
            }
        }

        //throw the party for the player who wins
        private void setWinner (string player)
        {
            winnerTextBlock.Text = player;
            Storyboard sb = FindResource("victoryStoryboard") as Storyboard;
            sb.Begin();
            winnerTextBlock.Visibility = Visibility.Visible;
            subDisplay.Text = "Press Any Key To Continue";
            subDisplay.Visibility = Visibility.Visible;
            gameOver = true;
        }
       
        //change whose turn it is 
        private void endTurn(string player)
        {
            //change the turn
            if (player == "Player 1")
            {
                isPlayerOneTurn = false;
                player = "Player 2";
            }
            else if (player == "Player 2")
            {
                isPlayerOneTurn = true;
                player = "Player 1";
            }
            BetweenTurnsDisplay(0, player);
        }

        //figure out all the nitty-gritty details once the missile is fired
        private void FireMissile(Tank player)
        {
            //determine transforms to be applied to the missile
            shotFired = true;
            TransformGroup transforms = new TransformGroup();
            TranslateTransform translate = new TranslateTransform();
            RotateTransform rotate = new RotateTransform();

            //these transforms put the missile where the tank has moved to
            //translations based on Player position and . . . TRIG! :(
            translate.X = player.Position.X;
            translate.Y = Math.Sin(player.Angle);
            //rotations based on angle
            missileAngle = player.Angle;
            rotate.Angle = missileAngle;
            //render transforms to the missile by accessing the tank image dictionary
            player.Images["Missile"].RenderTransform = transforms;

            //figure out how hard up and how hard sideways it is being shot
            var velocities = Tuple.Create(0.0, 0.0);
            velocities = player.Fire();
            //start the missile fired clock
            startTime = DateTime.Now;
            missileTimer.Start();
            //store velocity components
            horizontalComponent = velocities.Item1;
            verticalComponent = velocities.Item2;
            player.Images["Missile"].Visibility = Visibility.Visible;
        }

        //main logic for the missile's collisions, who wins, when a turn ends, etc
        private void MissileTimer_Tick(object sender, EventArgs e)
        {
            bool isCollision = false;
            bool hitTank = false;

            if (isPlayerOneTurn)
            {
                Tuple<bool, bool> conditions = MissileConditions(Player1, Player2);
                isCollision = conditions.Item1;
                hitTank = conditions.Item2;
                if(isCollision) //missile hit something
                {
                    missileTimer.Stop();
                    if (hitTank) //missile hit the tank --> Player 1 wins
                    {
                        setWinner("Player 1 Wins!");
                        updateHighScores(Player1);
                    }
                    else //missile hit the ground
                    {
                        endTurn("Player 1");
                    }
                }
                else //missile is still in the air
                {
                    UpdateMissile(Player1);
                }
            }
            else if (!isPlayerOneTurn)
            {
                Tuple<bool, bool> conditions = MissileConditions(Player2, Player1);
                isCollision = conditions.Item1;
                hitTank = conditions.Item2;
                if (isCollision) //missile hit something
                {
                    missileTimer.Stop();
                    if (hitTank) //missile hit tank --> Player 2 wins
                    {
                        setWinner("Player 2 Wins!");
                        updateHighScores(Player2);
                    }
                    else //missile hit the ground
                    {
                        endTurn("Player 2");
                    }
                }
                else //missile is still in the air
                {
                    UpdateMissile(Player2);
                }
            }       
        }

        //change where the missile is on the screen
        private void UpdateMissile(Tank player)
        {
            TransformGroup missileTransforms = new TransformGroup();
            RotateTransform rotation = new RotateTransform();

            //figure out how many seconds have passed since the missile was fired
            TimeSpan timeInterval = DateTime.Now - startTime;
            double time = timeInterval.TotalMilliseconds / 1000;
            double gravity = 75 * Math.Pow(time, 2); //gravity constant
            
            //determine components of translation based on components from firePower
            missileTranslation.Y = (-1 * verticalComponent * time) + gravity + player.Position.Y;
            missileTranslation.X = horizontalComponent * time + player.Position.X;

            if (player == Player1)
            {
                if (missileAngle < 90)
                {
                    missileAngle += 0.2; //increment the angle of rotation
                }
            }
            else if (player == Player2)
            {
                if (missileAngle > -90)
                {
                    missileAngle -= 0.2; //decrement angle of rotation
                }
            }
            //render transformations
            rotation.Angle = missileAngle;
            missileTransforms.Children.Add(rotation);
            missileTransforms.Children.Add(missileTranslation);
            player.Images["Missile"].RenderTransform = missileTransforms;
        }

        //figure out if the missile hit anything
        private Tuple<bool, bool> MissileConditions(Tank shooter, Tank victim)
        {
            Tuple<Rect, Rect, Rect> boxes = FindHitBoxes(shooter, victim);
            Tuple<bool, bool> conditions = CheckCollisions(boxes);
            return conditions;
        }

        //find where the collision boxes are
        private Tuple<Rect, Rect, Rect> FindHitBoxes(Tank player, Tank otherPlayer)
        {
            Rect missileBox = new Rect();
            Rect tankBox = new Rect();
            Rect ground = new Rect();

            //ground rectangle
            Point groundCorner = groundLeftImage.PointToScreen(new Point(0, 0));
            ground.X = groundCorner.X;
            ground.Y = groundCorner.Y;
            ground.Height = groundCorner.Y + groundLeftImage.ActualHeight;
            ground.Width = this.Width;

            //tank rectangle
            Point tankBoxCorner = otherPlayer.Images["Body"].PointToScreen(new Point(0, 0));
            tankBox.X = tankBoxCorner.X;
            tankBox.Y = tankBoxCorner.Y;
            tankBox.Height = otherPlayer.Images["Body"].ActualHeight;
            tankBox.Width = otherPlayer.Images["Body"].ActualWidth;

            //missile rectangle
            Point missileBoxCorner = player.Images["Missile"].PointToScreen(new Point(0, 0));
            missileBox.X = missileBoxCorner.X;
            missileBox.Y = missileBoxCorner.Y;
            missileBox.Height = player.Images["Missile"].ActualHeight;
            missileBox.Width = player.Images["Missile"].ActualWidth;

            return Tuple.Create(missileBox, tankBox, ground);
        }

        //check to see if the missile rectangle hit any other rectangles
        private Tuple<bool, bool> CheckCollisions(Tuple<Rect, Rect, Rect> boxes)
        {
            bool isCollision = false;
            bool hitTank = false;

            Rect missileBox = boxes.Item1;
            Rect otherTank = boxes.Item2;
            Rect ground = boxes.Item3;

            //check if hits other Tank
            Rect collisionBox = missileBox;
            collisionBox.Intersect(otherTank);
            if (!collisionBox.IsEmpty)
            {
                isCollision = true;
                hitTank = true;
            }
            //check for ground collision
            collisionBox = missileBox;
            collisionBox.Intersect(ground);
            if (!collisionBox.IsEmpty)
            {
                isCollision = true;
                hitTank = false;
            }
            //check if off screen
            if (missileBox.BottomRight.X > ground.BottomRight.X || missileBox.BottomLeft.X < ground.BottomLeft.X - 15)
            {
                isCollision = true;
                hitTank = false;
            }
            return Tuple.Create(isCollision, hitTank);
        }

        //figures out if one of the players made it onto the top three lowest scores
        private void updateHighScores(Tank player)
        {
            if (player.ShotsFired < StartWindow.HighScores[2] || StartWindow.HighScores[2] == 0) //player's shot less than third best
            {
                StartWindow.HighScores[2] = player.ShotsFired;
            }
            if (StartWindow.HighScores[2] < StartWindow.HighScores[1] || StartWindow.HighScores[1] == 0) //player shot less than the second best
            {
                int temp = StartWindow.HighScores[1];
                StartWindow.HighScores[1] = StartWindow.HighScores[2];
                StartWindow.HighScores[2] = temp;
            }
            if (StartWindow.HighScores[1] < StartWindow.HighScores[0] || StartWindow.HighScores[0] == 0) //player shot less than the best
            {
                int temp = StartWindow.HighScores[1];
                StartWindow.HighScores[1] = StartWindow.HighScores[0];
                StartWindow.HighScores[0] = temp;
            }
        }
    }
}
