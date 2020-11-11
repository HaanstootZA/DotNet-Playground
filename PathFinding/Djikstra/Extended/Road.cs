using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinding.Dijkstra.Extended
{
    public struct Road
    {
        public Location From { get; set; }
        public Location To { get; set; }
        public long Distance { get; set; }

        public Road(Location from, Location to, long distance)
        {
            this.From = from;
            this.To = to;
            this.Distance = distance;
        }
    }
}
