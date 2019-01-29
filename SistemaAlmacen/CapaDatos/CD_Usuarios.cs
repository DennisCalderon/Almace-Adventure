using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        public DataTable MostrarUsuarios()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Mostrar_Usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Update_Usuarios(int IdUsuario, string descripciontipouser, string CuentaUsuario, string PasswordUsuario, int DNIUsuario, string NombreUsuario, string ApellidoUsuario, string TelefonoUsuario, string CorreoUsuario, string DireccionUsuario, string ComentarioUsuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update_Usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("_descripciontipouser", descripciontipouser);
            comando.Parameters.AddWithValue("_CuentaUsuario", CuentaUsuario);
            comando.Parameters.AddWithValue("_PasswordUsuario", PasswordUsuario);
            comando.Parameters.AddWithValue("_DNIUsuario", DNIUsuario);
            comando.Parameters.AddWithValue("_NombreUsuario", NombreUsuario);
            comando.Parameters.AddWithValue("_ApellidoUsuario", ApellidoUsuario);
            comando.Parameters.AddWithValue("_TelefonoUsuario", TelefonoUsuario);
            comando.Parameters.AddWithValue("_CorreoUsuario", CorreoUsuario);
            comando.Parameters.AddWithValue("_DireccionUsuario", DireccionUsuario);
            comando.Parameters.AddWithValue("_ComentarioUsuario", ComentarioUsuario);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Insert_Usuarios(string descripciontipouser, string CuentaUsuario, string PasswordUsuario, int DNIUsuario, string NombreUsuario, string ApellidoUsuario, string TelefonoUsuario, string CorreoUsuario, string DireccionUsuario, string ComentarioUsuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insert_Usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_descripciontipouser", descripciontipouser);
            comando.Parameters.AddWithValue("_CuentaUsuario", CuentaUsuario);
            comando.Parameters.AddWithValue("_PasswordUsuario", PasswordUsuario);
            comando.Parameters.AddWithValue("_DNIUsuario", DNIUsuario);
            comando.Parameters.AddWithValue("_NombreUsuario", NombreUsuario);
            comando.Parameters.AddWithValue("_ApellidoUsuario", ApellidoUsuario);
            comando.Parameters.AddWithValue("_TelefonoUsuario", TelefonoUsuario);
            comando.Parameters.AddWithValue("_CorreoUsuario", CorreoUsuario);
            comando.Parameters.AddWithValue("_DireccionUsuario", DireccionUsuario);
            comando.Parameters.AddWithValue("_ComentarioUsuario", ComentarioUsuario);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public DataTable MostrarUsuariosTipos()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Mostrar_Usuarios_Tipos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public List<string> Btn_PU_Ultimo()
        {
            List<string> datos = new List<string>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Btn_PU_Ultimo";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();

            if (leer.Read())
            {
                datos.Add(leer.GetString("IdUsuario"));
                datos.Add(leer.GetString("DescripcionTipoUser"));
                datos.Add(leer.GetString("CuentaUsuario"));
                datos.Add(leer.GetString("NombreUsuario"));
                datos.Add(leer.GetString("ApellidoUsuario"));
                datos.Add(leer.GetString("PerProductos"));
                datos.Add(leer.GetString("PerIngresos"));
                datos.Add(leer.GetString("PerSalidas"));
                datos.Add(leer.GetString("PerSolicitudes"));
                datos.Add(leer.GetString("PerReportes"));
                datos.Add(leer.GetString("PerUsuarios"));
            }
            conexion.CerrarConexion();
            return datos;
        }
        public List<string> Btn_PU_Primero()
        {
            List<string> datos = new List<string>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Btn_PU_Primero";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();

            if (leer.Read())
            {
                datos.Add(leer.GetString("IdUsuario"));
                datos.Add(leer.GetString("DescripcionTipoUser"));
                datos.Add(leer.GetString("CuentaUsuario"));
                datos.Add(leer.GetString("NombreUsuario"));
                datos.Add(leer.GetString("ApellidoUsuario"));
                datos.Add(leer.GetString("PerProductos"));
                datos.Add(leer.GetString("PerIngresos"));
                datos.Add(leer.GetString("PerSalidas"));
                datos.Add(leer.GetString("PerSolicitudes"));
                datos.Add(leer.GetString("PerReportes"));
                datos.Add(leer.GetString("PerUsuarios"));
            }
            conexion.CerrarConexion();
            return datos;
        }
        public List<string> Btn_PU_Anterior(int IdUsuario)
        {
            List<string> datos = new List<string>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Btn_PU_Anterior";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_IdUsuario", IdUsuario);
            leer = comando.ExecuteReader();

            if (leer.Read())
            {
                datos.Add(leer.GetString("IdUsuario"));
                datos.Add(leer.GetString("DescripcionTipoUser"));
                datos.Add(leer.GetString("CuentaUsuario"));
                datos.Add(leer.GetString("NombreUsuario"));
                datos.Add(leer.GetString("ApellidoUsuario"));
                datos.Add(leer.GetString("PerProductos"));
                datos.Add(leer.GetString("PerIngresos"));
                datos.Add(leer.GetString("PerSalidas"));
                datos.Add(leer.GetString("PerSolicitudes"));
                datos.Add(leer.GetString("PerReportes"));
                datos.Add(leer.GetString("PerUsuarios"));
            }
            conexion.CerrarConexion();
            return datos;
        }
        public List<string> Btn_PU_Siguiente(int IdUsuario)
        {
            List<string> datos = new List<string>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Btn_PU_Siguiente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_IdUsuario", IdUsuario);
            leer = comando.ExecuteReader();

            if (leer.Read())
            {
                datos.Add(leer.GetString("IdUsuario"));
                datos.Add(leer.GetString("DescripcionTipoUser"));
                datos.Add(leer.GetString("CuentaUsuario"));
                datos.Add(leer.GetString("NombreUsuario"));
                datos.Add(leer.GetString("ApellidoUsuario"));
                datos.Add(leer.GetString("PerProductos"));
                datos.Add(leer.GetString("PerIngresos"));
                datos.Add(leer.GetString("PerSalidas"));
                datos.Add(leer.GetString("PerSolicitudes"));
                datos.Add(leer.GetString("PerReportes"));
                datos.Add(leer.GetString("PerUsuarios"));
            }
            conexion.CerrarConexion();
            return datos;
        }
        public void Update_Usuarios_Permisos(int IdUsuario, Boolean PerProductos, Boolean PerIngresos, Boolean PerSalidas, Boolean PerSolicitudes, Boolean PerReportes, Boolean PerUsuarios)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update_Usuarios_Permisos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("_PerProductos", PerProductos);
            comando.Parameters.AddWithValue("_PerIngresos", PerIngresos);
            comando.Parameters.AddWithValue("_PerSalidas", PerSalidas);
            comando.Parameters.AddWithValue("_PerSolicitudes", PerSolicitudes);
            comando.Parameters.AddWithValue("_PerReportes", PerReportes);
            comando.Parameters.AddWithValue("_PerUsuarios", PerUsuarios);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
