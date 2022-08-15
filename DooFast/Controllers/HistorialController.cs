using CapaEntidades.PedidoEntities;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DooFast.Controllers
{
    public class HistorialController : ApiController
    {
        // GET: api/registros
        public List<List<HistorialBe>> Get()
        {
            HistorialBl obj = new HistorialBl();
            _ = new List<HistorialBe>();

            List<List<HistorialBe>> lstRegistros = obj.listarRegistros();

            return lstRegistros;
        }

        //// GET: api/Historial/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Historial
        //public void Post([FromBody]string value)
        //{

        //// DELETE: api/Historial/5
        //public void Delete(int id)
        //{
        //}

        // PUT: api/Historial/5
        public string Put(HistorialBeUpdate mesaBe)
        {
            if (new HistorialBl().Update(mesaBe))
                return "Orden pagada!";
            else
                return "Algo salio mal, verificar el body del PUT!!";
        }
    }
}
