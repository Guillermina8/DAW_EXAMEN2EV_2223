using LotoClassNS;
using System.Collections.Generic;

namespace LotoTest
{
    [TestClass]
    public class LotoTest
    {
        public LotoTest()
        {
            [TestMethod]

            public void CombinacionValida()
            {
                int[] listaNumeros = new int[];


                listaNumeros.Add(1);
                listaNumeros.Add(2);
                listaNumeros.Add(3);
                listaNumeros.Add(4);
                listaNumeros.Add(25);
                listaNumeros.Add(49);

                LotoGP2223 listado = new LotoGP2223(listaNumeros);
                listado.Comprobar();

                Assert.IsTrue(listado);


            }

            [TestMethod]

            [ExpectedException(typeof(ArgumentException))]  

            public void CombinacionCeroNoValida()
            {
                list<int> listaNumeros = new list<int>;

                listaNumeros.Add(0);
                listaNumeros.Add(1);
                listaNumeros.Add(2);
                listaNumeros.Add(3);
                listaNumeros.Add(4);
                listaNumeros.Add(25);
                LotoGP2223 listado = new LotoGP2223(listaNumeros);

                listado.Comprobar();
                Assert.IsFalse(listado);
            }
            [TestMethod]

            [ExpectedException(typeof(ArgumentException))]

            public void CombinacionMayorNoValida()
            {
                list<int> listaNumeros = new list<int>;

                listaNumeros.Add(50);
                listaNumeros.Add(1);
                listaNumeros.Add(2);
                listaNumeros.Add(3);
                listaNumeros.Add(4);
                listaNumeros.Add(25);
                LotoGP2223 listado = new LotoGP2223(listaNumeros);

                listado.Comprobar();
                Assert.IsFalse(listado);
            }
        }