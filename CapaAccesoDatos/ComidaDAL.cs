﻿using CapaEntidades;
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
    public class ComidaDal
    {

        private String cnxStr = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

        // Crear comida 
        public bool Add(ComidaBE obj) {

            bool state = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_CrearComida", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 700;

                    cmd.Parameters.Add("@nombreComida", SqlDbType.VarChar).Value = obj.nombreComida;
                    cmd.Parameters.Add("@precio", SqlDbType.Money).Value = obj.precio;
                    cmd.Parameters.Add("@costo", SqlDbType.Money).Value = obj.costo;
                    cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = obj.idCategoria;
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

        //Listar comidas
        public List<ComidaBEforList> listarComidas()
        {

            SqlDataAdapter da = new SqlDataAdapter("usp_listarComidas", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ComidaBEforList> lstComidas = new List<ComidaBEforList>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComidaBEforList comida = new ComidaBEforList();

                    ObtenerCamposDt(dt, comida, i);

                    lstComidas.Add(comida);
                }
            }
            if (lstComidas.Count > 0)
            {
                return lstComidas;
            }
            else
            {
                List<ComidaBEforList> lstComidasVacia = new List<ComidaBEforList>();
                return lstComidasVacia;
            }
        }

        //Obtener una comida
        public List<ComidaBEforList> listarComida(int idComida)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {

                    SqlCommand cmd = new SqlCommand("usp_ObtenerComida", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.Add("@idComida", SqlDbType.Int).Value = idComida;
 
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    List<ComidaBEforList> lstComidas = new List<ComidaBEforList>();

                    if (dt.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ComidaBEforList comida = new ComidaBEforList();

                            ObtenerCamposDt(dt, comida, i);

                            lstComidas.Add(comida);
                        }
                    }
                    if (lstComidas.Count > 0)
                    {
                        return lstComidas;
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

        }

        //Actualizar comida
        public bool Update(ComidaBEforUpdate obj)
        {
            bool state = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("usp_ActualizarComida", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;


                    cmd.Parameters.Add("@idComida", SqlDbType.Int).Value = obj.idComida;
                    cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = obj.idCategoria;
                    cmd.Parameters.Add("@nombreComida", SqlDbType.VarChar).Value = obj.nombreComida;
                    cmd.Parameters.Add("@precio", SqlDbType.VarChar).Value = obj.precio;
                    cmd.Parameters.Add("@costo", SqlDbType.VarChar).Value = obj.costo;
                    cmd.Parameters.Add("@imagen", SqlDbType.VarChar).Value = obj.imagen;
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

        //Borrado LOGICO de comida
        public bool Delete(int idComida)
        {
            bool state = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarComida", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;


                    cmd.Parameters.Add("@idComida", SqlDbType.Int).Value = idComida;
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



        // ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- ----- -----

        //Diferentes listados para el MENU
        // Listar entradas
        public List<ComidaBEforList> listarEntradas()
        {

            SqlDataAdapter da = new SqlDataAdapter("usp_ListarEntradas", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ComidaBEforList> lstEntradas = new List<ComidaBEforList>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    ComidaBEforList proEntra = new ComidaBEforList();
                    ObtenerCamposDt(dt, proEntra, i);
             
                    lstEntradas.Add(proEntra);
                }
            }
            if (lstEntradas.Count > 0)
            {
                return lstEntradas;
            }
            else
            {

                List<ComidaBEforList> lstComidasVacia = new List<ComidaBEforList>();
                return lstComidasVacia;
            }
        }

        //Listar segundos
        public List<ComidaBEforList> listarPrincipal()
        {

            SqlDataAdapter da = new SqlDataAdapter("usp_ListarPrincipales", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ComidaBEforList> lstSegundos = new List<ComidaBEforList>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComidaBEforList proSegundo = new ComidaBEforList();
                    ObtenerCamposDt(dt, proSegundo, i);
                    lstSegundos.Add(proSegundo);
                }
            }
            if (lstSegundos.Count > 0)
            {
                return lstSegundos;
            }
            else
            {
                List<ComidaBEforList> lstSegundosVacio = new List<ComidaBEforList>();
                return lstSegundosVacio;
            }
        }

        //Listar bebidas
        public List<ComidaBEforList> listarBebidas()
        {

            SqlDataAdapter da = new SqlDataAdapter("usp_ListarBebidas", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ComidaBEforList> lstBebidas = new List<ComidaBEforList>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComidaBEforList proEntra = new ComidaBEforList();

                    ObtenerCamposDt(dt, proEntra, i);
                    lstBebidas.Add(proEntra);
                }
            }
            if (lstBebidas.Count > 0)
            {
                return lstBebidas;
            }
            else
            {

                List<ComidaBEforList> lstBebidasVacio = new List<ComidaBEforList>();
                return lstBebidasVacio;
            }
        }

        //Listar postres
        public List<ComidaBEforList> listarPostres()
        {

            SqlDataAdapter da = new SqlDataAdapter("usp_ListarPostres", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ComidaBEforList> lstPostres = new List<ComidaBEforList>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComidaBEforList proEntra = new ComidaBEforList();

                    ObtenerCamposDt(dt, proEntra, i);
                    lstPostres.Add(proEntra);
                }
            }
            if (lstPostres.Count > 0)
            {
                return lstPostres;
            }
            else
            {

                List<ComidaBEforList> lstPostresVacio = new List<ComidaBEforList>();
                return lstPostresVacio;
            }
        }

        //Obtener campos para listarlos en las funciones relacionadas a comida
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