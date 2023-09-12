using PathfindingLib;

namespace PathfindingLibTests
{
    public class Tests
    {
        private AdjacencyList adjacencyList = new AdjacencyList(10);

        [SetUp]
        public void Setup()
        {
            adjacencyList.AddEdge(0, 1);
            adjacencyList.AddEdges(1, new int[] { 1, 2, 3 });
            adjacencyList.AddEdges(7, new int[] { 0, 2, 4 });
        }

        [Test]
        public void ValidConstructorParam()
        {
            Assert.That(new AdjacencyList(10).VertexCount, Is.EqualTo(10));
        }

        [Test]
        public void InvalidConstructorParam()
        {
            var exception = Assert.Catch<Exception>(() => new AdjacencyList(-10));
            Assert.That(exception, Is.Not.EqualTo(null));
        }

        [Test]
        public void ValidEdgeAdds()
        {
            bool isCorrectNumberNeighbours = true;
            int[] correctNumbers = { 1, 3, 0, 0, 0,
                                     0, 0, 3, 0, 0 };

            for (int i = 0; i < correctNumbers.Length; ++i)
            {
                if (adjacencyList.CountNeighbours(i) != correctNumbers[i])
                {
                    isCorrectNumberNeighbours = false;
                    break;
                }
            }
            Assert.That(isCorrectNumberNeighbours, Is.True);
        }

        [Test]
        public void ValidContains()
        {
            bool isCorrectContains = true;
            int[] nodesWithNeighbours = { 0, 1, 7 };
            int[] nNeighboursPerNode = { 1, 3, 3 };
            int[] neighbours = { 1,
                                 1, 2, 3,
                                 0, 2, 4 };

            int currentTestingNeighbourIndex = 0;
            for (int i = 0; i < nodesWithNeighbours.Length; ++i)
            {
                int nCurrentNodeNeighbours = nNeighboursPerNode[i];
                for (int j = 0; j < nCurrentNodeNeighbours; ++j)
                {
                    if (!adjacencyList.HasNeighbour(nodesWithNeighbours[i], neighbours[currentTestingNeighbourIndex]))
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