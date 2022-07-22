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
    public class CartaDal
    {

        // Crear Carta 
        public bool Add(CartaBe obj) {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_CrearCarta");
            //Se añaden los parametros
            cmd.AddInt("@idRestaurante", obj.idRestaurante);
            cmd.AddString("@nombreCarta", obj.nombreCarta);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }

        //Listar Cartas



        //Listar 1 Carta

        //Actualizar Carta
        public bool Update(CartaBEforUpdate obj)
        {
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ActualizarCarta");
            //Se añaden los parametros
            cmd.AddInt("@idCarta", obj.idCarta);
            cmd.AddInt("@idRestaurante", obj.idRestaurante);
            cmd.AddString("@nombreCarta", obj.nombreCarta);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }

        //Borrado LOGICO de Carta
        public bool Delete(int idCarta)
        {
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_EliminarCarta");
            //Se añaden los parametros
            cmd.AddInt("@idCarta", idCarta);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }


    }
}
