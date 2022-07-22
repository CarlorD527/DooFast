using CapaEntidades;
using CapaEntidades.PedidoBe;
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
    public class PedidoDal
    {

        public bool Add(PedidoBe obj)
        {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_RegistrarOrden");
            //Se añaden los parametros
            cmd.AddInt("@idMesa", obj.idMesa);
            cmd.AddInt("@idComida", obj.idComida);
            cmd.Add(SqlDbType.Money, "@cantidad", obj.cantidad);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }

        public List<PedidoBEforListCocina> listarPedidosCocina()
        {

            List<PedidoBEforListCocina> lstPedidosCocina = new List<PedidoBEforListCocina>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarPedidosCocina");
            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaComidas = cmd.EjecutarTabla();
            for (int i = 0; i < tablaComidas.Rows.Count; i++)
            {
                TablaValores tv = new TablaValores(tablaComidas.Rows[i]);
                lstPedidosCocina.Add(
                    new PedidoBEforListCocina
                    {
                        idMesa = tv.GetInt("idMesa"),
                        idOrden = tv.GetInt("idOrden"),
                        nombreComida = tv.GetString("nombreComida"),
                        imagen = tv.GetString("imagen"),
                        cantidad = tv.GetInt("cantidad"),
                        fechaCreacion = tv.GetDateTime("fechaCreacion"),
                        estadoOrden = tv.GetString("estadoOrden")
                    }
                );
            }
            return lstPedidosCocina;
        }

        public List<PedidoBEforListPorMesa> listarPedidosPorMesa(int nroMesa)
        {

            List<PedidoBEforListPorMesa> lstPedidosPorMesa = new List<PedidoBEforListPorMesa>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarOrdenesPorMesa");
            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaComidas = cmd.EjecutarTabla();
            for (int i = 0; i < tablaComidas.Rows.Count; i++)
            {
                TablaValores tv = new TablaValores(tablaComidas.Rows[i]);
                lstPedidosPorMesa.Add(
                    new PedidoBEforListPorMesa
                    {
                        idMesa = tv.GetInt("idMesa"),
                        idOrden = tv.GetInt("idOrden"),
                        idComida = tv.GetInt("idComida"),
                        nombreCategoria = tv.GetString("nombreCategoria"),
                        nombreComida = tv.GetString("nombreComida"),
                        precio = tv.GetDouble("precio"),
                        estadoOrden = tv.GetString("estadoOrden"),
                        cantidad = tv.GetInt("cantidad"),
                        fechaCreacion = tv.GetDateTime("fechaCreacion")
                    }
                );
            }
            return lstPedidosPorMesa;
        }


        //eliminar pedido
        public bool Delete(int idOrden)
        {
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_EliminarOrden");
            //Se añaden los parametros
            cmd.AddInt("@idOrden", idOrden);
            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }

    }
}
