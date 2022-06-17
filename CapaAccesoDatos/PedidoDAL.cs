using CapaEntidades;
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
    public class PedidoDAL
    {
        private String cnxStr = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

        public bool Add(PedidoBE obj)
        {

            bool state = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_RegistrarOrden", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 700;

                    cmd.Parameters.Add("@idMesa", SqlDbType.VarChar).Value = obj.idMesa;
                    cmd.Parameters.Add("@idComida", SqlDbType.Money).Value = obj.idComida;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Money).Value = obj.cantidad;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    state = true;
                    cn.Close();

                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return state;
        }

        public List<PedidoBEforListCocina> listarPedidosCocina()
        {

            SqlDataAdapter da = new SqlDataAdapter("usp_ListarPedidosCocina", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<PedidoBEforListCocina> lstPedidos = new List<PedidoBEforListCocina>();

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PedidoBEforListCocina pedidoCocina = new PedidoBEforListCocina();

                    pedidoCocina.idMesa = Convert.ToInt32(dt.Rows[i]["idMesa"]);
                    pedidoCocina.idOrden = Convert.ToInt32(dt.Rows[i]["idOrden"]);
                    pedidoCocina.nombreComida = dt.Rows[i]["nombreComida"].ToString();
                    pedidoCocina.imagen = dt.Rows[i]["imagen"].ToString();
                    pedidoCocina.cantidad = Convert.ToInt32(dt.Rows[i]["cantidad"]);
                    pedidoCocina.fechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"]);
                    pedidoCocina.estadoOrden = dt.Rows[i]["estadoOrden"].ToString();

                    lstPedidos.Add(pedidoCocina);
                }
            }
            if (lstPedidos.Count > 0)
            {
                return lstPedidos;
            }
            else
            {

                return null;
            }
        }
    }
}
