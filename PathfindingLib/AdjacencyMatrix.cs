using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLib
{
    public class AdjacencyMatrix : IWeightedGraphRepresentation
    {
        private readonly BitArray[] data;
        public int VertexCount { get; init; }

        public AdjacencyMatrix(int vertexCount)
        {
            VertexCount = vertexCount;
            data = new BitArray[VertexCount];

            for (int i = 0; i < VertexCount; ++i)
                data[i] = new BitArray(VertexCount);
        }

        public void AddEdge(int from, int to) => data[from][to] = true;
        
        public void AddEdgeBidirectional(int from, int to)
        {
            AddEdge(from, to);
            AddEdge(to, from);
        }

        public void AddEdges(int from, int[] to)
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

            return neighbours;
        }
    }
}
