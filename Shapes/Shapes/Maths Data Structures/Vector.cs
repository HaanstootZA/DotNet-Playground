using System;

namespace Shapes
{
    public class Vector<T>
    {
        private T[] items;
        private int nSize;

        public virtual int Size
        {
            get
            {
                return nSize;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Coordinate systems, require more than 2 dimension");
                else
                    if (value != nSize)
                    {
                        nSize = value;
                        items = new T[nSize];
                    }
            }
        }

        public virtual T[] Items
        {
            get
            {
                return items;
            }
            set
            {
                if (value.Length == nSize)
                    items = value;
                else
                    throw new ArgumentOutOfRangeException(string.Format("Coordinates have to be within the {0}D plane", nSize));
            }
        }

        public Vector()
        {
            Size = 2;
        }

        public Vector(int size)
        {
            Size = size;
        }

        public T GetItem(int index)
        {
            T value = Items[index];
            return value;
        }

        public T SetItem(int index, T value)
        {
            T currValue = Items[index];
            Items[index] = value;
            return currValue;
        }

        public void SetItems(T[] Collection)
        {
            items = Collection;
        }

        public override string ToString()
        {
            string toReturn = "";
            for (int i = 0; i < Size; i++)
            {
                string currentValue = string.Format("{0:0.000}", Items[i]);
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