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
    public class ComidasController : ApiController
    {
      
        // GET: api/Comidas
        public List<List<ComidaBEforList>> Get()
        {
            ComidaBl obj = new ComidaBl();
            _ = new List<ComidaBEforList>();

            List<List<ComidaBEforList>> lstComidas = obj.listarComidas();

            return lstComidas;
        }

        // GET: api/Comidas/5
        public List<ComidaBEforList> Get(int id)
        {
            ComidaBl obj = new ComidaBl();
            _ = new List<ComidaBEforList>();

            List<ComidaBEforList> comida = obj.listarComida(id);

            return comida;
        }

        // POST: api/Comidas
        public string Post(ComidaBe comida)
        {
            

            ComidaBl obj = new ComidaBl();

            try
            {
                obj.Add(comida);
                return "Comida registrada con exito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Algo salio mal, verificar el body del POST!!";

            }
        }

        // PUT: api/Comidas/5
        public string Put(ComidaBEforUpdate comida)
        {
           

            ComidaBl obj = new ComidaBl();

            try
            {
                obj.Update(comida);

             
               
                return  "Comida actualizada con exito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Algo salio mal, verificar el body del PUT!!";

            
            }

        }

        // DELETE: api/Comidas/5
        public string Delete(int id)
        {
            

            ComidaBl obj = new ComidaBl();

            try
            {
                obj.Delete(id);
                return  "Comida eliminada con exito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Algo salio mal!";
            }
        }
    }
}
