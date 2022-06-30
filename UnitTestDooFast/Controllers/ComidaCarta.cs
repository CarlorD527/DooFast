using CapaEntidades;
using DooFast.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestDooFast.Controllers
{
    [TestClass]
    public class ComidaCarta
    {
        [TestMethod]
        //[UrlToTest("https://localhost:44301/")
        public void GetComidasCartaTest()
        {
            ComidaCartaController comidasCartas = new ComidaCartaController();

            var result = comidasCartas.Get();

            //test respuesta del servidor
            Assert.AreNotSame(comidasCartas, System.Net.HttpStatusCode.NotFound);
            //test listado
            Assert.AreNotSame(null, result);
        }
        [TestMethod]
        //[UrlToTest("https://localhost:44301/")

        public void PostComidaCartaTest()
        {


            ComidaCartaController comidasCartas = new ComidaCartaController();

            var comidaCartaObj = new CartaBEforComidaInsert();

            comidaCartaObj.idCarta= 1;
            comidaCartaObj.idComida= 19;


            var result = comidasCartas.Post(comidaCartaObj);

            Assert.AreNotSame(null, result);
            Assert.AreSame("Comida agregada a la carta con exito!", result);


        }
    }
}
