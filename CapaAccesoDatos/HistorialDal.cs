using CapaEntidades.PedidoEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaAccesoDatos
{

    public class HistorialDal
    {
        public List<HistorialBe> listarHistorial()
        {
            List<HistorialBe> lstMesas = new List<HistorialBe>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarHistorialPedidos");

            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaOrdenes = cmd.EjecutarTabla();
            for (int i = 0; i < tablaOrdenes.Rows.Count; i++)
            {
                lstMesas.Add(
                    ObtenerCamposHistorial(
                        new TablaValores(tablaOrdenes.Rows[i])
                    )
                );
            }
            return lstMesas;
        }
        //Actualizar historial [cambiar estado de SIN PAGAR A PAGADO]
        public bool Update(HistorialBeUpdate obj)
        {

            ComandoSqlDF cmd = new ComandoSqlDF("usp_ActualizarHistorial");
            cmd.AddInt("@idComidaOrden", obj.idOrden);
            return cmd.Ejecutar();
        }

        public static HistorialBe ObtenerCamposHistorial(TablaValores tv)
        {
            HistorialBe registro = new HistorialBe       
            {
                idHistorialPedido = tv.GetInt("idHistorialPedido"),
                nombreComida = tv.GetString("nombreComida"),
                nombreCategoria = tv.GetString("nombreCategoria"),
                cantidad = tv.GetInt("cantidad"),
                estado = tv.GetString("estado"),
                fechaRegistro = tv.GetDateTime("fechaRegistro")
            };
            return registro;
        }
    }
}
