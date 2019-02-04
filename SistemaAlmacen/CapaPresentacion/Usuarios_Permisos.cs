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
    public partial class Usuarios_Permisos : Form
    {
        CN_Usuarios usuarios = new CN_Usuarios();
        public int BarraNavNum;

        public Usuarios_Permisos()
        {
            InitializeComponent();
        }

        private void cboTiposUser_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataTable data = usuarios.MostrarUsuariosTipos();

                cboTiposUser.DisplayMember = "descripciontipouser";
                cboTiposUser.ValueMember = "idtipouser";
                cboTiposUser.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar los datos por: " + ex, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void VerDatos(List<string> datos)
        {
            txtID.Text = datos.ElementAt(0);
            cboTiposUser.Text = datos.ElementAt(1);
            txtCuenta.Text = datos.ElementAt(2);
            txtNombres.Text = datos.ElementAt(3);
            txtApellidos.Text = datos.ElementAt(4);

            chkProductos.Checked = Convert.ToBoolean(datos.ElementAt(5));
            chkIngresos.Checked = Convert.ToBoolean(datos.ElementAt(6));
            chkSalidas.Checked = Convert.ToBoolean(datos.ElementAt(7));
            chkSolicitudes.Checked = Convert.ToBoolean(datos.ElementAt(8));
            chkReportes.Checked = Convert.ToBoolean(datos.ElementAt(9));
            chkUsuarios.Checked = Convert.ToBoolean(datos.ElementAt(10));
        }
        private void Usuarios_Permisos_Load(object sender, EventArgs e)
        {
            ultimo();
            ChkControl(false);
            BtnControl(true);
        }
        private void BarraNav1(Boolean x)
        {
            btnPrimero.Enabled = x;
            btnAnterior.Enabled = x;
        }
        private void BarraNav2(Boolean x)
        {
            btnUltimo.Enabled = x;
            btnSiguiente.Enabled = x;
        }
        private void ultimo()
        {
            List<string> datos = new List<string>();
            datos = usuarios.Btn_PU_Ultimo();
            BarraNavNum = Convert.ToInt32(datos.ElementAt(0));
            VerDatos(datos);
            BarraNav1(true); BarraNav2(false);
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            ultimo();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            List<string> datos = new List<string>();
            datos = usuarios.Btn_PU_Primero();
            VerDatos(datos);
            BarraNav1(false); BarraNav2(true);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            CN_Usuarios usuarios1 = new CN_Usuarios();
            List<string> datos = new List<string>();
            datos = usuarios1.Btn_PU_Anterior(txtID.Text);
            VerDatos(datos);
            if (Convert.ToInt32(txtID.Text) == 1) { BarraNav1(false); BarraNav2(true); }
            if (Convert.ToInt32(txtID.Text) != 1) { BarraNav1(true); BarraNav2(true); }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            CN_Usuarios usuarios2 = new CN_Usuarios();
            List<string> datos = new List<string>();
            datos = usuarios2.Btn_PU_Siguiente(txtID.Text);
            VerDatos(datos);
            if (Convert.ToInt32(txtID.Text) == BarraNavNum) { BarraNav1(true); BarraNav2(false); }
            if (Convert.ToInt32(txtID.Text) != BarraNavNum) { BarraNav1(true); BarraNav2(true); }
        }
        private void ChkControl(Boolean x)
        {
            chkProductos.Enabled = x;
            chkIngresos.Enabled = x;
            chkSalidas.Enabled = x;
            chkSolicitudes.Enabled = x;
            chkReportes.Enabled = x;
            chkUsuarios.Enabled = x;
        }
        private void BtnControl(Boolean x)
        {
            btnEditar.Enabled = x;
            btnGuardar.Enabled = !x;
            btnCancelar.Enabled = !x;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            BtnControl(false);
            ChkControl(true);
            BarraNav1(false); BarraNav2(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BtnControl(true);
            ChkControl(false);
            try
            {
                usuarios.Update_Usuarios_Permisos(txtID.Text,chkProductos.Checked, chkIngresos.Checked, chkSalidas.Checked, chkSolicitudes.Checked, chkReportes.Checked, chkUsuarios.Checked);
                MessageBox.Show("Datos actualizados", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo editar los datos por: " + ex, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (Convert.ToInt32(txtID.Text) == 1) { BarraNav1(false); BarraNav2(true); }
            else if(Convert.ToInt32(txtID.Text) == BarraNavNum) { BarraNav1(true); BarraNav2(false); }
            else { BarraNav1(true); BarraNav2(true); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            BtnControl(true);
            ChkControl(false);
            if (Convert.ToInt32(txtID.Text) == 1) { BarraNav1(false); BarraNav2(true); }
            else if (Convert.ToInt32(txtID.Text) == BarraNavNum) { BarraNav1(true); BarraNav2(false); }
            else { BarraNav1(true); BarraNav2(true); }
        }
    }
}
