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
    public class ComidaCartaDal
    {

        //OBTENER UNA CARTA CON COMIDAS
        public List<ComidaBEforList> listarComidaCarta(int idCarta)
        {
            List<ComidaBEforList> lstComidasCarta = new List<ComidaBEforList>();
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarComidaCarta");
            //Se añaden los parametros
            cmd.AddInt("@idCarta", idCarta);

            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaComidas = cmd.EjecutarTabla();
            for(int i = 0; i < tablaComidas.Rows.Count; i++)
            {
                lstComidasCarta.Add(
                    ComidaDal.ObtenerCamposComida(
                        new TablaValores(tablaComidas.Rows[i])
                    )
                );
            }
            return lstComidasCarta;

            /*
            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_ListarComidaCarta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.Add("@idCarta", SqlDbType.Int).Value = idCarta;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    List<ComidaBEforList> lstComidasCarta = new List<ComidaBEforList>();

                    if (dt.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ComidaBEforList comida = new ComidaBEforList();

                            ObtenerCamposDt(dt, comida, i);

                            lstComidasCarta.Add(comida);
                        }
                    }
                    if (lstComidasCarta.Count > 0)
                    {
                        return lstComidasCarta;
                    }
                    else
                    {

                        List<ComidaBEforList> lstComidasVacia = new List<ComidaBEforList>();

                        return lstComidasVacia;
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
                return lstComidasVacia;

            }*/
        }

        // AGREGAR COMIDA A LA CARTA - DE MOMENTO SOLO SE TRABAJARA CON 1 CARTA

        public bool AddComidaCarta(CartaBEforComidaInsert obj)
        {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_AgregarPlatilloCarta");
            //Se añaden los parametros
            cmd.AddInt("@idCarta", obj.idCarta);
            cmd.AddInt("@idComida", obj.idComida);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();


            /*
            bool state = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_AgregarPlatilloCarta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 700;

                    cmd.Parameters.Add("@idCarta", SqlDbType.Int).Value = obj.idCarta;
                    cmd.Parameters.Add("@idComida", SqlDbType.VarChar).Value = obj.idComida;

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


        /*public void ObtenerCamposDt(DataTable dt, ComidaBEforList comida, int i)
        {

            comida.idComida = Convert.ToInt32(dt.Rows[i]["idComida"]);
            comida.nombreComida = dt.Rows[i]["nombreComida"].ToString();
            comida.nombreCategoria = dt.Rows[i]["nombreCategoria"].ToString();
            comida.precio = Convert.ToDouble(dt.Rows[i]["precio"]);
            comida.costo = Convert.ToDouble(dt.Rows[i]["costo"]);
            comida.imagen = dt.Rows[i]["imagen"].ToString();
            comida.fechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"]);
            comida.estado = dt.Rows[i]["estado"].ToString();

        }*/

    }
}
