using CapaEntidades;
using CapaNegocio;
using DooFast.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DooFastTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Get()
        {
            ComidaBL obj = new ComidaBL();
            List<ComidaBEforList> lstComidas = new List<ComidaBEforList>();

            var result = obj.listarComidas();
            Assert.AreEqual(15, result.Count());
        }
    }
}
