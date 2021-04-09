using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace KTDH
{
    public class DrawOptions
    {
        private bool isPoint1 = false;
        private bool isPoint2 = false;
        private bool drawLine = false;
        private bool drawRecangle = false;
        private bool moving = false;
        private bool drawArrow = false;
        private bool drawDashLine = false;
        private bool drawDashLineWithOneDot = false;
        private bool drawDashLineWithTwoDot = false;
        private bool drawBasicLine = false;

        public bool IsPoint1 { get => isPoint1; set => isPoint1 = value; }
        public bool IsPoint2 { get => isPoint2; set => isPoint2 = value; }
        public bool DrawLine { get => drawLine; set => drawLine = value; }
        public bool DrawRecangle { get => drawRecangle; set => drawRecangle = value; }
        public bool Moving { get => moving; set => moving = value; }
        public bool DrawArrow { get => drawArrow; set => drawArrow = value; }
        public bool DrawDashLine { get => drawDashLine; set => drawDashLine = value; }
        public bool DrawDashLineWithOneDot { get => drawDashLineWithOneDot; set => drawDashLineWithOneDot = value; }
        public bool DrawDashLineWithTwoDot { get => drawDashLineWithTwoDot; set => drawDashLineWithTwoDot = value; }
        public bool DrawBasicLine { get => drawBasicLine; set => drawBasicLine = value; }

        public void AllOptionsExceptLineOptionsOff()
        {
            IsPoint1 = IsPoint2 = DrawLine = DrawRecangle = DrawArrow = false;
        }
        public void AllDrawLineOptionsOff()
        {
            DrawBasicLine = DrawDashLine = DrawDashLineWithOneDot = DrawDashLineWithTwoDot = false;
        }
    }
}
