namespace AppInguiri
{
    partial class FrmServicioListar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanSuperior = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.PanInferior = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvServicio = new System.Windows.Forms.DataGridView();
            this.nIdServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodigoInterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanOpciones = new System.Windows.Forms.Panel();
            this.NdCantidad = new System.Windows.Forms.TextBox();
            this.LblCompra = new System.Windows.Forms.Label();
            this.LblMonto = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.PanSuperior.SuspendLayout();
            this.PanInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).BeginInit();
            this.PanOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanSuperior
            // 
            this.PanSuperior.BackColor = System.Drawing.Color.White;
            this.PanSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSuperior.Controls.Add(this.Label3);
            this.PanSuperior.Controls.Add(this.txtDescripcion);
            this.PanSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanSuperior.Name = "PanSuperior";
            this.PanSuperior.Size = new System.Drawing.Size(876, 36);
            this.PanSuperior.TabIndex = 4;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(10, 10);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(59, 13);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Servicios";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(95, 7);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(703, 20);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.Tag = "2";
            this.txtDescripcion.GotFocus += new System.EventHandler(this.txtDescripcion_GotFocus);
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // PanInferior
            // 
            this.PanInferior.BackColor = System.Drawing.Color.White;
            this.PanInferior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanInferior.Controls.Add(this.lblTotal);
            this.PanInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanInferior.Location = new System.Drawing.Point(0, 460);
            this.PanInferior.Name = "PanInferior";
            this.PanInferior.Size = new System.Drawing.Size(876, 20);
            this.PanInferior.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblTotal.Location = new System.Drawing.Point(0, 3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(174, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = " Se Encontraron 00 Registros";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvServicio
            // 
            this.dgvServicio.AllowUserToAddRows = false;
            this.dgvServicio.AllowUserToDeleteRows = false;
            this.dgvServicio.AllowUserToResizeColumns = false;
            this.dgvServicio.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvServicio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvServicio.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvServicio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdServicio,
            this.sCodigoInterno,
            this.sDescripcion,
            this.fPrecio});
            this.dgvServicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServicio.Location = new System.Drawing.Point(0, 36);
            this.dgvServicio.MultiSelect = false;
            this.dgvServicio.Name = "dgvServicio";
            this.dgvServicio.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicio.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvServicio.RowHeadersVisible = false;
            this.dgvServicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicio.Size = new System.Drawing.Size(876, 424);
            this.dgvServicio.TabIndex = 6;
            this.dgvServicio.SelectionChanged += new System.EventHandler(this.dgvServicio_SelectionChanged);
            this.dgvServicio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvServicio_KeyDown);
            // 
            // nIdServicio
            // 
            this.nIdServicio.DataPropertyName = "nIdServicio";
            this.nIdServicio.HeaderText = "nIdServicio";
            this.nIdServicio.Name = "nIdServicio";
            this.nIdServicio.ReadOnly = true;
            this.nIdServicio.Visible = false;
            // 
            // sCodigoInterno
            // 
            this.sCodigoInterno.DataPropertyName = "sCodigoInterno";
            this.sCodigoInterno.HeaderText = "Codigo Interno";
            this.sCodigoInterno.Name = "sCodigoInterno";
            this.sCodigoInterno.ReadOnly = true;
            // 
            // sDescripcion
            // 
            this.sDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sDescripcion.DataPropertyName = "sDescripcion";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sDescripcion.DefaultCellStyle = dataGridViewCellStyle11;
            this.sDescripcion.HeaderText = "Servicio";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 69;
            // 
            // fPrecio
            // 
            this.fPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fPrecio.DataPropertyName = "fPrecio";
            this.fPrecio.HeaderText = "Precio";
            this.fPrecio.Name = "fPrecio";
            this.fPrecio.ReadOnly = true;
            this.fPrecio.Width = 61;
            // 
            // PanOpciones
            // 
            this.PanOpciones.BackColor = System.Drawing.Color.White;
            this.PanOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanOpciones.Controls.Add(this.NdCantidad);
            this.PanOpciones.Controls.Add(this.LblCompra);
            this.PanOpciones.Controls.Add(this.LblMonto);
            this.PanOpciones.Controls.Add(this.Label1);
            this.PanOpciones.Controls.Add(this.Label10);
            this.PanOpciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanOpciones.Location = new System.Drawing.Point(0, 420);
            this.PanOpciones.Name = "PanOpciones";
            this.PanOpciones.Size = new System.Drawing.Size(876, 40);
            this.PanOpciones.TabIndex = 7;
            // 
            // NdCantidad
            // 
            this.NdCantidad.BackColor = System.Drawing.Color.Green;
            this.NdCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NdCantidad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NdCantidad.ForeColor = System.Drawing.Color.White;
            this.NdCantidad.Location = new System.Drawing.Point(73, 8);
            this.NdCantidad.MaxLength = 20;
            this.NdCantidad.Name = "NdCantidad";
            this.NdCantidad.Size = new System.Drawing.Size(78, 22);
            this.NdCantidad.TabIndex = 34;
            this.NdCantidad.Tag = "2";
            this.NdCantidad.Text = "0";
            this.NdCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NdCantidad.TextChanged += new System.EventHandler(this.NdCantidad_TextChanged);
            this.NdCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NdCantidad_KeyDown);
            this.NdCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NdCantidad_KeyPress);
            // 
            // LblCompra
            // 
            this.LblCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompra.ForeColor = System.Drawing.Color.Blue;
            this.LblCompra.Location = new System.Drawing.Point(217, 9);
            this.LblCompra.Name = "LblCompra";
            this.LblCompra.Size = new System.Drawing.Size(110, 20);
            this.LblCompra.TabIndex = 32;
            this.LblCompra.Text = "0.00";
            this.LblCompra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblMonto
            // 
            this.LblMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMonto.ForeColor = System.Drawing.Color.Blue;
            this.LblMonto.Location = new System.Drawing.Point(712, 4);
            this.LblMonto.Name = "LblMonto";
            this.LblMonto.Size = new System.Drawing.Size(153, 30);
            this.LblMonto.TabIndex = 5;
            this.LblMonto.Text = "0.00";
            this.LblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(171, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 13);
            this.Label1.TabIndex = 26;
            this.Label1.Text = "Precio";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(10, 13);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(57, 13);
            this.Label10.TabIndex = 24;
            this.Label10.Text = "Cantidad";
            // 
            // FrmServicioListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 480);
            this.ControlBox = false;
            this.Controls.Add(this.PanOpciones);
            this.Controls.Add(this.dgvServicio);
            this.Controls.Add(this.PanInferior);
            this.Controls.Add(this.PanSuperior);
            this.KeyPreview = true;
            this.Name = "FrmServicioListar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Servicios";
            this.Load += new System.EventHandler(this.FrmServicioListar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmServicioListar_KeyDown);
            this.PanSuperior.ResumeLayout(false);
            this.PanSuperior.PerformLayout();
            this.PanInferior.ResumeLayout(false);
            this.PanInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).EndInit();
            this.PanOpciones.ResumeLayout(false);
            this.PanOpciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel PanSuperior;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.Panel PanInferior;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.DataGridView dgvServicio;
        internal System.Windows.Forms.Panel PanOpciones;
        internal System.Windows.Forms.Label LblCompra;
        internal System.Windows.Forms.Label LblMonto;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCodigoInterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fPrecio;
        internal System.Windows.Forms.TextBox NdCantidad;
    }
}