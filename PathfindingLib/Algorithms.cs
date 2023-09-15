using System;
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

            PriorityQueue<int, int> frontier = new PriorityQueue<int,int>();
            int[] cameFrom = new int[graph.VertexCount];
            int[] costSoFar = new int[graph.VertexCount];

            Array.Fill(cameFrom, -1);
            Array.Fill(costSoFar, int.MaxValue);
            frontier.Enqueue(startNode, 0);
            costSoFar[startNode] = 0;

            while (frontier.Count > 0)
            {
                int current = frontier.Dequeue();
                IEnumerable<(int neighbour, int cost)> currentNeighbours = graph.GetNeighbours(current);

                if (current == endNode)
                    return BuildShortestPath(startNode, endNode, cameFrom);

                for (int i = 0; i < currentNeighbours.Count(); ++i)
                {
                    (int neighbour, int cost) next = currentNeighbours.ElementAt(i);
                    int newCost = costSoFar[current] + next.cost;

                    if (costSoFar[next.neighbour] > newCost)
                    {
                        costSoFar[next.neighbour] = newCost;
                        frontier.Enqueue(next.neighbour, newCost);
                        cameFrom[next.neighbour] = current;
                    }
                }
            }

            return new List<int>();
        }

        public static List<int> AStar(Func<int, int, int> funcky, IWeightedGraphRepresentation graph, int startNode, int endNode)
        {
            if (startNode == endNode)
                return new List<int>() { startNode };

            PriorityQueue<int, int> frontier = new PriorityQueue<int, int>();
            int[] cameFrom = new int[graph.VertexCount];
            int[] costSoFar = new int[graph.VertexCount];

            Array.Fill(cameFrom, -1);
            Array.Fill(costSoFar, int.MaxValue);
            frontier.Enqueue(startNode, 0);
            costSoFar[startNode] = 0;

            while (frontier.Count > 0)
            {
                int current = frontier.Dequeue();
                IEnumerable<(int neighbour, int cost)> currentNeighbours = graph.GetNeighbours(current);

                if (current == endNode)
                    return BuildShortestPath(startNode, endNode, cameFrom);

                for (int i = 0; i < currentNeighbours.Count(); ++i)
                {
                    (int neighbour, int cost) next = currentNeighbours.ElementAt(i);
                    int newCost = costSoFar[current] + next.cost;

                    if (costSoFar[next.neighbour] > newCost)
                    {
                        costSoFar[next.neighbour] = newCost;
                        frontier.Enqueue(next.neighbour, newCost + funcky(endNode,current));
                        cameFrom[next.neighbour] = current;
                    }
                }
            }

            return new List<int>();
        }
    }
}
