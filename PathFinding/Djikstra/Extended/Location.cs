using System.Runtime.InteropServices;

namespace PathFinding.Dijkstra.Extended
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.None, Size = 1)]
    public struct Location
    {
        public long Identifier { get; }
        public long Longitude { get; }
        public long Latitude { get; }

        public Location(long identifier, long longitude, long latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.Identifier = identifier;
        }

        public override int GetHashCode()
        {
            return this.Identifier.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Location)
            {
                return ((Location)obj).Identifier == this.Identifier;
            }
            else
            {
                return base.Equals(obj);
            }
        }
    }
}
