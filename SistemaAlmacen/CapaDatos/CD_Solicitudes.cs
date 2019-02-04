using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Solicitudes
    {
        private CD_Conexion conexion = new CD_Conexion();
        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        public List<string> Btn_Solicitudes_Ultimo()
        {
            List<string> datos = new List<string>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Btn_Solicitudes_Ultimo";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();

            if (leer.Read())
            {
                datos.Add(leer.GetString("CodSolicitud"));
                datos.Add(leer.GetString("FechaSolicitud"));
                datos.Add(leer.GetString("CantItemsSolicitud"));
                datos.Add(leer.GetString("CuentaUsuario"));
                datos.Add(leer.GetString("EstadoSolicitud"));
                //datos.Add(leer.GetString("DescripcionSolicitud"));
            }
            conexion.CerrarConexion();
            return datos;
        }
        public List<string> Btn_Solicitudes_Primero()
        {
            List<string> datos = new List<string>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Btn_Solicitudes_Primero";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();

            if (leer.Read())
            {
                datos.Add(leer.GetString("CodSolicitud"));
                datos.Add(leer.GetString("FechaSolicitud"));
                datos.Add(leer.GetString("CantItemsSolicitud"));
                datos.Add(leer.GetString("CuentaUsuario"));
                datos.Add(leer.GetString("EstadoSolicitud"));
                //datos.Add(leer.GetString("DescripcionSolicitud"));
            }
            conexion.CerrarConexion();
            return datos;
        }
        public List<string> Btn_Solicitudes_Anterior(int CodSolicitud)
        {
            List<string> datos = new List<string>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Btn_Solicitudes_Anterior";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_CodSolicitud", CodSolicitud);
            leer = comando.ExecuteReader();

            if (leer.Read())
            {
                datos.Add(leer.GetString("CodSolicitud"));
                datos.Add(leer.GetString("FechaSolicitud"));
                datos.Add(leer.GetString("CantItemsSolicitud"));
                datos.Add(leer.GetString("CuentaUsuario"));
                datos.Add(leer.GetString("EstadoSolicitud"));
            }
            conexion.CerrarConexion();
            return datos;
        }
        public List<string> Btn_Solicitudes_Siguiente(int CodSolicitud)
        {
            List<string> datos = new List<string>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Btn_Solicitudes_Siguiente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_CodSolicitud", CodSolicitud);
            leer = comando.ExecuteReader();

            if (leer.Read())
            {
                datos.Add(leer.GetString("CodSolicitud"));
                datos.Add(leer.GetString("FechaSolicitud"));
                datos.Add(leer.GetString("CantItemsSolicitud"));
                datos.Add(leer.GetString("CuentaUsuario"));
                datos.Add(leer.GetString("EstadoSolicitud"));
            }
            conexion.CerrarConexion();
            return datos;
        }
        public DataTable Read_Solicitud_Detalle(int CodSolicitud)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Read_Solicitud_Detalle";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_CodSolicitud", CodSolicitud);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
