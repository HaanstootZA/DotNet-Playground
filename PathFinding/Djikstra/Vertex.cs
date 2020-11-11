namespace PathFinding.Dijkstra
{
    public class Vertex
	{
		public Edge LeftEdge { get; }

		public Edge RightEdge { get; }

		public int Weight { get; }

		public Vertex(Edge start, Edge end, int weight)
		{
			this.LeftEdge = start;
			this.RightEdge = end;
			this.Weight = weight;
		}
	}
}
