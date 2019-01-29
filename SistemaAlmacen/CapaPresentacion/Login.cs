using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMostrar.Checked == true) txtPassword.PasswordChar = '\0';
            if(chkMostrar.Checked == false) txtPassword.PasswordChar = '*';
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "" && txtPassword.Text !="")
            {
                try
                {
                    CN_Login obj = new CN_Login();
                    List<string> datosUsuarios = new List<string>();
                    datosUsuarios = obj.ConsultarUser(txtUser.Text, txtPassword.Text);
                    if (datosUsuarios.ElementAt(0) != "0")
                    {
                        MessageBox.Show("Bienvenido");
                        Principal form = new Principal(datosUsuarios.ElementAt(1), datosUsuarios.ElementAt(2));
                        this.Hide();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Datos incorrectos, por favor intentelo de nuevo");
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Datos incorrectos" + ex);
                }                
            }           
        }
    }
}
