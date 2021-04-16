using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace KTDH
{
    public class MyCoordinate
    {
        public static Point centerPoint = new Point(350, 240);
        public static int scale = 5;

        public static Point ConvertToMyPoint(Point point)
        {
            return new Point((point.X - centerPoint.X) / scale, (centerPoint.Y - point.Y) / scale);
        }
        public static List<Point> DrawMyCoordinateAxis()
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < centerPoint.X * 2; i++)
            {
                Point point = new Point(i, centerPoint.Y);
                points.Add(point);
            }
            for (int i = 0; i < centerPoint.Y * 2; i++)
            {
                Point point = new Point(centerPoint.X, i);
                points.Add(point);
            }
            return points;
        }
        public static List<Point> DrawNetPixel()
        {
            List<Point> points = new List<Point>();
            for (int i = 2; i <= centerPoint.X * 2; i += scale)
            {
                Point point = new Point(i, 0);
                Point point1 = new Point(i, centerPoint.Y * 2);
                points.Add(point);
                points.Add(point1);
            }
            for (int i = 2; i <= centerPoint.Y * 2; i += scale)
            {
                Point point = new Point(0, i);
                Point point1 = new Point(centerPoint.X * 2, i);
                points.Add(point);
                points.Add(point1);
            }
            return points;
        }
    }
}
