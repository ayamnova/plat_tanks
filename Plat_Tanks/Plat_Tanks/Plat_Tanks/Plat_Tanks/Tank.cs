using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace G_FinalProject_Ladnerka
{
    class Tank
    {

        public double Angle = 0;
        public double PreviousAngle = 0;
        public Point Position = new Point();
        private double firePower = 100;
        private double fireIncreaseRate = 0;

        //private TranslateTransform position = new TranslateTransform();
        //private RotateTransform gunAngle = new RotateTransform();

        public Tank()
        {
           
        }

        public void UpdatePosition()
        {

        }

        public void MoveTank(string direction)
        {
            if (direction == "left")
            {
                Position.X -= 10;
            }
            else if (direction == "right")
            {
                Position.X += 10;
            }
        }

        public void MoveBarrel(string direction)
        {
            if (direction == "up")
            {
                if (Angle >= -15)
                {
                    Angle -= 0.5;
                }
            }
            else if (direction == "down")
            {
                if (Angle <= 3)
                {
                    Angle += 0.5;
                }

            }

            /*
            if (IsFacingRight)
            {
                if (direction == "up")
                {
                    if (Angle >= -15)
                    {
                        Angle -= 0.5;
                    }
                }
                else if (direction == "down")
                {
                    if (Angle <= 3)
                    {
                        Angle += 0.5;
                    }

                }
            }
            else if (!IsFacingRight)
            {
                if (direction == "up")
                {
                    if (Angle <= 15)
                    {
                        Angle += 0.5;
                    }
                }
                else if (direction == "down")
                {
                    if (Angle >= -3)
                    {
                        Angle -= 0.5;
                    }
                }
            }
            */
        }
        public void IncreaseFirePower()
        {
            if (firePower < 450)
            {
                firePower += fireIncreaseRate;
                fireIncreaseRate += 2;
            }
        }

        public Tuple<double, double> Fire()
          {
            //double horizontalVelocity = Math.Abs(firePower * Math.Cos(Angle));
            //double verticalVelocity = Math.Abs(firePower * Math.Sin(Angle));
            if (Angle < 0)
            {
                Angle -= 20;
            }
            double horizontalVelocity = Math.Abs(firePower * Math.Cos((Math.PI/180) * Angle));
            double verticalVelocity = Math.Abs(firePower * Math.Sin((Math.PI / 180) * Angle));
            return Tuple.Create(horizontalVelocity, verticalVelocity);
        }
    }


}
