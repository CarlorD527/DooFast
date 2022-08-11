using CapaEntidades;
using CapaEntidades.ComidaEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace CapaAccesoDatos
{
    public class ComidaDal
    {

        
        // Crear comida 
        public bool Add(ComidaBe obj) {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_CrearComida");
            //Se añaden los parametros
            cmd.AddString("@nombreComida", obj.nombreComida);
            cmd.Add(SqlDbType.Money, "@precio", obj.precio);
            cmd.AddString("@imagen", obj.imagen);
            cmd.Add(SqlDbType.Money, "@costo", obj.costo);
            cmd.AddInt("@idCategoria", obj.idCategoria);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }

        //Listar comidas
        public List<ComidaBEforList> listarComidas()
        {

            List<ComidaBEforList> lstComidasCarta = new List<ComidaBEforList>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_listarComidas");
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

        //Obtener una comida
        public List<ComidaBEforList> listarComida(int idComida)
        {

            List<ComidaBEforList> lstComidasCarta = new List<ComidaBEforList>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ObtenerComida");
            //Se añaden los parametros
            cmd.AddInt("@idComida", idComida);
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

        //Actualizar comida
        public bool Update(ComidaBEforUpdate obj)
        {
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ActualizarComida");
            //Se añaden los parametros
            cmd.AddInt("@idComida", obj.idComida);
            cmd.AddInt("@idCategoria", obj.idCategoria);
            cmd.AddString("@nombreComida", obj.nombreComida);
            cmd.Add(SqlDbType.Money, "@precio", obj.precio);
            cmd.Add(SqlDbType.Money, "@costo", obj.costo);
            cmd.AddString("@imagen", obj.imagen);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }

        //Borrado LOGICO de comida
        public bool Delete(int idComida)
        {
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_EliminarComida");
            //Se añaden los parametros
            cmd.AddInt("@idComida", idComida);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }


        //Obtener campos para listarlos en las funciones relacionadas a comida
        public static ComidaBEforList ObtenerCamposComida(TablaValores tv)
        {
            ComidaBEforList comida = new ComidaBEforList
            {
                idComida = tv.GetInt("idComida"),
                nombreComida = tv.GetString("nombreComida"),
                nombreCategoria = tv.GetString("nombreCategoria"),
                precio = tv.GetDouble("precio"),
                costo = tv.GetDouble("costo"),
                imagen = tv.GetString("imagen"),
                fechaCreacion = tv.GetDateTime("fechaCreacion"),
                estado = tv.GetString("estado")
            };
            return comida;
        }


    }
}
