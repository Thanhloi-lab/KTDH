using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace KTDH
{
    public class MyCoordinate
    {
        public static int myX = 0;
        public static int myY =0;

        public static Point ConvertToMyPoint(int x, int y)
        {
            return new Point(x - myX, y - myY);
        }
        public static List<Point> DrawMyCoordinate(Point center)
        {
            List<Point> points = new List<Point>();
            for(int i=0; i<center.X*2; i++)
            {
                Point point = new Point(i, center.Y);
                points.Add(point);
            }
            for (int i = 0; i < center.Y * 2; i++)
            {
                Point point = new Point(center.X, i);
                points.Add(point);
            }
            return points;
        }
    }
}
