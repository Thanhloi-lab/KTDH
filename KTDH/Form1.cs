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
            label.Text = "(" + MyCoordinate.ConvertToMyPoint(point).X + ", " + MyCoordinate.ConvertToMyPoint(point).Y + ")";
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
        public void DrawArrow(List<Point> points, Graphics graphics, Pen pen)
        {
            //viet vao day
        }
        private void btDrawLine_Click(object sender, EventArgs e)
        {
            if (options.DrawLine)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                EraseMyCoordinate();
            }
            else
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                options.DrawLine = true;
                options.DrawBasicLine = true;
                DrawCenterMyCoordinate();
            }
        }
        private void drawRecangle_Click(object sender, EventArgs e)
        {
            if (options.DrawRecangle)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                EraseMyCoordinate();
            }
            else
            {
                options.AllOptionsExceptLineOptionsOff();
                options.DrawRecangle = true;
                DrawCenterMyCoordinate();

            }
        }
        private void btDrawDashLine_Click(object sender, EventArgs e)
        {
            if (options.DrawDashLine)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                EraseMyCoordinate();
            }
            else if (!options.DrawDashLine)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                options.DrawLine = true;
                options.DrawDashLine = true;
                DrawCenterMyCoordinate();
            }
        }
        private void btDrawDashLineWithOneDot_Click(object sender, EventArgs e)
        {
            if (options.DrawDashLineWithOneDot)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                EraseMyCoordinate();
            }
            else if (!options.DrawDashLineWithOneDot)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                options.DrawLine = true;
                options.DrawDashLineWithOneDot = true;
                DrawCenterMyCoordinate();
            }
        }
        private void btDrawDashLineWithTwoDot_Click(object sender, EventArgs e)
        {
            if (options.DrawDashLineWithTwoDot)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                EraseMyCoordinate();
            }
            else if (!options.DrawDashLineWithTwoDot)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                options.DrawLine = true;
                options.DrawDashLineWithTwoDot = true;
                DrawCenterMyCoordinate();
            }
        }
        private void btDrawArrow_Click(object sender, EventArgs e)
        {
            if (options.DrawLine)
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                EraseMyCoordinate();
            }
            else
            {
                options.AllOptionsExceptLineOptionsOff();
                options.AllDrawLineOptionsOff();
                options.DrawLine = true;
                options.DrawArrow = true;
                DrawCenterMyCoordinate();
            }
        }
    }
}
