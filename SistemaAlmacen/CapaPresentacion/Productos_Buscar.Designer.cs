namespace CapaPresentacion
{
    partial class Productos_Buscar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCod = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.dgvProductosBuscar = new System.Windows.Forms.DataGridView();
            this.btnMandar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(61, 10);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(197, 20);
            this.txtCod.TabIndex = 54;
            this.txtCod.TextChanged += new System.EventHandler(this.txtCod_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 13);
            this.Label1.TabIndex = 53;
            this.Label1.Text = "Buscar :";
            // 
            // dgvProductosBuscar
            // 
            this.dgvProductosBuscar.AllowUserToAddRows = false;
            this.dgvProductosBuscar.AllowUserToDeleteRows = false;
            this.dgvProductosBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosBuscar.Location = new System.Drawing.Point(12, 37);
            this.dgvProductosBuscar.MultiSelect = false;
            this.dgvProductosBuscar.Name = "dgvProductosBuscar";
            this.dgvProductosBuscar.ReadOnly = true;
            this.dgvProductosBuscar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductosBuscar.Size = new System.Drawing.Size(377, 299);
            this.dgvProductosBuscar.TabIndex = 55;
            this.dgvProductosBuscar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            this.dgvProductosBuscar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            this.dgvProductosBuscar.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvProductos_ColumnAdded);
            // 
            // btnMandar
            // 
            this.btnMandar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMandar.Location = new System.Drawing.Point(277, 8);
            this.btnMandar.Name = "btnMandar";
            this.btnMandar.Size = new System.Drawing.Size(75, 23);
            this.btnMandar.TabIndex = 56;
            this.btnMandar.Text = "Mandar";
            this.btnMandar.UseVisualStyleBackColor = true;
            this.btnMandar.Click += new System.EventHandler(this.btnMandar_Click);
            // 
            // Productos_Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 347);
            this.Controls.Add(this.btnMandar);
            this.Controls.Add(this.dgvProductosBuscar);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Productos_Buscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos_Buscar";
            this.Load += new System.EventHandler(this.Productos_Buscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtCod;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dgvProductosBuscar;
        private System.Windows.Forms.Button btnMandar;
    }
}