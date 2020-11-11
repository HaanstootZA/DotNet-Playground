using System.Collections.Generic;

namespace PathFinding.Dijkstra.Extended
{
    public class Map
    {
        private int[][] _Distances;
        private SpecializedSet<Location> _Locations;
        private LinkedList<Road> _Routes;

        private Map()
        {

        }

        public Location AddLocation(long identifier, long longitude, long latitude)
        {
            Location result = new Location(identifier, longitude, latitude);
            if (!this._Locations.Contains(result))
            {
                this._Locations.Add(result);
            }
            return result;
        }

        public void AddRoute(long locationIdentifier1, long locationIdentifier2, long distance)
        {

            Location location1;
            Location location2;
            if (this._Locations.TryGetValue(locationIdentifier1, out location1) && this._Locations.TryGetValue(locationIdentifier2, out location2))
            {
                this._Routes.AddLast(new Road(location1, location2, distance));
            }
        }

        public void ImportLocationDistances(int[][] distances)
        {
            this._Distances = distances;
        }

        private void CreateRoutes()
        {

        }

        private void AddRoute()
        {

        }
    }
}
