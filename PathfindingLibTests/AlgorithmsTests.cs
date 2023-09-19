using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PathfindingLib;

namespace PathfindingLibTests
{
    public class AlgorithmsTests
    {
        Vector2[] positions = new Vector2[11];
        AdjacencyListCosts adjacencyListCosts = new AdjacencyListCosts(11);
        AdjacencyMatrixCosts adjacencyMatrixCosts = new AdjacencyMatrixCosts(11);
        AdjacencyList adjacencyList = new AdjacencyList(11);
        AdjacencyMatrix adjacencyMatrix = new AdjacencyMatrix(11);
        List<int> correctPathCosts = new List<int>();
        int correctPathLength = 5; //0 - 2 - 4 - 7 - 10 ou  1 - 2 - 4 - 8 - 10

        private int Distance(int p1, int p2)
        {
            return (int)Vector2.Distance(positions[p1], positions[p2]);
        }

        [SetUp]
        public void Setup()
        {
            //Setup the map
            positions[0] = new Vector2(0, 0);
            positions[1] = new Vector2(15, 20);
            positions[2] = new Vector2(20, -10);
            positions[3] = new Vector2(30, 15);
            positions[4] = new Vector2(45, 0);
            positions[5] = new Vector2(60, 25);
            positions[6] = new Vector2(40, -20);
            positions[7] = new Vector2(75, -25);
            positions[8] = new Vector2(80, 15);
            positions[9] = new Vector2(100, 30);
            positions[10] = new Vector2(90, 0);

            adjacencyListCosts.AddEdgeBidirectional(0, 1, Distance(0, 1));
            adjacencyListCosts.AddEdgeBidirectional(0, 2, Distance(0, 2));
            adjacencyListCosts.AddEdgeBidirectional(1, 3, Distance(1, 3));
            adjacencyListCosts.AddEdgeBidirectional(2, 4, Distance(2, 4));
            adjacencyListCosts.AddEdgeBidirectional(2, 6, Distance(2, 6));
            adjacencyListCosts.AddEdgeBidirectional(3, 4, Distance(3, 4));
            adjacencyListCosts.AddEdgeBidirectional(3, 5, Distance(3, 5));
            adjacencyListCosts.AddEdgeBidirectional(4, 7, Distance(4, 7));
            adjacencyListCosts.AddEdgeBidirectional(4, 8, Distance(4, 8));
            adjacencyListCosts.AddEdgeBidirectional(5, 9, Distance(5, 9));
            adjacencyListCosts.AddEdgeBidirectional(6, 7, Distance(6, 7));
            adjacencyListCosts.AddEdgeBidirectional(7, 10, Distance(7, 10));
            adjacencyListCosts.AddEdgeBidirectional(8, 10, Distance(8, 10));
            adjacencyListCosts.AddEdgeBidirectional(9, 10, Distance(9, 10));

            adjacencyMatrixCosts.AddEdgeBidirectional(0, 1, Distance(0, 1));
            adjacencyMatrixCosts.AddEdgeBidirectional(0, 2, Distance(0, 2));
            adjacencyMatrixCosts.AddEdgeBidirectional(1, 3, Distance(1, 3));
            adjacencyMatrixCosts.AddEdgeBidirectional(2, 4, Distance(2, 4));
            adjacencyMatrixCosts.AddEdgeBidirectional(2, 6, Distance(2, 6));
            adjacencyMatrixCosts.AddEdgeBidirectional(3, 4, Distance(3, 4));
            adjacencyMatrixCosts.AddEdgeBidirectional(3, 5, Distance(3, 5));
            adjacencyMatrixCosts.AddEdgeBidirectional(4, 7, Distance(4, 7));
            adjacencyMatrixCosts.AddEdgeBidirectional(4, 8, Distance(4, 8));
            adjacencyMatrixCosts.AddEdgeBidirectional(5, 9, Distance(5, 9));
            adjacencyMatrixCosts.AddEdgeBidirectional(6, 7, Distance(6, 7));
            adjacencyMatrixCosts.AddEdgeBidirectional(7, 10, Distance(7, 10));
            adjacencyMatrixCosts.AddEdgeBidirectional(8, 10, Distance(8, 10));
            adjacencyMatrixCosts.AddEdgeBidirectional(9, 10, Distance(9, 10));

            adjacencyList.AddEdgeBidirectional(0, 1);
            adjacencyList.AddEdgeBidirectional(0, 2);
            adjacencyList.AddEdgeBidirectional(1, 3);
            adjacencyList.AddEdgeBidirectional(2, 4);
            adjacencyList.AddEdgeBidirectional(2, 6);
            adjacencyList.AddEdgeBidirectional(3, 4);
            adjacencyList.AddEdgeBidirectional(3, 5);
            adjacencyList.AddEdgeBidirectional(4, 7);
            adjacencyList.AddEdgeBidirectional(4, 8);
            adjacencyList.AddEdgeBidirectional(5, 9);
            adjacencyList.AddEdgeBidirectional(6, 7);
            adjacencyList.AddEdgeBidirectional(7, 10);
            adjacencyList.AddEdgeBidirectional(8, 10);
            adjacencyList.AddEdgeBidirectional(9, 10);

            adjacencyMatrix.AddEdgeBidirectional(0, 1);
            adjacencyMatrix.AddEdgeBidirectional(0, 2);
            adjacencyMatrix.AddEdgeBidirectional(1, 3);
            adjacencyMatrix.AddEdgeBidirectional(2, 4);
            adjacencyMatrix.AddEdgeBidirectional(2, 6);
            adjacencyMatrix.AddEdgeBidirectional(3, 4);
            adjacencyMatrix.AddEdgeBidirectional(3, 5);
            adjacencyMatrix.AddEdgeBidirectional(4, 7);
            adjacencyMatrix.AddEdgeBidirectional(4, 8);
            adjacencyMatrix.AddEdgeBidirectional(5, 9);
            adjacencyMatrix.AddEdgeBidirectional(6, 7);
            adjacencyMatrix.AddEdgeBidirectional(7, 10);
            adjacencyMatrix.AddEdgeBidirectional(8, 10);
            adjacencyMatrix.AddEdgeBidirectional(9, 10);

            correctPathCosts.AddRange(new int[] { 0, 2, 4, 8, 10 });
        }

        [Test]
        public void ValidAdjacencyListBFSPath()
        {
            List<int> foundPath = Algorithms.BFS(adjacencyList, 0, 10);
            for (int i = 0; i < foundPath.Count; i++)
            {
                Console.WriteLine($"{foundPath[i]}");
            }

            Assert.That(foundPath.Count, Is.EqualTo(correctPathLength));
        }

        [Test]
        public void ValidAdjacencyMatrixBFSPath()
        {
            List<int> foundPath = Algorithms.BFS(adjacencyMatrix, 0, 10);
            for (int i = 0; i < foundPath.Count; i++)
            {
                Console.WriteLine($"{foundPath[i]}");
            }

            Assert.That(foundPath.Count, Is.EqualTo(correctPathLength));
        }

        [Test]

        public void ValidAdjacencyListCostsDijkstraPath()
        {
            List<int> foundPath = Algorithms.Dijkstra(adjacencyListCosts, 0, 10);
            bool pathIsEqual = true;

            for (int i = 0; i < foundPath.Count; i++)
            {
                Console.WriteLine($"Expected: {foundPath[i]} \t\tResult: {correctPathCosts[i]}");
                if (foundPath[i] != correctPathCosts[i])
                    pathIsEqual = false;
            }

            Assert.IsTrue(pathIsEqual);
        }

        [Test]
        public void ValidAdjacencyMatrixCostsDijkstraPath()
        {
            List<int> foundPath = Algorithms.Dijkstra(adjacencyMatrixCosts, 0, 10);
            bool pathIsEqual = true;

            for (int i = 0; i < foundPath.Count; i++)
            {
                Console.WriteLine($"Expected: {foundPath[i]} \t\tResult: {correctPathCosts[i]}");
                if (foundPath[i] != correctPathCosts[i])
                    pathIsEqual = false;
            }

            Assert.IsTrue(pathIsEqual);
        }

        [Test]
        public void ValidAdjacencyListCostsAStarPath()
        {
            List<int> foundPath = Algorithms.AStar(Distance, adjacencyListCosts, 0, 10);
            bool pathIsEqual = true;

            for (int i = 0; i < foundPath.Count; i++)
            {
                Console.WriteLine($"Expected: {foundPath[i]} \t\tResult: {correctPathCosts[i]}");
                if (foundPath[i] != correctPathCosts[i])
                    pathIsEqual = false;
            }

            Assert.IsTrue(pathIsEqual);
        }

        [Test]
        public void ValidAdjacencyMatrixCostsAStarPath()
        {
            List<int> foundPath = Algorithms.AStar(Distance, adjacencyMatrixCosts, 0, 10);
            bool pathIsEqual = true;

            for (int i = 0; i < foundPath.Count; i++)
            {
                Console.WriteLine($"Expected: {foundPath[i]} \t\tResult: {correctPathCosts[i]}");
                if (foundPath[i] != correctPathCosts[i])
                    pathIsEqual = false;
            }

            Assert.IsTrue(pathIsEqual);
        }
    }
}
