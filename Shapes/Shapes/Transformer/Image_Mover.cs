using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    public static class Image_Mover
    {
        public static Shape Move_First_Axis_Positive(Shape shape, int increment)
        {
            Shape newShape = new Shape(shape.Size);
            Vector<Coordinate> vShape = shape.GetItems;
            for (int i = 0; i < shape.Size; i++)
            {
                Coordinate currCoor = vShape.Items[i];
                Coordinate newCoor = new Coordinate(currCoor.Dimensions);
                for (int c = 0; c < currCoor.Dimensions; c++)
                {
                    if (c == 0)
                        newCoor.SetItem(c, currCoor.Items[c] + increment);
                    else
                        newCoor.SetItem(c, currCoor.Items[c]);
                }
                newShape.SetValue(i, newCoor);
            }
            return newShape;
        }
        public static Shape Move_First_Axis_Negative(Shape shape, int increment)
        {
            Shape newShape = new Shape(shape.Size);
            Vector<Coordinate> vShape = shape.GetItems;
            for (int i = 0; i < shape.Size; i++)
            {
                Coordinate currCoor = vShape.Items[i];
                Coordinate newCoor = new Coordinate(currCoor.Dimensions);
                for (int c = 0; c < currCoor.Dimensions; c++)
                {
                    if (c == 0)
                        newCoor.SetItem(c, currCoor.Items[c] - increment);
                    else
                        newCoor.SetItem(c, currCoor.Items[c]);
                }
                newShape.SetValue(i, newCoor);
            }
            return newShape;
        }
        public static Shape Move_Second_Axis_Positive(Shape shape, int increment)
        {
            Shape newShape = new Shape(shape.Size);
            Vector<Coordinate> vShape = shape.GetItems;
            for (int i = 0; i < shape.Size; i++)
            {
                Coordinate currCoor = vShape.Items[i];
                Coordinate newCoor = new Coordinate(currCoor.Dimensions);
                for (int c = 0; c < currCoor.Dimensions; c++)
                {
                    if (c == 1)
                        newCoor.SetItem(c, currCoor.Items[c] + increment);
                    else
                        newCoor.SetItem(c, currCoor.Items[c]);
                }
                newShape.SetValue(i, newCoor);
            }
            return newShape;
        }
        public static Shape Move_Second_Axis_Negative(Shape shape, int increment)
        {
            Shape newShape = new Shape(shape.Size);
            Vector<Coordinate> vShape = shape.GetItems;
            for (int i = 0; i < shape.Size; i++)
            {
                Coordinate currCoor = vShape.Items[i];
                Coordinate newCoor = new Coordinate(currCoor.Dimensions);
                for (int c = 0; c < currCoor.Dimensions; c++)
                {
                    if (c == 1)
                        newCoor.SetItem(c, currCoor.Items[c] - increment);
                    else
                        newCoor.SetItem(c, currCoor.Items[c]);
                }
                newShape.SetValue(i, newCoor);
            }
            return newShape;
        }
    }
}
