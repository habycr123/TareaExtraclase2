using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TareaExtraclase2
{
    [TestClass]
    public class UnitTestProblema1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_MergeSorted_NullListA_ShouldThrowException()
        {
            ListaDoble listaA = null;
            ListaDoble listaB = new ListaDoble();
            listaB.InsertInOrder(5);

            listaB.MergeSorted(listaA, listaB, SortDirection.Asc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_MergeSorted_NullListB_ShouldThrowException()
        {
            ListaDoble listaA = new ListaDoble();
            listaA.InsertInOrder(5);
            ListaDoble listaB = null;

            listaA.MergeSorted(listaA, listaB, SortDirection.Asc);
        }

        [TestMethod]
        public void Test_MergeSorted_Asc()
        {
            ListaDoble listaA = new ListaDoble();
            listaA.InsertInOrder(0);
            listaA.InsertInOrder(2);
            listaA.InsertInOrder(6);
            listaA.InsertInOrder(10);
            listaA.InsertInOrder(25);

            ListaDoble listaB = new ListaDoble();
            listaB.InsertInOrder(3);
            listaB.InsertInOrder(7);
            listaB.InsertInOrder(11);
            listaB.InsertInOrder(40);
            listaB.InsertInOrder(50);

            listaA.MergeSorted(listaA, listaB, SortDirection.Asc);

            int[] expected = { 0, 2, 3, 6, 7, 10, 11, 25, 40, 50 };
            Nodo? current = listaA.Head;

            foreach (int value in expected)
            {
                Assert.AreEqual(value, current?.Value);
                current = current?.Next;
            }
        }

        [TestMethod]
        public void Test_MergeSorted_Desc()
        {
            ListaDoble listaA = new ListaDoble();
            listaA.InsertInOrder(10);
            listaA.InsertInOrder(15);

            ListaDoble listaB = new ListaDoble();
            listaB.InsertInOrder(9);
            listaB.InsertInOrder(40);
            listaB.InsertInOrder(50);

            listaA.MergeSorted(listaA, listaB, SortDirection.Desc);

            int[] expected = { 50, 40, 15, 10, 9 };
            Nodo? current = listaA.Head;

            foreach (int value in expected)
            {
                Assert.AreEqual(value, current?.Value);
                current = current?.Next;
            }
        }

        [TestMethod]
        public void Test_MergeSorted_EmptyList()
        {
            ListaDoble listaA = new ListaDoble();
            ListaDoble listaB = new ListaDoble();
            listaB.InsertInOrder(9);
            listaB.InsertInOrder(40);
            listaB.InsertInOrder(50);

            listaA.MergeSorted(listaA, listaB, SortDirection.Desc);

            int[] expected = { 50, 40, 9 };
            Nodo? current = listaA.Head;

            foreach (int value in expected)
            {
                Assert.AreEqual(value, current?.Value);
                current = current?.Next;
            }
        }

        [TestMethod]
        public void Test_MergeSorted_EmptyListB()
        {
            ListaDoble listaA = new ListaDoble();
            listaA.InsertInOrder(10);
            listaA.InsertInOrder(15);

            ListaDoble listaB = new ListaDoble();

            listaA.MergeSorted(listaA, listaB, SortDirection.Asc);

            int[] expected = { 10, 15 };
            Nodo? current = listaA.Head;

            foreach (int value in expected)
            {
                Assert.AreEqual(value, current?.Value);
                current = current?.Next;
            }
        }
    }
}
