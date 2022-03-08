namespace AppInguiri
{
    partial class FrmRptProductoVendido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRptProductoVendido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanOpciones = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.PanSuperior = new System.Windows.Forms.Panel();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboOpcion = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.PanInferior = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.PanTodo = new System.Windows.Forms.Panel();
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.nIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodigoInterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bAlternativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sLaboratorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanOpciones.SuspendLayout();
            this.PanSuperior.SuspendLayout();
            this.PanInferior.SuspendLayout();
            this.PanTodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // PanOpciones
            // 
            this.PanOpciones.BackColor = System.Drawing.Color.White;
            this.PanOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanOpciones.Controls.Add(this.btnImprimir);
            this.PanOpciones.Controls.Add(this.btnSalir);
            this.PanOpciones.Controls.Add(this.btnBuscar);
            this.PanOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanOpciones.Location = new System.Drawing.Point(917, 0);
            this.PanOpciones.Name = "PanOpciones";
            this.PanOpciones.Size = new System.Drawing.Size(105, 461);
            this.PanOpciones.TabIndex = 3;
            // 
            // btnImprimir
            // 
            this.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = global::AppInguiri.Properties.Resources.xImprimir;
            this.btnImprimir.Location = new System.Drawing.Point(4, 66);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(94, 52);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.TabStop = false;
            this.btnImprimir.Text = "&Imprimir [F2]";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = global::AppInguiri.Properties.Resources.xSalir;
            this.btnSalir.Location = new System.Drawing.Point(4, 396);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(94, 52);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "&Salir      [Esc]";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(4, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 52);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "&Buscar    [F1]";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // PanSuperior
            // 
            this.PanSuperior.BackColor = System.Drawing.Color.White;
            this.PanSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSuperior.Controls.Add(this.txtNumero);
            this.PanSuperior.Controls.Add(this.Label3);
            this.PanSuperior.Controls.Add(this.Label4);
            this.PanSuperior.Controls.Add(this.cboOpcion);
            this.PanSuperior.Controls.Add(this.Label2);
            this.PanSuperior.Controls.Add(this.Label1);
            this.PanSuperior.Controls.Add(this.dtFechaFin);
            this.PanSuperior.Controls.Add(this.dtFechaInicio);
            this.PanSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanSuperior.Name = "PanSuperior";
            this.PanSuperior.Size = new System.Drawing.Size(917, 37);
            this.PanSuperior.TabIndex = 4;
            // 
            // txtNumero
            // 
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.ForeColor = System.Drawing.Color.Black;
            this.txtNumero.Location = new System.Drawing.Point(662, 7);
            this.txtNumero.MaxLength = 4;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 21);
            this.txtNumero.TabIndex = 51;
            this.txtNumero.Tag = "2";
            this.txtNumero.Text = "5";
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(622, 11);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(36, 13);
            this.Label3.TabIndex = 50;
            this.Label3.Text = "Total";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(294, 11);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(52, 13);
            this.Label4.TabIndex = 48;
            this.Label4.Text = "Reporte";
            // 
            // cboOpcion
            // 
            this.cboOpcion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboOpcion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOpcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOpcion.FormattingEnabled = true;
            this.cboOpcion.Items.AddRange(new object[] {
            "PRODUCTOS MÁS VENDIDOS",
            "PRODUCTOS MENOS VENDIDOS"});
            this.cboOpcion.Location = new System.Drawing.Point(349, 7);
            this.cboOpcion.Name = "cboOpcion";
            this.cboOpcion.Size = new System.Drawing.Size(270, 21);
            this.cboOpcion.TabIndex = 47;
            this.cboOpcion.SelectionChangeCommitted += new System.EventHandler(this.cboOpcion_SelectionChangeCommitted);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(163, 11);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(19, 13);
            this.Label2.TabIndex = 46;
            this.Label2.Text = "---";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(9, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(42, 13);
            this.Label1.TabIndex = 45;
            this.Label1.Text = "Fecha";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(185, 8);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(106, 21);
            this.dtFechaFin.TabIndex = 1;
            this.dtFechaFin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtFechaFin_KeyDown);
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(54, 7);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(106, 21);
            this.dtFechaInicio.TabIndex = 0;
            this.dtFechaInicio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtFechaInicio_KeyDown);
            // 
            // PanInferior
            // 
            this.PanInferior.BackColor = System.Drawing.Color.White;
            this.PanInferior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanInferior.Controls.Add(this.lblTotal);
            this.PanInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanInferior.Location = new System.Drawing.Point(0, 444);
            this.PanInferior.Name = "PanInferior";
            this.PanInferior.Size = new System.Drawing.Size(917, 17);
            this.PanInferior.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblTotal.Location = new System.Drawing.Point(0, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(174, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = " Se Encontraron 00 Registros";
            // 
            // PanTodo
            // 
            this.PanTodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanTodo.Controls.Add(this.dgvProducto);
            this.PanTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanTodo.Location = new System.Drawing.Point(0, 37);
            this.PanTodo.Name = "PanTodo";
            this.PanTodo.Size = new System.Drawing.Size(917, 407);
            this.PanTodo.TabIndex = 6;
            // 
            // dgvProducto
            // 
            this.dgvProducto.AllowUserToAddRows = false;
            this.dgvProducto.AllowUserToDeleteRows = false;
            this.dgvProducto.AllowUserToResizeColumns = false;
            this.dgvProducto.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducto.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdProducto,
            this.sCodigoInterno,
            this.sNombre,
            this.bAlternativo,
            this.sLaboratorio,
            this.fTotal});
            this.dgvProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducto.Location = new System.Drawing.Point(0, 0);
            this.dgvProducto.MultiSelect = false;
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProducto.RowHeadersVisible = false;
            this.dgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducto.Size = new System.Drawing.Size(915, 405);
            this.dgvProducto.TabIndex = 0;
            // 
            // nIdProducto
            // 
            this.nIdProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdProducto.DataPropertyName = "nIdProducto";
            this.nIdProducto.HeaderText = "IdProducto";
            this.nIdProducto.Name = "nIdProducto";
            this.nIdProducto.ReadOnly = true;
            this.nIdProducto.Visible = false;
            this.nIdProducto.Width = 66;
            // 
            // sCodigoInterno
            // 
            this.sCodigoInterno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sCodigoInterno.DataPropertyName = "sCodigoInterno";
            this.sCodigoInterno.HeaderText = "Codigo Interno";
            this.sCodigoInterno.Name = "sCodigoInterno";
            this.sCodigoInterno.ReadOnly = true;
            this.sCodigoInterno.Width = 96;
            // 
            // sNombre
            // 
            this.sNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sNombre.DataPropertyName = "sNombre";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sNombre.DefaultCellStyle = dataGridViewCellStyle3;
            this.sNombre.HeaderText = "Descripción";
            this.sNombre.Name = "sNombre";
            this.sNombre.ReadOnly = true;
            this.sNombre.Width = 86;
            // 
            // bAlternativo
            // 
            this.bAlternativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bAlternativo.DataPropertyName = "bAlternativo";
            this.bAlternativo.HeaderText = "Alternativo";
            this.bAlternativo.Name = "bAlternativo";
            this.bAlternativo.ReadOnly = true;
            this.bAlternativo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bAlternativo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.bAlternativo.Width = 85;
            // 
            // sLaboratorio
            // 
            this.sLaboratorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sLaboratorio.DataPropertyName = "sLaboratorio";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sLaboratorio.DefaultCellStyle = dataGridViewCellStyle4;
            this.sLaboratorio.HeaderText = "Categoria";
            this.sLaboratorio.Name = "sLaboratorio";
            this.sLaboratorio.ReadOnly = true;
            this.sLaboratorio.Width = 79;
            // 
            // fTotal
            // 
            this.fTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fTotal.DataPropertyName = "fTotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.fTotal.HeaderText = "Total";
            this.fTotal.Name = "fTotal";
            this.fTotal.ReadOnly = true;
            this.fTotal.Width = 56;
            // 
            // FrmRptProductoVendido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 461);
            this.ControlBox = false;
            this.Controls.Add(this.PanTodo);
            this.Controls.Add(this.PanInferior);
            this.Controls.Add(this.PanSuperior);
            this.Controls.Add(this.PanOpciones);
            this.KeyPreview = true;
            this.Name = "FrmRptProductoVendido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Productos Vendidos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRptProductoVendido_KeyDown);
            this.PanOpciones.ResumeLayout(false);
            this.PanSuperior.ResumeLayout(false);
            this.PanSuperior.PerformLayout();
            this.PanInferior.ResumeLayout(false);
            this.PanInferior.PerformLayout();
            this.PanTodo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PanOpciones;
        internal System.Windows.Forms.Button btnImprimir;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.Panel PanSuperior;
        internal System.Windows.Forms.TextBox txtNumero;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cboOpcion;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker dtFechaFin;
        internal System.Windows.Forms.DateTimePicker dtFechaInicio;
        internal System.Windows.Forms.Panel PanInferior;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Panel PanTodo;
        internal System.Windows.Forms.DataGridView dgvProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCodigoInterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bAlternativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLaboratorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fTotal;
    }
}