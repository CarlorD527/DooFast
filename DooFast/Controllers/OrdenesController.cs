﻿using CapaEntidades;
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
            PedidoBl obj = new PedidoBl();
            _ = new List<PedidoBEforListCocina>();

            List<PedidoBEforListCocina> lstComidas = obj.listarPedidos();

            return lstComidas;
        }


        // GET: api/Ordenes/5
        public List<PedidoBEforListPorMesa> Get(int id)
        {
            PedidoBl obj = new PedidoBl();
            _ = new List<PedidoBEforListPorMesa>();

            List<PedidoBEforListPorMesa> comida = obj.listarOrdenPorMesa(id);

            return comida;
        }

        // POST: api/Ordenes
        public string Post(PedidoBe pedido)
        {
            string msg;

            PedidoBl obj = new PedidoBl();

            try
            {
                obj.Add(pedido);
                return msg = "Pedido registrado con exito";
            }
            catch (Exception ex)
            {
                return "Algo salio mal, verificar el body del POST!!";

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
