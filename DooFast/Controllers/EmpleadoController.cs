using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using CapaNegocio;
using System.Web.Http.Cors;

namespace DooFast.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpleadoController : ApiController
    {

        /*  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
          // GET: api/Empleado
          public List<EmpleadoBE> Get()
          {
              EmpleadoBL obj = new EmpleadoBL();
              List<EmpleadoBE> lstEmpleado = new List<EmpleadoBE>();

              lstEmpleado = obj.listarEmpleados();

              return  lstEmpleado;
          }

          //// GET: api/Empleado/5
          //public string Get(int id)
          //{
          //    return "value";
          //}

          // POST: api/Empleado
          public string Post(EmpleadoBE empleado)
          {
              string msg;

              EmpleadoBL obj = new EmpleadoBL();

              try
              {
                  obj.Add(empleado);
                  return msg = "Empleado registrado con exito!";
              }
              catch (Exception ex)
              {
                  return msg = "Solo enviar nombre y tipo de empleado!!";

                  throw ex;
              }

          }
         */
        //// PUT: api/Empleado/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Empleado/5
        //public void Delete(int id)
        //{

    }
}
