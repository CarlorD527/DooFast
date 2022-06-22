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
    public class ComidaCartaController : ApiController
    {
        //// GET: api/ComidaCarta
        public List<List<ComidaBEforList>> Get()
        {

            //int IdCarta, luego se pondrá como parametro para obtener cualquier carta
            ComidaCartaBL obj = new ComidaCartaBL();
            _ = new List<ComidaBEforList>();

            //De momento se pasa 1 porque trabajaremos con la primera carta
            List<List<ComidaBEforList>> lstComidasCarta = obj.listarComidaCarta(1);
            return lstComidasCarta;
        }

        // POST: api/ComidaCarta
        public string Post(CartaBEforComidaInsert Carta)
        {
            string msg;

            ComidaCartaBL obj = new ComidaCartaBL();

            try
            {
                obj.AddComidaCarta(Carta);
                return msg = "Como agregada a la carta con exito!";
            }
            catch (Exception ex)
            {
                return "Algo salio mal, verificar el body del POST!!";

                throw ex;
            }
        }

        //// PUT: api/ComidaCarta/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ComidaCarta/5
        //public void Delete(int id)
        //{
        //}
    }
}
