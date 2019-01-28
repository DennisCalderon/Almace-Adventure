using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Principal : Form
    {
        public Principal(string cuentaUsuario = "default", string tipoUsuario = "default")
        {
            InitializeComponent();
            tstlUser.Text = cuentaUsuario;
            tstlTipoUser.Text = tipoUsuario;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
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
    }
}
