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

        //PUT: api/HistorialPedidos
        public string Put(HistorialPedidoBEforUpdate historial)
        {
            if (new HistorialBl().Update(historial))
                return "Estado del historial de pedido cambiado con exito!";
            else
                return "Algo salio mal, verificar el body del PUT!!";
        }

        // GET: api/HistorialPedidos
        public List<HistorialPedidoBE> Get(int dia, int mes, int anio)
        {
            HistorialBl obj = new HistorialBl();
            List<HistorialPedidoBE> lstHistorial;

            if(dia == -1) //Dia no especificado
            {
                if (mes == -1) //Mes no especificado
                {
                    if (anio == -1) //Año no especificado
                    {
                        //Listar todos los pedidos
                        lstHistorial = obj.listarHistorialPedidos();
                    }
                    else //Año especificado
                    {
                        //Listar todos los pedidos de un año
                        lstHistorial = obj.listarHistorialAnio(anio);
                    }
                }
                else //Mes especificado
                {
                    //Listar todos los pedidos de un mes
                    lstHistorial = obj.listarHistorialMes(mes, anio);
                }
            }
            else //Dia especificado
            {
                //Listar todos los pedidos de un dia
                lstHistorial = obj.listarHistorialDia(dia, mes, anio);
            }
            

            return lstHistorial;
        }
    }
}
