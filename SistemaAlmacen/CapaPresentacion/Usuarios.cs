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
    public partial class Usuarios : Form
    {
        CN_Usuarios usuarios = new CN_Usuarios();
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarForm();
            activar(true);
        }

        private void CargarForm()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarios.MostrarUsuarios();

            dgvUsuarios.Columns[0].HeaderText = "ID";       // "IdUsuario"
            dgvUsuarios.Columns[0].Width = 30;
            dgvUsuarios.Columns[1].HeaderText = "Tipo";       // "IdTipoUser"
            dgvUsuarios.Columns[1].Width = 80;
            dgvUsuarios.Columns[2].HeaderText = "Cuenta";  // "CuentaUsuario"
            dgvUsuarios.Columns[2].Width = 80;
            dgvUsuarios.Columns[3].HeaderText = "Contraseña";        // "PasswordUsuario"
            dgvUsuarios.Columns[3].Width = 20;
            dgvUsuarios.Columns[3].Visible = false;
            dgvUsuarios.Columns[4].HeaderText = "DNI";       // "DNIUsuario"
            dgvUsuarios.Columns[4].Width = 80;
            dgvUsuarios.Columns[5].HeaderText = "Nombres";        // "NombreUsuario"
            dgvUsuarios.Columns[5].Width = 100;
            dgvUsuarios.Columns[6].HeaderText = "Apellidos";       // "ApellidoUsuario"
            dgvUsuarios.Columns[6].Width = 100;
            dgvUsuarios.Columns[7].HeaderText = "Teléfono";       // "TelefonoUsuario"
            dgvUsuarios.Columns[7].Width = 70;
            dgvUsuarios.Columns[8].HeaderText = "Correo";  // "CorreoUsuario"
            dgvUsuarios.Columns[8].Width = 150;
            dgvUsuarios.Columns[9].HeaderText = "Dirección";        // "DireccionUsuario"
            dgvUsuarios.Columns[9].Width = 250;
            dgvUsuarios.Columns[10].HeaderText = "Comentario";       // "ComentarioUsuario"
            dgvUsuarios.Columns[10].Width = 180;

            txtID.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[0].Value.ToString();
            cboTiposUser.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[1].Value.ToString();
            txtCuenta.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[2].Value.ToString();
            txtPass.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[3].Value.ToString();
            txtDNI.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[4].Value.ToString();
            txtNombres.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[5].Value.ToString();
            txtApellidos.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[6].Value.ToString();
            txtTelefono.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[7].Value.ToString();
            txtCorreo.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[8].Value.ToString();
            txtDireccion.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[9].Value.ToString();
            txtObs.Text = dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Cells[10].Value.ToString();

            dgvUsuarios.ClearSelection();
            dgvUsuarios.Rows[dgvUsuarios.RowCount - 1].Selected = true;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            txtID.Text = dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
            cboTiposUser.Text = dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCuenta.Text = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPass.Text = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDNI.Text = dgvUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtNombres.Text = dgvUsuarios.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtApellidos.Text = dgvUsuarios.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtTelefono.Text = dgvUsuarios.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtCorreo.Text = dgvUsuarios.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtDireccion.Text = dgvUsuarios.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtObs.Text = dgvUsuarios.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void dgvUsuarios_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void activar(Boolean x)
        {
            btnNuevo.Enabled = x;
            btnEditar.Enabled = x;
            btnGuardar.Enabled = !x;
            btnCancelar.Enabled = !x;

            cboTiposUser.Enabled = !x;
            txtCuenta.Enabled = !x;
            txtPass.Enabled = !x;
            txtDNI.Enabled = !x;
            txtNombres.Enabled = !x;
            txtApellidos.Enabled = !x;
            txtTelefono.Enabled = !x;
            txtCorreo.Enabled = !x;
            txtDireccion.Enabled = !x;
            txtObs.Enabled = !x;

            dgvUsuarios.Enabled = x;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            activar(false);
            txtID.Text = "";
            cboTiposUser.Text = "";
            txtCuenta.Text = "";
            txtPass.Text = "";
            txtDNI.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtObs.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            activar(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(cboTiposUser.Text != "" && txtCuenta.Text != "" && txtPass.Text != "" && txtDNI.Text != "" && txtTelefono.Text != "")
            {
                if (txtID.Text == "")
                {
                    //MessageBox.Show("Guardar");
                    try
                    {
                        usuarios.Insert_Productos(cboTiposUser.Text, txtCuenta.Text, txtPass.Text, txtDNI.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtCorreo.Text, txtDireccion.Text, txtObs.Text);
                        MessageBox.Show("Datos actualizados", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        activar(true);
                        CargarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo guardar los datos por: " + ex, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    //MessageBox.Show("Editar");
                    try
                    {
                        usuarios.Update_Productos(txtID.Text, cboTiposUser.Text, txtCuenta.Text, txtPass.Text, txtDNI.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtCorreo.Text, txtDireccion.Text, txtObs.Text);
                        MessageBox.Show("Datos actualizados", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        activar(true);
                        CargarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo editar los datos por: " + ex, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe de llenar los Datos de : Cuenta, Contraseña, DNI y Teléfono ", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            activar(true);
            CargarForm();
        }
    }
}
