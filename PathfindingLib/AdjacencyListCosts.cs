using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLib
{
    public class AdjacencyListCosts : IWeightedGraphRepresentation
    {
        private readonly Dictionary<(int, int), int> data;
        public int VertexCount { get; init; }

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

        public void AddEdgeBidirectional(int nodeA, int nodeB, int cost)
        {
            AddEdge(nodeA, nodeB, cost);
            AddEdge(nodeB, nodeA, cost);
        }

        public void AddEdges(int from, int[] to, int[] costs)
        {
            for (int i = 0; i < to.Length; ++i)
                AddEdge(from, to[i], costs[i]);
        }

        public void RemoveEdge(int from, int to)
        {
            data.Remove((from, to));
        }

        public int CountNeighbours(int node)
        {
            int counter = 0;
            for (int i = 0; i < VertexCount; ++i)
            {
                if (data.ContainsKey((node ,i)))
                {
                    counter++;
                }
            }
            return counter;
        }
        public bool HasNeighbour(int node, int neighbour) => data.ContainsKey((node, neighbour));
        public IReadOnlyCollection<(int neighbour, int cost)> GetNeighbours(int node) {
            var neighbours = new List<(int neighbour, int cost)>();
            for (int i = 0; i < VertexCount; ++i)
            {
                (int, int) keys = data.Keys.ElementAt(i);
                if (data.ContainsKey((node, i)))
                {
                    neighbours.Add((i, data[(node, i)]));
                }
            }

            return neighbours;
        }  
    }
}
