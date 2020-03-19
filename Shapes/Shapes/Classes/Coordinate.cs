using System;

namespace Shapes
{
    public class Coordinate : Vector<double>
    {
        public virtual int Dimensions
        {
            get
            {
                return Size;
            }
            set
            {
                if (value >= 2)
                {
                    Size = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Coordinate systems, require more than 2 dimension");
            }
        }

        public virtual double[] Coordinates
        {
            get
            {
                return Items;
            }
            set
            {
                Items = value;
            }
        }

        public Coordinate() :
            base(2) { }

        public Coordinate(int nDimension) :
            base(nDimension) { }

        public override string ToString()
        {
            string toReturn = "";
            for (int i = 0; i < Dimensions; i++)
            {
                string currentValue = string.Format("{0:0.000}", Coordinates[i]);
                if (i == 0)
                    toReturn += currentValue;
                else
                    toReturn += ", " + currentValue;
            }
            toReturn = "(" + toReturn + ")";
            return toReturn;
        }
    }
}