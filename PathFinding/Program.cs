using System;
using System.Collections.Generic;
using System.Diagnostics;
using PathFinding.Dijkstra;

namespace PathFinding
{
	class Program
	{
		static int[][] GenerateConnections(int seed, int seedClosed, int minDistance, int maxDistance, int endpoints)
		{
			int[][] result = new int[endpoints][];
			Random random = new Random(seed);
			Random randomClosed = new Random(seedClosed);
			for (int x = 0; x < endpoints; x++)
			{
				if (result[x] == null)
				{
					result[x] = new int[endpoints - x];
				}

				for (int y = 1; y < result[x].Length; y++)
				{

					if (randomClosed.Next(0, 10) % 2 == 0)
					{
						result[x][y] = -1;
					}
					else
					{
						result[x][y] = random.Next(minDistance, maxDistance);
					}
				}
			}
			return result;
		}

		static int GetNextSeed(int seed, double seedMultiplier)
		{
			if ((seed <= 10 && seedMultiplier < 1) || seedMultiplier > 1)
			{
				return (int)(seed / seedMultiplier);
			}
			else
			{
				return (int)(seed * seedMultiplier);
			}
		}

		static LinkedList<Edge> GetEdgeVertices(int[][] connections, int leftEdge, Edge[] allEdges)
		{
			LinkedList<Edge> result = new LinkedList<Edge>();
			for (int y = 0; y < connections[leftEdge].Length; y++)
			{
				if (y != leftEdge && connections[leftEdge][y] > 0)
				{
					Edge newEdge = GetCurrentEdge(y, allEdges);
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

		static Edge GetCurrentEdge(int currentIndex, Edge[] edges)
		{
			if (edges[currentIndex] == null)
			{
				edges[currentIndex] = new Edge(currentIndex);
			}
			return edges[currentIndex];
		}

		static bool RecalculatePathForLocationStep(int[][] connections, LinkedListNode<KeyValuePair<int, int>> currentEdge)
		{
			return currentEdge?.Next != null && connections[currentEdge.Value.Key][currentEdge.Next.Value.Key] < 0;
		}

		static Path FindDijkstraPath(int[][] connections, int startLocation, int endLocation)
		{
			Path result = new Path(0, startLocation);
			Path currentPath = new Path(0, startLocation);

			Queue<Edge> openList = new Queue<Edge>();
			HashSet<int> visitedList = new HashSet<int>();

			Edge leftEdge = new Edge(startLocation);
			Edge[] allEdges = new Edge[connections.Length];

			LinkedList<Edge> edgeVertices = GetEdgeVertices(connections, startLocation, allEdges);
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
					edgeVertexNode = GetEdgeVertices(connections, leftEdge.Location, allEdges).First;

					Path newPath = new Path(0, startLocation);
					newPath.MoveForwardToEdge(leftEdge.Location, leftEdge.DistanceFromStart);
					currentPath = newPath;
				}
			}
			return result;
		}

		static void Problem1(int seed, double seedClosedMultipler, int minDistance, int maxDistance, int endpoints, int start, int end)
		{
			Console.Out.WriteLine($"Starting problem 1 from {start} to {end}");
			int seedClosed = GetNextSeed(seed, seedClosedMultipler);
			int[][] connections = GenerateConnections(seed, seedClosed, minDistance, maxDistance, endpoints);

			Path myPath = FindDijkstraPath(connections, start, end);
			LinkedListNode<KeyValuePair<int, int>> currentEdge = myPath.EdgePath.First;
			int i = 0;
			while (currentEdge != null && currentEdge.Value.Key > -1 && currentEdge.Value.Key != end)
			{
				Console.Out.WriteLine($"Step {i}) Location {start}");
				currentEdge = currentEdge.Next;
				start = currentEdge?.Value.Key ?? -1;
				i++;
			}
			Console.Out.WriteLine($"Step {i}) Location {start}");
		}

		static void Problem2(int seed, double seedMultiplier, double seedClosedMultipler, int minDistance, int maxDistance, int endpoints, int start, int end)
		{
			Console.Out.WriteLine($"Starting problem 2 from {start} to {end}");

			Path myPath = null;
			LinkedListNode<KeyValuePair<int, int>> currentEdge = null;
			int i = 0;
			Console.Out.WriteLine($"Step {i}) Location {start}");
			do
			{
				int seedClosed = Program.GetNextSeed(seed, seedClosedMultipler);
				seed = GetNextSeed(seed, seedMultiplier);
				int[][] connections = Program.GenerateConnections(seed, seedClosed, minDistance, maxDistance, endpoints);

				if (myPath == null || RecalculatePathForLocationStep(connections, currentEdge))
				{
					myPath = FindDijkstraPath(connections, start, end);
					currentEdge = myPath.EdgePath.First?.Next;
				}
				else
				{
					currentEdge = currentEdge.Next;
				}

				start = currentEdge?.Value.Key ?? -1;
				i++;
				Console.Out.WriteLine($"Step {i}) Location {start}");
			} while (currentEdge != null && currentEdge.Value.Key > -1 && currentEdge.Value.Key != end);

			if (currentEdge == null || currentEdge.Value.Key < 0)
			{
				Console.Out.WriteLine("end is unreachable");
			}
			else
			{
				Console.Out.WriteLine();
			}
		}
		
		static void Main(string[] args)
		{
			int endpoints = 1000;
			int seed = 1000;

			int startLocation = 20;
			int endLocation = 430;

			int minDistance = 1;
			int maxDistance = 10;

			double seedMultiplier = 1.0 / 8.0;
			double seedClosedMultipler = 1.0 / 7.0;
			
			Stopwatch sp = new Stopwatch();
			sp.Start();
			Problem1(seed, seedMultiplier, minDistance, maxDistance, endpoints, startLocation, endLocation);
			sp.Stop();
			Console.WriteLine($"Problem 1 completed in {sp.ElapsedMilliseconds}ms");

			sp.Reset();
			sp = new Stopwatch();
			sp.Start();
			Problem2(seed, seedMultiplier, seedClosedMultipler, minDistance, maxDistance, endpoints, startLocation, endLocation);
			sp.Stop();

			Console.WriteLine($"Problem 2 completed in {sp.ElapsedMilliseconds}ms");
			Console.ReadKey();
		}
	}
}
