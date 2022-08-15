using CapaEntidades.PedidoEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class BalanceDal
    {
        public List<BalanceBe> listarBalance(int anio)
        {
            List<BalanceBe> lstBalance = new List<BalanceBe>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarIngresosAnio");

            cmd.AddInt("@anio", anio);
            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaBalance= cmd.EjecutarTabla();
            for (int i = 0; i < tablaBalance.Rows.Count; i++)
            {
                lstBalance.Add(
                    ObtenerCamposBalance(
                        new TablaValores(tablaBalance.Rows[i])
                    )
                );
            }
            return lstBalance;
        }

        public static BalanceBe ObtenerCamposBalance(TablaValores tv)
        {
            BalanceBe registro = new BalanceBe
            {
                mes = tv.GetInt("mes"),
                TotalMes = tv.GetDouble("TotalMes"),
                CantidadPedidos = tv.GetInt("CantidadPedidos")
            };
            return registro;
        }
    }
}
