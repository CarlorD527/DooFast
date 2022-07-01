using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CartaBl
    {

        // CRUD DE CartaS
        private readonly CartaDal CartaDALC = new CartaDal();

       
        public bool Add(CartaBe obj)
        {
            bool state = false;
            try
            {
                state = CartaDALC.Add(obj);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return state;
        }
     
        public bool Update (CartaBEforUpdate obj)
        {

            bool state = false;
            try
            {
                state = CartaDALC.Update(obj);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
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

                Console.WriteLine(e.Message);
            }
            return state;
        }

    }
}
