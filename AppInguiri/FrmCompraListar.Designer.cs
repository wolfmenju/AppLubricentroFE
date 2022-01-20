namespace AppInguiri
{
    partial class FrmCompraListar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompraListar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanOpciones = new System.Windows.Forms.Panel();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnDetalle = new System.Windows.Forms.Button();
            this.PanInferior = new System.Windows.Forms.Panel();
            this.LblTotal = new System.Windows.Forms.Label();
            this.PanSuperior = new System.Windows.Forms.Panel();
            this.chAnuladas = new System.Windows.Forms.CheckBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.dFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.RdFecha = new System.Windows.Forms.RadioButton();
            this.TabConsulta = new System.Windows.Forms.TabControl();
            this.TabCompras = new System.Windows.Forms.TabPage();
            this.dgvCompra = new System.Windows.Forms.DataGridView();
            this.nIdCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIdAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIdProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bCredito = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TabDetalle = new System.Windows.Forms.TabPage();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.IdDetalleCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCompras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanOpciones.SuspendLayout();
            this.PanInferior.SuspendLayout();
            this.PanSuperior.SuspendLayout();
            this.TabConsulta.SuspendLayout();
            this.TabCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra)).BeginInit();
            this.TabDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // PanOpciones
            // 
            this.PanOpciones.BackColor = System.Drawing.Color.White;
            this.PanOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanOpciones.Controls.Add(this.BtnEliminar);
            this.PanOpciones.Controls.Add(this.BtnSalir);
            this.PanOpciones.Controls.Add(this.BtnBuscar);
            this.PanOpciones.Controls.Add(this.BtnDetalle);
            this.PanOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanOpciones.Location = new System.Drawing.Point(797, 0);
            this.PanOpciones.Name = "PanOpciones";
            this.PanOpciones.Size = new System.Drawing.Size(109, 420);
            this.PanOpciones.TabIndex = 11;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnEliminar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.Black;
            this.BtnEliminar.Image = global::AppInguiri.Properties.Resources.X;
            this.BtnEliminar.Location = new System.Drawing.Point(2, 120);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(102, 52);
            this.BtnEliminar.TabIndex = 4;
            this.BtnEliminar.TabStop = false;
            this.BtnEliminar.Text = "&Anular [F4]";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.BtnSalir.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Black;
            this.BtnSalir.Image = global::AppInguiri.Properties.Resources.xSalir;
            this.BtnSalir.Location = new System.Drawing.Point(3, 355);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(102, 52);
            this.BtnSalir.TabIndex = 5;
            this.BtnSalir.TabStop = false;
            this.BtnSalir.Text = "&Salir      [Esc]";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(3, 3);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(102, 52);
            this.BtnBuscar.TabIndex = 3;
            this.BtnBuscar.TabStop = false;
            this.BtnBuscar.Text = "  &Buscar  [F2]";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnDetalle
            // 
            this.BtnDetalle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnDetalle.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDetalle.ForeColor = System.Drawing.Color.Black;
            this.BtnDetalle.Image = global::AppInguiri.Properties.Resources.xDetalle1;
            this.BtnDetalle.Location = new System.Drawing.Point(3, 62);
            this.BtnDetalle.Name = "BtnDetalle";
            this.BtnDetalle.Size = new System.Drawing.Size(102, 52);
            this.BtnDetalle.TabIndex = 1;
            this.BtnDetalle.TabStop = false;
            this.BtnDetalle.Text = "&Detalle [F3]";
            this.BtnDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnDetalle.UseVisualStyleBackColor = true;
            this.BtnDetalle.Click += new System.EventHandler(this.BtnDetalle_Click);
            // 
            // PanInferior
            // 
            this.PanInferior.BackColor = System.Drawing.Color.White;
            this.PanInferior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanInferior.Controls.Add(this.LblTotal);
            this.PanInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanInferior.Location = new System.Drawing.Point(0, 400);
            this.PanInferior.Name = "PanInferior";
            this.PanInferior.Size = new System.Drawing.Size(797, 20);
            this.PanInferior.TabIndex = 12;
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblTotal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.ForeColor = System.Drawing.Color.Blue;
            this.LblTotal.Location = new System.Drawing.Point(0, 0);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(174, 13);
            this.LblTotal.TabIndex = 17;
            this.LblTotal.Text = " Se Encontraron 00 Registros";
            // 
            // PanSuperior
            // 
            this.PanSuperior.BackColor = System.Drawing.Color.White;
            this.PanSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSuperior.Controls.Add(this.chAnuladas);
            this.PanSuperior.Controls.Add(this.Label9);
            this.PanSuperior.Controls.Add(this.dFechaFin);
            this.PanSuperior.Controls.Add(this.dFechaInicio);
            this.PanSuperior.Controls.Add(this.RdFecha);
            this.PanSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanSuperior.Name = "PanSuperior";
            this.PanSuperior.Size = new System.Drawing.Size(797, 41);
            this.PanSuperior.TabIndex = 13;
            // 
            // chAnuladas
            // 
            this.chAnuladas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chAnuladas.AutoSize = true;
            this.chAnuladas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chAnuladas.Location = new System.Drawing.Point(619, 11);
            this.chAnuladas.Name = "chAnuladas";
            this.chAnuladas.Size = new System.Drawing.Size(160, 17);
            this.chAnuladas.TabIndex = 2;
            this.chAnuladas.Text = "Incluir Ventas Anuladas";
            this.chAnuladas.UseVisualStyleBackColor = true;
            this.chAnuladas.Visible = false;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(214, 13);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(19, 13);
            this.Label9.TabIndex = 41;
            this.Label9.Text = "---";
            // 
            // dFechaFin
            // 
            this.dFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaFin.Location = new System.Drawing.Point(236, 10);
            this.dFechaFin.Name = "dFechaFin";
            this.dFechaFin.Size = new System.Drawing.Size(97, 20);
            this.dFechaFin.TabIndex = 1;
            // 
            // dFechaInicio
            // 
            this.dFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaInicio.Location = new System.Drawing.Point(114, 9);
            this.dFechaInicio.Name = "dFechaInicio";
            this.dFechaInicio.Size = new System.Drawing.Size(97, 20);
            this.dFechaInicio.TabIndex = 0;
            // 
            // RdFecha
            // 
            this.RdFecha.AutoSize = true;
            this.RdFecha.Checked = true;
            this.RdFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdFecha.Location = new System.Drawing.Point(11, 10);
            this.RdFecha.Name = "RdFecha";
            this.RdFecha.Size = new System.Drawing.Size(100, 17);
            this.RdFecha.TabIndex = 38;
            this.RdFecha.TabStop = true;
            this.RdFecha.Text = "[F1] - Fechas";
            this.RdFecha.UseVisualStyleBackColor = true;
            // 
            // TabConsulta
            // 
            this.TabConsulta.Controls.Add(this.TabCompras);
            this.TabConsulta.Controls.Add(this.TabDetalle);
            this.TabConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabConsulta.Location = new System.Drawing.Point(0, 41);
            this.TabConsulta.Name = "TabConsulta";
            this.TabConsulta.SelectedIndex = 0;
            this.TabConsulta.Size = new System.Drawing.Size(797, 359);
            this.TabConsulta.TabIndex = 14;
            this.TabConsulta.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabConsulta_Selecting);
            // 
            // TabCompras
            // 
            this.TabCompras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.TabCompras.Controls.Add(this.dgvCompra);
            this.TabCompras.Location = new System.Drawing.Point(4, 22);
            this.TabCompras.Name = "TabCompras";
            this.TabCompras.Padding = new System.Windows.Forms.Padding(3);
            this.TabCompras.Size = new System.Drawing.Size(789, 333);
            this.TabCompras.TabIndex = 0;
            this.TabCompras.Text = "Compras";
            // 
            // dgvCompra
            // 
            this.dgvCompra.AllowUserToAddRows = false;
            this.dgvCompra.AllowUserToDeleteRows = false;
            this.dgvCompra.AllowUserToResizeColumns = false;
            this.dgvCompra.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCompra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompra.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvCompra.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdCompra,
            this.nIdAlmacen,
            this.sIdDocumento,
            this.nIdProveedor,
            this.sRazonSocial,
            this.bCredito,
            this.dFecha,
            this.fTotal,
            this.bEstado});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompra.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompra.Location = new System.Drawing.Point(3, 3);
            this.dgvCompra.MultiSelect = false;
            this.dgvCompra.Name = "dgvCompra";
            this.dgvCompra.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompra.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCompra.RowHeadersVisible = false;
            this.dgvCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompra.Size = new System.Drawing.Size(783, 327);
            this.dgvCompra.TabIndex = 0;
            // 
            // nIdCompra
            // 
            this.nIdCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdCompra.DataPropertyName = "nIdCompra";
            this.nIdCompra.HeaderText = "IdCompra";
            this.nIdCompra.Name = "nIdCompra";
            this.nIdCompra.ReadOnly = true;
            this.nIdCompra.Visible = false;
            // 
            // nIdAlmacen
            // 
            this.nIdAlmacen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdAlmacen.DataPropertyName = "nIdAlmacen";
            this.nIdAlmacen.HeaderText = "IdAlmacen";
            this.nIdAlmacen.Name = "nIdAlmacen";
            this.nIdAlmacen.ReadOnly = true;
            this.nIdAlmacen.Visible = false;
            // 
            // sIdDocumento
            // 
            this.sIdDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sIdDocumento.DataPropertyName = "sIdDocumento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sIdDocumento.DefaultCellStyle = dataGridViewCellStyle3;
            this.sIdDocumento.HeaderText = "Documento";
            this.sIdDocumento.Name = "sIdDocumento";
            this.sIdDocumento.ReadOnly = true;
            this.sIdDocumento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sIdDocumento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sIdDocumento.Width = 77;
            // 
            // nIdProveedor
            // 
            this.nIdProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdProveedor.DataPropertyName = "nIdProveedor";
            this.nIdProveedor.HeaderText = "IdProveedor";
            this.nIdProveedor.Name = "nIdProveedor";
            this.nIdProveedor.ReadOnly = true;
            this.nIdProveedor.Visible = false;
            // 
            // sRazonSocial
            // 
            this.sRazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sRazonSocial.DataPropertyName = "sRazonSocial";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sRazonSocial.DefaultCellStyle = dataGridViewCellStyle4;
            this.sRazonSocial.HeaderText = "Razón Social";
            this.sRazonSocial.Name = "sRazonSocial";
            this.sRazonSocial.ReadOnly = true;
            this.sRazonSocial.Width = 98;
            // 
            // bCredito
            // 
            this.bCredito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bCredito.DataPropertyName = "bCredito";
            this.bCredito.HeaderText = "Crédito";
            this.bCredito.Name = "bCredito";
            this.bCredito.ReadOnly = true;
            this.bCredito.Width = 53;
            // 
            // dFecha
            // 
            this.dFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFecha.DataPropertyName = "dFecha";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dFecha.DefaultCellStyle = dataGridViewCellStyle5;
            this.dFecha.HeaderText = "Fecha";
            this.dFecha.Name = "dFecha";
            this.dFecha.ReadOnly = true;
            this.dFecha.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dFecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dFecha.Width = 48;
            // 
            // fTotal
            // 
            this.fTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fTotal.DataPropertyName = "fTotal";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.fTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.fTotal.HeaderText = "Total";
            this.fTotal.Name = "fTotal";
            this.fTotal.ReadOnly = true;
            this.fTotal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fTotal.Width = 42;
            // 
            // bEstado
            // 
            this.bEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bEstado.DataPropertyName = "bEstado";
            this.bEstado.HeaderText = "Estado";
            this.bEstado.Name = "bEstado";
            this.bEstado.ReadOnly = true;
            this.bEstado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.bEstado.Width = 71;
            // 
            // TabDetalle
            // 
            this.TabDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.TabDetalle.Controls.Add(this.dgvDetalle);
            this.TabDetalle.Location = new System.Drawing.Point(4, 22);
            this.TabDetalle.Name = "TabDetalle";
            this.TabDetalle.Padding = new System.Windows.Forms.Padding(3);
            this.TabDetalle.Size = new System.Drawing.Size(789, 333);
            this.TabDetalle.TabIndex = 1;
            this.TabDetalle.Text = "Detalle De Compras";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeColumns = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDetalleCompra,
            this.IdCompras,
            this.IdTarjeta,
            this.IdProducto,
            this.Descripcion,
            this.Lote,
            this.Cantidad,
            this.Precio,
            this.SubTotal});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(3, 3);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(783, 327);
            this.dgvDetalle.TabIndex = 0;
            // 
            // IdDetalleCompra
            // 
            this.IdDetalleCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdDetalleCompra.DataPropertyName = "IdDetalleCompra";
            this.IdDetalleCompra.HeaderText = "IdDetalleCompra";
            this.IdDetalleCompra.Name = "IdDetalleCompra";
            this.IdDetalleCompra.ReadOnly = true;
            this.IdDetalleCompra.Visible = false;
            this.IdDetalleCompra.Width = 106;
            // 
            // IdCompras
            // 
            this.IdCompras.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdCompras.DataPropertyName = "IdCompra";
            this.IdCompras.HeaderText = "IdCompra";
            this.IdCompras.Name = "IdCompras";
            this.IdCompras.ReadOnly = true;
            this.IdCompras.Visible = false;
            this.IdCompras.Width = 66;
            // 
            // IdTarjeta
            // 
            this.IdTarjeta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdTarjeta.DataPropertyName = "IdTarjeta";
            this.IdTarjeta.HeaderText = "IdTarjeta";
            this.IdTarjeta.Name = "IdTarjeta";
            this.IdTarjeta.ReadOnly = true;
            this.IdTarjeta.Visible = false;
            this.IdTarjeta.Width = 64;
            // 
            // IdProducto
            // 
            this.IdProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdProducto.DataPropertyName = "IdProducto";
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            this.IdProducto.Width = 75;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Descripcion.DataPropertyName = "Descripcion";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle11;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 99;
            // 
            // Lote
            // 
            this.Lote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Lote.DataPropertyName = "Lote";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Lote.DefaultCellStyle = dataGridViewCellStyle12;
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            this.Lote.Visible = false;
            this.Lote.Width = 57;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle13;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 82;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Precio.DataPropertyName = "Precio";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "C2";
            dataGridViewCellStyle14.NullValue = null;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle14;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 68;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SubTotal.DataPropertyName = "SubTotal";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "C2";
            dataGridViewCellStyle15.NullValue = null;
            this.SubTotal.DefaultCellStyle = dataGridViewCellStyle15;
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Width = 83;
            // 
            // FrmCompraListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(906, 420);
            this.ControlBox = false;
            this.Controls.Add(this.TabConsulta);
            this.Controls.Add(this.PanSuperior);
            this.Controls.Add(this.PanInferior);
            this.Controls.Add(this.PanOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompraListar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Compras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCompraListar_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCompraListar_KeyDown);
            this.PanOpciones.ResumeLayout(false);
            this.PanInferior.ResumeLayout(false);
            this.PanInferior.PerformLayout();
            this.PanSuperior.ResumeLayout(false);
            this.PanSuperior.PerformLayout();
            this.TabConsulta.ResumeLayout(false);
            this.TabCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra)).EndInit();
            this.TabDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel PanOpciones;
        internal System.Windows.Forms.Button BtnEliminar;
        internal System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnBuscar;
        internal System.Windows.Forms.Button BtnDetalle;
        internal System.Windows.Forms.Panel PanInferior;
        internal System.Windows.Forms.Label LblTotal;
        internal System.Windows.Forms.Panel PanSuperior;
        internal System.Windows.Forms.CheckBox chAnuladas;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.DateTimePicker dFechaFin;
        internal System.Windows.Forms.DateTimePicker dFechaInicio;
        internal System.Windows.Forms.RadioButton RdFecha;
        internal System.Windows.Forms.TabControl TabConsulta;
        internal System.Windows.Forms.TabPage TabCompras;
        internal System.Windows.Forms.DataGridView dgvCompra;
        internal System.Windows.Forms.TabPage TabDetalle;
        internal System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRazonSocial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn fTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDetalleCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
    }
}