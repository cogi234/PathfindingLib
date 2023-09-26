using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace PathfindingLib
{
    public interface IWeightedGraphRepresentation : IGraphRepresentation
    {
        public void AddEdge(int from, int to, int cost);
        public void AddEdges(int from, int[] to, int[] costs);
        public new IReadOnlyCollection<(int neighbour, int cost)> GetNeighbours(int node);
    }
}
