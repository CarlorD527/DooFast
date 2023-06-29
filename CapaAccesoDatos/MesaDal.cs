﻿using CapaEntidades.MesaEntities;
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
    public class MesaDal
    {

        //Agregar mesa
        public bool Add(MesaBePost obj)
        {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_CrearMesa");
            //Se añaden los parametros
            cmd.AddInt("@nroMesa", obj.nroMesa);
            cmd.AddInt("@idRestaurante", obj.idRestaurante);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }

        //Actualizar mesa

        //Actualizar Usuario
        public bool Update(MesaBeUpdate obj)
        {

            ComandoSqlDF cmd = new ComandoSqlDF("usp_ActualizarEstadoMesa");
            cmd.AddInt("@idMesa", obj.idMesa);
            cmd.AddInt("@nroAsientos", obj.nroAsientos);
            cmd.AddString("@estadoMesa", obj.estadoMesa);
            cmd.AddString("@idRestaurante", "1");

            bool res = cmd.Ejecutar();

            return res;
        }
        //Listar Mesas
        public List<MesaBE> listarMesas()
        {
            List<MesaBE> lstMesas = new List<MesaBE>();

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_listarMesas");

            //Se ejecuta el comando y se devuelve el resultado
            DataTable tablaMesas = cmd.EjecutarTabla();
            for (int i = 0; i < tablaMesas.Rows.Count; i++)
            {
                lstMesas.Add(
                    ObtenerCamposMesa(
                        new TablaValores(tablaMesas.Rows[i])
                    )
                );
            }
            return lstMesas;
        }

        //Borrar mesa
        public bool Delete(int idMesas)
        {

            //Se crea un nuevo comando sql
            ComandoSqlDF cmd = new ComandoSqlDF("usp_BorrarMesa");
            //Se añaden los parametros
            cmd.AddInt("@nroMesa", idMesas);

            //Se ejecuta el comando y se devuelve el resultado
            return cmd.Ejecutar();
        }

        public static MesaBE ObtenerCamposMesa(TablaValores tv)
        {
            MesaBE comida = new MesaBE
            {
                idMesa = tv.GetInt("idMesa"),
                estadoMesa = tv.GetString("estadoMesa"),
                nroMesa = tv.GetInt("nroMesa"),
                IdRestaurante = tv.GetInt("IdRestaurante")
            };
            return comida;
        }

    }
}
