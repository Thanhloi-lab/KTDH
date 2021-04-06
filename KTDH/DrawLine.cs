using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace KTDH
{
    public class DrawLine
    {
        public static int space = 3;
        public static int line = 5;
        public static List<Point> DDA(Point point1, Point point2)
        {
            List<Point> points = new List<Point>();
            //point1.X = point1.X % 5 == 0 ? point1.X : (int)(point1.X / 5) * 5;
            //point1.Y = point1.Y % 5 == 0 ? point1.Y : (int)(point1.Y / 5) * 5;

            //point2.X = point2.X % 5 == 0 ? point2.X : (int)(point2.X / 5) * 5;
            //point2.Y = point2.Y % 5 == 0 ? point2.Y : (int)(point2.Y / 5) * 5;

            //point1.X = point1.X - 3;
            //point1.Y = point1.Y - 3;

            //point2.X = point2.X - 3;
            //point2.Y = point2.Y - 3;

            int dx = point2.X - point1.X;
            int dy = point2.Y - point1.Y;

            // calculate steps required for generating pixels
            int steps = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            // calculate increment in x & y for each steps
            float Xinc = dx / (float)steps;
            float Yinc = dy / (float)steps;

            // Put pixel for each step
            float X = point1.X;
            float Y = point1.Y;
            for (int i = 0; i <= steps; i++)
            {
                Point point = new Point();
                point.X = (int)X;
                point.Y = (int)Y;
                points.Add(point);
                X += Xinc;           // increment in x at each step
                Y += Yinc;           // increment in y at each step
            }

            return points;
        }
    }
}
