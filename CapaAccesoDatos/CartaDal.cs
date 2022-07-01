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
        public bool Add(CartaBe obj) {

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

                Console.WriteLine(e.Message);
            }

            return state;
        }

        //Listar Cartas



        //Listar 1 Carta

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
               
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    state = true;
                    cn.Close();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
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

                Console.WriteLine(e.Message);
            }

            return state;
        }
        public void ObtenerCamposDt(DataTable dt, ComidaBEforList comida, int i)
        {

            comida.idComida = Convert.ToInt32(dt.Rows[i]["idComida"]);
            comida.nombreComida = dt.Rows[i]["nombreComida"].ToString();
            comida.nombreCategoria = dt.Rows[i]["nombreCategoria"].ToString();
            comida.precio = Convert.ToDouble(dt.Rows[i]["precio"]);
            comida.costo = Convert.ToDouble(dt.Rows[i]["costo"]);
            comida.imagen = dt.Rows[i]["imagen"].ToString();
            comida.fechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"]);
            comida.estado = dt.Rows[i]["estado"].ToString();

        }


    }
}
