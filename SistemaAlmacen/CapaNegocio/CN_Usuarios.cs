using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        CD_Usuarios usuarios = new CD_Usuarios();

        public DataTable MostrarUsuarios()
        {
            DataTable tabla = new DataTable();
            tabla = usuarios.MostrarUsuarios();
            return tabla;
        }
        public void Update_Productos(string IdUsuario, string descripciontipouser, string CuentaUsuario, string PasswordUsuario, string DNIUsuario, string NombreUsuario, string ApellidoUsuario, string TelefonoUsuario, string CorreoUsuario, string DireccionUsuario, string ComentarioUsuario)
        {
            usuarios.Update_Usuarios(Convert.ToInt32(IdUsuario), descripciontipouser, CuentaUsuario, PasswordUsuario,Convert.ToInt32(DNIUsuario), NombreUsuario, ApellidoUsuario, TelefonoUsuario, CorreoUsuario, DireccionUsuario, ComentarioUsuario);
        }
        public void Insert_Productos(string descripciontipouser, string CuentaUsuario, string PasswordUsuario, string DNIUsuario, string NombreUsuario, string ApellidoUsuario, string TelefonoUsuario, string CorreoUsuario, string DireccionUsuario, string ComentarioUsuario)
        {
            usuarios.Insert_Usuarios(descripciontipouser, CuentaUsuario, PasswordUsuario, Convert.ToInt32(DNIUsuario), NombreUsuario, ApellidoUsuario, TelefonoUsuario, CorreoUsuario, DireccionUsuario, ComentarioUsuario);
        }
    }
}
