using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PedidoBL
    {
        // CRUD DE PEDIDO
        private PedidoDAL pedidoDALC = new PedidoDAL();

        //CREAR PEDIDO - TOMAR PEDIDO DEL CLIENTE
        public bool Add(PedidoBE obj)
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

    }
}
