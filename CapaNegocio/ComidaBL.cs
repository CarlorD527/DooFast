using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ComidaBL
    {

        // CRUD DE COMIDAS
        private ComidaDal comidaDALC = new ComidaDal();

        public bool Add(ComidaBE obj)
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


        
        public List<ComidaBEforList> listarEntradas()
        {

            try
            {
                List<ComidaBEforList> lstEntradas = new List<ComidaBEforList>();
                lstEntradas = comidaDALC.listarEntradas();

                return lstEntradas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<ComidaBEforList> listarSegundos()
        {

            try
            {
                List<ComidaBEforList> lstSegundos = new List<ComidaBEforList>();
                lstSegundos = comidaDALC.listarPrincipal();

                return lstSegundos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public List<ComidaBEforList> listarBebidas()
        {

            try
            {
                List<ComidaBEforList> lstBebidas = new List<ComidaBEforList>();
                lstBebidas = comidaDALC.listarBebidas();

                return lstBebidas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public List<ComidaBEforList> listarPostres()
        {

            try
            {
                List<ComidaBEforList> lstPostres = new List<ComidaBEforList>();
                lstPostres = comidaDALC.listarPostres();

                return lstPostres;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


    }
}
