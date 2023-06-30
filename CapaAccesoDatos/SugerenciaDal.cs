using CapaEntidades;
using CapaEntidades.SugerenciaBE;
using CapaEntidades.UsuarioEntities;
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
    // CREAR PEDIDO [TOMAR PEDIDO]
    public class SugerenciaDal
    {

        public bool Add(SugerenciaBE obj)
        {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_CrearSugerencia");
            //Se añaden los parametros
            cmd.AddString("@titulo", obj.titulo);
            cmd.AddString("@descripcion", obj.descripcion);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }

        public List<SugerenciaBEforList> Listar()
        {

            List<SugerenciaBEforList> lstSugerencias = new List<SugerenciaBEforList>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarSugerencias");
            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaSugerencias = cmd.EjecutarTabla();
            for (int i = 0; i < tablaSugerencias.Rows.Count; i++)
            {
                TablaValores tv = new TablaValores(tablaSugerencias.Rows[i]);
                lstSugerencias.Add(
                    new SugerenciaBEforList
                    {
                        idSugerencia = tv.GetInt("idSugerencia"),
                        titulo = tv.GetString("titulo"),
                        descripcion = tv.GetString("descripcion"),
                        estado = tv.GetString("estado")
                    }
                );
            }
            return lstSugerencias;
        }

        public SugerenciaBEforList Listar(int idSugerencia)
        {
            SugerenciaBEforList sugerencia = new SugerenciaBEforList();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ObtenerSugerencia");
            //Se añaden los parametros
            cmd.AddInt("@idSugerencia", idSugerencia);
            //Se ejecuta el comando y se devuelve el resultado
            DataTable dt = cmd.EjecutarTabla();
            if (dt.Rows.Count > 0)
            {
                TablaValores tv = new TablaValores(dt.Rows[0]);
                sugerencia = new SugerenciaBEforList()
                {
                    idSugerencia = tv.GetInt("idSugerencia"),
                    titulo = tv.GetString("titulo"),
                    descripcion = tv.GetString("descripcion"),
                    estado = tv.GetString("estado")
                };
            }

            return sugerencia;
        }

        //actualizar estado de sugerencia
        public bool Update(SugerenciaBEforUpdate obj)
        {
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ActualizarSugerencia");
            cmd.AddInt("@idSugerencia", obj.idSugerencia);
            cmd.AddString("@estado", obj.estadoSugerencia);

            return cmd.Ejecutar();
        }
        
        //eliminar sugerencia (pasar estado a archivado)
        public bool Delete(int idSugerencia)
        {
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ActualizarSugerencia");
            cmd.AddInt("@idSugerencia", idSugerencia);
            cmd.AddString("@estado", "archivado");

            return cmd.Ejecutar();
        }

    }
}
