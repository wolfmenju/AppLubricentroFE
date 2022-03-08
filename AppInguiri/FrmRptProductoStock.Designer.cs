namespace AppInguiri
{
    partial class FrmRptProductoStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRptProductoStock));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanOpciones = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.PanSuperior = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ndFin = new System.Windows.Forms.NumericUpDown();
            this.ndInicio = new System.Windows.Forms.NumericUpDown();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboAlmacen = new System.Windows.Forms.ComboBox();
            this.PanInferior = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.PanTodo = new System.Windows.Forms.Panel();
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.nIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodigoInterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sLaboratorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanOpciones.SuspendLayout();
            this.PanSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndInicio)).BeginInit();
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
            this.btnImprimir.Text = "&Imprimir [F3]";
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
            this.btnBuscar.Text = "&Buscar    [F2]";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // PanSuperior
            // 
            this.PanSuperior.BackColor = System.Drawing.Color.White;
            this.PanSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSuperior.Controls.Add(this.Label1);
            this.PanSuperior.Controls.Add(this.Label2);
            this.PanSuperior.Controls.Add(this.ndFin);
            this.PanSuperior.Controls.Add(this.ndInicio);
            this.PanSuperior.Controls.Add(this.chkTodos);
            this.PanSuperior.Controls.Add(this.Label4);
            this.PanSuperior.Controls.Add(this.cboAlmacen);
            this.PanSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanSuperior.Name = "PanSuperior";
            this.PanSuperior.Size = new System.Drawing.Size(917, 66);
            this.PanSuperior.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(186, 38);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(23, 13);
            this.Label1.TabIndex = 55;
            this.Label1.Text = "----";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(5, 37);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 13);
            this.Label2.TabIndex = 54;
            this.Label2.Text = "Stock";
            // 
            // ndFin
            // 
            this.ndFin.Location = new System.Drawing.Point(212, 34);
            this.ndFin.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ndFin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndFin.Name = "ndFin";
            this.ndFin.Size = new System.Drawing.Size(120, 21);
            this.ndFin.TabIndex = 53;
            this.ndFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ndFin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ndInicio
            // 
            this.ndInicio.Location = new System.Drawing.Point(63, 34);
            this.ndInicio.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ndInicio.Name = "ndInicio";
            this.ndInicio.Size = new System.Drawing.Size(120, 21);
            this.ndInicio.TabIndex = 52;
            this.ndInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.Location = new System.Drawing.Point(493, 10);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(193, 17);
            this.chkTodos.TabIndex = 51;
            this.chkTodos.Text = "[F1] - Todos Los Laboratorios";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(5, 12);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(55, 13);
            this.Label4.TabIndex = 50;
            this.Label4.Text = "Almacén";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAlmacen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(63, 8);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(424, 21);
            this.cboAlmacen.TabIndex = 43;
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
            this.PanTodo.Location = new System.Drawing.Point(0, 66);
            this.PanTodo.Name = "PanTodo";
            this.PanTodo.Size = new System.Drawing.Size(917, 378);
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
            this.sAlmacen,
            this.sCodigoInterno,
            this.sNombreProducto,
            this.bSeleccionar,
            this.sLaboratorio,
            this.sLote,
            this.dFechaVencimiento,
            this.nStock});
            this.dgvProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducto.Location = new System.Drawing.Point(0, 0);
            this.dgvProducto.MultiSelect = false;
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProducto.RowHeadersVisible = false;
            this.dgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducto.Size = new System.Drawing.Size(915, 376);
            this.dgvProducto.TabIndex = 1;
            // 
            // nIdProducto
            // 
            this.nIdProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdProducto.DataPropertyName = "nIdProducto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nIdProducto.DefaultCellStyle = dataGridViewCellStyle3;
            this.nIdProducto.HeaderText = "IdProducto";
            this.nIdProducto.Name = "nIdProducto";
            this.nIdProducto.ReadOnly = true;
            this.nIdProducto.Visible = false;
            this.nIdProducto.Width = 66;
            // 
            // sAlmacen
            // 
            this.sAlmacen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sAlmacen.DataPropertyName = "sAlmacen";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sAlmacen.DefaultCellStyle = dataGridViewCellStyle4;
            this.sAlmacen.HeaderText = "Almacén";
            this.sAlmacen.Name = "sAlmacen";
            this.sAlmacen.ReadOnly = true;
            this.sAlmacen.Width = 72;
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
            // sNombreProducto
            // 
            this.sNombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sNombreProducto.DataPropertyName = "sNombreProducto";
            this.sNombreProducto.HeaderText = "Producto";
            this.sNombreProducto.Name = "sNombreProducto";
            this.sNombreProducto.ReadOnly = true;
            this.sNombreProducto.Width = 75;
            // 
            // bSeleccionar
            // 
            this.bSeleccionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bSeleccionar.DataPropertyName = "bSeleccionar";
            this.bSeleccionar.HeaderText = "Alternativo";
            this.bSeleccionar.Name = "bSeleccionar";
            this.bSeleccionar.ReadOnly = true;
            this.bSeleccionar.Width = 66;
            // 
            // sLaboratorio
            // 
            this.sLaboratorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sLaboratorio.DataPropertyName = "sLaboratorio";
            this.sLaboratorio.HeaderText = "Laboratorio";
            this.sLaboratorio.Name = "sLaboratorio";
            this.sLaboratorio.ReadOnly = true;
            this.sLaboratorio.Width = 87;
            // 
            // sLote
            // 
            this.sLote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sLote.DataPropertyName = "sLote";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sLote.DefaultCellStyle = dataGridViewCellStyle5;
            this.sLote.HeaderText = "Lote";
            this.sLote.Name = "sLote";
            this.sLote.ReadOnly = true;
            this.sLote.Visible = false;
            this.sLote.Width = 53;
            // 
            // dFechaVencimiento
            // 
            this.dFechaVencimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFechaVencimiento.DataPropertyName = "dFechaVencimiento";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dFechaVencimiento.DefaultCellStyle = dataGridViewCellStyle6;
            this.dFechaVencimiento.HeaderText = "Fecha Vencimiento";
            this.dFechaVencimiento.Name = "dFechaVencimiento";
            this.dFechaVencimiento.ReadOnly = true;
            this.dFechaVencimiento.Visible = false;
            this.dFechaVencimiento.Width = 111;
            // 
            // nStock
            // 
            this.nStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nStock.DataPropertyName = "nStock";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.nStock.DefaultCellStyle = dataGridViewCellStyle7;
            this.nStock.HeaderText = "Stock";
            this.nStock.Name = "nStock";
            this.nStock.ReadOnly = true;
            this.nStock.Width = 58;
            // 
            // FrmRptProductoStock
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
            this.Name = "FrmRptProductoStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock de Productos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRptProductoStock_KeyDown);
            this.PanOpciones.ResumeLayout(false);
            this.PanSuperior.ResumeLayout(false);
            this.PanSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndInicio)).EndInit();
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
        internal System.Windows.Forms.Panel PanInferior;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Panel PanTodo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cboAlmacen;
        internal System.Windows.Forms.DataGridView dgvProducto;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.NumericUpDown ndFin;
        internal System.Windows.Forms.NumericUpDown ndInicio;
        internal System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCodigoInterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombreProducto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLaboratorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nStock;
    }
}