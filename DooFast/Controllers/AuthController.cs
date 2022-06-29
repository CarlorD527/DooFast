using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DooFast.Controllers
{
    public class AuthController : ApiController
    {
        // GET: api/Auth
        public List<AuthBe> Get(string usuario, string contrasenia)
        {
            AuthBl obj = new AuthBl();

            var rolUsuario = obj.listarRol(usuario, contrasenia);

            return rolUsuario;
        }

        //// GET: api/Auth/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Auth
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Auth/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Auth/5
        //public void Delete(int id)
        //{
        //}
    }
}
