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
    }
}
