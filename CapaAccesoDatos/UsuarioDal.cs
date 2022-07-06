using CapaEntidades;
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
    public class UsuarioDal
    {

        // Crear Usuario
        public bool Add(UsuarioBe obj)
        {
            obj.contrasenia= DalUtil.GetSHA256(obj.contrasenia);
            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_CrearUsuario");
            //Se añaden los parametros
            cmd.AddInt("@idRestaurante", obj.idRestaurante);
            cmd.AddInt("@idRol", obj.idRol);
            cmd.AddSring("@usuario", obj.usuario);
            cmd.AddSring("@nombreUsuario", obj.nombreUsuario);
            cmd.AddSring("@contrasenia", obj.contrasenia);
            cmd.AddSring("@nroCelular", obj.nroCelular);
            cmd.AddSring("@correoElectronico", obj.correoElectronico);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }

        //Listar Usuarios
        public List<UsuarioBEforList> List()
        {

            DataTable dt = DalUtil.LlenarTabla("usp_ListarUsuarios");

            List<UsuarioBEforList> lstUsuarios = new List<UsuarioBEforList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstUsuarios.Add(ObtenerCamposUsuario(new TablaValores(dt.Rows[i])));
            }
            return lstUsuarios;
        }

        //Listar 1 Usuario
        public UsuarioBEforList List(int idUsuario)
        {
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ListarUsuario");
            cmd.AddInt("@idUsuario", idUsuario);

            DataTable dt = cmd.EjecutarTabla();
            UsuarioBEforList usuario = new UsuarioBEforList();

            if(dt.Rows.Count > 0)
            {
                usuario = ObtenerCamposUsuario(new TablaValores(dt.Rows[0]));
            }

            return usuario;
        }

        //Actualizar Usuario
        public bool Update(UsuarioBEforUpdate obj)
        {
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ActualizarUsuario");
            cmd.AddInt("@idUsuario", obj.idUsuario);
            cmd.AddInt("@idRestaurante", obj.idRestaurante);
            cmd.AddInt("@idRol", obj.idRol);
            cmd.AddSring("@usuario", obj.usuario);
            cmd.AddSring("@nombreUsuario", obj.nombreUsuario);
            cmd.AddSring("@contrasenia", obj.contrasenia);
            cmd.AddSring("@nroCelular", obj.nroCelular);
            cmd.AddSring("@correoElectronico", obj.correoElectronico);

            return cmd.Ejecutar();
        }

        //Actualizar ultimo login
        public bool UpdateLastLogin(int idUsuario)
        {
            ComandoSqlDF cmd = new ComandoSqlDF("usp_ActualizarUltimoLoginUsuario");
            cmd.AddInt("@idUsuario", idUsuario);

            return cmd.Ejecutar();
        }

        //Borrado DE USUARIO
        public bool Delete(int idUsuario)
        {
            ComandoSqlDF cmd = new ComandoSqlDF("usp_EliminarUsuario");
            cmd.AddInt("@idUsuario", idUsuario);

            return cmd.Ejecutar();
        }


        public UsuarioBEforList ObtenerCamposUsuario(TablaValores tv)
        {
            UsuarioBEforList usuario = new UsuarioBEforList
            {
                idUsuario = tv.GetInt("idUsuario"),
                nombreLocal = tv.GetString("nombreLocal"),
                nombreRol = tv.GetString("nombreRol"),
                usuario = tv.GetString("usuario"),
                nombreUsuario = tv.GetString("nombreUsuario"),
                contrasenia = tv.GetString("contrasenia"),
                nroCelular = tv.GetString("nroCelular"),
                correoElectronico = tv.GetString("correoElectronico"),
                fechaCreacion = tv.GetDateTime("fechaCreacion"),
                ultimoLogin = tv.GetDateTime("ultimoLogin")
            };
            return usuario;
        }
    }
}
