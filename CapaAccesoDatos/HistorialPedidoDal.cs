using CapaEntidades;
using CapaEntidades.PedidoBe;
using CapaEntidades.PedidoEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    // CREAR PEDIDO [TOMAR PEDIDO]
    public class HistorialPedidoDal
    {

        public List<HistorialPedidoBE> listarHistorialPedidos()
        {

            List<HistorialPedidoBE> lstHistorial = new List<HistorialPedidoBE>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarHistorialPedidos");
            //Se ejecuta el comando y se devuelve el resultado
            return EjecutarListar(cmd);
        }

        public List<HistorialPedidoBE> listarHistorialMes(int mes, int anio)
        {
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarHistorialMes");
            //Se añaden los parametros
            cmd.AddInt("@mes", mes);
            cmd.AddInt("@anio", anio);
            //Se ejecuta el comando y se devuelve el resultado
            return EjecutarListar(cmd);
        }

        public List<HistorialPedidoBE> listarHistorialAnio(int anio)
        {
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarHistorialAnio");
            //Se añaden los parametros
            cmd.AddInt("@anio", anio);
            //Se ejecuta el comando y se devuelve el resultado
            return EjecutarListar(cmd);
        }

        private List<HistorialPedidoBE> EjecutarListar(ComandoSqlDF cmd)
        {
            List<HistorialPedidoBE> lstHistorial = new List<HistorialPedidoBE>();

            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaComidas = cmd.EjecutarTabla();
            for (int i = 0; i < tablaComidas.Rows.Count; i++)
            {
                TablaValores tv = new TablaValores(tablaComidas.Rows[i]);
                lstHistorial.Add(
                    ObtenerCamposHistorial(
                        new TablaValores(tablaComidas.Rows[i])
                    )
                );
            }
            return lstHistorial;
        }

        public static HistorialPedidoBE ObtenerCamposHistorial(TablaValores tv)
        {
            HistorialPedidoBE hist = new HistorialPedidoBE
            {
                idHistorial = tv.GetInt("idHistorialPedido"),
                idOrden = tv.GetInt("idOrden"),
                idComida = tv.GetInt("idComida"),
                cantidad = tv.GetInt("cantidad"),
                mes = tv.GetString("mes"),
                anio = tv.GetString("anio"),
                fechaRegistro = tv.GetDateTime("fechaRegistro"),
                estado = tv.GetString("estado")
            };
            return hist;
        }

    }
}
