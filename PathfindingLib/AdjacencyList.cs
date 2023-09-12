using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLib
{
    public class AdjacencyList : IGraphRepresentation
    {
        private readonly SortedSet<int>[] data;
        public int VertexCount { get; init; }

        public AdjacencyList(int vertexCount)
        {
            VertexCount = vertexCount;
            data = new SortedSet<int>[vertexCount];

            for (int i = 0; i < vertexCount; ++i)
                data[i] = new SortedSet<int>();
        }

        public void AddEdge(int from, int to)
        {
            data[from].Add(to);
        }

        public void AddEdgeBidirectional(int nodeA, int nodeB)
        {
            AddEdge(nodeA, nodeB);
            AddEdge(nodeB, nodeA);
        }

        public void AddEdges(int from, int[] to)
        {
            for (int i = 0; i < to.Length; ++i)
                AddEdge(from, to[i]);
        }

        public void RemoveEdge(int from, int to)
        {
            data[from].Remove(to);
        }

        public int CountNeighbours(int node) => data[node].Count;
        public bool HasNeighbour(int node, int neighbour) => data[node].Contains(neighbour);
        public IReadOnlyCollection<int> GetNeighbours(int node) => data[node];
    }
}
