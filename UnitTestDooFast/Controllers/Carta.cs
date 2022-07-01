using CapaEntidades;
using DooFast.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestDooFast.Controllers
{
    [TestClass]
    public class Carta
    {
        [TestMethod]
        //[UrlToTest("https://localhost:44301/")
        public void PostCartaTest()
        {


            var carta = new CartaController();

            var cartaobj = new CartaBe();

            cartaobj.nombreCarta = "prueba";
            cartaobj.idRestaurante = 1;

            var result = carta.Post(cartaobj);

            Assert.AreSame("Carta registrada con exito!", result);

        }

        [TestMethod]
        //[UrlToTest("https://localhost:44301/")
        public void UpdateCartaTest()
        {

            var carta = new CartaController();

            var cartaobj = new CartaBEforUpdate();
            cartaobj.idCarta = 4;
            cartaobj.nombreCarta = "prueba";
            cartaobj.idRestaurante = 1;

            var result = carta.Put(cartaobj);

            Assert.AreSame("Carta actualizada con exito!", result);

        }
    }
}
