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
using System.Windows.Threading;


namespace G_FinalProject_Ladnerka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isPlayerOneTurn = true;
        bool shotFired = false;

        double horizontalComponent = 0;
        double verticalComponent = 0;
        double missileAngle = 0;

        Tank Player1 = new Tank();
        Tank Player2 = new Tank();

        TranslateTransform missileTranslation = new TranslateTransform();

        DateTime startTime;
        DispatcherTimer missileTimer = new DispatcherTimer();

        TranslateTransform arrowTranslate = new TranslateTransform();



        public MainWindow()
        {
            InitializeComponent();
            missileTimer.Tick += MissileTimer_Tick;
            missileTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
        }

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
                rotation.Angle = -1 * Player2.Angle;
                gunTransform.Children.Add(rotation);

                //update translation
                translation.X = Player2.Position.X;
                gunTransform.Children.Add(translation);

                //render transformations
                tank2Gun.RenderTransform = gunTransform;
                tank2Body.RenderTransform = translation;
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (isPlayerOneTurn)
            {
                switch (e.Key)
                {
                    case Key.Left:
                        Player1.MoveTank("left");
                        break;
                    case Key.Right:
                        Player1.MoveTank("right");
                        break;
                    case Key.Up:
                        Player1.MoveBarrel("up");
                        break;
                    case Key.Down:
                        Player1.MoveBarrel("down");
                        break;
                    case Key.Space:
                        Player1.IncreaseFirePower();
                        break;
                }
            }
            else if (!isPlayerOneTurn)
            {
                switch (e.Key)
                {
                    case Key.Left:
                        Player2.MoveTank("left");
                        break;
                    case Key.Right:
                        Player2.MoveTank("right");
                        break;
                    case Key.Up:
                        Player2.MoveBarrel("up");
                        break;
                    case Key.Down:
                        Player2.MoveBarrel("down");
                        break;
                    case Key.Space:
                        Player2.IncreaseFirePower();
                        break;
                }
            }
            Update();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            var velocities = Tuple.Create(0.0, 0.0); 

            if (isPlayerOneTurn)
            {
                switch (e.Key)
                {
                    case Key.Space:
                        tank1Missile.RenderTransform = new RotateTransform(Player1.Angle);
                        velocities = Player1.Fire();
                        shotFired = true;

                        //transform the missile to the tip of the barrel and make it visible
                        missileAngle = Player1.Angle;
                        TransformGroup transforms = new TransformGroup();
                        TranslateTransform translation = new TranslateTransform(Player1.Position.X, Math.Sin(Player1.Angle));
                        RotateTransform rotation = new RotateTransform(missileAngle);
                        transforms.Children.Add(translation);
                        transforms.Children.Add(rotation);
                        tank1Missile.RenderTransform = transforms;
                        tank1Missile.Visibility = Visibility.Visible;

                        //start the missile fired clock
                        startTime = DateTime.Now;
                        missileTimer.Start();
                        horizontalComponent = velocities.Item1;
                        verticalComponent = velocities.Item2;
                        break;
                }
            }
            else if (!isPlayerOneTurn)
            {
                switch (e.Key)
                {
                    case Key.Space:
                        tank2Missile.RenderTransform = new RotateTransform(Player2.Angle);
                        velocities = Player2.Fire();
                        shotFired = true;

                        missileAngle = Player2.Angle;
                        TransformGroup transforms = new TransformGroup();
                        RotateTransform rotation = new RotateTransform(missileAngle);
                        TranslateTransform translation = new TranslateTransform(Player2.Position.X, Math.Sin(Player2.Angle));
                        transforms.Children.Add(rotation);
                        transforms.Children.Add(translation);
                        tank2Missile.RenderTransform = transforms;
                        tank2Missile.Visibility = Visibility.Visible;

                        horizontalComponent = velocities.Item1;
                        verticalComponent = velocities.Item2;
                        startTime = DateTime.Now;
                        missileTimer.Start();
                        break;
                }
            }

        }

        private void MissileTimer_Tick(object sender, EventArgs e)
        {
            //figure out how many seconds have passed since the missile was fired
            TimeSpan timeInterval = DateTime.Now - startTime;
            double time = timeInterval.TotalMilliseconds / 1000;
            double gravity = 75 * Math.Pow(time, 2); //gravity constant

            TransformGroup missileTransforms = new TransformGroup();
            RotateTransform rotation = new RotateTransform();
            Rect missileBox = new Rect();
            Rect tankBox = new Rect();
            Rect ground = new Rect();
            ground.X = groundLeftImage.Margin.Left;
            ground.Y = groundLeftImage.Margin.Top;
            ground.Height = groundLeftImage.ActualHeight;
            ground.Width = this.Width;

            if (isPlayerOneTurn)
            {
                bool isCollision = false;

                tankBox.X = tank2Body.Margin.Left;
                tankBox.Y = tank2Body.Margin.Top;
                tankBox.Height = tank2Body.ActualHeight;
                tankBox.Width = tank2Body.ActualWidth; 

                missileBox.X = tank1Missile.Margin.Left;
                missileBox.Y = tank1Missile.Margin.Top;
                missileBox.Height = tank1Missile.ActualHeight;
                missileBox.Width = tank1Missile.ActualWidth;

                Rect collisionBox = missileBox;
                collisionBox.Intersect(tankBox);
                if (!collisionBox.IsEmpty)
                {
                    isCollision = true;
                }
                collisionBox.Intersect(ground);
                if (!collisionBox.IsEmpty)
                {
                    isCollision = true;
                }

                if (!isCollision)
                {
                    //determine components of translation based on components from firePower
                    missileTranslation.X = horizontalComponent * time + Player1.Position.X;
                    missileTranslation.Y = (-1 * verticalComponent * time) + gravity + Player1.Position.Y;

                    if (missileAngle < 90)
                    {
                        missileAngle += 0.1; //increment the angle of rotation
                    }
                    //render transformations
                    rotation.Angle = missileAngle;
                    missileTransforms.Children.Add(rotation);
                    missileTransforms.Children.Add(missileTranslation);
                    tank1Missile.RenderTransform = missileTransforms;
                }
                if (isCollision)
                {
                    missileTimer.Stop();
                }
            }

                
            else if (!isPlayerOneTurn)
            {
                //determine components of translation based on components from firePower
                missileTranslation.X = -1 * horizontalComponent * time;
                missileTranslation.Y = (-1 * verticalComponent * time) + gravity;
                
                if (missileAngle > -90)
                {
                    missileAngle -= 0.1; //decrement angle of rotation
                }

                //render transformations
                rotation.Angle = missileAngle;
                missileTransforms.Children.Add(rotation);
                missileTransforms.Children.Add(missileTranslation);
                tank2Missile.RenderTransform = missileTransforms;
            }


            
        }
    }
}
