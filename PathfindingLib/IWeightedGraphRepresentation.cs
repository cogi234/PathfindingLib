using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLib
{
    internal interface IWeightedGraphRepresentation
    {

        public int VertexCount { get; }
        public void AddEdge(int from, int to, int cost);
        public void AddEdges(int from, int[] to, int[] costs);
        public void RemoveEdge(int from, int to);
        public bool HasNeighbour(int nodeA, int nodeB);
        public int CountNeighbours(int node);
        public IReadOnlyCollection<(int neighbour, int cost)> GetNeighbours(int node);
    }
}
