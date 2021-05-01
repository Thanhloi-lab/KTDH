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
        private List<List<Point>> shapesPoints = new List<List<Point>>();
        private List<Point> defaultPoints = new List<Point>();
        private Point point1 = new Point(-1, -1);
        private Point point2 = new Point(-1, -1);
        private Point centerPoint = new Point(-1, -1);
        private bool isPoint1 = false;
        private bool isPoint2 = false;
        private bool isEllipseCenter = false;
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
            graphics.DrawLine(redPen, new Point(MyCoordinate.centerPoint.X, 0), new Point(MyCoordinate.centerPoint.X, MyCoordinate.centerPoint.Y * 2));
            graphics.DrawLine(redPen, new Point(0, MyCoordinate.centerPoint.Y), new Point(MyCoordinate.centerPoint.X * 2, MyCoordinate.centerPoint.Y));
        }

        private void EraseCenterMyCoordinate()
        {
            List<Point> points = MyCoordinate.DrawMyCoordinateAxis();

            graphics.DrawLine(eraser, new Point(MyCoordinate.centerPoint.X, 0), new Point(MyCoordinate.centerPoint.X, MyCoordinate.centerPoint.Y * 2));
            graphics.DrawLine(eraser, new Point(0, MyCoordinate.centerPoint.Y), new Point(MyCoordinate.centerPoint.X * 2, MyCoordinate.centerPoint.Y));
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
                    this.transformationComboBox.Enabled = false;
                    point1.X = e.X;
                    point1.Y = e.Y;
                    isPoint1 = true;
                    if (isEllipseCenter == false && lineStyleComboBox.SelectedIndex == 6)
                    {
                        centerPoint = point1;
                        isPoint1 = false;
                        isEllipseCenter = true;
                    }
                }
                else if (isPoint1 && !isPoint2)
                {
                    this.transformationComboBox.Enabled = true;
                    point2.X = e.X;
                    point2.Y = e.Y;
                    isPoint2 = true;
                    Point firstPoint = point1;
                    Point seccondPoint = point2;
                    List<Point> points = DrawLine.DDA(firstPoint, seccondPoint);
                    
                    switch(lineStyleComboBox.SelectedIndex)
                    {
                        case 0:
                            {
                                DrawMyShape(points);
                                if (hasArrowCheckBox.Checked)
                                    DrawArrow(point1, point2, 3);
                                break;
                            }
                        case 1:
                            {
                                points = DrawLine.DashLine(points);
                                DrawMyShape(points,1);
                                if (hasArrowCheckBox.Checked)
                                    DrawArrow(point1, point2, 3);

                                break;
                            }
                        case 2:
                            {
                                points = DrawLine.DashedLineWithOneDot(points);
                                DrawMyShape(points,1);
                                if (hasArrowCheckBox.Checked)
                                    DrawArrow(point1, point2, 3);

                                break;
                            }
                        case 3:
                            {
                                points = DrawLine.DashLineWithTwoDot(points);
                                DrawMyShape(points,1);
                                if (hasArrowCheckBox.Checked)
                                   DrawArrow(point1, point2, 3);
                                break;
                            }
                        case 4:
                            {
                                points = DrawRecangle.DDA(point1, point2);
                                DrawMyShape(points);
                                break;
                            }
                        case 5:
                            {
                                int radius = (int)Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
                                points = DrawCircle.circleBrese(point1.X, point1.Y, radius);
                                DrawMyShape(points);
                                break;
                            }
                        case 6:
                            {
                                int radiusX = (int)Math.Sqrt(Math.Pow(point1.X - centerPoint.X, 2) + Math.Pow(point1.Y - centerPoint.Y, 2));
                                int radiusY = (int)Math.Sqrt(Math.Pow(point2.X - centerPoint.X, 2) + Math.Pow(point2.Y - centerPoint.Y, 2)); ;
                                points = DrawEllipse.MidPoint(centerPoint, radiusX, radiusY);
                                DrawMyShape(points);
                                isEllipseCenter = false;
                                break;
                            }

                        default:
                            break;
                    }

                    shapesPoints.Add(points);
                    defaultPoints = shapesPoints.ElementAt(shapesPoints.Count - 1);
                    isPoint1 = isPoint2 = false;
                }
            }
        }
        
        private void DrawMyShape(List<Point> points)
        {
            DrawMyShape(points, MyCoordinate.scale);
        }

        private void DrawMyShape(List<Point> points, int step)
        {
            for (int i = 0; i < points.Count; i += step)
            {
                Point point = points.ElementAt(i);
                graphics.DrawRectangle(pen, new Rectangle(point.X - 1, point.Y - 1, 2, 2));
            }
        }

        private void DrawMyShapeWithLabel(List<Point> points)
        {
            DrawMyShape(points, MyCoordinate.scale);

            Label labelStart = new Label();
            labelStart.Location = new Point(points[0].X + 10, points[0].Y);
            labelStart.Text = "(" + MyCoordinate.ConvertToMyPoint(points[0]).X + ", " + MyCoordinate.ConvertToMyPoint(points[0]).Y + ")";
            labelStart.SendToBack();
            labelStart.ForeColor = Color.Red;
            labelStart.AutoSize = true;
            drawPanel.Controls.Add(labelStart);
            labelStart.Show();

            Label labelEnd = new Label();
            labelEnd.Location = new Point(points[points.Count-1].X + 10, points[points.Count - 1].Y);
            labelEnd.Text = "(" + MyCoordinate.ConvertToMyPoint(points[points.Count - 1]).X + ", " + MyCoordinate.ConvertToMyPoint(points[points.Count - 1]).Y + ")";
            labelEnd.SendToBack();
            labelEnd.ForeColor = Color.Red;
            labelEnd.AutoSize = true;
            drawPanel.Controls.Add(labelEnd);
            labelEnd.Show();
        }

        private void DrawArrow(PointF ArrowStart, PointF ArrowEnd, int ArrowMultiplier)
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
            Point arrowPointInt = new Point((int)Math.Round(arrowPoint.X), (int)Math.Round(arrowPoint.Y));
            Point arrowPointBackInt = new Point((int)Math.Round(arrowPointBack.X), (int)Math.Round(arrowPointBack.Y));
            Point arrowPointLeftInt = new Point((int)Math.Round(arrowPointLeft.X), (int)Math.Round(arrowPointLeft.Y));
            Point arrowPointRightInt = new Point((int)Math.Round(arrowPointRight.X), (int)Math.Round(arrowPointRight.Y));

            List<Point> points = DrawLine.DDA(arrowPointInt, arrowPointLeftInt);
            DrawMyShape(points, 1);

            points = DrawLine.DDA(arrowPointInt, arrowPointRightInt);
            DrawMyShape(points,1);

            points = DrawLine.DDA(arrowPointLeftInt, arrowPointBackInt);
            DrawMyShape(points,1);

            points = DrawLine.DDA(arrowPointRightInt, arrowPointBackInt);
            DrawMyShape(points,1);

            //draw the outline
            //g.DrawPolygon(pen, arrowPoints);

            //fill the polygon
            //g.FillPolygon(new SolidBrush(pen.Color), arrowPoints);
        }

        private void PerformTransform(List<Point> points, int mode, Point value)
        {
            switch(mode)
            {
                case 0:
                    {
                        RedrawShapes();
                        DrawMyShapeWithLabel(defaultPoints);
                        shapesPoints[shapesPoints.Count - 1] = defaultPoints;
                        break;
                    }
                case 1:
                    {
                        RedrawShapes();
                        List<List<int>> transform = Transformation.MoveTo(value.X, value.Y);
                        points = Transformation.getTransformedPoint(points, transform);
                        DrawMyShapeWithLabel(points);
                        shapesPoints[shapesPoints.Count - 1] = points;
                        break;
                    }
                case 2:
                    {
                        
                        break;
                    }
                case 3:
                    {

                        break;
                    }
                case 4:
                    {
                        RedrawShapes();
                        List<List<int>> transform = Transformation.Flip(true, false);
                        points = Transformation.getTransformedPoint(points, transform);
                        DrawMyShapeWithLabel(points);
                        shapesPoints[shapesPoints.Count - 1] = points;
                        break;
                    }
                case 5:
                    {
                        RedrawShapes();
                        List<List<int>> transform = Transformation.Flip(false, true);
                        points = Transformation.getTransformedPoint(points, transform);
                        DrawMyShapeWithLabel(points);
                        shapesPoints[shapesPoints.Count - 1] = points;
                        break;
                    }
                case 6:
                    {
                        RedrawShapes();
                        List<List<int>> transform = Transformation.Flip(true, true);
                        points = Transformation.getTransformedPoint(points, transform);
                        DrawMyShapeWithLabel(points);
                        shapesPoints[shapesPoints.Count - 1] = points;
                        break;
                    }
            }
        }

        private void RedrawShapes()
        {
            DrawCenterMyCoordinate();
            for(int i=0; i<shapesPoints.Count-1; i++)
            {
                List<Point> points = shapesPoints.ElementAt(i);
                DrawMyShapeWithLabel(points);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DrawCenterMyCoordinate();
        }

        private void TransformationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x= int.Parse(valueXTextBox.Text);
            int y = int.Parse(valueYTextBox.Text);
            Point value = new Point(x, -y);
            int index = transformationComboBox.SelectedIndex;
            PerformTransform(shapesPoints.ElementAt(shapesPoints.Count - 1), index, value);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void valueYTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
