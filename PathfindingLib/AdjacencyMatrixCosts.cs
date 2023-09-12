using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLib
{
    internal class AdjacencyMatrixCosts: IWeightedGraphRepresentation
    {
        private readonly BitArray[] data;
        public int VertexCount { get; init; }

        public AdjacencyMatrixCosts(int vertexCount)
        {
            VertexCount = vertexCount;
            data = new BitArray[VertexCount];

            for (int i = 0; i < VertexCount; ++i)
                data[i] = new BitArray(VertexCount);
        }

        public void AddEdge(int from, int to) => data[from][to] = true;

        public void AddEdgeBidirectional(int from, int to, int cost)
        {
            AddEdge(from, to);
            AddEdge(to, from);
        }

        public void AddEdges(int from, int[] to, int[] costs)
        {
            for (int i = 0; i < to.Length; ++i)
                AddEdge(from, to[i]);
        }

        public int CountNeighbours(int node)
        {
            int count = 0;
            for (int i = 0; i < VertexCount; ++i)
                if (data[node][i])
                    ++count;

            return count;
        }
        public void RemoveEdge(int from, int to) => data[from][to] = false;
        public bool HasNeighbour(int nodeA, int nodeB) => data[nodeA][nodeB];
        public IReadOnlyCollection<int> GetNeighbours(int node)
        {
            var neighbours = new List<int>();
            var row = data[node];

            for (int i = 0; i < VertexCount; ++i)
                if (row[i])
                    neighbours.Add(i);

            return neighbours.ToArray();
        }

        public void AddEdge(int from, int to, int cost)
        {
            throw new NotImplementedException();
        }

        IReadOnlyCollection<(int neighbour, int cost)> IWeightedGraphRepresentation.GetNeighbours(int node)
        {
            throw new NotImplementedException();
        }

        public void AddEdges(int from, int[] to)
        {
            throw new NotImplementedException();
        }
    }
}
