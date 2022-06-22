using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ComidaBl
    {

        // CRUD DE COMIDAS
        private ComidaDal comidaDALC = new ComidaDal();

        public bool Add(ComidaBe obj)
        {
            bool state = false;
            try
            {
                state = comidaDALC.Add(obj);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return state;
        }
        public List<ComidaBEforList> listarComidas()
        {

            try
            {
                List<ComidaBEforList> lstComidas = new List<ComidaBEforList>();
                lstComidas = comidaDALC.listarComidas();

                return lstComidas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<ComidaBEforList> listarComida(int idComida)
        {

            try
            {
                List<ComidaBEforList> lstComidas = new List<ComidaBEforList>();
                lstComidas = comidaDALC.listarComida(idComida);

                return lstComidas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public bool Update (ComidaBEforUpdate obj)
        {

            bool state = false;
            try
            {
                state = comidaDALC.Update(obj);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return state;

        }
        public bool Delete(int idComida)
        {
            bool state = false;
            try
            {
                state = comidaDALC.Delete(idComida);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return state;
        }


        


    }
}
