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
    public partial class Principal : Form
    {
        public Principal(string cuentaUsuario = "default", string tipoUsuario = "default")
        {
            InitializeComponent();
            tstlUser.Text = cuentaUsuario;
            tstlTipoUser.Text = tipoUsuario;

            try
            {
                CN_Login obj = new CN_Login();
                List<string> datosUsuarios = new List<string>();
                datosUsuarios = obj.ConsultarPermisosUser(cuentaUsuario);
                //MessageBox.Show(datosUsuarios.ElementAt(1));
                //MessageBox.Show("0");
                //MessageBox.Show(datosUsuarios.ElementAt(2));

                if (Convert.ToBoolean(datosUsuarios.ElementAt(1)) == true) { tsmiProductos.Enabled = true; tsmiProductos.Visible = true; }
                else { tsmiProductos.Enabled = false; tsmiProductos.Visible = false; }

                if (Convert.ToBoolean(datosUsuarios.ElementAt(2)) == true) { tsmiIngresos.Enabled = true; tsmiIngresos.Visible = true; }
                else { tsmiIngresos.Enabled = false; tsmiIngresos.Visible = false; }

                if (Convert.ToBoolean(datosUsuarios.ElementAt(3)) == true) { tsmiSalidas.Enabled = true; tsmiSalidas.Visible = true; }
                else { tsmiSalidas.Enabled = false; tsmiSalidas.Visible = false; }

                if (Convert.ToBoolean(datosUsuarios.ElementAt(4)) == true) { tsmiSolicitudes.Enabled = true; tsmiSolicitudes.Visible = true; }
                else { tsmiSolicitudes.Enabled = false; tsmiSolicitudes.Visible = false; }

                if (Convert.ToBoolean(datosUsuarios.ElementAt(5)) == true) { tsmiReportes.Enabled = true; tsmiReportes.Visible = true; }
                else { tsmiReportes.Enabled = false; tsmiReportes.Visible = false; }

                if (Convert.ToBoolean(datosUsuarios.ElementAt(6)) == true) { UsuariosToolStripMenuItem.Enabled = true; UsuariosToolStripMenuItem.Visible = true; }
                else { UsuariosToolStripMenuItem.Enabled = false; UsuariosToolStripMenuItem.Visible = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, vuelva a cargar el sistema!!!");
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                CN_Productos productos1 = new CN_Productos();
                DataTable data = productos1.ObteneDescripcionCategoria();

                lbCategorias.DisplayMember = "NombreCatProd";
                lbCategorias.ValueMember = "IdCatProd";
                lbCategorias.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar los datos por: " + ex, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        private void registroDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos form = new Productos();
            form.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos_Categorias form = new Productos_Categorias();
            form.ShowDialog();
        }

        private void tsmiSoporte_Click(object sender, EventArgs e)
        {
            Soporte form = new Soporte();
            form.ShowDialog();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios form = new Usuarios();
            form.ShowDialog();
        }
    }
}
