using CapaEntidades;
using CapaEntidades.CartaEntities;
using CapaEntidades.ComidaEntities;
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
    public class ComidaCartaDal
    {

        //OBTENER UNA CARTA CON COMIDAS
        public List<ComidaBEforList> listarComidaCarta(int idCarta)
        {
            List<ComidaBEforList> lstComidasCarta = new List<ComidaBEforList>();
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarComidaCarta");
            //Se añaden los parametros
            cmd.AddInt("@idCarta", idCarta);

            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaComidas = cmd.EjecutarTabla();
            for (int i = 0; i < tablaComidas.Rows.Count; i++)
            {
                lstComidasCarta.Add(
                    ComidaDal.ObtenerCamposComida(
                        new TablaValores(tablaComidas.Rows[i])
                    )
                );
            }
            return lstComidasCarta;
        }

        // AGREGAR COMIDA A LA CARTA - DE MOMENTO SOLO SE TRABAJARA CON 1 CARTA

        public bool AddComidaCarta(CartaBEforComidaInsert obj)
        {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_AgregarPlatilloCarta");
            //Se añaden los parametros
            cmd.AddInt("@idCarta", obj.idCarta);
            cmd.AddInt("@idComida", obj.idComida);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }


        public bool Delete(int idComida, int idCarta)
        {
            ComandoSqlDF cmd = new ComandoSqlDF("usp_EliminarComidaDeCarta");
            cmd.AddInt("@idComida", idComida);
            cmd.AddInt("@idCarta", idCarta);
            return cmd.Ejecutar();
        }

    }
}
