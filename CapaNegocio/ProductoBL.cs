using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ProductoBL
    {
        private ProductoDAL productoDALC = new ProductoDAL();
        public List<ProductoBE> listarEntradas()
        {

            try
            {
                List<ProductoBE> lstEntradas = new List<ProductoBE>();
                lstEntradas = productoDALC.listarEntradas();

                return lstEntradas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<ProductoBE> listarSegundos()
        {

            try
            {
                List<ProductoBE> lstSegundos = new List<ProductoBE>();
                lstSegundos = productoDALC.listarSegundos();

                return lstSegundos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public List<ProductoBE> listarBebidas()
        {

            try
            {
                List<ProductoBE> lstBebidas= new List<ProductoBE>();
                lstBebidas = productoDALC.listarBebidas();

                return lstBebidas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public List<ProductoBE> listarPostres()
        {

            try
            {
                List<ProductoBE> lstPostres = new List<ProductoBE>();
                lstPostres = productoDALC.listarPostres();

                return lstPostres;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

    
    }
}
