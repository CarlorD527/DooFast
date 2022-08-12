using CapaEntidades;
using CapaEntidades.PedidoBe;
using CapaEntidades.PedidoEntities;
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
    public class HistorialController : ApiController
    {
        /*
        // GET: api/HistorialPedidos
        public List<HistorialPedidoBE> Get()
        {
            HistorialBl obj = new HistorialBl();

            List<HistorialPedidoBE> lstHistorial = obj.listarHistorialPedidos();

            return lstHistorial;
        }

        // GET: api/HistorialPedidos
        public List<HistorialPedidoBE> Get(int anio)
        {
            HistorialBl obj = new HistorialBl();

            List<HistorialPedidoBE> lstHistorial = obj.listarHistorialAnio(anio);

            return lstHistorial;
        }*/

        // GET: api/HistorialPedidos
        public List<HistorialPedidoBE> Get(int mes, int anio)
        {
            HistorialBl obj = new HistorialBl();
            List<HistorialPedidoBE> lstHistorial;

            if (mes == -1)
            {
                if(anio == -1)
                {
                    //Listar todos los pedidos
                    lstHistorial = obj.listarHistorialPedidos();
                }
                else
                {
                    //Listar todos los pedidos de un año
                    lstHistorial = obj.listarHistorialAnio(anio);
                }
            }
            else
            {
                //Listar todos los pedidos de un mes
                lstHistorial = obj.listarHistorialMes(mes, anio);
            }

            return lstHistorial;
        }
    }
}
