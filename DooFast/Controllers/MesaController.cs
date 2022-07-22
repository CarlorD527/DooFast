using CapaEntidades.MesaEntities;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DooFast.Controllers
{
    public class MesaController : ApiController
    {
        // GET: api/Mesa
        public List<MesaBE> Get()
        {
            MesaBl obj = new MesaBl();
            _ = new List<MesaBE>();

            List<MesaBE> mesas = obj.listarMesas();

            return mesas;
        }

        //// GET: api/Mesa/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Mesa
        public string Post(MesaBePost mesabe)
        {

            MesaBl obj = new MesaBl();

            try
            {
                obj.Add(mesabe);

                return "Mesa registrada con exito!";
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);


                return "Algo salio mal";


            }
        }

        //// PUT: api/Mesa/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Mesa/5
        public string Delete(int id)
        {
            if (id > 0)
            {
                if (new MesaBl().Delete(id))

                    return "Mesa eliminada con exito!";
                else
                    return "Algo salio mal!!";
            }
            else {

                return "ingrese un id valido!";
            }
         
        }

    }
}
