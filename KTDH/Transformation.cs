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

        public static List<List<int>> RotateTo(int degree)//Xoay
        {
            List<List<int>> matrix = new List<List<int>>();
            int scale = MyCoordinate.scale;

            int cos = (int)(Math.Cos(degree));
            int sin = (int)(Math.Sin(degree));

            matrix.Add(new List<int> { cos, sin, 0 });
            matrix.Add(new List<int> { -sin, cos, 0 });
            matrix.Add(new List<int> { 0, 0, scale });

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

    }
}
