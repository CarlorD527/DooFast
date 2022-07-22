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

        // Crear Carta 
        public bool Add(CartaBe obj) {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_CrearCarta");
            //Se añaden los parametros
            cmd.AddInt("@idRestaurante", obj.idRestaurante);
            cmd.AddString("@nombreCarta", obj.nombreCarta);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();

            /*
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
            */
        }

        //Listar Cartas



        //Listar 1 Carta

        //Actualizar Carta
        public bool Update(CartaBEforUpdate obj)
        {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ActualizarCarta");
            //Se añaden los parametros
            cmd.AddInt("@idCarta", obj.idCarta);
            cmd.AddInt("@idRestaurante", obj.idRestaurante);
            cmd.AddString("@nombreCarta", obj.nombreCarta);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();


            /*
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

                throw new Exception(e.Message);
            }

            return state;*/

        }

        //Borrado LOGICO de Carta
        public bool Delete(int idCarta)
        {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_EliminarCarta");
            //Se añaden los parametros
            cmd.AddInt("@idCarta", idCarta);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();

            /*
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

            return state;*/
        }


    }
}
