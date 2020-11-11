using System.Collections.Generic;

namespace PathFinding.Dijkstra
{
	public class Implementation
	{
		private LinkedList<Edge> GetEdgeVertices(int[][] connections, int leftEdge, Edge[] allEdges)
		{
			var result = new LinkedList<Edge>();
			for (var y = 0; y < connections[leftEdge].Length; y++)
			{
				if (y != leftEdge && connections[leftEdge][y] > 0)
				{
					Edge newEdge = this.GetCurrentEdge(y, allEdges);
					if (newEdge.LeftEdge == null || leftEdge != newEdge.LeftEdge.Location)
					{
						if (newEdge.DistanceFromStart <= 0)
						{
							newEdge.DistanceFromStart = connections[leftEdge][y];
						}

						LinkedListNode<Edge> firstEdge = result.First;
						if (firstEdge == null)
						{
							result.AddFirst(newEdge);
						}

						while (firstEdge != null)
						{
							if (connections[leftEdge][y] < connections[leftEdge][firstEdge.Value.Location])
							{
								result.AddBefore(firstEdge, newEdge);
								firstEdge = null;
							}
							else if (firstEdge.Next == null)
							{
								result.AddAfter(firstEdge, newEdge);
								firstEdge = null;
							}
							else
							{
								firstEdge = firstEdge.Next;
							}
						}
					}
				}
			}
			return result;
		}

		private Edge GetCurrentEdge(int currentIndex, Edge[] edges)
		{
			if (edges[currentIndex] == null)
			{
				edges[currentIndex] = new Edge(currentIndex);
			}
			return edges[currentIndex];
		}

		public Path FindDijkstraPath(int[][] connections, int startLocation, int endLocation)
		{
			var result = new Path(totalWeight: 0, firstEdge: startLocation);
			var currentPath = new Path(totalWeight: 0, firstEdge: startLocation);

			var openList = new Queue<Edge>();
			var visitedList = new HashSet<int>();

			var leftEdge = new Edge(startLocation);
			var allEdges = new Edge[connections.Length];

			LinkedList<Edge> edgeVertices = this.GetEdgeVertices(connections, startLocation, allEdges);
			LinkedListNode<Edge> edgeVertexNode = edgeVertices.First;

			while (edgeVertexNode != null)
			{
				currentPath.MoveForwardToEdge(edgeVertexNode.Value.Location, connections[leftEdge.Location][edgeVertexNode.Value.Location]);
				if (currentPath.CurrentEdge == endLocation)
				{
					if (result.TotalWeight == 0 || currentPath.TotalWeight < result.TotalWeight)
					{
						result = currentPath;
					}
				}
				else
				{
					currentPath.MoveBackwardToPreviousEdge();
					if (!(visitedList.Contains(edgeVertexNode.Value.Location) || openList.Contains(edgeVertexNode.Value)))
					{
						edgeVertexNode.Value.LeftEdge = leftEdge;
						openList.Enqueue(edgeVertexNode.Value);
					}
				}

				if ((visitedList.Contains(edgeVertexNode.Value.Location) || openList.Contains(edgeVertexNode.Value)) && edgeVertexNode.Value.DistanceFromStart < currentPath.TotalWeight)
				{
					edgeVertexNode.Value.DistanceFromStart = currentPath.TotalWeight;
					edgeVertexNode.Value.LeftEdge = leftEdge;
				}

				if (edgeVertexNode.Next == null)
				{
					visitedList.Add(leftEdge.Location);
				}

				edgeVertexNode = edgeVertexNode.Next;

				while (edgeVertexNode == null && openList.Count > 0)
				{
					leftEdge = openList.Dequeue();
					edgeVertexNode = this.GetEdgeVertices(connections, leftEdge.Location, allEdges).First;

					var newPath = new Path(totalWeight: 0, firstEdge: startLocation);
					newPath.MoveForwardToEdge(leftEdge.Location, leftEdge.DistanceFromStart);
					currentPath = newPath;
				}
			}
			return result;
		}
	}
}
