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
    }
}
