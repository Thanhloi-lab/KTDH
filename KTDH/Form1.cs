using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTDH
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        private Point point1 = new Point(-1, -1);
        private Point point2 = new Point(-1, -1);
        private readonly Pen pen;
        private readonly Pen eraser;
        DrawOptions options = new DrawOptions();
        public Form1()
        {
            InitializeComponent();
            graphics = mainPanel.CreateGraphics();
            //graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 4);
            eraser = new Pen(mainPanel.BackColor, 5);
            eraser.StartCap = eraser.EndCap = pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void DrawCenterMyCoordinate()
        {
            List<Point> axis = MyCoordinate.DrawMyCoordinateAxis();
            List<Point> netPixel = MyCoordinate.DrawNetPixel();
            Pen redPen = new Pen(Color.Red, 5);
            Pen blackPen = new Pen(Color.Black, 1);

            for (int i = 0; i < netPixel.Count - 1; i++)
            {
                if (netPixel.ElementAt(i).X == netPixel.ElementAt(i + 1).X
                    || netPixel.ElementAt(i).Y == netPixel.ElementAt(i + 1).Y)
                {
                    graphics.DrawLine(blackPen, netPixel.ElementAt(i), netPixel.ElementAt(i + 1));
                }
            }
            //EraseMyCoordinate();
            for (int i = 0; i < axis.Count - 1; i++)
            {
                if (axis.ElementAt(i).X == axis.ElementAt(i + 1).X
                    || axis.ElementAt(i).Y == axis.ElementAt(i + 1).Y)
                {
                    graphics.DrawLine(redPen, axis.ElementAt(i), axis.ElementAt(i + 1));
                }
            }
        }
        private void EraseMyCoordinate()
        {
            graphics.Clear(mainPanel.BackColor);
            foreach (var item in mainPanel.Controls.OfType<Label>().ToList())
            {
                mainPanel.Controls.Remove(item as Label);
            }
        }
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //cai nay chuc nang khac
            if (options.Moving && point1.X != -1 && point1.Y != -1 && options.DrawLine == false)
            {
                graphics.DrawLine(pen, point1, e.Location);
                point1.X = e.X;
                point1.Y = e.Y;
            }
        }
        private void mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            //cai nay chuc nang khac
            if (options.DrawLine == false && !options.DrawRecangle)
            {
                options.Moving = false;
                point1.X = -1;
                point1.Y = -1;
            }
        }
        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = new Label();
            Point point = new Point(e.X, e.Y);
            label.Location = new Point(e.X+10, e.Y);
            //label.Text = "(" + MyCoordinate.ConvertToMyPoint(point).X + ", " + MyCoordinate.ConvertToMyPoint(point).Y + ")";
            label.Text = "(" + e.X + ", " + e.Y + ")";
            label.SendToBack();
            label.ForeColor = Color.Red;
            label.AutoSize = true;
            mainPanel.Controls.Add(label);
            label.Show();
            // xu ly ve doan thang
            if (!options.DrawLine && !options.DrawRecangle)
            {
                options.Moving = true;
                point1.X = e.X;
                point1.Y = e.Y;
            }
            else
            {
                if (options.IsPoint1 == false)
                {
                    point1.X = e.X;
                    point1.Y = e.Y;
                    options.IsPoint1 = true;
                }
                else if (options.IsPoint1 && !options.IsPoint2 && options.DrawLine)
                {
                    point2.X = e.X;
                    point2.Y = e.Y;
                    options.IsPoint2 = true;
                    List<Point> points = DrawLine.DDA(point1, point2);
                    DrawLineWithOption(points);
                    DrawArrow(graphics, point1, point2, 3);
                    options.IsPoint1 = options.IsPoint2 = false;
                }
                else if (options.IsPoint1 && !options.IsPoint2 && options.DrawRecangle)
                {
                    point2.X = e.X;
                    point2.Y = e.Y;
                    options.IsPoint2 = true;
                    List<Point> points = DrawRecangle.DDA(point1, point2);
                    DrawLineWithOption(points);
                    options.IsPoint1 = options.IsPoint2 = false;
                }
            }
        }
        private void DrawLineWithOption(List<Point> points)
        {
            if (options.DrawBasicLine)
            {
                DrawBasicLine(points, graphics, pen);
            }
            else if (options.DrawDashLine)
            {
                DrawDashLine(points, graphics, pen);
            }
            else if (options.DrawDashLineWithOneDot)
            {
                DrawDashedLineWithOneDot(points, graphics, pen);
            }
            else if (options.DrawDashLineWithTwoDot)
            {
                DrawDashLineWithTwoDot(points, graphics, pen);
            }
        }
        public void DrawDashedLineWithOneDot(List<Point> points, Graphics graphics, Pen pen)
        {
            int count = 0;
            int line = 0;
            int countSpace = 0;
            for (int i = 0; i < points.Count - 1; i += MyCoordinate.scale)
            {
                if (line != DrawLine.Line)
                {
                    Point point = points.ElementAt(i);
                    graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                    line++;
                }
                else
                {
                    count++;
                    if (count == DrawLine.Space && countSpace == 0)
                    {
                        Point point = points.ElementAt(i);
                        graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                        countSpace++;
                        count = 0;
                    }
                    else if (count == DrawLine.Space && countSpace == 1)
                    {
                        count = line = countSpace = 0;
                    }
                }
            }
        }
        public void DrawDashLineWithTwoDot(List<Point> points, Graphics graphics, Pen pen)
        {
            int count = 0;
            int countDot = 0;
            int inLine = 0;
            int countSpace = 0;
            for (int i = 0; i < points.Count - 1; i += MyCoordinate.scale)
            {
                if (inLine != DrawLine.Line)
                {
                    Point point = points.ElementAt(i);
                    graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                    inLine++;
                }
                else
                {
                    count++;
                    if (count == DrawLine.Space && countSpace == 0)
                    {
                        Point point = points.ElementAt(i);
                        graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
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
        }
        public void DrawDashLine(List<Point> points, Graphics graphics, Pen pen)
        {
            int count = 0;
            int inLine = 0;

            for (int i = 0; i < points.Count - 1; i += MyCoordinate.scale)
            {
                if (inLine != DrawLine.Line)
                {
                    Point point = points.ElementAt(i);
                    graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
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
        }
        public void DrawBasicLine(List<Point> points, Graphics graphics, Pen pen)
        {
            for (int i = 0; i < points.Count - 1; i += MyCoordinate.scale)
            {
                Point point = points.ElementAt(i);
                graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
            }
        }
        private void DrawArrow(Graphics g, PointF ArrowStart, PointF ArrowEnd, int ArrowMultiplier)
        {

            //tip of the arrow
            PointF arrowPoint = ArrowEnd;

            //determine arrow length
            double arrowLength = Math.Sqrt(Math.Pow(Math.Abs(ArrowStart.X - ArrowEnd.X), 2) +
                                           Math.Pow(Math.Abs(ArrowStart.Y - ArrowEnd.Y), 2));

            //determine arrow angle
            double arrowAngle = Math.Atan2(Math.Abs(ArrowStart.Y - ArrowEnd.Y), Math.Abs(ArrowStart.X - ArrowEnd.X));

            //get the x,y of the back of the point

            //to change from an arrow to a diamond, change the 3
            //in the next if/else blocks to 6

            double pointX, pointY;
            if (ArrowStart.X > ArrowEnd.X)
            {
                pointX = ArrowStart.X - (Math.Cos(arrowAngle) * (arrowLength - (3 * ArrowMultiplier)));
            }
            else
            {
                pointX = Math.Cos(arrowAngle) * (arrowLength - (3 * ArrowMultiplier)) + ArrowStart.X;
            }

            if (ArrowStart.Y > ArrowEnd.Y)
            {
                pointY = ArrowStart.Y - (Math.Sin(arrowAngle) * (arrowLength - (3 * ArrowMultiplier)));
            }
            else
            {
                pointY = (Math.Sin(arrowAngle) * (arrowLength - (3 * ArrowMultiplier))) + ArrowStart.Y;
            }

            PointF arrowPointBack = new PointF((float)pointX, (float)pointY);

            //get the secondary angle of the left tip
            double angleB = Math.Atan2((3 * ArrowMultiplier), (arrowLength - (3 * ArrowMultiplier)));

            double angleC = Math.PI * (90 - (arrowAngle * (180 / Math.PI)) - (angleB * (180 / Math.PI))) / 180;

            //get the secondary length
            double secondaryLength = (3 * ArrowMultiplier) / Math.Sin(angleB);

            if (ArrowStart.X > ArrowEnd.X)
            {
                pointX = ArrowStart.X - (Math.Sin(angleC) * secondaryLength);
            }
            else
            {
                pointX = (Math.Sin(angleC) * secondaryLength) + ArrowStart.X;
            }

            if (ArrowStart.Y > ArrowEnd.Y)
            {
                pointY = ArrowStart.Y - (Math.Cos(angleC) * secondaryLength);
            }
            else
            {
                pointY = (Math.Cos(angleC) * secondaryLength) + ArrowStart.Y;
            }

            //get the left point
            PointF arrowPointLeft = new PointF((float)pointX, (float)pointY);

            //move to the right point
            angleC = arrowAngle - angleB;

            if (ArrowStart.X > ArrowEnd.X)
            {
                pointX = ArrowStart.X - (Math.Cos(angleC) * secondaryLength);
            }
            else
            {
                pointX = (Math.Cos(angleC) * secondaryLength) + ArrowStart.X;
            }

            if (ArrowStart.Y > ArrowEnd.Y)
            {
                pointY = ArrowStart.Y - (Math.Sin(angleC) * secondaryLength);
            }
            else
            {
                pointY = (Math.Sin(angleC) * secondaryLength) + ArrowStart.Y;
            }

            PointF arrowPointRight = new PointF((float)pointX, (float)pointY);

            //create the point list
            PointF[] arrowPoints = new PointF[4];
            arrowPoints[0] = arrowPoint;
            arrowPoints[1] = arrowPointLeft;
            arrowPoints[2] = arrowPointBack;
            arrowPoints[3] = arrowPointRight;
            Point arrowPointInt = new Point((int)arrowPoint.X, (int)arrowPoint.Y);
            Point arrowPointBackInt = new Point((int)arrowPointBack.X, (int)arrowPointBack.Y);
            Point arrowPointLeftInt = new Point((int)arrowPointLeft.X, (int)arrowPointLeft.Y);
            Point arrowPointRightInt = new Point((int)arrowPointRight.X, (int)arrowPointRight.Y);

            List<Point> points =  DrawLine.DDA(arrowPointInt, arrowPointLeftInt);
            DrawBasicLine(points, g, pen);

            points = DrawLine.DDA(arrowPointInt, arrowPointRightInt);
            DrawBasicLine(points, g, pen);

            points = DrawLine.DDA(arrowPointLeftInt, arrowPointRightInt);
            DrawBasicLine(points, g, pen);

            //draw the outline
            //g.DrawPolygon(pen, arrowPoints);

            //fill the polygon
            //g.FillPolygon(new SolidBrush(ArrowColor), arrowPoints);
        }
        private void btDrawLine_Click(object sender, EventArgs e)
        {
            if (options.DrawLine)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
            }
            else
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                options.DrawLine = true;
                options.DrawBasicLine = true;
            }
        }
        private void drawRecangle_Click(object sender, EventArgs e)
        {
            if (options.DrawRecangle)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
            }
            else
            {
                options.AllOptionsExceptLineOptionsOff();
                options.DrawRecangle = true;
            }
        }
        private void btDrawDashLine_Click(object sender, EventArgs e)
        {
            if (options.DrawDashLine)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
            }
            else if (!options.DrawDashLine)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                options.DrawLine = true;
                options.DrawDashLine = true;
            }
        }
        private void btDrawDashLineWithOneDot_Click(object sender, EventArgs e)
        {
            if (options.DrawDashLineWithOneDot)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
            }
            else if (!options.DrawDashLineWithOneDot)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                options.DrawLine = true;
                options.DrawDashLineWithOneDot = true;
            }
        }
        private void btDrawDashLineWithTwoDot_Click(object sender, EventArgs e)
        {
            if (options.DrawDashLineWithTwoDot)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
            }
            else if (!options.DrawDashLineWithTwoDot)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                options.DrawLine = true;
                options.DrawDashLineWithTwoDot = true;
            }
        }
        private void btDrawArrow_Click(object sender, EventArgs e)
        {
            if (options.DrawLine)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
            }
            else
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                options.DrawLine = true;
                options.DrawArrow = true;
            }
        }
        private void btClear_Click(object sender, EventArgs e)
        {
            EraseMyCoordinate();
        }
        private void btDrawMyCoordinate_Click(object sender, EventArgs e)
        {
            DrawCenterMyCoordinate();
        }
    }
}
