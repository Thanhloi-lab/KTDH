using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace KTDH
{
    public class DrawEllipse
    {
        public static List<Point> MidPoint(Point center, int radiusX, int radiusY)
        {
            List<Point> points = new List<Point>();

            double dx, dy, d1, d2;
            int x = 0, y = radiusY;
            int scale = MyCoordinate.scale;

            d1 = (radiusY * radiusY) - (radiusX * radiusX * radiusY) + (0.25 * radiusX * radiusX);

            dx = 2 * radiusY * radiusY * x;
            dy = 2 * radiusX * radiusX * y;

            while(dx<dy)
            {
                int x1 = (int)((x + center.X) / scale) * scale -1;
                int x2 = (int)((-x + center.X) / scale) * scale -1;
                int y1 = (int)((y + center.Y) / scale) * scale -1;
                int y2 = (int)((-y + center.Y) / scale) * scale -1;

                points.Add(new Point(x1, y1));
                points.Add(new Point(x2, y1));
                points.Add(new Point(x1, y2));
                points.Add(new Point(x2, y2));

                if (d1<0)
                {
                    x++;
                    dx += 2 * radiusY * radiusY;
                    d1 += dx + (radiusY * radiusY);
                }
                else
                {
                    x++;
                    y--;
                    dx = dx + (2 * radiusY * radiusY);
                    dy = dy - (2 * radiusX * radiusX);
                    d1 = d1 + dx - dy + (radiusY * radiusY);
                }
            }

            d2 = ((radiusY * radiusY) * ((x + 0.5f) * (x + 0.5f))) +
                 ((radiusX * radiusX) * ((y - 1) * (y - 1))) -
                 (radiusX * radiusX * radiusY * radiusY);

            while(y>=0)
            {
                int x1 = (int)((x + center.X) / scale) * scale -1;
                int x2 = (int)((-x + center.X) / scale) * scale -1;
                int y1 = (int)((y + center.Y) / scale) * scale -1;
                int y2 = (int)((-y + center.Y) / scale) * scale -1;

                points.Add(new Point(x1, y1));
                points.Add(new Point(x2, y1));
                points.Add(new Point(x1, y2));
                points.Add(new Point(x2, y2));

                if (d2 > 0)
                {
                    y--;
                    dy = dy - (2 * radiusX * radiusX);
                    d2 = d2 + (radiusX * radiusX) - dy;
                }
                else
                {
                    y--;
                    x++;
                    dx = dx + (2 * radiusY * radiusY);
                    dy = dy - (2 * radiusX * radiusX);
                    d2 = d2 + dx - dy + (radiusX * radiusX);
                }
            }
            return points;
        }
    }
}
