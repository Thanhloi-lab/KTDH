using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace KTDH
{
    public class Transformation
    {
        public static List<List<int>> MoveTo(int trX, int trY)//Tịnh tiến
        {
            List<List<int>> matrix = new List<List<int>>();
            int scale = MyCoordinate.scale;

            matrix.Add(new List<int> { 1, 0, 0 });
            matrix.Add(new List<int> { 0, 1, 0 });
            matrix.Add(new List<int> { scale * trX, scale * trY, scale });

            return matrix;
        }

        public static List<List<int>> ScaleTo(int sX, int sY)//biến đổi tỉ lệ
        {
            List<List<int>> matrix = new List<List<int>>();
            int scale = MyCoordinate.scale;

            matrix.Add(new List<int> { sX, 0, 0 });
            matrix.Add(new List<int> { 0, sY, 0 });
            matrix.Add(new List<int> { 0, 0, scale });

            return matrix;
        }

        public static List<List<double>> RotateTo(int degree)//Xoay
        {
            List<List<double>> matrix = new List<List<double>>();
            int scale = MyCoordinate.scale;

            double cos = Math.Cos(ConvertDegreesToRadiants(degree));
            double sin = Math.Sin(ConvertDegreesToRadiants(degree));

            matrix.Add(new List<double> { cos, -sin, 0 });
            matrix.Add(new List<double> { sin,  cos, 0 });
            matrix.Add(new List<double> { 0, 0,  scale });

            return matrix;
        }

        public static List<List<int>> Flip(bool oX, bool oY)//Đối xứng
        {
            List<List<int>> matrix = new List<List<int>>();
            int scale = MyCoordinate.scale;

            int newX = oY ? -1 : 1;
            int newY = oX ? -1 : 1;

            matrix.Add(new List<int> { newX, 0, 0 });
            matrix.Add(new List<int> { 0, newY, 0 });
            matrix.Add(new List<int> { 0, 0, scale });

            return matrix;
        }

        public static List<List<int>> Flip3D(bool oX, bool oY, bool oZ)//Đối xứng
        {
            List<List<int>> matrix = new List<List<int>>();
            int scale = MyCoordinate.scale;

            int newX = oY ? -1 : 1;
            int newY = oX ? -1 : 1;
            int newZ = oX ? -1 : 1;

            matrix.Add(new List<int> { newX, 0, 0 });
            matrix.Add(new List<int> { 0, newY, 0 });
            matrix.Add(new List<int> { 0, 0, scale });

            return matrix;
        }
        public static List<List<int>> CombineTransform(List<List<int>> transform1, List<List<int>> transform2)
        {
            for(int i=0; i<transform1.Count; i++)
            {
                transform1[i][0] += transform2[i][0];
                transform1[i][1] += transform2[i][1];
                transform1[i][2] += transform2[i][2];
            }

            return transform1;
        }

        public static List<Point> getTransformedPoint(List<Point> points, List<List<int>> transform)
        {
            List<Point> result = new List<Point>();

            foreach (Point point in points)
            {
                int x = (point.X * transform[0][0]) + (point.Y * transform[1][0]) + transform[2][0];
                int y = (point.X * transform[0][1]) + (point.Y * transform[1][1]) + transform[2][1];
                int h = (point.X * transform[0][2]) + (point.Y * transform[1][2]) + transform[2][2];
                result.Add(new Point(x, y));
            }

            return result;
        }
        public static List<Point> getTransformedPointDouble(List<Point> points, List<List<double>> transform)
        {
            List<Point> result = new List<Point>();
            foreach (Point point in points)
            {
                double x = (point.X * transform[0][0]) + (point.Y * transform[0][1]);
                double y = (point.X * transform[1][0]) + (point.Y * transform[1][1]);
                double h = (point.X * transform[0][2]) + (point.Y * transform[1][2]) + transform[2][2];
                result.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
            }

            return result;
        }
        public static List<Point> MoveToO(List<Point> points, Point firstPoint)
        {
            List<Point> pointsAfter = new List<Point>();
            foreach (var item in points)
            {
                Point point = new Point(item.X-firstPoint.X, item.Y-firstPoint.Y);
                pointsAfter.Add(point);
            }

            return pointsAfter;
        }
        public static double ConvertDegreesToRadiants(double degree)
        {
            double radiant = (degree * Math.PI) /180;
            return (radiant);
        }
    }
}
