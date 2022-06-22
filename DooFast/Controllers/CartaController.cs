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
      
        // POST: api/Carta
            public string Post(CartaBE Carta)
        {
            string msg;

            CartaBL obj = new CartaBL();

            try
            {
                obj.Add(Carta);
                return msg = "Carta registrada con exito!";
            }
            catch (Exception ex)
            {
                return "Algo salio mal, verificar el body del POST!!";

                throw ex;
            }
        }

        // PUT: api/Carta
        public string Put(CartaBEforUpdate Carta)
        {
            string msg;

            CartaBL obj = new CartaBL();

            try
            {
                obj.Update(Carta);

                return msg = "Carta actualizada con exito!";
            }
            catch (Exception ex)
            {
                return "Algo salio mal, verificar el body del PUT!!";

                throw ex;
            }

        }

        // DELETE: api/Carta
        
        public string Delete(int id)
        {
            string msg;

            CartaBL obj = new CartaBL();

            try
            {
                obj.Delete(id);
                return msg = "Carta eliminada con exito!";
            }
            catch (Exception ex)
            {
                return "Algo salio mal!";

                throw ex;
            }
        }
        

    }
}
