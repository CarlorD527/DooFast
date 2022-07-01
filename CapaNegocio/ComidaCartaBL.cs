using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ComidaCartaBl
    {
        // CRUD DE CartaS
        private  readonly ComidaCartaDal ComidaCartaDALC = new ComidaCartaDal();

        public bool AddComidaCarta(CartaBEforComidaInsert obj)
        {
            bool state = false;
            try
            {
                state = ComidaCartaDALC.AddComidaCarta(obj);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return state;
        }
        //metodo para listar carta, de momento solo recibe el id 1 
        public List<List<ComidaBEforList>> listarComidaCarta(int idCarta)
        {    
                //Lista ordenada
                List<List<ComidaBEforList>> lstComidasOrdenado = new List<List<ComidaBEforList>>();

                //obteniendo lista de la BD 
                List<ComidaBEforList> lstComidasSinFiltrar = ComidaCartaDALC.listarComidaCarta(idCarta);

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


        public bool Delete(int idComida ,int idCarta)
        {
            return ComidaCartaDALC.Delete(idComida,idCarta);
        }
    }
}
