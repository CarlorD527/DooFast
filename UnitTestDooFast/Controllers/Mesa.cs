using CapaEntidades.MesaEntities;
using DooFast.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDooFast.Controllers
{

    [TestClass]
    public class Mesa
    {
        [TestMethod()]
        //[UrlToTest("https://localhost:44301/")
        public void GetMesasTest()
        {
            MesaController  mesas = new MesaController();

            var result = mesas.Get();

            //test respuesta del servidor

            Assert.AreNotSame(mesas, System.Net.HttpStatusCode.NotFound);
            //test listado
            Assert.AreNotSame(null, result);
        }

        [TestMethod]
        //[UrlToTest("https://localhost:44301/")
        public void PostMesas()
        {

            MesaController mesaController = new MesaController();

            var mesa = new MesaBePost();

            mesa.nroMesa = 4;
            mesa.idRestaurante = 1;
            var result = mesaController.Post(mesa);

            Assert.AreSame("Mesa registrada con exito!", result);

        }

    }
}
