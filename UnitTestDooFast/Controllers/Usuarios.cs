using CapaAccesoDatos;
using CapaEntidades;
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
        [TestMethod]
        //[UrlToTest("https://localhost:44301/")
        public void PostCartaTest()
        {


            var usuario = new UsuariosController();

            var obj = new UsuarioBe();
            obj.contrasenia = "123456789";
            obj.contrasenia = DalUtil.GetSHA256(obj.contrasenia);

            obj.idRestaurante = 1;
            obj.idRol= 1;
            obj.usuario = "testUnit";
            obj.nombreUsuario = "Prueba Unitaria";
            obj.nroCelular = "924251711";
            obj.correoElectronico = "pruebaunitaria@gmail.com";

            var result = usuario.Post(obj);

            Assert.AreSame("Usuario registrado con exito!", result);

        }
    }
}
