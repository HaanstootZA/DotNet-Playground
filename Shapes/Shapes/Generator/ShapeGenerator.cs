using System;
using System.Collections.Generic;

namespace Shapes
{
    public static class ShapeGenerator
    {
        private static void AddCircleCoordinates(int counter, int advance, double x, double y, Shape circle)
        {
            Coordinate2D c1 = new Coordinate2D();
            Coordinate2D c2 = new Coordinate2D();
            Coordinate2D c3 = new Coordinate2D();
            Coordinate2D c4 = new Coordinate2D();
            c1.Items = new double[2] { x, y };
            c2.Items = new double[2] { -1 * x, y };
            c3.Items = new double[2] { x, -1 * y };
            c4.Items = new double[2] { -1 * x, -1 * y };
            circle.SetValue(counter + (advance * 0), c1);
            circle.SetValue(counter + (advance * 1), c2);
            circle.SetValue(counter + (advance * 2), c3);
            circle.SetValue(counter + (advance * 3), c4);
        }

        public static Shape GenerateCircle(int rad)
        {
            Shape circle = new Shape(rad * 8);
            for (int x = 0; x < rad; x++)
            {
                double y = Math.Sqrt((rad * rad) - (x * x));
                AddCircleCoordinates(x, rad, x, y, circle);
                AddCircleCoordinates(x + (rad*4), rad, y, x, circle);
            }

            return circle;
        }
    }
}