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
    public class ProductoDAL
    {

        private String cnxStr = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

        public List<ProductoBE> listarEntradas()
        {

            SqlDataAdapter da = new SqlDataAdapter("ListarEntradas", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ProductoBE> lstEntradas = new List<ProductoBE>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductoBE proEntra = new ProductoBE();
                    proEntra.idProducto = Convert.ToInt32(dt.Rows[i]["idProducto"]);
                    proEntra.nombreProducto = dt.Rows[i]["nombreProducto"].ToString();
                    proEntra.precio = Convert.ToDouble(dt.Rows[i]["precio"]);
                    proEntra.costo = Convert.ToDouble(dt.Rows[i]["costo"]);
                    proEntra.imagen = null;
                    proEntra.nombreCategoria = dt.Rows[i]["nombreCategoria"].ToString();

                    lstEntradas.Add(proEntra);
                }
            }
            if (lstEntradas.Count > 0)
            {
                return lstEntradas;
            }
            else
            {

                return null;
            }
        }

        public List<ProductoBE> listarSegundos()
        {

            SqlDataAdapter da = new SqlDataAdapter("ListarSegundos", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ProductoBE> lstSegundos = new List<ProductoBE>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductoBE proEntra = new ProductoBE();
                    proEntra.idProducto = Convert.ToInt32(dt.Rows[i]["idProducto"]);
                    proEntra.nombreProducto = dt.Rows[i]["nombreProducto"].ToString();
                    proEntra.precio = Convert.ToDouble(dt.Rows[i]["precio"]);
                    proEntra.costo = Convert.ToDouble(dt.Rows[i]["costo"]);
                    proEntra.imagen = null;
                    proEntra.nombreCategoria = dt.Rows[i]["nombreCategoria"].ToString();

                    lstSegundos.Add(proEntra);
                }
            }
            if (lstSegundos.Count > 0)
            {
                return lstSegundos;
            }
            else
            {

                return null;
            }
        }

        public List<ProductoBE> listarBebidas()
        {

            SqlDataAdapter da = new SqlDataAdapter("ListarBebidas", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ProductoBE> lstBebidas = new List<ProductoBE>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductoBE proEntra = new ProductoBE();
                    proEntra.idProducto = Convert.ToInt32(dt.Rows[i]["idProducto"]);
                    proEntra.nombreProducto = dt.Rows[i]["nombreProducto"].ToString();
                    proEntra.precio = Convert.ToDouble(dt.Rows[i]["precio"]);
                    proEntra.costo = Convert.ToDouble(dt.Rows[i]["costo"]);
                    proEntra.imagen = null;
                    proEntra.nombreCategoria = dt.Rows[i]["nombreCategoria"].ToString();

                    lstBebidas.Add(proEntra);
                }
            }
            if (lstBebidas.Count > 0)
            {
                return lstBebidas;
            }
            else
            {

                return null;
            }
        }
        public List<ProductoBE> listarPostres()
        {

            SqlDataAdapter da = new SqlDataAdapter("ListarPostres", cnxStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ProductoBE> lstPostres = new List<ProductoBE>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductoBE proEntra = new ProductoBE();
                    proEntra.idProducto = Convert.ToInt32(dt.Rows[i]["idProducto"]);
                    proEntra.nombreProducto = dt.Rows[i]["nombreProducto"].ToString();
                    proEntra.precio = Convert.ToDouble(dt.Rows[i]["precio"]);
                    proEntra.costo = Convert.ToDouble(dt.Rows[i]["costo"]);
                    proEntra.imagen = null;
                    proEntra.nombreCategoria = dt.Rows[i]["nombreCategoria"].ToString();

                    lstPostres.Add(proEntra);
                }
            }
            if (lstPostres.Count > 0)
            {
                return lstPostres;
            }
            else
            {

                return null;
            }
        }

    }
}
