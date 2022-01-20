namespace AppInguiri
{
    partial class FrmProductoListar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanSuperior = new System.Windows.Forms.Panel();
            this.CboTipoBusqueda = new System.Windows.Forms.ComboBox();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblTotal = new System.Windows.Forms.Label();
            this.PanOpciones = new System.Windows.Forms.Panel();
            this.NdCantidad = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.dtVencimiento = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtVenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtCompra = new System.Windows.Forms.TextBox();
            this.PanLotes = new System.Windows.Forms.Panel();
            this.DgvDetalles = new System.Windows.Forms.DataGridView();
            this.PanProducto = new System.Windows.Forms.Panel();
            this.DgvProducto = new System.Windows.Forms.DataGridView();
            this.nIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodigoInterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bAlternativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sLaboratorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPrincipioActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIdProductoHistorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PanSuperior.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanOpciones.SuspendLayout();
            this.PanLotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).BeginInit();
            this.PanProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // PanSuperior
            // 
            this.PanSuperior.BackColor = System.Drawing.Color.White;
            this.PanSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSuperior.Controls.Add(this.CboTipoBusqueda);
            this.PanSuperior.Controls.Add(this.BtnNuevo);
            this.PanSuperior.Controls.Add(this.txtDescripcion);
            this.PanSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanSuperior.Name = "PanSuperior";
            this.PanSuperior.Size = new System.Drawing.Size(1075, 47);
            this.PanSuperior.TabIndex = 17;
            // 
            // CboTipoBusqueda
            // 
            this.CboTipoBusqueda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CboTipoBusqueda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipoBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoBusqueda.FormattingEnabled = true;
            this.CboTipoBusqueda.Items.AddRange(new object[] {
            "CODIGO INTERNO",
            "PRODUCTO"});
            this.CboTipoBusqueda.Location = new System.Drawing.Point(7, 9);
            this.CboTipoBusqueda.Name = "CboTipoBusqueda";
            this.CboTipoBusqueda.Size = new System.Drawing.Size(138, 21);
            this.CboTipoBusqueda.TabIndex = 26;
            this.CboTipoBusqueda.TabStop = false;
            this.CboTipoBusqueda.SelectedIndexChanged += new System.EventHandler(this.CboTipoBusqueda_SelectedIndexChanged);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.Location = new System.Drawing.Point(988, 9);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(78, 23);
            this.BtnNuevo.TabIndex = 25;
            this.BtnNuevo.TabStop = false;
            this.BtnNuevo.Text = "Nuevo [F1]";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(151, 10);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(831, 20);
            this.txtDescripcion.TabIndex = 24;
            this.txtDescripcion.Tag = "2";
            this.txtDescripcion.GotFocus += new System.EventHandler(this.txtDescripcion_GotFocus);
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            this.txtDescripcion.LostFocus += new System.EventHandler(this.txtDescripcion_LostFocus);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.LblTotal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 17);
            this.panel1.TabIndex = 19;
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
            // PanOpciones
            // 
            this.PanOpciones.BackColor = System.Drawing.Color.White;
            this.PanOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanOpciones.Controls.Add(this.NdCantidad);
            this.PanOpciones.Controls.Add(this.lblMonto);
            this.PanOpciones.Controls.Add(this.dtVencimiento);
            this.PanOpciones.Controls.Add(this.Label5);
            this.PanOpciones.Controls.Add(this.Label4);
            this.PanOpciones.Controls.Add(this.txtLote);
            this.PanOpciones.Controls.Add(this.Label2);
            this.PanOpciones.Controls.Add(this.txtVenta);
            this.PanOpciones.Controls.Add(this.label3);
            this.PanOpciones.Controls.Add(this.Label10);
            this.PanOpciones.Controls.Add(this.txtCompra);
            this.PanOpciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanOpciones.Location = new System.Drawing.Point(0, 390);
            this.PanOpciones.Name = "PanOpciones";
            this.PanOpciones.Size = new System.Drawing.Size(1075, 40);
            this.PanOpciones.TabIndex = 20;
            // 
            // NdCantidad
            // 
            this.NdCantidad.BackColor = System.Drawing.Color.Green;
            this.NdCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NdCantidad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NdCantidad.ForeColor = System.Drawing.Color.White;
            this.NdCantidad.Location = new System.Drawing.Point(67, 7);
            this.NdCantidad.MaxLength = 20;
            this.NdCantidad.Name = "NdCantidad";
            this.NdCantidad.Size = new System.Drawing.Size(78, 22);
            this.NdCantidad.TabIndex = 33;
            this.NdCantidad.Tag = "2";
            this.NdCantidad.Text = "0";
            this.NdCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NdCantidad.TextChanged += new System.EventHandler(this.NdCantidad_TextChanged);
            this.NdCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NdCantidad_KeyDown);
            this.NdCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NdCantidad_KeyPress);
            // 
            // lblMonto
            // 
            this.lblMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.ForeColor = System.Drawing.Color.Blue;
            this.lblMonto.Location = new System.Drawing.Point(916, 4);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(148, 30);
            this.lblMonto.TabIndex = 5;
            this.lblMonto.Text = "0.00";
            this.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtVencimiento
            // 
            this.dtVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVencimiento.Location = new System.Drawing.Point(632, 9);
            this.dtVencimiento.Name = "dtVencimiento";
            this.dtVencimiento.Size = new System.Drawing.Size(95, 21);
            this.dtVencimiento.TabIndex = 4;
            this.dtVencimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtVencimiento_KeyDown);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(552, 13);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 13);
            this.Label5.TabIndex = 32;
            this.Label5.Text = "Fecha Venc.";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(549, 13);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(32, 13);
            this.Label4.TabIndex = 30;
            this.Label4.Text = "Lote";
            this.Label4.Visible = false;
            // 
            // txtLote
            // 
            this.txtLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLote.ForeColor = System.Drawing.Color.Black;
            this.txtLote.Location = new System.Drawing.Point(584, 9);
            this.txtLote.MaxLength = 20;
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(94, 21);
            this.txtLote.TabIndex = 3;
            this.txtLote.Tag = "2";
            this.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLote.Visible = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(355, 13);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 13);
            this.Label2.TabIndex = 28;
            this.Label2.Text = "Precio Venta";
            // 
            // txtVenta
            // 
            this.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVenta.ForeColor = System.Drawing.Color.Black;
            this.txtVenta.Location = new System.Drawing.Point(438, 9);
            this.txtVenta.MaxLength = 20;
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(94, 21);
            this.txtVenta.TabIndex = 2;
            this.txtVenta.Tag = "2";
            this.txtVenta.Text = "0.00";
            this.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVenta_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(152, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Precio Compra";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(10, 12);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(57, 13);
            this.Label10.TabIndex = 24;
            this.Label10.Text = "Cantidad";
            // 
            // txtCompra
            // 
            this.txtCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompra.ForeColor = System.Drawing.Color.Black;
            this.txtCompra.Location = new System.Drawing.Point(244, 9);
            this.txtCompra.MaxLength = 20;
            this.txtCompra.Name = "txtCompra";
            this.txtCompra.Size = new System.Drawing.Size(94, 21);
            this.txtCompra.TabIndex = 1;
            this.txtCompra.Tag = "2";
            this.txtCompra.Text = "0.00";
            this.txtCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCompra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompra_KeyDown);
            this.txtCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompra_KeyPress);
            // 
            // PanLotes
            // 
            this.PanLotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanLotes.Controls.Add(this.DgvDetalles);
            this.PanLotes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanLotes.Location = new System.Drawing.Point(0, 257);
            this.PanLotes.Name = "PanLotes";
            this.PanLotes.Size = new System.Drawing.Size(1075, 133);
            this.PanLotes.TabIndex = 21;
            // 
            // DgvDetalles
            // 
            this.DgvDetalles.AllowUserToAddRows = false;
            this.DgvDetalles.AllowUserToDeleteRows = false;
            this.DgvDetalles.AllowUserToResizeColumns = false;
            this.DgvDetalles.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvDetalles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.DgvDetalles.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DgvDetalles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.DgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdProductoHistorial,
            this.sLote,
            this.dFechaVencimiento,
            this.fPrecioCompra,
            this.fPrecioVenta,
            this.nStock,
            this.bSeleccionar});
            this.DgvDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDetalles.Location = new System.Drawing.Point(0, 0);
            this.DgvDetalles.MultiSelect = false;
            this.DgvDetalles.Name = "DgvDetalles";
            this.DgvDetalles.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.DgvDetalles.RowHeadersVisible = false;
            this.DgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDetalles.Size = new System.Drawing.Size(1073, 131);
            this.DgvDetalles.TabIndex = 0;
            this.DgvDetalles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalles_CellDoubleClick);
            this.DgvDetalles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDetalles_KeyDown);
            // 
            // PanProducto
            // 
            this.PanProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanProducto.Controls.Add(this.DgvProducto);
            this.PanProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanProducto.Location = new System.Drawing.Point(0, 47);
            this.PanProducto.Name = "PanProducto";
            this.PanProducto.Size = new System.Drawing.Size(1075, 210);
            this.PanProducto.TabIndex = 22;
            // 
            // DgvProducto
            // 
            this.DgvProducto.AllowUserToAddRows = false;
            this.DgvProducto.AllowUserToDeleteRows = false;
            this.DgvProducto.AllowUserToResizeColumns = false;
            this.DgvProducto.AllowUserToResizeRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.DgvProducto.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DgvProducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.DgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdProducto,
            this.sCodigoInterno,
            this.sDescripcion,
            this.bAlternativo,
            this.sLaboratorio,
            this.nTotal,
            this.sPrincipioActivo,
            this.sPresentacion});
            this.DgvProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProducto.Location = new System.Drawing.Point(0, 0);
            this.DgvProducto.MultiSelect = false;
            this.DgvProducto.Name = "DgvProducto";
            this.DgvProducto.ReadOnly = true;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.DgvProducto.RowHeadersVisible = false;
            this.DgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProducto.Size = new System.Drawing.Size(1073, 208);
            this.DgvProducto.TabIndex = 0;
            this.DgvProducto.SelectionChanged += new System.EventHandler(this.DgvProducto_SelectionChanged);
            this.DgvProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvProducto_KeyDown);
            // 
            // nIdProducto
            // 
            this.nIdProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdProducto.DataPropertyName = "nIdProducto";
            this.nIdProducto.Frozen = true;
            this.nIdProducto.HeaderText = "IdProducto";
            this.nIdProducto.Name = "nIdProducto";
            this.nIdProducto.ReadOnly = true;
            this.nIdProducto.Visible = false;
            // 
            // sCodigoInterno
            // 
            this.sCodigoInterno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sCodigoInterno.DataPropertyName = "sCodigoInterno";
            this.sCodigoInterno.Frozen = true;
            this.sCodigoInterno.HeaderText = "Codigo Interno";
            this.sCodigoInterno.Name = "sCodigoInterno";
            this.sCodigoInterno.ReadOnly = true;
            this.sCodigoInterno.Width = 96;
            // 
            // sDescripcion
            // 
            this.sDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sDescripcion.DataPropertyName = "sDescripcion";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sDescripcion.DefaultCellStyle = dataGridViewCellStyle27;
            this.sDescripcion.Frozen = true;
            this.sDescripcion.HeaderText = "Producto";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 75;
            // 
            // bAlternativo
            // 
            this.bAlternativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bAlternativo.DataPropertyName = "bAlternativo";
            this.bAlternativo.HeaderText = "Alternativo";
            this.bAlternativo.Name = "bAlternativo";
            this.bAlternativo.ReadOnly = true;
            this.bAlternativo.Visible = false;
            // 
            // sLaboratorio
            // 
            this.sLaboratorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sLaboratorio.DataPropertyName = "sLaboratorio";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sLaboratorio.DefaultCellStyle = dataGridViewCellStyle28;
            this.sLaboratorio.HeaderText = "Categoria";
            this.sLaboratorio.Name = "sLaboratorio";
            this.sLaboratorio.ReadOnly = true;
            this.sLaboratorio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sLaboratorio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sLaboratorio.Width = 60;
            // 
            // nTotal
            // 
            this.nTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nTotal.DataPropertyName = "nTotal";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.Format = "N0";
            dataGridViewCellStyle29.NullValue = "0";
            this.nTotal.DefaultCellStyle = dataGridViewCellStyle29;
            this.nTotal.HeaderText = "Total";
            this.nTotal.Name = "nTotal";
            this.nTotal.ReadOnly = true;
            this.nTotal.Width = 56;
            // 
            // sPrincipioActivo
            // 
            this.sPrincipioActivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sPrincipioActivo.DataPropertyName = "sPrincipioActivo";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sPrincipioActivo.DefaultCellStyle = dataGridViewCellStyle30;
            this.sPrincipioActivo.HeaderText = "Referencia";
            this.sPrincipioActivo.Name = "sPrincipioActivo";
            this.sPrincipioActivo.ReadOnly = true;
            this.sPrincipioActivo.Width = 84;
            // 
            // sPresentacion
            // 
            this.sPresentacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sPresentacion.DataPropertyName = "sPresentacion";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sPresentacion.DefaultCellStyle = dataGridViewCellStyle31;
            this.sPresentacion.HeaderText = "Presentación";
            this.sPresentacion.Name = "sPresentacion";
            this.sPresentacion.ReadOnly = true;
            this.sPresentacion.Width = 94;
            // 
            // nIdProductoHistorial
            // 
            this.nIdProductoHistorial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdProductoHistorial.DataPropertyName = "nIdProductoHistorial";
            this.nIdProductoHistorial.HeaderText = "IdHistorial";
            this.nIdProductoHistorial.Name = "nIdProductoHistorial";
            this.nIdProductoHistorial.ReadOnly = true;
            this.nIdProductoHistorial.Visible = false;
            this.nIdProductoHistorial.Width = 61;
            // 
            // sLote
            // 
            this.sLote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sLote.DataPropertyName = "sLote";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sLote.DefaultCellStyle = dataGridViewCellStyle19;
            this.sLote.HeaderText = "Lote";
            this.sLote.Name = "sLote";
            this.sLote.ReadOnly = true;
            this.sLote.Visible = false;
            this.sLote.Width = 34;
            // 
            // dFechaVencimiento
            // 
            this.dFechaVencimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFechaVencimiento.DataPropertyName = "dFechaVencimiento";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Format = "d";
            dataGridViewCellStyle20.NullValue = null;
            this.dFechaVencimiento.DefaultCellStyle = dataGridViewCellStyle20;
            this.dFechaVencimiento.HeaderText = "Vencimiento";
            this.dFechaVencimiento.Name = "dFechaVencimiento";
            this.dFechaVencimiento.ReadOnly = true;
            this.dFechaVencimiento.Visible = false;
            this.dFechaVencimiento.Width = 70;
            // 
            // fPrecioCompra
            // 
            this.fPrecioCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fPrecioCompra.DataPropertyName = "fPrecioCompra";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "C2";
            dataGridViewCellStyle21.NullValue = null;
            this.fPrecioCompra.DefaultCellStyle = dataGridViewCellStyle21;
            this.fPrecioCompra.HeaderText = "Precio Compra";
            this.fPrecioCompra.Name = "fPrecioCompra";
            this.fPrecioCompra.ReadOnly = true;
            this.fPrecioCompra.Width = 101;
            // 
            // fPrecioVenta
            // 
            this.fPrecioVenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fPrecioVenta.DataPropertyName = "fPrecioVenta";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "C2";
            this.fPrecioVenta.DefaultCellStyle = dataGridViewCellStyle22;
            this.fPrecioVenta.HeaderText = "Precio Venta";
            this.fPrecioVenta.Name = "fPrecioVenta";
            this.fPrecioVenta.ReadOnly = true;
            this.fPrecioVenta.Width = 92;
            // 
            // nStock
            // 
            this.nStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nStock.DataPropertyName = "nStock";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nStock.DefaultCellStyle = dataGridViewCellStyle23;
            this.nStock.HeaderText = "Stock";
            this.nStock.Name = "nStock";
            this.nStock.ReadOnly = true;
            this.nStock.Width = 58;
            // 
            // bSeleccionar
            // 
            this.bSeleccionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bSeleccionar.DataPropertyName = "bSeleccionar";
            this.bSeleccionar.HeaderText = "Seleccionar";
            this.bSeleccionar.Name = "bSeleccionar";
            this.bSeleccionar.ReadOnly = true;
            this.bSeleccionar.Width = 67;
            // 
            // FrmProductoListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 447);
            this.ControlBox = false;
            this.Controls.Add(this.PanProducto);
            this.Controls.Add(this.PanLotes);
            this.Controls.Add(this.PanOpciones);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanSuperior);
            this.KeyPreview = true;
            this.Name = "FrmProductoListar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda De Productos";
            this.Load += new System.EventHandler(this.FrmCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProductoListar_KeyDown);
            this.PanSuperior.ResumeLayout(false);
            this.PanSuperior.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanOpciones.ResumeLayout(false);
            this.PanOpciones.PerformLayout();
            this.PanLotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).EndInit();
            this.PanProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PanSuperior;
        internal System.Windows.Forms.ComboBox CboTipoBusqueda;
        internal System.Windows.Forms.Button BtnNuevo;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label LblTotal;
        internal System.Windows.Forms.Panel PanOpciones;
        internal System.Windows.Forms.Label lblMonto;
        internal System.Windows.Forms.DateTimePicker dtVencimiento;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtLote;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtVenta;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtCompra;
        internal System.Windows.Forms.Panel PanLotes;
        internal System.Windows.Forms.DataGridView DgvDetalles;
        internal System.Windows.Forms.Panel PanProducto;
        internal System.Windows.Forms.DataGridView DgvProducto;
        internal System.Windows.Forms.TextBox NdCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCodigoInterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bAlternativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLaboratorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPrincipioActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdProductoHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fPrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn fPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nStock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bSeleccionar;
    }
}