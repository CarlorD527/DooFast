using CapaAccesoDatos;
using CapaEntidades;
using CapaEntidades.PedidoBe;
using CapaEntidades.PedidoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class HistorialBl
    {
        // LISTADOS DE HISTORIAL
        private readonly HistorialPedidoDal historialDALC = new HistorialPedidoDal();

        public bool Update(HistorialPedidoBEforUpdate obj)
        {
            bool state = false;
            try
            {
                state = historialDALC.actualizarEstadoHistorial(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return state;
        }

        public List<HistorialPedidoBE> listarHistorialPedidos()
        {
                List<HistorialPedidoBE> lstHistorial = historialDALC.listarHistorialPedidos();

                return lstHistorial;
        }

        public List<HistorialPedidoBE> listarHistorialDia(int dia, int mes, int anio)
        {
            List<HistorialPedidoBE> lstHistorial = historialDALC.listarHistorialDia(dia, mes, anio);

            return lstHistorial;
        }
        public List<HistorialPedidoBE> listarHistorialMes(int mes, int anio)
        {
            List<HistorialPedidoBE> lstHistorial = historialDALC.listarHistorialMes(mes, anio);

            return lstHistorial;
        }

        public List<HistorialPedidoBE> listarHistorialAnio(int anio)
        {
            List<HistorialPedidoBE> lstHistorial = historialDALC.listarHistorialAnio(anio);

            return lstHistorial;
        }

    }
}
