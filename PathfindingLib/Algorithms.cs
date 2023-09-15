﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PathfindingLib
{
    public static class Algorithms
    {
        public static List<int> BFS(IGraphRepresentation graph, int startNode, int endNode)
        {
            if (startNode == endNode)
                return new List<int>() { startNode };

            var frontier = new Queue<int>();
            var cameFrom = new int[graph.VertexCount];
            Array.Fill(cameFrom, -1);

            frontier.Enqueue(startNode);

            while (frontier.Count > 0)
            {
                int current = frontier.Dequeue();
                IEnumerable<int> currentNeighbours = graph.GetNeighbours(current);

                for (int i = 0; i < currentNeighbours.Count(); ++i)
                {
                    int next = currentNeighbours.ElementAt(i);

                    if (next == endNode)
                    {
                        cameFrom[next] = current;
                        return BuildShortestPath(startNode, endNode, cameFrom);
                    }

                    if (cameFrom[next] == -1)
                    {
                        frontier.Enqueue(next);
                        cameFrom[next] = current;
                    }
                }
            }

            return new List<int>();
        }

        private static List<int> BuildShortestPath(int startNode, int endNode, int[] cameFrom)
        {
            int current = endNode;
            var shortestPath = new List<int>();

            while (current != startNode)
            {
                shortestPath.Add(current);
                current = cameFrom[current];
            }
            shortestPath.Add(startNode);
            shortestPath.Reverse();
            return shortestPath;
        }

        public static List<int> Dijkstra(IWeightedGraphRepresentation graph, int startNode, int endNode)
        {
            if (startNode == endNode)
                return new List<int>() { startNode };
            var cost_so_far = new int[graph.VertexCount];
            cost_so_far[startNode] = 0;
            var frontier = new PriorityQueue<int,int>();
            var cameFrom = new int[graph.VertexCount];
            Array.Fill(cameFrom, -1);

            frontier.Enqueue(startNode, 0);

            while (frontier.Count > 0)
            {
                int current = frontier.Dequeue();
                IEnumerable<(int neighbour, int cost)> currentNeighbours = graph.GetNeighbours(current);

                for (int i = 0; i < currentNeighbours.Count(); ++i)
                {
                    (int,int) next = currentNeighbours.ElementAt(i);

                    if (next.Item1 == endNode)
                    {

                        cameFrom[next.Item1] = current;
                        return BuildShortestPath(startNode, endNode, cameFrom);
                    }

                    if (cameFrom[next.Item1] == -1)
                    {
                        cost_so_far[next.Item1] = cost_so_far[next.Item1]+next.Item2;
                        frontier.Enqueue(next.Item1,next.Item2 + cost_so_far[next.Item1]);
                        cameFrom[next.Item1] = current;
                    }
                }
            }

            return new List<int>();
        }

        public static List<int> AStar(Func<int, int, int> funcky, IWeightedGraphRepresentation graph, int startNode, int endNode)
        {
            if (startNode == endNode)
                return new List<int>() { startNode };
            var cost_so_far = new int[graph.VertexCount];
            cost_so_far[startNode] = 0;
            var frontier = new PriorityQueue<int, int>();
            var cameFrom = new int[graph.VertexCount];
            Array.Fill(cameFrom, -1);

            frontier.Enqueue(startNode, 0);

            while (frontier.Count > 0)
            {
                int current = frontier.Dequeue();
                IEnumerable<(int neighbour, int cost)> currentNeighbours = graph.GetNeighbours(current);

                for (int i = 0; i < currentNeighbours.Count(); ++i)
                {
                    (int neightbour, int cout) next = currentNeighbours.ElementAt(i);

                    if (next.Item1 == endNode)
                    {

                        cameFrom[next.Item1] = current;
                        return BuildShortestPath(startNode, endNode, cameFrom);
                    }

                    if (cameFrom[next.Item1] == -1)
                    {
                        cost_so_far[next.Item1] = cost_so_far[next.Item1] + next.Item2;
                        frontier.Enqueue(next.Item1, next.Item2 + cost_so_far[next.Item1]);
                        cameFrom[next.Item1] = current;
                    }
                }
            }

            return new List<int>();
        }
    }
}
