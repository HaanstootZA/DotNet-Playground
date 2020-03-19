using System;
using System.Text;

namespace Shapes
{
    public enum ShapeType
    {
        Circle, Polygon
    }

    //Based on Vector_Matrix
    public class Shape
    {
        protected Vector<Coordinate> items;
        //Matrix size nXm
        protected int nSize;
        protected int mSize = 2;

        public int Rows
        {
            get { return nSize; }
        }

        public int Columns
        {
            get { return mSize; }
        }

        public virtual int Size
        {
            get
            {
                return nSize;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Matrix can not have less than 1 row");
                else if (value != nSize)
                {
                    nSize = value;
                    Coordinate tempVector = new Coordinate(mSize);
                    Vector<Coordinate> newVector = new Vector<Coordinate>(nSize);
                    for (int i = 0; i < nSize; i++)
                    {
                        newVector.Items[i] = tempVector;
                    }
                    SetItems = newVector;
                }
            }
        }

        public Vector<Coordinate> GetItems
        {
            get
            {
                return items;
            }
        }

        protected Vector<Coordinate> SetItems
        {
            set
            {
                if (value.Size == nSize)
                {
                    items = value;
                }
                else
                    throw new ArgumentOutOfRangeException(string.Format("Coordinates have to be within the {0}D plane", nSize));
            }
        }

        public Shape()
        {
            Size = 2;
        }

        public Shape(int size)
        {
            Size = size;
        }

        public Coordinate SetValue(int nRow, Coordinate value)
        {
            Coordinate CurrValue = items.SetItem(nRow, value);
            return CurrValue;
        }

        public void SetCoordinates(Coordinate[] Collection)
        {
            items.SetItems(Collection);
        }

        public Coordinate GetValue(int nRow)
        {
            Coordinate value = items.GetItem(nRow);
            return value;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int r = 0; r < nSize; r++)
            {
                builder.Append(items.GetItem(r).ToString());
                if (r < nSize - 1)
                    builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}