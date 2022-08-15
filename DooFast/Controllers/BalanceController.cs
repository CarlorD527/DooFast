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
    public class BalanceController : ApiController
    {
        // GET: api/Balance
        //public List<BalanceBe> Get()
        //{
       
        //    return lstBalance;
        //}

        //// GET: api/Balance/5
        public List<BalanceBe> Get(int anio)
        {
            BalanceBl obj = new BalanceBl();
            _ = new List<BalanceBe>();

            List<BalanceBe> lstBalance = obj.listarBalance(anio);

            return lstBalance;
        }

        //// POST: api/Balance
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Balance/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Balance/5
        //public void Delete(int id)
        //{
    }

}
