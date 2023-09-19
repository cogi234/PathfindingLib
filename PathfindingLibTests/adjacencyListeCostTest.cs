using PathfindingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLibTests
{
    internal class adjacencyListeCostTest
    {
       
        private AdjacencyListCosts adjacencyListCosts = new AdjacencyListCosts(10);
        [SetUp]
        public void Setup()
        {
             

            adjacencyListCosts.AddEdgeBidirectional(0, 1, 1);
            adjacencyListCosts.AddEdgeBidirectional(0, 2, 1);
            adjacencyListCosts.AddEdgeBidirectional(1, 3, 1);
            adjacencyListCosts.AddEdgeBidirectional(2, 4, 1);
            adjacencyListCosts.AddEdgeBidirectional(2, 6, 1);
            adjacencyListCosts.AddEdgeBidirectional(3, 4, 1);
            adjacencyListCosts.AddEdgeBidirectional(3, 5, 1);
            adjacencyListCosts.AddEdgeBidirectional(4, 7, 1);
            adjacencyListCosts.AddEdgeBidirectional(4, 8, 1);
            adjacencyListCosts.AddEdgeBidirectional(5, 9, 1);
            adjacencyListCosts.AddEdgeBidirectional(6, 7, 1);
            adjacencyListCosts.AddEdgeBidirectional(7, 10, 1);
            
            adjacencyListCosts.AddEdgeBidirectional(8, 10, 1);
            adjacencyListCosts.AddEdgeBidirectional(9, 10, 1);
        }

        [Test]
        public void ValidConstructorParam()
        {
            Assert.That(new AdjacencyList(10).VertexCount, Is.EqualTo(10));
        }

        [Test]
        public void InvalidConstructorParam()
        {
            var exception = Assert.Catch<Exception>(() => new AdjacencyListCosts(-10));
            Assert.That(exception, Is.Not.EqualTo(null));
        }

        [Test]
        public void ValidEdgeAdds()
        {
            bool isCorrectNumberNeighbours = true;
            int[] correctNumbers = { 2, 2, 3, 3, 4,
                                     2, 2, 2, 2, 2,3 };

            for (int i = 0; i < correctNumbers.Length; ++i)
            {
                if (adjacencyListCosts.CountNeighbours(i) != correctNumbers[i])
                {
                    Console.WriteLine($"Invalid neighbour:{i}-- {adjacencyListCosts.CountNeighbours(i)},{correctNumbers[i]}");
                    isCorrectNumberNeighbours = false;
                    break;
                }
            }
            Assert.That(isCorrectNumberNeighbours, Is.True);
        }

        [Test]
        public void ValideGetNeighbour()
        {
            Console.WriteLine("allo");
            bool isCorrectContains = true;
            int[] nodesWithNeighbours = { 0, 1, 7 };
            int[] nNeighboursPerNode = { 2, 2, 3 };
            int[] neighbours = { 1,2,
                                 0, 3,
                                 4, 6, 10 };
            IEnumerable<(int neighbour, int cost)> data;
            int currentTestingNeighbourIndex = 0;
            for (int i = 0; i < nodesWithNeighbours.Length; ++i)
            {
                int nCurrentNodeNeighbours = nNeighboursPerNode[i];
                data  = adjacencyListCosts.GetNeighbours(nodesWithNeighbours[i]);
                for (int j = 0; j < data.Count(); ++j)
                {
                    
                    if (data.ElementAt(j).neighbour == neighbours[currentTestingNeighbourIndex])
                    {
                        Console.WriteLine($"Invalid neighbour: {data.ElementAt(j).neighbour},{neighbours[currentTestingNeighbourIndex]}");
                        isCorrectContains = false;
                        break;
                    }
                    ++currentTestingNeighbourIndex;
                }
            }
            Assert.That(isCorrectContains, Is.True);
        }
        [Test]
        public void ValidContains()
        {
            bool isCorrectContains = true;
            int[] nodesWithNeighbours = { 0, 1, 7 };
            int[] nNeighboursPerNode = { 2, 2, 3 };
            int[] neighbours = { 1,2,
                                 0, 3,
                                 4, 6, 10 };

            int currentTestingNeighbourIndex = 0;
            for (int i = 0; i < nodesWithNeighbours.Length; ++i)
            {
                int nCurrentNodeNeighbours = nNeighboursPerNode[i];
                for (int j = 0; j < nCurrentNodeNeighbours; ++j)
                {
                    if (!adjacencyListCosts.HasNeighbour(nodesWithNeighbours[i], neighbours[currentTestingNeighbourIndex]))
                    {
                        
                        isCorrectContains = false;
                        break;
                    }
                    ++currentTestingNeighbourIndex;
                }
            }
            Assert.That(isCorrectContains, Is.True);
        }
    }
}
