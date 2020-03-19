using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace InteractiveImage
{
    class MPoint
    {
        private double m_x = 0;
        private double m_y = 0;

        public double X
        {
            get { return m_x; }
            set { m_x = value; }
        }
        public double Y
        {
            get { return m_y; }
            set { m_y = value; }
        }
        public int iX
        {
            get { return (int)Math.Floor(m_x); }
            set { m_x = value; }
        }
        public int iY
        {
            get { return (int)Math.Floor(m_y); }
            set { m_y = value; }
        }
        public bool IsOrigin { get { return (m_y == 0 && m_x == 0); } }

        public MPoint(int x, int y)
        {
            m_x = x;
            m_y = y;
        }
        public MPoint(double x, double y)
        {
            m_x = x;
            m_y = y;
        }
        public MPoint(Point p)
        {
            m_x = p.X;
            m_y = p.Y;
        }

        public Point Point()
        {
            return new Point((int)m_x, (int)m_y);
        }
        public PointF PointF() {
            return new PointF((float)m_x, (float)m_y);
        }

        public static bool operator ==(MPoint a, MPoint b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return (a.X == b.X && a.Y == b.Y) || (a.iX == b.iX && a.iY == b.iY);
        }
        public static bool operator !=(MPoint a, MPoint b)
        {
            return !(a == b);
        }
        public static MPoint operator +(MPoint a, MPoint b)
        {
            MPoint newp = new MPoint(a.X + b.X, a.Y + b.Y);
            return newp;
        }
        public static MPoint operator +(MPoint a, int b)
        {
            MPoint newp = new MPoint(a.X + b, a.Y + b);
            return newp;
        }
        public static MPoint operator +(MPoint a, double b)
        {
            MPoint newp = new MPoint(a.X + b, a.Y + b);
            return newp;
        }
        public static MPoint operator -(MPoint a, MPoint b)
        {
            MPoint newp = new MPoint(a.X - b.X, a.Y - b.Y);
            return newp;
        }
        public static MPoint operator -(MPoint a, int b)
        {
            MPoint newp = new MPoint(a.X - b, a.Y - b);
            return newp;
        }
        public static MPoint operator -(MPoint a, double b)
        {
            MPoint newp = new MPoint(a.X - b, a.Y - b);
            return newp;
        }
        public static MPoint operator *(MPoint a, int b)
        {
            MPoint newp = new MPoint(a.X * b, a.Y * b);
            return newp;
        }
        public static MPoint operator *(MPoint a, double b)
        {
            MPoint newp = new MPoint(a.X * b, a.Y * b);
            return newp;
        }
        public override bool Equals(object obj)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)this == null) || ((object)obj == null))
            {
                return false;
            }
            if (obj.GetType() == typeof(MPoint))
            {
                MPoint b = (MPoint)obj;
                // Return true if the fields match:
                return (m_x == b.X && m_y == b.Y) || (iX == b.iX && iY == b.iY);
            }
            return false;
        }
    }
}
