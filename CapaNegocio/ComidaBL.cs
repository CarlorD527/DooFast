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
        private readonly ComidaDal comidaDALC = new ComidaDal();

        public bool Add(ComidaBe obj)
        {
            bool state = false;
            try
            {
                state = comidaDALC.Add(obj);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return state;
        }
        public List<List<ComidaBEforList>> listarComidas()
        {

                  //Lista ordenada
                List<List<ComidaBEforList>> lstComidasOrdenado = new List<List<ComidaBEforList>>();

                //obteniendo lista de la BD 
                List<ComidaBEforList> lstComidasSinFiltrar = comidaDALC.listarComidas();

                //Obteniendo la lista de entradas de la lista sin ordenar
                List<ComidaBEforList> lstEntradas = lstComidasSinFiltrar.Where(x => x.nombreCategoria == "Entrada").ToList();

                lstComidasOrdenado.Add(lstEntradas);

                //obteniendo la lista de principales de la lista sin ordenar
                List<ComidaBEforList> lstPrincipales = lstComidasSinFiltrar.Where(x => x.nombreCategoria == "Principal").ToList();

                lstComidasOrdenado.Add(lstPrincipales);

                //obteniendo la lista de bebidas de la lista sin ordenar
                List<ComidaBEforList> lstBebidas = lstComidasSinFiltrar.Where(x => x.nombreCategoria == "Bebida").ToList();

                lstComidasOrdenado.Add(lstBebidas);

                //obteniendo la lista de bebidas de la lista sin ordenar
                List<ComidaBEforList> lstPostres = lstComidasSinFiltrar.Where(x => x.nombreCategoria == "Postre").ToList();

                lstComidasOrdenado.Add(lstPostres);

                return lstComidasOrdenado;
            }
        public List<ComidaBEforList> listarComida(int idComida)
        {
                List<ComidaBEforList> lstComidas = comidaDALC.listarComida(idComida);

                return lstComidas;
       
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

                Console.WriteLine(e.Message);
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

                Console.WriteLine(e.Message);
            }
            return state;
        }


        


    }
}
