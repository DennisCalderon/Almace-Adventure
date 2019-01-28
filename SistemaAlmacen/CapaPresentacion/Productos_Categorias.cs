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
    public partial class Productos_Categorias : Form
    {
        CN_Productos productos = new CN_Productos();
        public Productos_Categorias()
        {
            InitializeComponent();
        }

        private void Productos_Categorias_Load(object sender, EventArgs e)
        {
            CargarForm();
        }
        private void CargarForm()
        {
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = productos.ObteneCategoriProductos();

            dgvCategorias.Columns[0].HeaderText = "Código";        // "IdCatProd"
            dgvCategorias.Columns[0].Width = 40;
            dgvCategorias.Columns[1].HeaderText = "Nombre";       // "NombreCatProd"
            dgvCategorias.Columns[1].Width = 152;
            
            txtCod.Text = dgvCategorias.Rows[dgvCategorias.RowCount - 1].Cells[0].Value.ToString();
            txtNombre.Text = dgvCategorias.Rows[dgvCategorias.RowCount - 1].Cells[1].Value.ToString();

            dgvCategorias.ClearSelection();
            dgvCategorias.Rows[dgvCategorias.RowCount - 1].Selected = true;

            botones(true);
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            txtCod.Text = dgvCategorias.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgvCategorias.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        public void botones(Boolean x)
        {
            btnNuevo.Enabled = x;
            btnEditar.Enabled = x;
            btnGuardar.Enabled = !x;
            btnCancelar.Enabled = !x;
            txtNombre.Enabled = !x;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            botones(false);
            txtCod.Text = "";
            txtNombre.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            botones(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {            
            if(txtCod.Text == "")
            {
                //MessageBox.Show("Guardar");
                try
                {
                    productos.Insert_Categorias(txtNombre.Text);
                    MessageBox.Show("Datos actualizados", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    botones(true);
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
                    productos.Update_Categorias(txtCod.Text, txtNombre.Text);
                    MessageBox.Show("Datos actualizados", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    botones(true);
                    CargarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            botones(true);
            CargarForm();
        }

        private void dgvCategorias_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
