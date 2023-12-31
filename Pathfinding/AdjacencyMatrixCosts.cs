﻿using System.Collections.Generic;
using System.Collections;

namespace PathfindingLib
{
    public class AdjacencyMatrixCosts : IWeightedGraphRepresentation
    {
        private readonly int[][] data;
        public int VertexCount { get; private set; }

        public AdjacencyMatrixCosts(int vertexCount)
        {
            VertexCount = vertexCount;
            data = new int[vertexCount][];

            for (int i = 0; i < VertexCount; ++i)
            {
                data[i] = new int[vertexCount];
                for (int j = 0; j < VertexCount; j++)
                {
                    data[i][j] = -1;
                }
            }
        }

        public void AddEdge(int from, int to, int cost) => data[from][to] = cost;
        public void AddEdge(int from, int to) => data[from][to] = 1;

        public void AddEdgeBidirectional(int from, int to, int cost)
        {
            AddEdge(from, to, cost);
            AddEdge(to, from, cost);
        }
        public void AddEdgeBidirectional(int from, int to)
        {
            AddEdge(from, to);
            AddEdge(to, from);
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

        public int CountNeighbours(int node)
        {
            int count = 0;
            for (int i = 0; i < VertexCount; ++i)
                if (data[node][i] >= 0)
                    ++count;

            return count;
        }
        public void RemoveEdge(int from, int to) => data[from][to] = -1;
        public bool HasNeighbour(int nodeA, int nodeB) => data[nodeA][nodeB] >= 0;
        public IReadOnlyCollection<(int neighbour, int cost)> GetNeighbours(int node)
        {
            var neighbours = new List<(int neighbour, int cost)>();
            var row = data[node];

            for (int i = 0; i < VertexCount; ++i)
                if (row[i] >= 0)
                    neighbours.Add((i, row[i]));

            return neighbours;
        }
        IReadOnlyCollection<int> IGraphRepresentation.GetNeighbours(int node)
        {
            var neighbours = new List<int>();
            var row = data[node];

            for (int i = 0; i < VertexCount; ++i)
                if (row[i] >= 0)
                    neighbours.Add(i);

            return neighbours;
        }
    }
}
