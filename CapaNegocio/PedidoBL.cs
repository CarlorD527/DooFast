using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PedidoBl
    {
        // CRUD DE PEDIDO
        private readonly PedidoDal pedidoDALC = new PedidoDal();

        //CREAR PEDIDO - TOMAR PEDIDO DEL CLIENTE
        public bool Add(PedidoBe obj)
        {
            bool state = false;
            try
            {
                state = pedidoDALC.Add(obj);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return state;
        }
        public List<PedidoBEforListCocina> listarPedidos()
        {

            try
            {
                List<PedidoBEforListCocina> lstPedidos = new List<PedidoBEforListCocina>();
                lstPedidos = pedidoDALC.listarPedidosCocina();

                return lstPedidos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


        public List<PedidoBEforListPorMesa> listarOrdenPorMesa(int idMesa)
        {

            try
            {
                List<PedidoBEforListPorMesa> lstPedidosPorMesa= new List<PedidoBEforListPorMesa>();

                lstPedidosPorMesa = pedidoDALC.listarPedidosPorMesa(idMesa);

                return lstPedidosPorMesa;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
