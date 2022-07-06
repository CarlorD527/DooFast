using CapaAccesoDatos;
using CapaEntidades;
using CapaEntidades.PedidoBe;
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

                Console.WriteLine(e.Message);
            }
            return state;
        }
        public List<PedidoBEforListCocina> listarPedidos()
        {
                List<PedidoBEforListCocina> lstPedidos = pedidoDALC.listarPedidosCocina();

                return lstPedidos;
        }


        public List<PedidoBEforListPorMesa> listarOrdenPorMesa(int idMesa)
        {

                List<PedidoBEforListPorMesa> lstPedidosPorMesa = pedidoDALC.listarPedidosPorMesa(idMesa);

                return lstPedidosPorMesa;
         
        }

        
        //Eliminar pedido
        public bool Delete(int idOrden)
        {
            return pedidoDALC.Delete(idOrden);
        }
    }
}
