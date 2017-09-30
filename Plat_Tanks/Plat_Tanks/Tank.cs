using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace Plat_Tanks
{
    public class Tank
    {
        //this class contains methods and properties to keep track
        //of each player's position and to calculate the missile's velocity components
        public int ShotsFired = 0;
        public double Angle = 0;
        public Point Position = new Point();
        public Dictionary<string, Image> Images = new Dictionary<string, Image>();
        private double firePower = 300;
        private double fireIncreaseRate = 0;
        private bool isFacingRight;

        public Tank(Image body, Image gun, Image missile, bool facingRight) 
        {
            Images.Add("Body", body);
            Images.Add("Gun", gun);
            Images.Add("Missile", missile);
            isFacingRight = facingRight;
        }

        //handle arrow key input
        public void Update (Key key)
        {
            switch (key)
            {
                case Key.Left:
                    MoveTank("left");
                    break;
                case Key.Right:
                    MoveTank("right");
                    break;
                case Key.Up:
                    MoveBarrel("up");
                    break;
                case Key.Down:
                    MoveBarrel("down");
                    break;
                case Key.Space:
                    IncreaseFirePower();
                    break;
            }
        }
        //code for moving the body
        public void MoveTank(string direction)
        {
            if (direction == "left")
            {
                Position.X -= 2.5;
            }
            else if (direction == "right")
            {
                Position.X += 2.5;
            }
        }
        
        //code for moving the barrel
        public void MoveBarrel(string direction)
        {
            if (direction == "up")
            {
                if (isFacingRight)
                {
                    if (Angle >= -15)
                    {
                        Angle -= 0.5;
                    }
                }
                else if (!isFacingRight)
                {
                    if (Angle <= 15)
                    {
                        Angle += 0.5;
                    }
                }

            }
            else if (direction == "down")
            {
                if (isFacingRight)
                {
                    if (Angle <= 4)
                    {
                        Angle += 0.5;
                    }
                }
                else if (!isFacingRight)
                {
                    if (Angle >= -4)
                    {
                        Angle -= 0.5;
                    }

                }
            }
          
        }

        //increases the fire exponentially
        public void IncreaseFirePower()
        {
            if (firePower < 450)
            {
                firePower += fireIncreaseRate;
                fireIncreaseRate += 1;
            }
        }

        public Tuple<double, double> Fire()
          {
            //returns the components for the missile's path --> item1 = horizontal component and item2 = vertical component
            ShotsFired += 1;
            //make the fire angle greater
            if (Angle < -5)
            {
                Angle -= 20;
            }
            else if (Angle > 5)
            {
                Angle += 20;
            }
            //calculate the components of the flight path
            double horizontalVelocity = Math.Abs(firePower * Math.Cos((Math.PI/180) * Angle));
            double verticalVelocity = Math.Abs(firePower * Math.Sin((Math.PI / 180) * Angle));
            
            //account for facing opposite sides
            if (!isFacingRight)
            {
                horizontalVelocity *= -1;
            }
            //reset firepower and angle 
            firePower = 300;
            if (Angle < -5)
            {
                Angle += 20;
            }
            else if (Angle > 5)
            {
                Angle -= 20;
            }
            return Tuple.Create(horizontalVelocity, verticalVelocity);
        }
    }


}
