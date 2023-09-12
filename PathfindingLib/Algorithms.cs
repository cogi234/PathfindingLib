using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
