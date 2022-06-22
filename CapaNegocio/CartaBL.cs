using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CartaBL
    {

        // CRUD DE CartaS
        private CartaDal CartaDALC = new CartaDal();

        public bool Add(CartaBE obj)
        {
            bool state = false;
            try
            {
                state = CartaDALC.Add(obj);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return state;
        }
        //public List<CartaBEforList> listarCartas()
        //{

        //    try
        //    {
        //        List<CartaBEforList> lstCartas = new List<CartaBEforList>();
        //        lstCartas = CartaDALC.listarCartas();

        //        return lstCartas;
        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception(e.Message);
        //    }

        //}
        public bool Update (CartaBEforUpdate obj)
        {

            bool state = false;
            try
            {
                state = CartaDALC.Update(obj);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return state;

        }
        public bool Delete(int idCarta)
        {
            bool state = false;
            try
            {
                state = CartaDALC.Delete(idCarta);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return state;
        }

    }
}
