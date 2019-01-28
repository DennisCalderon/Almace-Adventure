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
    public partial class Productos : Form
    {
        CN_Productos productos = new CN_Productos();
        public Productos()
        {
            InitializeComponent();
        }
        
        private void Productos_Load(object sender, EventArgs e)
        {
            CargarForm();            
        }
        public void CargarForm()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos.MostrarProductos();

            dgvProductos.Columns[0].HeaderText = "Código";       // "CodProd"
            dgvProductos.Columns[0].Width = 45;
            dgvProductos.Columns[1].HeaderText = "Nombre";       // "IdCatProd"
            dgvProductos.Columns[1].Width = 100;
            dgvProductos.Columns[2].HeaderText = "Descripción";  // "DescripcionProd"
            dgvProductos.Columns[2].Width = 100;
            dgvProductos.Columns[3].HeaderText = "Marca";        // "MarcaProd"
            dgvProductos.Columns[3].Width = 60;
            dgvProductos.Columns[4].HeaderText = "Precio";       // "PrecioProd"
            dgvProductos.Columns[4].Width = 50;
            dgvProductos.Columns[5].HeaderText = "Stock";        // "StockProd"
            dgvProductos.Columns[5].Width = 50;

            txtCod.Text = dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[0].Value.ToString();
            cboCategoria.Text = dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[1].Value.ToString();
            txtDescripcion.Text = dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[2].Value.ToString();
            txtMarca.Text = dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[3].Value.ToString();
            txtPrecio.Text = dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[4].Value.ToString();
            txtExistencias.Text = dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[5].Value.ToString();

            dgvProductos.ClearSelection();
            dgvProductos.Rows[dgvProductos.RowCount - 1].Selected = true;

            activar(true);
        }
        public void activar(Boolean x)
        {
            btnNuevo.Enabled = x;
            btnEditar.Enabled = x;
            btnGuardar.Enabled = !x;
            btnCancelar.Enabled = !x;

            cboCategoria.Enabled = !x;
            txtDescripcion.Enabled = !x;
            txtMarca.Enabled = !x;
            txtPrecio.Enabled = !x;
            txtExistencias.Enabled = !x;

            dgvProductos.Enabled = x;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCod.Text = dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
            cboCategoria.Text = dgvProductos.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDescripcion.Text = dgvProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMarca.Text = dgvProductos.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPrecio.Text = dgvProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtExistencias.Text = dgvProductos.Rows[e.RowIndex].Cells[5].Value.ToString();
            //dgvProductos.ClearSelection();
            //dgvProductos.Rows[e.RowIndex].Selected = true;
        }

        private void dgvProductos_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCod.Text = "";
            cboCategoria.Text = "";
            txtDescripcion.Text = "";
            txtMarca.Text = "";
            txtPrecio.Text = "";
            txtExistencias.Text = "";

            activar(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            activar(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text == "")
            {
                //MessageBox.Show("Guardar");
                try
                {
                    productos.Insert_Productos(cboCategoria.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtExistencias.Text);
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
                    productos.Update_Productos(txtCod.Text, cboCategoria.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtExistencias.Text);
                    MessageBox.Show("Datos actualizados", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    activar(true);
                    CargarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            activar(true);
            CargarForm();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            activar(true);
            CargarForm();
        }

        private void cboCategoria_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                CN_Productos productos1 = new CN_Productos();
                DataTable data = productos1.ObteneDescripcionCategoria();
                
                cboCategoria.DisplayMember = "NombreCatProd";
                cboCategoria.ValueMember = "IdCatProd";
                cboCategoria.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar los datos por: " + ex, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }
    }
}
