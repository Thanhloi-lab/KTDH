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
            int scale = MyCoordinate.scale;
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
            for (int i = 0; i <= steps+1; i++)
            {
                Point point = new Point();
                point.X = (int)Math.Round(X / scale) * scale;
                point.Y = (int)Math.Round(Y / scale) * scale;
                points.Add(point);
                X += Xinc;           // increment in x at each step
                Y += Yinc;           // increment in y at each step
            }
            return points;
        }

        public static List<Point> DashedLineWithOneDot(List<Point> points)
        {
            int count = 0;
            int line = 0;
            int countSpace = 0;
            List<Point> returnPoints = new List<Point>();

            for (int i = 0; i < points.Count - 1; i += MyCoordinate.scale)
            {
                if (line != DrawLine.Line)
                {
                    Point point = points.ElementAt(i);
                    returnPoints.Add(point);
                    line++;
                }
                else
                {
                    count++;
                    if (count == DrawLine.Space && countSpace == 0)
                    {
                        Point point = points.ElementAt(i);
                        returnPoints.Add(point);
                        countSpace++;
                        count = 0;
                    }
                    else if (count == DrawLine.Space && countSpace == 1)
                    {
                        count = line = countSpace = 0;
                    }
                }
            }

            return returnPoints;
        }
        public static List<Point> DashLineWithTwoDot(List<Point> points)
        {
            int count = 0;
            int countDot = 0;
            int inLine = 0;
            int countSpace = 0;
            List<Point> returnPoints = new List<Point>();

            for (int i = 0; i < points.Count - 1; i += MyCoordinate.scale)
            {
                if (inLine != DrawLine.Line)
                {
                    Point point = points.ElementAt(i);
                    returnPoints.Add(point);
                    inLine++;
                }
                else
                {
                    count++;
                    if (count == DrawLine.Space && countSpace == 0)
                    {
                        Point point = points.ElementAt(i);
                        returnPoints.Add(point);
                        countSpace++;
                        count = 0;
                    }
                    else if (count == DrawLine.Space && countSpace == 1 && countDot == 0)
                    {
                        count = countSpace = 0;
                        countDot++;
                    }
                    else if (count == DrawLine.Space && countSpace == 1 && countDot == 1)
                    {
                        count = countSpace = countDot = inLine = 0;
                    }
                }
            }

            return returnPoints;
        }
        public static List<Point> DashLine(List<Point> points)
        {
            int count = 0;
            int inLine = 0;
            List<Point> returnPoints = new List<Point>();

            for (int i = 0; i < points.Count - 1; i += MyCoordinate.scale)
            {
                if (inLine != DrawLine.Line)
                {
                    Point point = points.ElementAt(i);
                    returnPoints.Add(point);
                    inLine++;
                }
                else
                {
                    count++;
                    if (count == DrawLine.Space)
                    {
                        count = inLine = 0;
                    }
                }
            }
            return returnPoints;
        }
    }
}
