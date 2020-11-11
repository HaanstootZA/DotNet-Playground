using System.Collections.Generic;

namespace PathFinding.Dijkstra
{
	public class Edge
	{
		public LinkedList<Vertex> Vertices { get; }

		public int Location { get; }
		
		public Edge LeftEdge { get; set; }

		public int DistanceFromStart { get; set; }

		public Edge(int location)
		{
			this.Location = location;
			this.Vertices = new LinkedList<Vertex>();
		}
	}
}
