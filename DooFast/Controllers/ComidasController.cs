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
    public class ComidasController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/Comidas
        public List<ComidaBEforList> Get()
        {
            ComidaBL obj = new ComidaBL();
            List<ComidaBEforList> lstComidas= new List<ComidaBEforList>();

            lstComidas = obj.listarComidas();

            return lstComidas;
        }

        // GET: api/Comidas/5
        public List<ComidaBEforList> Get(int id)
        {
            ComidaBL obj = new ComidaBL();
            List<ComidaBEforList> comida = new List<ComidaBEforList>();

            comida = obj.listarComida(id);

            return comida;
        }

        // POST: api/Comidas
        public string Post(ComidaBE comida)
        {
            string msg;

            ComidaBL obj = new ComidaBL();

            try
            {
                obj.Add(comida);
                return msg = "Comida registrada con exito!";
            }
            catch (Exception ex)
            {
                return msg = "Algo salio mal, verificar el body del POST!!";

                throw ex;
            }
        }

        // PUT: api/Comidas/5
        public string Put(ComidaBEforUpdate comida)
        {
            string msg;

            ComidaBL obj = new ComidaBL();

            try
            {
                obj.Update(comida);

             
               
                return msg = "Comida actualizada con exito!";
            }
            catch (Exception ex)
            {
                return msg = "Algo salio mal, verificar el body del PUT!!";

                throw ex;
            }

        }

        // DELETE: api/Comidas/5
        public string Delete(int id)
        {
            string msg;

            ComidaBL obj = new ComidaBL();

            try
            {
                obj.Delete(id);
                return msg = "Comida eliminada con exito!";
            }
            catch (Exception ex)
            {
                return msg = "Algo salio mal!";

                throw ex;
            }
        }
    }
}
