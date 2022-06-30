using Microsoft.VisualStudio.TestTools.UnitTesting;
using DooFast.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace DooFast.Controllers.Tests
{
    [TestClass]
    public class Comidas
    {

        [TestMethod()]
        //[UrlToTest("https://localhost:44301/")
        public void GetComidaTest()
        {
            ComidasController comidas = new ComidasController();

            var result = comidas.Get();

            //test respuesta del servidor

            Assert.AreNotSame(comidas, System.Net.HttpStatusCode.NotFound);
            //test listado
            Assert.AreNotSame(null, result);
        }

        [TestMethod]
        //[UrlToTest("https://localhost:44301/")
        public void PostComdiaTest() {


            ComidasController comidas = new ComidasController();

            ComidaBe comidaPrueba = new ComidaBe();

            comidaPrueba.idCategoria = 1;
            comidaPrueba.nombreComida = "Ensalada de cebolla";
            comidaPrueba.costo = 20;
            comidaPrueba.precio = 10;

            var result = comidas.Post(comidaPrueba);

            List<ComidaBEforList> lstComidasVacia = new List<ComidaBEforList>();
            
        
            Assert.AreSame("Comida registrada con exito!", result);

        }
    }
}