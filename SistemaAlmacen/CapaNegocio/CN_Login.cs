using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
    public class CN_Login
    {
        private CD_Login login = new CD_Login();

        public List<string> ConsultarUser(string CuentaUsuario, string PasswordUsuario)
        {
            List<string> datosUsuarios = new List<string>();
            datosUsuarios = login.ConsultarUser(CuentaUsuario, PasswordUsuario);
            return datosUsuarios;
        }
        public List<string> ConsultarPermisosUser(string CuentaUsuario)
        {
            List<string> PermisosUsuarios = new List<string>();
            PermisosUsuarios = login.ConsultarPermisosUser(CuentaUsuario);
            return PermisosUsuarios;
        }
    }
}
