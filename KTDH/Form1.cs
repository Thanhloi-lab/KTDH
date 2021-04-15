﻿using System;
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
        private bool isPoint1 = false;
        private bool isPoint2 = false;
        private bool drawLine = false;
        private bool moving = false;
        private readonly Pen pen;
        private readonly Pen eraser; 
        public Form1()
        {
            InitializeComponent();
            graphics = drawPanel.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.BlueViolet, 3);
            eraser = new Pen(drawPanel.BackColor, 5);
            eraser.StartCap = eraser.EndCap = pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    
        }
        private void DrawCenterMyCoordinate()
        {
            EraseMyCoordinate();
            List<Point> axis = MyCoordinate.DrawMyCoordinateAxis();
            List<Point> netPixel = MyCoordinate.DrawNetPixel();
            Pen redPen = new Pen(Color.Red, 5);
            Pen grayPen = new Pen(Color.LightGray, 1);
            
            for (int i = 0; i < netPixel.Count - 1; i++)
            {
                if (netPixel.ElementAt(i).X == netPixel.ElementAt(i + 1).X
                    || netPixel.ElementAt(i).Y == netPixel.ElementAt(i + 1).Y)
                {
                    graphics.DrawLine(grayPen, netPixel.ElementAt(i), netPixel.ElementAt(i + 1));
                }
            }
            EraseCenterMyCoordinate();
            for (int i = 0; i < axis.Count - 1; i++)
            {
                if (axis.ElementAt(i).X == axis.ElementAt(i + 1).X
                    || axis.ElementAt(i).Y == axis.ElementAt(i + 1).Y)
                {
                    graphics.DrawLine(redPen, axis.ElementAt(i), axis.ElementAt(i + 1));
                }
            }
        }

        private void EraseCenterMyCoordinate()
        {
            List<Point> points = MyCoordinate.DrawMyCoordinateAxis();
            
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (points.ElementAt(i).X == points.ElementAt(i + 1).X
                    || points.ElementAt(i).Y == points.ElementAt(i + 1).Y)
                {
                    graphics.DrawLine(eraser, points.ElementAt(i), points.ElementAt(i + 1));
                }
            }
        }

        private void EraseMyCoordinate()
        {
            graphics.Clear(drawPanel.BackColor);
            foreach (var item in drawPanel.Controls.OfType<Label>().ToList())
            {
                drawPanel.Controls.Remove(item as Label);
            }
        }

        private void btDrawLine_Click(object sender, EventArgs e)
        {

            if (drawLine)
            {
                drawLine = false;
                EraseMyCoordinate();
            }       
            else
            {
                drawLine = true;
                DrawCenterMyCoordinate();
                
            }   
        }

        private void drawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            //cai nay chuc nang khac
            if (drawLine == false)
            {
                moving = false;
                point1.X = -1;
                point1.Y = -1;
            }
        }

        private void drawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //cai nay chuc nang khac
            if (moving && point1.X != -1 && point1.Y != -1 && drawLine == false)
            {
                graphics.DrawLine(pen, point1, e.Location);
                point1.X = e.X;
                point1.Y = e.Y;
            }
        }

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            
            // xu ly ve doan thang
            if (drawLine == false)
            {
                moving = true;
                point1.X = e.X;
                point1.Y = e.Y;
            }
            else
            {
                Label label = new Label();
                Point point = MyCoordinate.ConvertToMyPoint(new Point(e.X, e.Y));
                label.Location = new Point(e.X + 10, e.Y);
                label.Text = "(" + MyCoordinate.ConvertToMyPoint(point).X + ", " + MyCoordinate.ConvertToMyPoint(point).Y + ")";
                label.Text = "(" + point.X + ", " + point.Y + ")";
                label.SendToBack();
                label.ForeColor = Color.Red;
                label.AutoSize = true;
                drawPanel.Controls.Add(label);
                label.Show();
                if (isPoint1 == false)
                {
                    point1.X = e.X;
                    point1.Y = e.Y;
                    isPoint1 = true;
                    Point showPoint = MyCoordinate.ConvertToMyPoint(point1);
                    textBoxX.Text = showPoint.X.ToString();
                    textBoxY.Text = showPoint.Y.ToString();
                }
                else if (isPoint1 && !isPoint2)
                {
                    point2.X = e.X;
                    point2.Y = e.Y;
                    isPoint2 = true;
                    Point showPoint = MyCoordinate.ConvertToMyPoint(point2);
                    textBoxX.Text = showPoint.X.ToString();
                    textBoxY.Text = showPoint.Y.ToString();
                    Point firstPoint = point1;
                    Point seccondPoint = point2;
                    List<Point> points = DrawLine.DDA(firstPoint, seccondPoint);
                    
                    switch(lineStyleComboBox.SelectedIndex)
                    {
                        case 0:
                            {
                                DrawBasicLine(points,graphics,pen);
                                if (hasArrowCheckBox.Checked)
                                    DrawArrow(graphics, point1, point2, 3);

                                break;
                            }
                        case 1:
                            {
                                DrawDashLine(points, graphics, pen);
                                if (hasArrowCheckBox.Checked)
                                    DrawArrow(graphics, point1, point2, 3);

                                break;
                            }
                        case 2:
                            {
                                DrawDashedLineWithOneDot(points, graphics, pen);
                                if (hasArrowCheckBox.Checked)
                                    DrawArrow(graphics, point1, point2, 3);

                                break;
                            }
                        case 3:
                            {
                                DrawDashLineWithTwoDot(points, graphics, pen);
                                if (hasArrowCheckBox.Checked)
                                    DrawArrow(graphics, point1, point2, 3);

                                break;
                            }
                        case 4:
                            {
                                List<Point> rectPoints = DrawRecangle.DDA(point1, point2);
                                DrawBasicLine(rectPoints, graphics, pen);
                                break;
                            }
                        default:
                            break;
                    }
                    
                    isPoint1 = isPoint2 = false;
                }
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
                    graphics.DrawRectangle(pen, new Rectangle(point.X, point.Y, 1, 1));
                    line++;
                }
                else
                {
                    count++;
                    if (count == DrawLine.Space && countSpace == 0)
                    {
                        Point point = points.ElementAt(i);
                        graphics.DrawRectangle(pen, new Rectangle(point.X, point.Y, 1, 1));
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
                    graphics.DrawRectangle(pen, new Rectangle(point.X, point.Y, 1, 1));
                    inLine++;
                }
                else
                {
                    count++;
                    if (count == DrawLine.Space && countSpace == 0)
                    {
                        Point point = points.ElementAt(i);
                        graphics.DrawRectangle(pen, new Rectangle(point.X, point.Y, 1, 1));
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
                    graphics.DrawRectangle(pen, new Rectangle(point.X, point.Y, 1, 1));
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
            for (int i = 0; i < points.Count; i += MyCoordinate.scale)
            {
                Point point = points.ElementAt(i);
                graphics.DrawRectangle(pen, new Rectangle(point.X, point.Y, 1, 1));
            }
        }

        private void DrawFixedArrow(Graphics g, PointF ArrowStart, PointF ArrowEnd)
        {
            double x1, x2, y1, y2;
            double arrowLength = 20, arrowDegrees = 0.4;
            double angle = Math.Atan2(ArrowEnd.Y - ArrowStart.Y, ArrowEnd.X - ArrowStart.X) + Math.PI;
            x1 = ArrowEnd.X + arrowLength * Math.Cos(angle - arrowDegrees);
            y1 = ArrowEnd.Y + arrowLength * Math.Sin(angle - arrowDegrees);
            x2 = ArrowEnd.X + arrowLength * Math.Cos(angle + arrowDegrees);
            y2 = ArrowEnd.Y + arrowLength * Math.Sin(angle + arrowDegrees);
            int x4 = (int)((x1 + x2 + ArrowEnd.X) / 3);
            int y4 = (int)((y1 + y2 + ArrowEnd.Y) / 3);
            List<Point> points = new List<Point>();
            List<Point> temp = new List<Point>();
            Point arrowPoint1 = new Point((int)x1, (int)y1);
            Point arrowPoint2 = new Point((int)x2, (int)y2);
            Point arrowPoint3 = new Point((int)ArrowEnd.X, (int)ArrowEnd.Y);

            temp = DrawLine.DDA(arrowPoint1, arrowPoint2);
            points.AddRange(temp);
            temp = DrawLine.DDA(arrowPoint2, arrowPoint3);
            points.AddRange(temp);
            temp = DrawLine.DDA(arrowPoint3, arrowPoint1);
            points.AddRange(temp);

            Pen arrowPen = new Pen(Color.BlueViolet,4);
            DrawBasicLine(points, g, arrowPen);
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

            List<Point> points = DrawLine.DDA(arrowPointInt, arrowPointLeftInt);
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

        private void button1_Click(object sender, EventArgs e)
        {
            DrawCenterMyCoordinate();
        }
    }
}
