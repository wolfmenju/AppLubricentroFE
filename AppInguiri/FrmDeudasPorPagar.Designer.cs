namespace AppInguiri
{
    partial class FrmDeudasPorPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeudasPorPagar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanOpciones = new System.Windows.Forms.Panel();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnDetalle = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.PanSuperior = new System.Windows.Forms.Panel();
            this.lblCodigoProveedor = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.rdProveedor = new System.Windows.Forms.RadioButton();
            this.Label9 = new System.Windows.Forms.Label();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.rdFecha = new System.Windows.Forms.RadioButton();
            this.Label2 = new System.Windows.Forms.Label();
            this.PanInferior = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.PanTodo = new System.Windows.Forms.Panel();
            this.TabConsulta = new System.Windows.Forms.TabControl();
            this.TabCompras = new System.Windows.Forms.TabPage();
            this.dgvDeudas = new System.Windows.Forms.DataGridView();
            this.nIdDeuda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabDetalle = new System.Windows.Forms.TabPage();
            this.dgvDeudaDetalle = new System.Windows.Forms.DataGridView();
            this.nIdDetalleDeuda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIdDeudas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fMontos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanOpciones.SuspendLayout();
            this.PanSuperior.SuspendLayout();
            this.PanInferior.SuspendLayout();
            this.PanTodo.SuspendLayout();
            this.TabConsulta.SuspendLayout();
            this.TabCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudas)).BeginInit();
            this.TabDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudaDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // PanOpciones
            // 
            this.PanOpciones.BackColor = System.Drawing.Color.White;
            this.PanOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanOpciones.Controls.Add(this.BtnEliminar);
            this.PanOpciones.Controls.Add(this.BtnDetalle);
            this.PanOpciones.Controls.Add(this.BtnAgregar);
            this.PanOpciones.Controls.Add(this.btnSalir);
            this.PanOpciones.Controls.Add(this.btnBuscar);
            this.PanOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanOpciones.Location = new System.Drawing.Point(917, 0);
            this.PanOpciones.Name = "PanOpciones";
            this.PanOpciones.Size = new System.Drawing.Size(105, 461);
            this.PanOpciones.TabIndex = 3;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnEliminar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.Black;
            this.BtnEliminar.Image = global::AppInguiri.Properties.Resources.X;
            this.BtnEliminar.Location = new System.Drawing.Point(4, 182);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(94, 52);
            this.BtnEliminar.TabIndex = 6;
            this.BtnEliminar.TabStop = false;
            this.BtnEliminar.Text = "&Eliminar [F7]";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnDetalle
            // 
            this.BtnDetalle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnDetalle.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDetalle.ForeColor = System.Drawing.Color.Black;
            this.BtnDetalle.Image = global::AppInguiri.Properties.Resources.xDetalle1;
            this.BtnDetalle.Location = new System.Drawing.Point(4, 124);
            this.BtnDetalle.Name = "BtnDetalle";
            this.BtnDetalle.Size = new System.Drawing.Size(94, 52);
            this.BtnDetalle.TabIndex = 5;
            this.BtnDetalle.TabStop = false;
            this.BtnDetalle.Text = "&Detalle [F6]";
            this.BtnDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnDetalle.UseVisualStyleBackColor = true;
            this.BtnDetalle.Click += new System.EventHandler(this.BtnDetalle_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAgregar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.ForeColor = System.Drawing.Color.Black;
            this.BtnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregar.Image")));
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAgregar.Location = new System.Drawing.Point(3, 66);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(95, 52);
            this.BtnAgregar.TabIndex = 3;
            this.BtnAgregar.TabStop = false;
            this.BtnAgregar.Text = "  &Nuevo  [F5]";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
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
            this.btnBuscar.Text = "&Buscar    [F4]";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // PanSuperior
            // 
            this.PanSuperior.BackColor = System.Drawing.Color.White;
            this.PanSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSuperior.Controls.Add(this.lblCodigoProveedor);
            this.PanSuperior.Controls.Add(this.lblNombre);
            this.PanSuperior.Controls.Add(this.txtRuc);
            this.PanSuperior.Controls.Add(this.rdProveedor);
            this.PanSuperior.Controls.Add(this.Label9);
            this.PanSuperior.Controls.Add(this.dtFechaFin);
            this.PanSuperior.Controls.Add(this.dtFechaInicio);
            this.PanSuperior.Controls.Add(this.rdFecha);
            this.PanSuperior.Controls.Add(this.Label2);
            this.PanSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanSuperior.Name = "PanSuperior";
            this.PanSuperior.Size = new System.Drawing.Size(917, 71);
            this.PanSuperior.TabIndex = 4;
            // 
            // lblCodigoProveedor
            // 
            this.lblCodigoProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCodigoProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoProveedor.ForeColor = System.Drawing.Color.Blue;
            this.lblCodigoProveedor.Location = new System.Drawing.Point(366, 12);
            this.lblCodigoProveedor.Name = "lblCodigoProveedor";
            this.lblCodigoProveedor.Size = new System.Drawing.Size(49, 20);
            this.lblCodigoProveedor.TabIndex = 59;
            this.lblCodigoProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCodigoProveedor.Visible = false;
            // 
            // lblNombre
            // 
            this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Blue;
            this.lblNombre.Location = new System.Drawing.Point(260, 36);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(446, 20);
            this.lblNombre.TabIndex = 58;
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRuc
            // 
            this.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.ForeColor = System.Drawing.Color.Black;
            this.txtRuc.Location = new System.Drawing.Point(133, 36);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(97, 20);
            this.txtRuc.TabIndex = 53;
            this.txtRuc.Tag = "2";
            this.txtRuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdProveedor
            // 
            this.rdProveedor.AutoSize = true;
            this.rdProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdProveedor.Location = new System.Drawing.Point(11, 38);
            this.rdProveedor.Name = "rdProveedor";
            this.rdProveedor.Size = new System.Drawing.Size(117, 17);
            this.rdProveedor.TabIndex = 56;
            this.rdProveedor.Text = "[F2] - Proveedor";
            this.rdProveedor.UseVisualStyleBackColor = true;
            this.rdProveedor.Click += new System.EventHandler(this.rdProveedor_Click);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(237, 14);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(19, 13);
            this.Label9.TabIndex = 55;
            this.Label9.Text = "---";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(260, 11);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(97, 21);
            this.dtFechaFin.TabIndex = 52;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(133, 10);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(97, 21);
            this.dtFechaInicio.TabIndex = 51;
            // 
            // rdFecha
            // 
            this.rdFecha.AutoSize = true;
            this.rdFecha.Checked = true;
            this.rdFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdFecha.Location = new System.Drawing.Point(11, 11);
            this.rdFecha.Name = "rdFecha";
            this.rdFecha.Size = new System.Drawing.Size(100, 17);
            this.rdFecha.TabIndex = 54;
            this.rdFecha.TabStop = true;
            this.rdFecha.Text = "[F1] - Fechas";
            this.rdFecha.UseVisualStyleBackColor = true;
            this.rdFecha.Click += new System.EventHandler(this.rdFecha_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(231, 40);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(29, 13);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "[F3]";
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
            this.PanTodo.Controls.Add(this.TabConsulta);
            this.PanTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanTodo.Location = new System.Drawing.Point(0, 71);
            this.PanTodo.Name = "PanTodo";
            this.PanTodo.Size = new System.Drawing.Size(917, 373);
            this.PanTodo.TabIndex = 6;
            // 
            // TabConsulta
            // 
            this.TabConsulta.Controls.Add(this.TabCompras);
            this.TabConsulta.Controls.Add(this.TabDetalle);
            this.TabConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabConsulta.Location = new System.Drawing.Point(0, 0);
            this.TabConsulta.Name = "TabConsulta";
            this.TabConsulta.SelectedIndex = 0;
            this.TabConsulta.Size = new System.Drawing.Size(915, 371);
            this.TabConsulta.TabIndex = 1;
            this.TabConsulta.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabConsulta_Selecting);
            // 
            // TabCompras
            // 
            this.TabCompras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.TabCompras.Controls.Add(this.dgvDeudas);
            this.TabCompras.Location = new System.Drawing.Point(4, 22);
            this.TabCompras.Name = "TabCompras";
            this.TabCompras.Padding = new System.Windows.Forms.Padding(3);
            this.TabCompras.Size = new System.Drawing.Size(907, 345);
            this.TabCompras.TabIndex = 0;
            this.TabCompras.Text = "Deudas";
            // 
            // dgvDeudas
            // 
            this.dgvDeudas.AllowUserToAddRows = false;
            this.dgvDeudas.AllowUserToDeleteRows = false;
            this.dgvDeudas.AllowUserToResizeColumns = false;
            this.dgvDeudas.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDeudas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvDeudas.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvDeudas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeudas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvDeudas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeudas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdDeuda,
            this.sIdDocumento,
            this.sSerie,
            this.dFecha,
            this.sRuc,
            this.sObservacion,
            this.nNumero,
            this.fMonto,
            this.fSaldo});
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeudas.DefaultCellStyle = dataGridViewCellStyle32;
            this.dgvDeudas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeudas.Location = new System.Drawing.Point(3, 3);
            this.dgvDeudas.MultiSelect = false;
            this.dgvDeudas.Name = "dgvDeudas";
            this.dgvDeudas.ReadOnly = true;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeudas.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.dgvDeudas.RowHeadersVisible = false;
            this.dgvDeudas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeudas.Size = new System.Drawing.Size(901, 339);
            this.dgvDeudas.TabIndex = 0;
            // 
            // nIdDeuda
            // 
            this.nIdDeuda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdDeuda.DataPropertyName = "nIdDeuda";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nIdDeuda.DefaultCellStyle = dataGridViewCellStyle23;
            this.nIdDeuda.HeaderText = "IdDeuda";
            this.nIdDeuda.Name = "nIdDeuda";
            this.nIdDeuda.ReadOnly = true;
            this.nIdDeuda.Visible = false;
            // 
            // sIdDocumento
            // 
            this.sIdDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sIdDocumento.DataPropertyName = "sIdDocumento";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sIdDocumento.DefaultCellStyle = dataGridViewCellStyle24;
            this.sIdDocumento.HeaderText = "Documento";
            this.sIdDocumento.Name = "sIdDocumento";
            this.sIdDocumento.ReadOnly = true;
            this.sIdDocumento.Width = 105;
            // 
            // sSerie
            // 
            this.sSerie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sSerie.DataPropertyName = "sSerie";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sSerie.DefaultCellStyle = dataGridViewCellStyle25;
            this.sSerie.HeaderText = "Numeración";
            this.sSerie.Name = "sSerie";
            this.sSerie.ReadOnly = true;
            this.sSerie.Width = 110;
            // 
            // dFecha
            // 
            this.dFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFecha.DataPropertyName = "dFecha";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.Format = "d";
            dataGridViewCellStyle26.NullValue = null;
            this.dFecha.DefaultCellStyle = dataGridViewCellStyle26;
            this.dFecha.HeaderText = "Fecha";
            this.dFecha.Name = "dFecha";
            this.dFecha.ReadOnly = true;
            this.dFecha.Width = 71;
            // 
            // sRuc
            // 
            this.sRuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sRuc.DataPropertyName = "sRuc";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sRuc.DefaultCellStyle = dataGridViewCellStyle27;
            this.sRuc.HeaderText = "Ruc";
            this.sRuc.Name = "sRuc";
            this.sRuc.ReadOnly = true;
            this.sRuc.Width = 57;
            // 
            // sObservacion
            // 
            this.sObservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sObservacion.DataPropertyName = "sObservacion";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sObservacion.DefaultCellStyle = dataGridViewCellStyle28;
            this.sObservacion.HeaderText = "Razón Social";
            this.sObservacion.Name = "sObservacion";
            this.sObservacion.ReadOnly = true;
            this.sObservacion.Width = 107;
            // 
            // nNumero
            // 
            this.nNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nNumero.DataPropertyName = "nNumero";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nNumero.DefaultCellStyle = dataGridViewCellStyle29;
            this.nNumero.HeaderText = "Dias";
            this.nNumero.Name = "nNumero";
            this.nNumero.ReadOnly = true;
            this.nNumero.Width = 61;
            // 
            // fMonto
            // 
            this.fMonto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fMonto.DataPropertyName = "fMonto";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Format = "C2";
            dataGridViewCellStyle30.NullValue = null;
            this.fMonto.DefaultCellStyle = dataGridViewCellStyle30;
            this.fMonto.HeaderText = "Monto";
            this.fMonto.Name = "fMonto";
            this.fMonto.ReadOnly = true;
            this.fMonto.Width = 72;
            // 
            // fSaldo
            // 
            this.fSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fSaldo.DataPropertyName = "fSaldo";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle31.Format = "C2";
            dataGridViewCellStyle31.NullValue = null;
            this.fSaldo.DefaultCellStyle = dataGridViewCellStyle31;
            this.fSaldo.HeaderText = "Saldo";
            this.fSaldo.Name = "fSaldo";
            this.fSaldo.ReadOnly = true;
            this.fSaldo.Width = 69;
            // 
            // TabDetalle
            // 
            this.TabDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.TabDetalle.Controls.Add(this.dgvDeudaDetalle);
            this.TabDetalle.Location = new System.Drawing.Point(4, 22);
            this.TabDetalle.Name = "TabDetalle";
            this.TabDetalle.Padding = new System.Windows.Forms.Padding(3);
            this.TabDetalle.Size = new System.Drawing.Size(907, 345);
            this.TabDetalle.TabIndex = 1;
            this.TabDetalle.Text = "Detalle De Deudas";
            // 
            // dgvDeudaDetalle
            // 
            this.dgvDeudaDetalle.AllowUserToAddRows = false;
            this.dgvDeudaDetalle.AllowUserToDeleteRows = false;
            this.dgvDeudaDetalle.AllowUserToResizeColumns = false;
            this.dgvDeudaDetalle.AllowUserToResizeRows = false;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDeudaDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle34;
            this.dgvDeudaDetalle.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvDeudaDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeudaDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle35;
            this.dgvDeudaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeudaDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdDetalleDeuda,
            this.nIdDeudas,
            this.dFechas,
            this.Observacion,
            this.fMontos});
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeudaDetalle.DefaultCellStyle = dataGridViewCellStyle39;
            this.dgvDeudaDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeudaDetalle.Location = new System.Drawing.Point(3, 3);
            this.dgvDeudaDetalle.MultiSelect = false;
            this.dgvDeudaDetalle.Name = "dgvDeudaDetalle";
            this.dgvDeudaDetalle.ReadOnly = true;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeudaDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.dgvDeudaDetalle.RowHeadersVisible = false;
            this.dgvDeudaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeudaDetalle.Size = new System.Drawing.Size(901, 339);
            this.dgvDeudaDetalle.TabIndex = 1;
            // 
            // nIdDetalleDeuda
            // 
            this.nIdDetalleDeuda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdDetalleDeuda.DataPropertyName = "nIdDetalleDeuda";
            this.nIdDetalleDeuda.HeaderText = "IdDetalleDeuda";
            this.nIdDetalleDeuda.Name = "nIdDetalleDeuda";
            this.nIdDetalleDeuda.ReadOnly = true;
            this.nIdDetalleDeuda.Visible = false;
            // 
            // nIdDeudas
            // 
            this.nIdDeudas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdDeudas.DataPropertyName = "nIdDeuda";
            this.nIdDeudas.HeaderText = "IdDeuda";
            this.nIdDeudas.Name = "nIdDeudas";
            this.nIdDeudas.ReadOnly = true;
            this.nIdDeudas.Visible = false;
            // 
            // dFechas
            // 
            this.dFechas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFechas.DataPropertyName = "dFecha";
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.Format = "d";
            dataGridViewCellStyle36.NullValue = null;
            this.dFechas.DefaultCellStyle = dataGridViewCellStyle36;
            this.dFechas.HeaderText = "Fecha";
            this.dFechas.Name = "dFechas";
            this.dFechas.ReadOnly = true;
            this.dFechas.Width = 71;
            // 
            // Observacion
            // 
            this.Observacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Observacion.DataPropertyName = "sObservacion";
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Observacion.DefaultCellStyle = dataGridViewCellStyle37;
            this.Observacion.HeaderText = "Observación";
            this.Observacion.Name = "Observacion";
            this.Observacion.ReadOnly = true;
            this.Observacion.Width = 111;
            // 
            // fMontos
            // 
            this.fMontos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fMontos.DataPropertyName = "fMonto";
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle38.Format = "C2";
            dataGridViewCellStyle38.NullValue = null;
            this.fMontos.DefaultCellStyle = dataGridViewCellStyle38;
            this.fMontos.HeaderText = "Monto";
            this.fMontos.Name = "fMontos";
            this.fMontos.ReadOnly = true;
            this.fMontos.Width = 72;
            // 
            // FrmDeudasPorPagar
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
            this.Name = "FrmDeudasPorPagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deudas Por Pagar";
            this.Load += new System.EventHandler(this.FrmDeudasPorPagar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDeudasPorPagar_KeyDown);
            this.PanOpciones.ResumeLayout(false);
            this.PanSuperior.ResumeLayout(false);
            this.PanSuperior.PerformLayout();
            this.PanInferior.ResumeLayout(false);
            this.PanInferior.PerformLayout();
            this.PanTodo.ResumeLayout(false);
            this.TabConsulta.ResumeLayout(false);
            this.TabCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudas)).EndInit();
            this.TabDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudaDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PanOpciones;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.Panel PanSuperior;
        internal System.Windows.Forms.Panel PanInferior;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Panel PanTodo;
        internal System.Windows.Forms.Button BtnAgregar;
        internal System.Windows.Forms.Button BtnEliminar;
        internal System.Windows.Forms.Button BtnDetalle;
        internal System.Windows.Forms.Label lblCodigoProveedor;
        internal System.Windows.Forms.Label lblNombre;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtRuc;
        internal System.Windows.Forms.RadioButton rdProveedor;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.DateTimePicker dtFechaFin;
        internal System.Windows.Forms.DateTimePicker dtFechaInicio;
        internal System.Windows.Forms.RadioButton rdFecha;
        internal System.Windows.Forms.TabControl TabConsulta;
        internal System.Windows.Forms.TabPage TabCompras;
        internal System.Windows.Forms.DataGridView dgvDeudas;
        internal System.Windows.Forms.TabPage TabDetalle;
        internal System.Windows.Forms.DataGridView dgvDeudaDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdDeuda;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn sObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn fMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdDetalleDeuda;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdDeudas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fMontos;
    }
}