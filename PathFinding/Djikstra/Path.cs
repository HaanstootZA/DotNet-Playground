using System.Collections.Generic;

namespace PathFinding.Dijkstra
{
	public class Path
	{
		public LinkedList<KeyValuePair<int, int>> EdgePath { get; private set; }
		public int CurrentEdge { get => this.EdgePath.Last.Value.Key; }
		public int TotalWeight { get; private set; }

		public Path(int totalWeight, int firstEdge)
		{
			this.TotalWeight = totalWeight;

			this.EdgePath = new LinkedList<KeyValuePair<int, int>>();
			this.EdgePath.AddFirst(new KeyValuePair<int, int>(firstEdge, 0));
		}

		public void MoveBackwardToPreviousEdge()
		{
			this.TotalWeight -= this.EdgePath.Last.Value.Value;
			this.EdgePath.RemoveLast();
		}

		public void MoveForwardToEdge(int rightEdge, int weight)
		{
			this.EdgePath.AddLast(new KeyValuePair<int, int>(rightEdge, weight));
			this.TotalWeight += weight;
		}
	}
}
