using System;
using System.Text;

namespace Shapes
{
    public class Vector_Matrix<T>
    {
        protected Vector<Vector<T>> items;
        //Matrix size nXm
        protected int nSize;
        protected int mSize;

        public int Rows
        {
            get { return nSize; }
        }

        public int Columns
        {
            get { return mSize; }
        }

        public int[] Size
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
                        Vector<T> tempVector = new Vector<T>(mSize);
                        Vector<Vector<T>> newVector = new Vector<Vector<T>>(nSize);
                        for (int i = 0; i < nSize; i++)
                        {
                            newVector.Items[i] = tempVector;
                        }
                        SetItems = newVector;
                    }
                }
            }
        }

        public Vector<Vector<T>> GetItems
        {
            get
            {
                return items;
            }
        }
        
        protected Vector<Vector<T>> SetItems
        {
            set
            {
                if (value.Size == nSize)
                {
                    if (nSize > 0)
                        if (value.Items[0].Size == mSize)
                            items = value;
                }
                else
                    throw new ArgumentOutOfRangeException(string.Format("Coordinates have to be within the {0}D plane", nSize));
            }
        }

        public Vector_Matrix()
        {
            Size = new int[] { 2, 2 };
        }

        public Vector_Matrix(int[] size)
        {
            if (size.Length != 2)
                throw new ArgumentOutOfRangeException("Size declaration can not have more than 2 values");
            else
                Size = size;
        }

        public Vector_Matrix(int nSize, int mSize)
        {
            Size = new int[] { nSize, mSize };
        }

        public T SetValue(int nRow, int mCol, T value){
            T CurrValue = items.GetItem(nRow).SetItem(mCol, value);
            return CurrValue;
        }

        public T GetValue(int nRow, int mCol)
        {
            T value = items.GetItem(nRow).GetItem(mCol);
            return value;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int r = 0; r < nSize; r++)
            {
                StringBuilder minBuilder = new StringBuilder();
                for (int c = 0; c < mSize; c++)
                {
                    string currentValue = string.Format("{0:0.000}", GetItems.GetItem(r).GetItem(c));
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