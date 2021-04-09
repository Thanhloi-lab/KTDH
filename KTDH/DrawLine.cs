using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace KTDH
{
    public class DrawLine
    {
        private static int space = 3;
        private static int line = 5;

        public static int Space { get => space; set => space = value; }
        public static int Line { get => line; set => line = value; }

        public static List<Point> DDA(Point point1, Point point2)
        {
            List<Point> points = new List<Point>();

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
