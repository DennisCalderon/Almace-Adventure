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
    public partial class Productos_Buscar : Form
    {
        CN_Productos productos = new CN_Productos();


        public Productos_Buscar()
        {
            InitializeComponent();
        }

        private void Productos_Buscar_Load(object sender, EventArgs e)
        {
            CargarForm();
        }

        private void CargarForm()
        {
            CN_Productos productos1 = new CN_Productos();

            dgvProductosBuscar.DataSource = productos1.Read_Productos_Buscar();
            dgvProductosBuscar.Columns[0].HeaderText = "Categoría";       // "NombreCatProd"
            dgvProductosBuscar.Columns[0].Width = 130;
            dgvProductosBuscar.Columns[1].HeaderText = "Descripción";     // "DescripcionProd"
            dgvProductosBuscar.Columns[1].Width = 130;
            dgvProductosBuscar.Columns[2].HeaderText = "Stock";     // "StockProd"
            dgvProductosBuscar.Columns[2].Width = 50;
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {
            if (txtCod.Text!="" )
            {
                dgvProductosBuscar.CurrentCell = null;
                foreach (DataGridViewRow r in dgvProductosBuscar.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dgvProductosBuscar.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().ToUpper()).Contains(txtCod.Text.ToUpper()) == true)
                        {
                            r.Visible = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                CargarForm();
            }
        }

        private void dgvProductos_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            categoria = dgvProductosBuscar.Rows[e.RowIndex].Cells[0].Value.ToString();
            descripcion = dgvProductosBuscar.Rows[e.RowIndex].Cells[1].Value.ToString();
            cantidad = Convert.ToInt32(dgvProductosBuscar.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

        public string categoria, descripcion;
        public int cantidad;

        private void btnMandar_Click(object sender, EventArgs e)
        {

        }
        

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnMandar.PerformClick();
        }
    }
}
