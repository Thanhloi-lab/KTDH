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
        private Point centerPoint = new Point(400, 225);
        private int x = -1;
        private int y = -1;
        private int x1 = -1;
        private int y1 = -1;
        private bool point1 = false;
        private bool point2 = false;
        private bool drawLine = false;
        private bool moving = false;
        private readonly Pen pen;
        private readonly Pen eraser; 
        public Form1()
        {
            InitializeComponent();
            graphics = mainPanel.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 1);
            eraser = new Pen(mainPanel.BackColor, 6);
            eraser.StartCap = eraser.EndCap = pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void DrawCenterMyCoordinate()
        {
            List<Point> points = MyCoordinate.DrawMyCoordinate(centerPoint);
            for (int i = 0; i < points.Count - 1; i++)
            {
                if(points.ElementAt(i).X == points.ElementAt(i + 1).X
                    || points.ElementAt(i).Y == points.ElementAt(i + 1).Y)
                {
                    graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                }
                    
            }
        }

        private void EraseCenterMyCoordinate()
        {
            List<Point> points = MyCoordinate.DrawMyCoordinate(centerPoint);
            
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (points.ElementAt(i).X == points.ElementAt(i + 1).X
                    || points.ElementAt(i).Y == points.ElementAt(i + 1).Y)
                {
                    graphics.DrawLine(eraser, points.ElementAt(i), points.ElementAt(i + 1));
                }
            }
        }

        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //cai nay chuc nang khac
            if (moving && x!=-1 && y!=-1 && drawLine == false)
            {
                graphics.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            //cai nay chuc nang khac
            if (drawLine == false)
            {
                moving = false;
                x = -1;
                y = -1;
            }
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // xu ly ve doan thang
            if (drawLine == false)
            {
                moving = true;
                x = e.X;
                y = e.Y;
            }
            else
            {
                if(point1==false)
                {
                    x = e.X;
                    y = e.Y;
                    point1 = true;
                }
                else if(point1 && point2 == false)
                {
                    x1 = e.X;
                    y1 = e.Y;
                    point2 = true;
                    Point firstPoint = new Point(x, y);
                    Point seccondPoint = new Point(x1, y1);
                    List<Point> points = DrawLine.DDA(firstPoint, seccondPoint);
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        if(i%5==0)
                        {
                            Point point = points.ElementAt(i);
                            graphics.DrawLine(pen, points.ElementAt(i), points.ElementAt(i + 1));
                        }
                    }
                    point1 = point2 = false;
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
    }
}
