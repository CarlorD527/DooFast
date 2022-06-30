using CapaEntidades;
using DooFast.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestDooFast.Controllers
{
    [TestClass]
    public class Auth
    {
        [TestMethod]
        public void TestAutenticacion()
        {
            //CREDENCIALES
            string correo = "admin@doofast.com";
            string contrasenia = "admin";

            var auth = new AuthController();
            var authObjeto = new AuthBe();


            authObjeto.correo = correo;
            authObjeto.contrasenia = contrasenia;
          

            var result =auth.Post(authObjeto);

            //test respuesta del servidor
            Assert.AreNotSame(auth, System.Net.HttpStatusCode.NotFound);
            //test listado
            Assert.AreNotSame(null, result);
        }
    }
}
