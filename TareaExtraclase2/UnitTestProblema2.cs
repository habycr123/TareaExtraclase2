using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TareaExtraclase2
{
    [TestClass]
    public class UnitTestProblema2
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Invert_NullList_ShouldThrowException()
        {
            ListaDoble lista = null;
            lista.Invert();
        }

        [TestMethod]
        public void Test_Invert_EmptyList()
        {
            ListaDoble lista = new ListaDoble();
            lista.Invert();

            Assert.IsNull(lista.Head);
            Assert.IsNull(lista.Tail);
        }

        [TestMethod]
        public void Test_Invert_SingleElement()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(2);

            lista.Invert();

            Assert.AreEqual(2, lista.Head?.Value);
            Assert.AreEqual(2, lista.Tail?.Value);
            Assert.IsNull(lista.Head?.Next);
            Assert.IsNull(lista.Tail?.Previous);
        }

        [TestMethod]
        public void Test_Invert_MultipleElements()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(1);
            lista.InsertInOrder(0);
            lista.InsertInOrder(30);
            lista.InsertInOrder(50);
            lista.InsertInOrder(2);

            lista.Invert();

            int[] expected = { 2, 50, 30, 0, 1 };
            Nodo? current = lista.Head;

            foreach (int value in expected)
            {
                Assert.AreEqual(value, current?.Value);
                current = current?.Next;
            }
        }
    }
}
