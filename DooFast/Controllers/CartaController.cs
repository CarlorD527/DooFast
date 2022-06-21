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
using System.Web.Http.Cors;

namespace DooFast.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CartaController : ApiController
    {
        // GET: api/Carta
        public List<List<ComidaBEforList>> Get()
        {
            List<List<ComidaBEforList>> lstProductos = new List<List<ComidaBEforList>>();

            ComidaBL obj = new ComidaBL();
            _ = new List<ComidaBEforList>();
            List<ComidaBEforList> lstEntradas = obj.listarEntradas();
            _ = new List<ComidaBEforList>();

            List<ComidaBEforList> lstSegundos = obj.listarSegundos();
            _ = new List<ComidaBEforList>();
            List<ComidaBEforList> lstBebidas = obj.listarBebidas();
            _ = new List<ComidaBEforList>();
            List<ComidaBEforList> lstPostres = obj.listarPostres();

            lstProductos.Add(lstEntradas);
            lstProductos.Add(lstSegundos);
            lstProductos.Add(lstBebidas);
            lstProductos.Add(lstPostres);

            return lstProductos;
        }
        //    // GET: api/Carta/5
        //    /*public string Get(int id)
        //    {
        //        return "value";
        //    }

        //    // POST: api/Carta
        //    public void Post([FromBody]string value)
        //    {
        //    }

        //    // PUT: api/Carta/5
        //    public void Put(int id, [FromBody]string value)
        //    {
        //    }

        //    // DELETE: api/Carta/5
        //    public void Delete(int id)
        //    {
        //    }*/
    }
}
