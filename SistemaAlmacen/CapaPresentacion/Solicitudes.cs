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
    public partial class Solicitudes : Form
    {
        public int BarraNavNum;

        CN_Solicitudes solicitudes = new CN_Solicitudes();

        public Solicitudes( string user = "Default")
        {
            InitializeComponent();
            tsslUser.Text = user;
        }

        private void Solicitudes_Load(object sender, EventArgs e)
        {
            Botones(true);
            ultimo();
        }
        private void VerDatos(List<string> datos)
        {
            txtCod.Text = datos.ElementAt(0);
            dtpFecha.Text = datos.ElementAt(1);
            txtCantidadItems.Text = datos.ElementAt(2);
            txtUser.Text = datos.ElementAt(3);
            txtEstado.Text = datos.ElementAt(4);
        }


        private void Botones(Boolean x)
        {
            btnNuevo.Enabled = x;
            btnEditar.Enabled = x;
            btnGuardar.Enabled = !x;
            btnCancelar.Enabled = !x;
            btnAgregar.Enabled = !x;
            btnQuitar.Enabled = !x;
        }

        private void Nav1(Boolean x)
        {
            btnPrimero.Enabled = x;
            btnAnterior.Enabled = x;
        }

        private void Nav2(Boolean x)
        {
            btnSiguiente.Enabled = x;
            btnUltimo.Enabled = x;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botones(false);
            Nav1(false); Nav2(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botones(false);
            Nav1(false); Nav2(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Botones(true);
            if(Convert.ToInt32(txtCod.Text) == 1) { Nav1(false); Nav2(true); }
            else if (Convert.ToInt32(txtCod.Text) == BarraNavNum) { Nav1(true); Nav2(false); }
            else { Nav1(true); Nav2(true); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Botones(true);
            if (Convert.ToInt32(txtCod.Text) == 1) { Nav1(false); Nav2(true); }
            else if (Convert.ToInt32(txtCod.Text) == BarraNavNum) { Nav1(true); Nav2(false); }
            else { Nav1(true); Nav2(true); }
        }
        private void ultimo()
        {            
            List<string> datos = new List<string>();
            datos = solicitudes.Btn_Solicitudes_Ultimo();
            BarraNavNum = Convert.ToInt32(datos.ElementAt(0));
            VerDatos(datos);
            Nav1(true); Nav2(false);
            MostrarGrid(txtCod.Text);
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            ultimo();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            List<string> datos = new List<string>();
            datos = solicitudes.Btn_Solicitudes_Primero();
            BarraNavNum = Convert.ToInt32(datos.ElementAt(0));
            VerDatos(datos);
            Nav1(false); Nav2(true);
            MostrarGrid(txtCod.Text);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            CN_Solicitudes solicitudes1 = new CN_Solicitudes();
            List<string> datos = new List<string>();
            datos = solicitudes1.Btn_PU_Anterior(txtCod.Text);
            VerDatos(datos);
            if (Convert.ToInt32(txtCod.Text) == 1) { Nav1(false); Nav2(true); }
            if (Convert.ToInt32(txtCod.Text) != 1) { Nav1(true); Nav2(true); }
            MostrarGrid(txtCod.Text);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            CN_Solicitudes solicitudes2 = new CN_Solicitudes();
            List<string> datos = new List<string>();
            datos = solicitudes2.Btn_Solicitudes_Siguiente(txtCod.Text);
            VerDatos(datos);
            if (Convert.ToInt32(txtCod.Text) == BarraNavNum) { Nav1(true); Nav2(false); }
            if (Convert.ToInt32(txtCod.Text) != BarraNavNum) { Nav1(true); Nav2(true); }
            MostrarGrid(txtCod.Text);
        }

        private void MostrarGrid(string CodSolicitud)
        {
            try
            {
                dgvProductos.DataSource = null;
                CN_Solicitudes solicitudesrid = new CN_Solicitudes();
                dgvProductos.DataSource = solicitudesrid.Read_Solicitud_Detalle(CodSolicitud);
                dgvProductos.Columns[0].HeaderText = "Categoría";       // "NombreCatProd"
                dgvProductos.Columns[0].Width = 145;
                dgvProductos.Columns[1].HeaderText = "Descripción";       // "DescripcionProd"
                dgvProductos.Columns[1].Width = 145;
                dgvProductos.Columns[2].HeaderText = "Cantidad";       // "CantProd"
                dgvProductos.Columns[2].Width = 75;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar los datos por: " + ex, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Productos_Agregar_Solicitud buscar = new Productos_Agregar_Solicitud();
            DialogResult res = buscar.ShowDialog(); //abrimos el formulario 2 como cuadro de dialogo modal

            if (res == DialogResult.OK)
            {
                AgregarGrid();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            //dgvProductos.Rows.Add("prueba", "prueba", "2");
            
        }
        public void AgregarGrid()
        {
            DataTable dataTable = (DataTable)dgvProductos.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            drToAdd["NombreCatProd"] = "Value1";
            drToAdd["DescripcionProd"] = "Value2";
            drToAdd["CantProd"] = "3";

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();
        }
    }
}
