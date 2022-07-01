﻿using CapaEntidades;
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
            public string Post(CartaBe Carta)
        {
            

            CartaBl obj = new CartaBl();

            try
            {
                obj.Add(Carta);
                return  "Carta registrada con exito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Algo salio mal, verificar el body del POST!!";
            }
        }

        // PUT: api/Carta
        public string Put(CartaBEforUpdate Carta)
        {
        

            CartaBl obj = new CartaBl();

            try
            {
                obj.Update(Carta);

                return  "Carta actualizada con exito!";
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return "Algo salio mal, verificar el body del PUT!!";

            }

        }

        // DELETE: api/Carta
        
        public string Delete(int id)
        {
           

            CartaBl obj = new CartaBl();

            try
            {
                obj.Delete(id);
                return "Carta eliminada con exito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Algo salio mal!";

            }
        }
        

    }
}
