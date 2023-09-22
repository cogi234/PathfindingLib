/*author: William Bégin
 *but: test the big code
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingLibTests
{
    public class AdjacencyMatrixCostTests
    {
        [Test]
        public void AddEdgeTest()
        {
            AdjacencyMatrixCosts matrixCost = new AdjacencyMatrixCosts(12);
            matrixCost.AddEdge(1, 2, 69);//le chiffre chanceux

            Assert.IsTrue(matrixCost.HasNeighbour(1, 2));
        }

        [Test]
        public void RemoveEdgeTest()
        {
            AdjacencyMatrixCosts matrixCost = new AdjacencyMatrixCosts(12);
            matrixCost.AddEdge(1, 2, 69);//le chiffre chanceux
            matrixCost.RemoveEdge(1, 2);

            Assert.IsFalse(matrixCost.HasNeighbour(1, 2));
        }

        [Test]
        public void VertexCountTest()
        {
            int nbVertex = 12;
            AdjacencyMatrixCosts matrixCost = new AdjacencyMatrixCosts(nbVertex);
            Assert.IsTrue(matrixCost.VertexCount == nbVertex);
        }

        [Test]
        public void NeighboursTest()
        {
            AdjacencyMatrixCosts matrixCost = new AdjacencyMatrixCosts(12);
            matrixCost.AddEdge(1, 3, 4);
            matrixCost.AddEdgeBidirectional(4, 1, 3);
            matrixCost.AddEdge(1, 7, 1);
            Assert.IsTrue(matrixCost.CountNeighbours(1) == 3);
        }

        [Test]
        public void AddEdgeBidirectionalTest()
        {
            AdjacencyMatrixCosts matrixCost = new AdjacencyMatrixCosts(12);
            matrixCost.AddEdgeBidirectional(1, 4, 5);
            Assert.IsTrue(matrixCost.HasNeighbour(1, 4) && matrixCost.HasNeighbour(4, 1));
        }
    }
}
