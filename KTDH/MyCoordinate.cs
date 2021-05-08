using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public static List<Point> Draw3DNetPixel()
        {
            List<Point> points = new List<Point>();
            List<Point> pointsY = new List<Point>();
            List<Point> pointsZ = new List<Point>();

            for (int i = 2; i <= centerPoint.X; i += scale)
            {
                Point point = new Point(centerPoint.X + i, 0);
                Point point1 = new Point(centerPoint.X + i, centerPoint.Y);
                points.Add(point);
                points.Add(point1);

                point = new Point(point.X, centerPoint.Y);
                point1 = new Point(point1.X, centerPoint.Y * 2);
                pointsY.Add(point);
                pointsY.Add(point1);
                
            }
            for (int i = 2; i <= centerPoint.Y; i += scale)
            {
                Point point = new Point(centerPoint.X, i);
                Point point1 = new Point(centerPoint.X * 2, i);
                points.Add(point);
                points.Add(point1);

                point = new Point(point.X - i*2, point.Y);
                point1 = new Point(point1.X, point1.Y);
                pointsZ.Add(point);
                pointsZ.Add(point1);
            }

            points.AddRange(pointsY);
            return points;
        }

        public static List<Point> DrawMyCoordinateAxis3D()
        {
            List<Point> pointsZ = new List<Point>();
            List<Point> points = new List<Point>();
            for (int i = 0; i < centerPoint.X; i++)
            {
                Point point = new Point(centerPoint.X + i, centerPoint.Y);
                points.Add(point);
            }
            for (int i = 0; i < centerPoint.Y*2; i++)
            {
                Point point = new Point(centerPoint.X, i);
                if (i > centerPoint.Y)
                {
                    pointsZ.Add(point);
                }
                else
                {
                    points.Add(point);
                }
            }
            List<List<double>> transform = Transformation.RotateTo(45);
            Point firstPoint = new Point(pointsZ.ElementAt(0).X, pointsZ.ElementAt(0).Y);
            pointsZ = Transformation.MoveToO(pointsZ, firstPoint);
            pointsZ = Transformation.getTransformedPointDouble(pointsZ, transform);
            var pointsAfter = new List<Point>();
            foreach (var item in pointsZ)
            {
                Point point = new Point(item.X + firstPoint.X, item.Y + firstPoint.Y);
                pointsAfter.Add(point);
            }
            pointsZ = pointsAfter;

            points.AddRange(pointsZ);
            return points;
        }
    }
}
