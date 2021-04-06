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
            pen = new Pen(Color.Black, 4);
            eraser = new Pen(drawPanel.BackColor, 5);
            eraser.StartCap = eraser.EndCap = pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    
        }
        private void DrawCenterMyCoordinate()
        {
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

        private void btDrawLine_Click(object sender, EventArgs e)
        {

            if (drawLine)
            {
                drawLine = false;
                EraseCenterMyCoordinate();
            }       
            else
            {
                drawLine = true;
                DrawCenterMyCoordinate();
                
            }   
        }

        private void drawStraightLine(List<Point> points)
        {
            int line = 0;
            for (int i = 0; i < points.Count - 1; i += 5)
            {
                if (line != DrawLine.line)
                {
                    Point point = points.ElementAt(i);
                    graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                }
            }
        }

        private void drawDashedLine(List<Point> points)
        {
            int count = 0;
            int line = 0;
            for (int i = 0; i < points.Count - 1; i += 5)
            {
                if (line != DrawLine.line)
                {
                    Point point = points.ElementAt(i);
                    graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                    line++;
                }
                else
                {
                    count++;
                    if (count == DrawLine.space)
                    {
                        count = line = 0;
                    }
                }
            }
        }

        private void drawDotLine(List<Point> points)
        {
            int count = 0;
            int countSpace = 0;
            int line = 0;

            for (int i = 0; i < points.Count - 1; i += 5)
            {
                if (line != DrawLine.line)
                {
                    Point point = points.ElementAt(i);
                    graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                    line++;
                }
                else
                {
                    count++;
                    if (count == DrawLine.space && countSpace == 0)
                    {
                        Point point = points.ElementAt(i);
                        graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                        countSpace++;
                        count = 0;
                    }
                    else if (count == DrawLine.space && countSpace == 1)
                    {
                        count = line = countSpace = 0;
                    }
                }
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
                if (isPoint1 == false)
                {
                    point1.X = e.X;
                    point1.Y = e.Y;
                    isPoint1 = true;
                    Point showPoint = MyCoordinate.ConvertToMyPoint(point1.X, point1.Y);
                    textBoxX.Text = showPoint.X.ToString();
                    textBoxY.Text = showPoint.Y.ToString();
                }
                else if (isPoint1 && !isPoint2)
                {
                    point2.X = e.X;
                    point2.Y = e.Y;
                    isPoint2 = true;
                    Point showPoint = MyCoordinate.ConvertToMyPoint(point2.X, point2.Y);
                    textBoxX.Text = showPoint.X.ToString();
                    textBoxY.Text = showPoint.Y.ToString();
                    Point firstPoint = point1;
                    Point seccondPoint = point2;
                    List<Point> points = DrawLine.DDA(firstPoint, seccondPoint);
                    
                    switch(lineStyleComboBox.SelectedIndex)
                    {
                        case 0:
                            {
                                drawStraightLine(points);
                                break;
                            }
                        case 1:
                            {
                                drawDotLine(points);
                                break;
                            }
                        case 2:
                            {
                                drawDashedLine(points);
                                break;
                            }
                        default:
                            break;
                    }
                    
                    isPoint1 = isPoint2 = false;
                }
            }
        }
    }
}
