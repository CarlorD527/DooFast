using CapaEntidades;
using DooFast.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestDooFast.Controllers
{
    [TestClass]
    public class Ordenes
    {
        [TestMethod]
        public void GetOrdenesTest()
        {
            OrdenesController ordenes = new OrdenesController();

            var result = ordenes.Get();

            //test respuesta del servidor

            Assert.AreNotSame(ordenes, System.Net.HttpStatusCode.NotFound);
            //test listado
            Assert.AreNotSame(null, result);
        }
        [TestMethod]
        //[UrlToTest("https://localhost:44301/")
        public void GetOrdenTest()
        {
        
            OrdenesController orden = new OrdenesController(); 

            var result = orden.Get(1);
            //test respuesta del servidor

            Assert.AreNotSame(orden, System.Net.HttpStatusCode.NotFound);
            //test listado
            Assert.AreNotSame(null, result);

        }


        [TestMethod]
        //[UrlToTest("https://localhost:44301/")
        public void PostOrdenesTest()
        {

            OrdenesController orden = new OrdenesController();

            var pedidoObj = new PedidoBe();

            pedidoObj.idMesa = 2;
            pedidoObj.idComida = 7;
            pedidoObj.cantidad=10;
          

            var result = orden.Post(pedidoObj);

            Assert.AreSame("Pedido registrado con exito", result);

        }

    }
}
