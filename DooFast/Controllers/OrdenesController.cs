using CapaEntidades;
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
    public class OrdenesController : ApiController
    {
        // GET: api/Ordenes
        public List<PedidoBEforListCocina> Get()
        {
            PedidoBL obj = new PedidoBL();
            List<PedidoBEforListCocina> lstComidas = new List<PedidoBEforListCocina>();

            lstComidas = obj.listarPedidos();

            return lstComidas;
        }


        // GET: api/Ordenes/5
        public List<PedidoBEforListPorMesa> Get(int id)
        {
            PedidoBL obj = new PedidoBL();

            List<PedidoBEforListPorMesa> comida = new List<PedidoBEforListPorMesa>();

            comida = obj.listarOrdenPorMesa(id);

            return comida;
        }

        // POST: api/Ordenes
        public string Post(PedidoBE pedido)
        {
            string msg;

            PedidoBL obj = new PedidoBL();

            try
            {
                obj.Add(pedido);
                return msg = "Pedido registrado con exito";
            }
            catch (Exception ex)
            {
                return msg = "Algo salio mal, verificar el body del POST!!";

                throw ex;
            }
        }

        //// PUT: api/Ordenes/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Ordenes/5
        //public void Delete(int id)
        //{
        //}
    }
}
