using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Login
    {
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        public List<string> ConsultarUser(string CuentaUsuario, string PasswordUsuario)
        {
            List<string> datosUsuarios = new List<string>();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Login";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_CuentaUsuario", CuentaUsuario);
            comando.Parameters.AddWithValue("_PasswordUsuario", PasswordUsuario);
            leer = comando.ExecuteReader();

            if (leer.Read())
            {
                datosUsuarios.Add("1");
                datosUsuarios.Add(leer.GetString("cuenta"));
                datosUsuarios.Add(leer.GetString("descripcion"));                
            }
            else
            {
                datosUsuarios.Add("0");
            }
            conexion.CerrarConexion();
            return datosUsuarios;

        }
    }
}
