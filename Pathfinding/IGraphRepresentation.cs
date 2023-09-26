﻿using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace PathfindingLib
{
    public interface IGraphRepresentation
    {
        public int VertexCount { get; }
        public void AddEdge(int from, int to);
        public void AddEdges(int from, int[] to);
        public void RemoveEdge(int from, int to);
        public bool HasNeighbour(int nodeA, int nodeB);
        public int CountNeighbours(int node);
        public IReadOnlyCollection<int> GetNeighbours(int node);
    }
}
