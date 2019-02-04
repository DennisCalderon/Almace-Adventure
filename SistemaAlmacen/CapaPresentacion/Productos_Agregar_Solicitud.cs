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
    public partial class Productos_Agregar_Solicitud : Form
    {
        public Productos_Agregar_Solicitud()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Productos_Buscar buscar = new Productos_Buscar();
            DialogResult res = buscar.ShowDialog(); //abrimos el formulario 2 como cuadro de dialogo modal

            if (res == DialogResult.OK)
            {
                //recuperando la variable publica del formulario 2
                txtCategoria.Text = buscar.categoria; //asignamos al texbox el dato de la variable
                txtDescripcion.Text = buscar.descripcion;
                nudCantidad.Maximum = buscar.cantidad;
            }
        }

        private void nudCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (nudCantidad.Value > nudCantidad.Maximum)
            {
                MessageBox.Show("No puede sobrepasar el valor de " + nudCantidad.Maximum, "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
