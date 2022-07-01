using DooFast.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestDooFast.Controllers
{
    [TestClass]
    public class Usuarios
    {
        [TestMethod]
        public void GetUsuariosTest()
        {
            var usuariosController = new UsuariosController();

            var result = usuariosController.Get();

            //test respuesta del servidor

            Assert.AreNotSame(usuariosController, System.Net.HttpStatusCode.NotFound);
            //test listado
            Assert.AreNotSame(null, result);
        }
        
        [TestMethod]
        //[UrlToTest("https://localhost:44301/")
        public void GetUsuarioTest()
        {
            int idUsuario;

            var usuarioController = new UsuariosController();

            idUsuario = 1;

            var result = usuarioController.Get(idUsuario);
            //test respuesta del servidor

            Assert.AreNotSame(usuarioController, System.Net.HttpStatusCode.NotFound);
            //test listado
            Assert.AreNotSame(null, result);

        }
    }
}
