using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingApplication
{
    static class MapMath
    {
        public static Random RAND = new Random(); //Debug
        public static double MINRAD = 5;
        public static double MINDIST = 0;
        public static int NODES = 0;

        public static double PI { get { return 3.14159265358979; } }

        public static MPoint FindMiddle(int Width, int Height)
        {
            return new MPoint(Width / 2.0, Height / 2.0);
        }

        public static bool IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32
            || Expression is Int64 || Expression is double
            || Expression is Single || Expression is Double
            || Expression is Boolean)
                return true;

            try
            {
                double result;
                if (Expression is string)
                    return Double.TryParse(Expression as string, out result);
                else
                    return Double.TryParse(Expression.ToString(), out result);
            }
            catch { } // just dismiss errors but return false
            return false;
        }

        public static double FindDiffAngle(int nodes)
        {
            double angle = 360.00 / nodes;
            return (angle / 180.00) * PI;
        }

        public static double GetRadian(double Angle)
        {
            return (Angle * PI) / 180;
        }

        //using arc length
        public static double FindArcRadius(double DAngle, double DLength)
        {
            double theta = DAngle;//(DAngle * PI)/180;
            double rad = DLength / theta;
            if (rad < MINRAD)
                rad = MINRAD;
            return rad;
        }

        //using chord length
        public static double FindChordRadius(double DAngle, double DLength)
        {
            double angleR = (PI - DAngle) / 2;
            angleR = Math.Sin(angleR);
            DAngle = Math.Sin(DAngle);
            double rad = Math.Abs(angleR * DLength / DAngle);
            if (rad < MINRAD)
                rad = MINRAD;
            return rad;
        }

        public static double FindLineCut(MPoint point, double Gradient)
        {
            double c = point.Y - Gradient * point.X;
            return c;
        }

        public static double FindGradient(MPoint point1, MPoint point2)
        {
            if (point2.X == point1.X)
                return double.PositiveInfinity;
            double gradient = (point1.Y - point2.Y) / (point1.X - point2.X);
            return gradient;
        }

        public static double FindLineLength(MPoint point1, MPoint point2)
        {
            double distance = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
            return distance;
        }

        private static MPoint FindPointOnLineWithLength(double c, double m, double r){
            double msq = Math.Pow(m, 2);
            double p1 = (c*msq)/Math.Pow(1+msq, 2);
            double p2 = (Math.Pow(c, 2)  - Math.Pow(r, 2))/(1 + msq);
            double p3 = Math.Sqrt(p1 - p2);
            double p4 = c*m/(1+msq);
            double x = (p3 - p4);
            double y = (m * x) + c;
            return new MPoint(x, y);
        }

        //double d = Mindistance / 2;
        //double r1 = Math.Sqrt(Math.Pow(Parent.X, 2) + Math.Pow(Parent.Y, 2));
        ////double pr1 = Math.Sqrt(Math.Pow(r1, 2) - Math.Pow(d, 2));
        ////double pr2 = LongRadius - pr1;
        ////double r3 = Math.Sqrt(Math.Pow(d, 2) + Math.Pow(pr2, 2));
        ////double newx = Math.Sqrt((Math.Pow(LongRadius, 2) + Math.Pow(r3, 2)) / 2);
        ////double newy = Math.Sqrt(Math.Pow(LongRadius, 2) - Math.Pow(newx, 2));
        ////MPoint newPoint = new MPoint(newx, newy);
        ////return newPoint;
        //double angleD = -1 * Math.Asin(GetRadian(d / r1));
        //double ratio = LongRadius / r1;
        //MPoint newpoint = TransformPoint(angleD, Parent);
        //double m = FindGradient(newpoint, new MPoint(0, 0));
        //double c = FindLineCut(new MPoint(0, 0), m);
        //double newy =  ratio* (m * newpoint.X + c);
        //double newx = (newy / m) - c;
        //newpoint = new MPoint(newx, newy);
        //return newpoint;

        public static MPoint TransformPoint(double angle, MPoint p)
        {
            double cosTheta = Math.Cos(angle);
            double sinTheta = Math.Sin(angle);
            double x = p.X * cosTheta + p.Y * sinTheta;
            double y = p.Y * cosTheta - p.X * sinTheta;
            return new MPoint(Math.Round(x, 7), Math.Round(y, 7));
        }
    }
}
