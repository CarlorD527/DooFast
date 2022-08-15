using CapaAccesoDatos;
using CapaEntidades.MesaEntities;
using CapaEntidades.PedidoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class HistorialBl
    {
        // CRUD DE COMIDAS
        private readonly HistorialDal historialDALC = new HistorialDal();

        public List<List<HistorialBe>> listarRegistros()
        {

            //Lista ordenada
            List<List<HistorialBe>> lstComidasOrdenado = new List<List<HistorialBe>>();

            //obteniendo lista de la BD 
            List<HistorialBe> lstComidasSinFiltrar = historialDALC.listarHistorial();

            //Obteniendo la lista de entradas de la lista sin ordenar
            List<HistorialBe> lstEntradas = lstComidasSinFiltrar.Where(x => x.nombreCategoria == "Entrada").ToList();

            lstComidasOrdenado.Add(lstEntradas);

            //obteniendo la lista de principales de la lista sin ordenar
            List<HistorialBe> lstPrincipales = lstComidasSinFiltrar.Where(x => x.nombreCategoria == "Principal").ToList();

            lstComidasOrdenado.Add(lstPrincipales);

            //obteniendo la lista de bebidas de la lista sin ordenar
            List<HistorialBe> lstBebidas = lstComidasSinFiltrar.Where(x => x.nombreCategoria == "Bebida").ToList();

            lstComidasOrdenado.Add(lstBebidas);

            //obteniendo la lista de bebidas de la lista sin ordenar
            List<HistorialBe> lstPostres = lstComidasSinFiltrar.Where(x => x.nombreCategoria == "Postre").ToList();

            lstComidasOrdenado.Add(lstPostres);

            return lstComidasOrdenado;
        }

        public bool Update(HistorialBeUpdate obj)
        {
            return historialDALC.Update(obj);
        }
    }
}
