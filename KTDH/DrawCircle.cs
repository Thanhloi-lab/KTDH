using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace KTDH
{
    public class DrawCircle
    {
        public static List<Point> DDA(double centerX, double centerY, int r)
        {
            List<Point> points = new List<Point>();
            double x1, y1, x2, y2, x, y, k;
            int i, val;

            x1 = r * Math.Cos(0);
            y1 = r * Math.Sin(0);
            x = x1;
            y = y1;
            i = 0;
            do
            {
                val = (int)Math.Pow(2, i);
                i+=1;
            } while (val < r);
            k = 1 / Math.Pow(2, i - 1);
            do
            {
                x2 = x1 + y1 * k;
                y2 = y1 - k * x2;

                Point point = new Point((int)Math.Round(centerX + x2), (int)Math.Round(centerY + y2));
                points.Add(point);

                x1 = x2;
                y1 = y2;


            } while ((y1 - y) < k || (x - x1) > k);
            return points;
        }

        private static List<Point> get8Point(int x0, int y0, int x, int y)
        {
            int scale = MyCoordinate.scale;
            x0 = (int)(x0 / scale) * scale + 1;
            y0 = (int)(y0 / scale) * scale - 1;
            x = (int)(x / scale) * scale +1;
            y = (int)(y / scale) * scale -1;

            List<Point> points = new List<Point>();
            points.Add(new Point(x0 + x, y0 + y));
            points.Add(new Point(x0 - x, y0 + y));
            points.Add(new Point(x0 + x, y0 - y));
            points.Add(new Point(x0 - x, y0 - y));
            points.Add(new Point(x0 + y, y0 + x));
            points.Add(new Point(x0 - y, y0 + x));
            points.Add(new Point(x0 + y, y0 - x));
            points.Add(new Point(x0 - y, y0 - x));
            return points;
        }
        public static List<Point> circleBrese(int x0, int y0, int r)
        {
            int scale = MyCoordinate.scale;

            List<Point> points = new List<Point>();
            Point centerPoint = new Point((int)(x0 / scale) * scale + 1, (int)(y0 / scale) * scale - 1);
            points.Add(centerPoint);
            int x = 0; int y = r;
            int p = 3 - 2 * r;

            while (x <= y)
            {
                points.AddRange(get8Point(x0, y0, x, y));

                if (p < 0)
                {
                    p = p + 4 * x + 6;
                }
                else
                {
                    p = p + 4 * (x - y) + 10;
                    y = y - 1;
                }
                x = x + 1;
            }
            return points;
        }
    }
}
