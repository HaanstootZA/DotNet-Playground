using System;

namespace Shapes
{
    public class Coordinate2D : Coordinate
    {
        public override int Dimensions
        {
            get
            {
                return Size;
            }
            set
            {
                if (value == 2)
                {
                    Size = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Coordinate systems, require more than 2 dimension");
            }
        }

        public Coordinate2D() : base (2) {}

        public override string ToString()
        {
            string toReturn = string.Format("({0:0.000}, {1:0.000})", Coordinates[0], Coordinates[1]);
            return toReturn;
        }
    }
}