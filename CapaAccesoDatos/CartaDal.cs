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
    public class CartaDal
    {

        private readonly String cnxStr = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

        // Crear Carta 
        public bool Add(CartaBE obj) {

            bool state = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_CrearCarta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 700;

                    cmd.Parameters.Add("@idRestaurante", SqlDbType.Int).Value = obj.idRestaurante;
                    cmd.Parameters.Add("@nombreCarta", SqlDbType.VarChar).Value = obj.nombreCarta;
                    
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

        //Listar Cartas
        public List<CartaBEforList> listarCartas()
        {

            SqlDataAdapter da = new SqlDataAdapter("usp_ListarCartas", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<CartaBEforList> lstCartas = new List<CartaBEforList>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CartaBEforList Carta = new CartaBEforList();

                    Carta.idCarta = Convert.ToInt32(dt.Rows[i]["idCarta"]);
                    Carta.nombreLocal = dt.Rows[i]["nombreLocal"].ToString();
                    Carta.nombreCarta = dt.Rows[i]["nombreCarta"].ToString();
                    Carta.fechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"]);
                    Carta.estado = dt.Rows[i]["estado"].ToString();

                    lstCartas.Add(Carta);
                }
            }
            if (lstCartas.Count > 0)
            {
                return lstCartas;
            }
            else
            {
                List<CartaBEforList> lstCartasVacia = new List<CartaBEforList>();
                return lstCartasVacia;
            }
        }

        //Actualizar Carta
        public bool Update(CartaBEforUpdate obj)
        {
            bool state = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("usp_ActualizarCarta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;


                    cmd.Parameters.Add("@idCarta", SqlDbType.Int).Value = obj.idCarta;
                    cmd.Parameters.Add("@idRestaurante", SqlDbType.Int).Value = obj.idRestaurante;
                    cmd.Parameters.Add("@nombreCarta", SqlDbType.VarChar).Value = obj.nombreCarta;
                    cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = obj.estado;
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

        //Borrado LOGICO de Carta
        public bool Delete(int idCarta)
        {
            bool state = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarCarta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;


                    cmd.Parameters.Add("@idCarta", SqlDbType.Int).Value = idCarta;
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

    }
}
