using System;
using System.Text;

namespace Shapes
{
    public class Matrix<T>
    {
        T[,] _Items;
        //Matrix size nXm
        int nSize;
        int mSize;

        public int Rows
        {
            get { return nSize; }
        }

        public int Columns
        {
            get { return mSize; }
        }

        public virtual int[] Size
        {
            get
            {
                return new int[2] { nSize, mSize };
            }
            set
            {
                if (value.Length != 2)
                    throw new ArgumentOutOfRangeException("Size declaration can not have more than 2 values");
                if (value[0] < 1)
                    throw new ArgumentOutOfRangeException("Matrix can not have less than 1 row");
                if (value[1] < 1)
                    throw new ArgumentOutOfRangeException("Matrix can not have less than 1 column");
                else
                {
                    bool changed = false;
                    if (value[0] != nSize)
                    {
                        changed = true;
                        nSize = value[0];
                    } if (value[1] != mSize)
                    {
                        changed = true;
                        mSize = value[1];
                    }
                    if (changed)
                    {
                        Items = new T[nSize, mSize];
                    }
                }
            }
        }

        public virtual T[,] Items
        {
            get
            {
                return _Items;
            }
            set
            {
                if (value.GetLength(0) == nSize && value.GetLength(1) == mSize)
                    _Items = value;
                else
                    throw new ArgumentOutOfRangeException(string.Format("Coordinates have to be within the {0}D plane", nSize));
            }
        }

        public Matrix()
        {
            Size = new int[] { 2, 2 };
        }

        public Matrix(int[] size)
        {
            if (size.Length != 2)
                throw new ArgumentOutOfRangeException("Size declaration can not have more than 2 values");
            else
                Size = size;
        }

        public Matrix(int nSize, int mSize)
        {
            Size = new int[] { nSize, mSize };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int r = 0; r < nSize; r++)
            {
                StringBuilder minBuilder = new StringBuilder();
                for (int c = 0; c < mSize; c++)
                {
                    string currentValue = string.Format("{0:0.000}", Items[r, c]);
                    if (c == 0)
                        minBuilder.Append(currentValue);
                    else
                    {
                        minBuilder.Append(", ");
                        minBuilder.Append(currentValue);
                    }
                }
                builder.Append("(");
                builder.Append(minBuilder.ToString());
                builder.Append(")");
                if (r < nSize - 1)
                    builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}