using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaNegocio;
using Newtonsoft.Json;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace DooFast.Controllers
{
    public class MenuController : ApiController
    {
        // GET: api/Menu
        public List<List<ProductoBE>> Get()
        {
            List<List<ProductoBE>> lstProductos= new List<List<ProductoBE>>();

            ProductoBL obj = new ProductoBL();
            List<ProductoBE> lstEntradas = new List<ProductoBE>();
            lstEntradas = obj.listarEntradas();

            List<ProductoBE> lstSegundos = new List<ProductoBE>();
            lstSegundos = obj.listarSegundos();

            List<ProductoBE> lstBebidas = new List<ProductoBE>();
            lstBebidas = obj.listarBebidas();

            List<ProductoBE> lstPostres = new List<ProductoBE>();
            lstPostres = obj.listarPostres();

            lstProductos.Add(lstEntradas);
            lstProductos.Add(lstSegundos);
            lstProductos.Add(lstBebidas);
            lstProductos.Add(lstPostres);

            return lstProductos;
        }
        // GET: api/Menu/5
        /*public string Get(int id)
        {
            return "value";
        }

        // POST: api/Menu
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Menu/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Menu/5
        public void Delete(int id)
        {
        }*/
    }
}
