using CapaEntidades;
using CapaEntidades.AuthEntities;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DooFast.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {
        // GET: api/Auth
        //public List<AuthBe> get()
        //{

        //}

        //// GET: api/Auth/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Auth
        public List<AuthBeList> Post(AuthBe auth)
        {
            AuthBl obj = new AuthBl();

            var rolUsuario = obj.listarRol(auth);

            return rolUsuario;
        }

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
