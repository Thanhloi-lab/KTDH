using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace KTDH
{
    public class DrawRecangle
    {
        public static int space = 3;
        public static int line = 5;

        public static List<Point> DDA(Point point1, Point point2)
        {
            Point point3 = new Point(point1.X, point2.Y);
            Point point4 = new Point(point2.X, point1.Y);
            List<Point> points = new List<Point>();
            List<Point> temp = new List<Point>();
            temp = DrawLine.DDA(point1, point3);
            points.AddRange(temp);
            temp = DrawLine.DDA(point1, point4);
            points.AddRange(temp);
            temp = DrawLine.DDA(point4, point2);
            points.AddRange(temp);
            temp = DrawLine.DDA(point2, point3);
            points.AddRange(temp);
            return points;
        }
        //public static void DrawRecangleByListPoint(List<Point> points, Graphics graphics, Pen pen)
        //{
        //    for (int i = 0; i < points.Count - 1; i ++)
        //    {
        //        graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
        //        if (i == points.Count - 1)
        //        {
        //            Point temp = points.ElementAt(i);
        //            temp.X = temp.X++;
        //            temp.Y = temp.Y++;
        //            graphics.DrawLine(pen, points.ElementAt(i), temp);
        //        }

        //    }
        //}
    }
}
