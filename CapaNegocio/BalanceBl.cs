using CapaAccesoDatos;
using CapaEntidades.PedidoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BalanceBl
    {
        // CRUD DE MESA
        private readonly BalanceDal balanceDALC = new BalanceDal();
        public List<BalanceBe> listarBalance(int anio)
        {
            List<BalanceBe> lstBalance = balanceDALC.listarBalance(anio);

            return lstBalance;
        }
    }
}
