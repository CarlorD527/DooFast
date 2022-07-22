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



            /*
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

            return state;*/
        }

        //LISTAR PEDIDOS
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
                    new PedidoBEforListCocina {
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


            /*

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

                List<PedidoBEforListCocina> lstPedidosVacia = new List<PedidoBEforListCocina>();

                return lstPedidosVacia;
            }*/
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



            /*
            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_ListarOrdenesPorMesa", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.Add("@idMesa", SqlDbType.Int).Value = nroMesa;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    List<PedidoBEforListPorMesa> lstOrdenesPorMesa= new List<PedidoBEforListPorMesa>();

                    if (dt.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            PedidoBEforListPorMesa comida = new PedidoBEforListPorMesa();

                            comida.idMesa = Convert.ToInt32(dt.Rows[i]["idMesa"]);
                            comida.idOrden= Convert.ToInt32(dt.Rows[i]["idOrden"]);
                            comida.idComida = Convert.ToInt32(dt.Rows[i]["idComida"]);
                            comida.nombreCategoria= dt.Rows[i]["nombreCategoria"].ToString();
                            comida.nombreComida = dt.Rows[i]["nombreComida"].ToString();
                            comida.precio = Convert.ToDouble(dt.Rows[i]["precio"]);
                            comida.estadoOrden = dt.Rows[i]["estadoOrden"].ToString();
                            comida.cantidad = Convert.ToInt32(dt.Rows[i]["cantidad"]);
                            comida.fechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"]);


                            lstOrdenesPorMesa.Add(comida);
                        }
                    }
                    if (lstOrdenesPorMesa.Count > 0)
                    {
                        return lstOrdenesPorMesa;
                    }
                    else
                    {
                        List<PedidoBEforListPorMesa> lstOrdenesPorMesaVacia = new List<PedidoBEforListPorMesa>();

                        return lstOrdenesPorMesaVacia;
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                List<PedidoBEforListPorMesa> lstOrdenesPorMesaVacia = new List<PedidoBEforListPorMesa>();
                return lstOrdenesPorMesaVacia;
            }*/
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
