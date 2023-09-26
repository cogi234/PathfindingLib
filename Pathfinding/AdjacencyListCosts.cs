using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;

namespace PathfindingLib
{
    public class AdjacencyListCosts : IWeightedGraphRepresentation
    {
        private readonly Dictionary<(int, int), int> data;
        public int VertexCount { get; private set; }

        public AdjacencyListCosts(int vertexCount)
        {
            if (vertexCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vertexCount));
            }
            VertexCount = vertexCount;
            data = new Dictionary<(int, int), int>();
        }

        public void AddEdge(int from, int to, int cost)
        {
            data[(from, to)] = cost;
        }
        public void AddEdge(int from, int to)
        {
            data[(from, to)] = 1;
        }

        public void AddEdgeBidirectional(int nodeA, int nodeB, int cost)
        {
            AddEdge(nodeA, nodeB, cost);
            AddEdge(nodeB, nodeA, cost);
        }
        public void AddEdgeBidirectional(int nodeA, int nodeB)
        {
            AddEdge(nodeA, nodeB);
            AddEdge(nodeB, nodeA);
        }

        public void AddEdges(int from, int[] to, int[] costs)
        {
            for (int i = 0; i < to.Length; ++i)
                AddEdge(from, to[i], costs[i]);
        }
        public void AddEdges(int from, int[] to)
        {
            for (int i = 0; i < to.Length; ++i)
                AddEdge(from, to[i]);
        }

        public void RemoveEdge(int from, int to)
        {
            data.Remove((from, to));
        }

        public int CountNeighbours(int node)
        {
            return data.Count<KeyValuePair<(int, int), int>>((KeyValuePair<(int, int), int> kv) => { return kv.Key.Item1 == node; });
        }
        public bool HasNeighbour(int node, int neighbour) => data.ContainsKey((node, neighbour));
        public IReadOnlyCollection<(int neighbour, int cost)> GetNeighbours(int node)
        {
            var neighbours = new List<(int neighbour, int cost)>();
            for (int i = 0; i < VertexCount; ++i)
            {
                if (data.ContainsKey((node, i)))
                {
                    neighbours.Add((i, data[(node, i)]));
                }
            }
            return neighbours;
        }
        IReadOnlyCollection<int> IGraphRepresentation.GetNeighbours(int node)
        {
            var neighbours = new List<int>();
            for (int i = 0; i < VertexCount; ++i)
            {
                if (data.ContainsKey((node, i)))
                {
                    neighbours.Add(i);
                }
            }
            return neighbours;
        }
    }
}
