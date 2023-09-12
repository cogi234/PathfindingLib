using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLib
{
    public class AdjacencyListCosts : IWeightedGraphRepresentation
    {
        private readonly Dictionary<int, int>[] data;
        public int VertexCount { get; init; }

        public AdjacencyListCosts(int vertexCount)
        {
            VertexCount = vertexCount;
            data = new Dictionary<int, int>[vertexCount];

            for (int i = 0; i < vertexCount; ++i)
                data[i] = new Dictionary<int, int>();
        }

        public void AddEdge(int from, int to, int cost)
        {
            data[from].Add(to, cost);
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
            data[from].Remove(to);
        }

        public int CountNeighbours(int node) => data[node].Count;
        public bool HasNeighbour(int node, int neighbour) => data[node].ContainsKey(neighbour);
        public IReadOnlyCollection<(int neighbour, int cost)> GetNeighbours(int node) {
            var neighbours = new List<(int neighbour, int cost)>();
            var row = data[node];

            foreach (KeyValuePair<int,int> kv in row)
            {
                neighbours.Add((kv.Key, kv.Value));
            }

            return neighbours;
        }  
    }
}
