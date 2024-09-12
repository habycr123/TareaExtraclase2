using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TareaExtraclase2
{
    [TestClass]
    public class UnitTestProblema3
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_GetMiddle_NullList_ShouldThrowException()
        {
            ListaDoble lista = new ListaDoble();
            lista.GetMiddle(); // Debería lanzar excepción
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_GetMiddle_EmptyList_ShouldThrowException()
        {
            ListaDoble lista = new ListaDoble();
            lista.GetMiddle(); // Debería lanzar excepción
        }

        [TestMethod]
        public void Test_GetMiddle_SingleElement()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(1);

            int middle = lista.GetMiddle();
            Assert.AreEqual(1, middle);
        }

        [TestMethod]
        public void Test_GetMiddle_TwoElements()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);

            int middle = lista.GetMiddle();
            Assert.AreEqual(2, middle); // El elemento central es el segundo
        }

        [TestMethod]
        public void Test_GetMiddle_OddNumberOfElements()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            int middle = lista.GetMiddle();
            Assert.AreEqual(2, middle); // El elemento central es 2
        }

        [TestMethod]
        public void Test_GetMiddle_EvenNumberOfElements()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);
            lista.InsertInOrder(4);

            int middle = lista.GetMiddle();
            Assert.AreEqual(3, middle); // El elemento central es 3 (segundo de la segunda mitad)
        }
    }
}
