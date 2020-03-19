using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicRenamer
{
    public static class Comparer
    {
        public static bool CompareTags(RenamerTag left, RenamerTag right)
        {
            return left.Compare(right);
        }
    }
}
