namespace AppInguiri
{
    partial class FrmActualizarPrecio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActualizarPrecio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanOpciones = new System.Windows.Forms.Panel();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.PanSuperior = new System.Windows.Forms.Panel();
            this.cboTipoProducto = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.PanInferior = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabMedicamento = new System.Windows.Forms.TabPage();
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.TabDetalle = new System.Windows.Forms.TabPage();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.nIdProductoHistorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PanProducto = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bAlternativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLaboratorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPrincipioActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanOpciones.SuspendLayout();
            this.PanSuperior.SuspendLayout();
            this.PanInferior.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TabMedicamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.TabDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            this.PanProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanOpciones
            // 
            this.PanOpciones.BackColor = System.Drawing.Color.White;
            this.PanOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanOpciones.Controls.Add(this.btnDetalle);
            this.PanOpciones.Controls.Add(this.btnSalir);
            this.PanOpciones.Controls.Add(this.btnModificar);
            this.PanOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanOpciones.Location = new System.Drawing.Point(938, 0);
            this.PanOpciones.Name = "PanOpciones";
            this.PanOpciones.Size = new System.Drawing.Size(109, 480);
            this.PanOpciones.TabIndex = 3;
            // 
            // btnDetalle
            // 
            this.btnDetalle.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.ForeColor = System.Drawing.Color.Black;
            this.btnDetalle.Image = global::AppInguiri.Properties.Resources.xDetalle;
            this.btnDetalle.Location = new System.Drawing.Point(2, 7);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(102, 52);
            this.btnDetalle.TabIndex = 0;
            this.btnDetalle.TabStop = false;
            this.btnDetalle.Text = "&Detalle   [F1]";
            this.btnDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = global::AppInguiri.Properties.Resources.xSalir1;
            this.btnSalir.Location = new System.Drawing.Point(3, 415);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 52);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "&Salir      [Esc]";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.Black;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.Location = new System.Drawing.Point(3, 64);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(102, 52);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.TabStop = false;
            this.btnModificar.Text = "&Actualizar [F2]";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // PanSuperior
            // 
            this.PanSuperior.BackColor = System.Drawing.Color.White;
            this.PanSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSuperior.Controls.Add(this.cboTipoProducto);
            this.PanSuperior.Controls.Add(this.Label3);
            this.PanSuperior.Controls.Add(this.txtDescripcion);
            this.PanSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanSuperior.Name = "PanSuperior";
            this.PanSuperior.Size = new System.Drawing.Size(938, 36);
            this.PanSuperior.TabIndex = 4;
            // 
            // cboTipoProducto
            // 
            this.cboTipoProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTipoProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoProducto.FormattingEnabled = true;
            this.cboTipoProducto.Items.AddRange(new object[] {
            "PRODUCTOS",
            "PRINCIPIO ACTIVO"});
            this.cboTipoProducto.Location = new System.Drawing.Point(11, 6);
            this.cboTipoProducto.Name = "cboTipoProducto";
            this.cboTipoProducto.Size = new System.Drawing.Size(138, 21);
            this.cboTipoProducto.TabIndex = 23;
            this.cboTipoProducto.TabStop = false;
            this.cboTipoProducto.SelectionChangeCommitted += new System.EventHandler(this.cboTipoProducto_SelectionChangeCommitted);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(10, 10);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(82, 13);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Medicamento";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(155, 7);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(765, 20);
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
            this.PanInferior.Size = new System.Drawing.Size(938, 20);
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
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabMedicamento);
            this.TabControl.Controls.Add(this.TabDetalle);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl.Location = new System.Drawing.Point(0, 36);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(938, 424);
            this.TabControl.TabIndex = 6;
            this.TabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_Selecting);
            // 
            // TabMedicamento
            // 
            this.TabMedicamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.TabMedicamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabMedicamento.Controls.Add(this.dgvProducto);
            this.TabMedicamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabMedicamento.Location = new System.Drawing.Point(4, 22);
            this.TabMedicamento.Name = "TabMedicamento";
            this.TabMedicamento.Padding = new System.Windows.Forms.Padding(3);
            this.TabMedicamento.Size = new System.Drawing.Size(930, 398);
            this.TabMedicamento.TabIndex = 0;
            this.TabMedicamento.Text = "Productos";
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sDescripcion,
            this.bAlternativo,
            this.sPresentacion,
            this.sLaboratorio,
            this.nTotal,
            this.sPrincipioActivo});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducto.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducto.Location = new System.Drawing.Point(3, 3);
            this.dgvProducto.MultiSelect = false;
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProducto.RowHeadersVisible = false;
            this.dgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducto.Size = new System.Drawing.Size(922, 390);
            this.dgvProducto.TabIndex = 1;
            this.dgvProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProducto_KeyDown);
            // 
            // TabDetalle
            // 
            this.TabDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.TabDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabDetalle.Controls.Add(this.dgvLotes);
            this.TabDetalle.Controls.Add(this.PanProducto);
            this.TabDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabDetalle.Location = new System.Drawing.Point(4, 22);
            this.TabDetalle.Name = "TabDetalle";
            this.TabDetalle.Padding = new System.Windows.Forms.Padding(3);
            this.TabDetalle.Size = new System.Drawing.Size(930, 398);
            this.TabDetalle.TabIndex = 1;
            this.TabDetalle.Text = "Detalle De Lotes";
            // 
            // dgvLotes
            // 
            this.dgvLotes.AllowUserToAddRows = false;
            this.dgvLotes.AllowUserToDeleteRows = false;
            this.dgvLotes.AllowUserToResizeColumns = false;
            this.dgvLotes.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvLotes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvLotes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvLotes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdProductoHistorial,
            this.sLote,
            this.dFechaVencimiento,
            this.fPrecioCompra,
            this.fPrecioVenta,
            this.nStock,
            this.bSeleccionar});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLotes.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvLotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLotes.Location = new System.Drawing.Point(3, 37);
            this.dgvLotes.MultiSelect = false;
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.ReadOnly = true;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLotes.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvLotes.RowHeadersVisible = false;
            this.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLotes.Size = new System.Drawing.Size(922, 356);
            this.dgvLotes.TabIndex = 0;
            // 
            // nIdProductoHistorial
            // 
            this.nIdProductoHistorial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdProductoHistorial.DataPropertyName = "nIdProductoHistorial";
            this.nIdProductoHistorial.HeaderText = "IdHistorial";
            this.nIdProductoHistorial.Name = "nIdProductoHistorial";
            this.nIdProductoHistorial.ReadOnly = true;
            this.nIdProductoHistorial.Visible = false;
            // 
            // sLote
            // 
            this.sLote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sLote.DataPropertyName = "sLote";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sLote.DefaultCellStyle = dataGridViewCellStyle11;
            this.sLote.HeaderText = "Lote";
            this.sLote.Name = "sLote";
            this.sLote.ReadOnly = true;
            this.sLote.Width = 60;
            // 
            // dFechaVencimiento
            // 
            this.dFechaVencimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFechaVencimiento.DataPropertyName = "dFechaVencimiento";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Format = "d";
            dataGridViewCellStyle12.NullValue = null;
            this.dFechaVencimiento.DefaultCellStyle = dataGridViewCellStyle12;
            this.dFechaVencimiento.HeaderText = "Fecha Vencimiento";
            this.dFechaVencimiento.Name = "dFechaVencimiento";
            this.dFechaVencimiento.ReadOnly = true;
            this.dFechaVencimiento.Width = 141;
            // 
            // fPrecioCompra
            // 
            this.fPrecioCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fPrecioCompra.DataPropertyName = "fPrecioCompra";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "C2";
            dataGridViewCellStyle13.NullValue = null;
            this.fPrecioCompra.DefaultCellStyle = dataGridViewCellStyle13;
            this.fPrecioCompra.HeaderText = "Precio Compra";
            this.fPrecioCompra.Name = "fPrecioCompra";
            this.fPrecioCompra.ReadOnly = true;
            this.fPrecioCompra.Width = 116;
            // 
            // fPrecioVenta
            // 
            this.fPrecioVenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fPrecioVenta.DataPropertyName = "fPrecioVenta";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "C2";
            this.fPrecioVenta.DefaultCellStyle = dataGridViewCellStyle14;
            this.fPrecioVenta.HeaderText = "Precio Venta";
            this.fPrecioVenta.Name = "fPrecioVenta";
            this.fPrecioVenta.ReadOnly = true;
            this.fPrecioVenta.Width = 104;
            // 
            // nStock
            // 
            this.nStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nStock.DataPropertyName = "nStock";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nStock.DefaultCellStyle = dataGridViewCellStyle15;
            this.nStock.HeaderText = "Stock";
            this.nStock.Name = "nStock";
            this.nStock.ReadOnly = true;
            this.nStock.Width = 67;
            // 
            // bSeleccionar
            // 
            this.bSeleccionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bSeleccionar.DataPropertyName = "bSeleccionar";
            this.bSeleccionar.HeaderText = "Seleccionar";
            this.bSeleccionar.Name = "bSeleccionar";
            this.bSeleccionar.ReadOnly = true;
            this.bSeleccionar.Visible = false;
            // 
            // PanProducto
            // 
            this.PanProducto.BackColor = System.Drawing.Color.PaleGreen;
            this.PanProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanProducto.Controls.Add(this.lblNombre);
            this.PanProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanProducto.Location = new System.Drawing.Point(3, 3);
            this.PanProducto.Name = "PanProducto";
            this.PanProducto.Size = new System.Drawing.Size(922, 34);
            this.PanProducto.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Blue;
            this.lblNombre.Location = new System.Drawing.Point(4, 6);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(909, 20);
            this.lblNombre.TabIndex = 34;
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sDescripcion
            // 
            this.sDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sDescripcion.DataPropertyName = "sDescripcion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sDescripcion.DefaultCellStyle = dataGridViewCellStyle3;
            this.sDescripcion.Frozen = true;
            this.sDescripcion.HeaderText = "Producto";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 89;
            // 
            // bAlternativo
            // 
            this.bAlternativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bAlternativo.DataPropertyName = "bAlternativo";
            this.bAlternativo.HeaderText = "Alternativo";
            this.bAlternativo.Name = "bAlternativo";
            this.bAlternativo.ReadOnly = true;
            this.bAlternativo.Visible = false;
            this.bAlternativo.Width = 80;
            // 
            // sPresentacion
            // 
            this.sPresentacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sPresentacion.DataPropertyName = "sPresentacion";
            this.sPresentacion.HeaderText = "Presentación";
            this.sPresentacion.Name = "sPresentacion";
            this.sPresentacion.ReadOnly = true;
            this.sPresentacion.Width = 116;
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
            this.sLaboratorio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sLaboratorio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sLaboratorio.Width = 75;
            // 
            // nTotal
            // 
            this.nTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nTotal.DataPropertyName = "nTotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.nTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.nTotal.HeaderText = "Total";
            this.nTotal.Name = "nTotal";
            this.nTotal.ReadOnly = true;
            this.nTotal.Width = 64;
            // 
            // sPrincipioActivo
            // 
            this.sPrincipioActivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sPrincipioActivo.DataPropertyName = "sPrincipioActivo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sPrincipioActivo.DefaultCellStyle = dataGridViewCellStyle6;
            this.sPrincipioActivo.HeaderText = "Principio Activo";
            this.sPrincipioActivo.Name = "sPrincipioActivo";
            this.sPrincipioActivo.ReadOnly = true;
            this.sPrincipioActivo.Width = 119;
            // 
            // FrmActualizarPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 480);
            this.ControlBox = false;
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.PanInferior);
            this.Controls.Add(this.PanSuperior);
            this.Controls.Add(this.PanOpciones);
            this.KeyPreview = true;
            this.Name = "FrmActualizarPrecio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizacion de Precio";
            this.Load += new System.EventHandler(this.FrmActualizarPrecio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmActualizarPrecio_KeyDown);
            this.PanOpciones.ResumeLayout(false);
            this.PanSuperior.ResumeLayout(false);
            this.PanSuperior.PerformLayout();
            this.PanInferior.ResumeLayout(false);
            this.PanInferior.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.TabMedicamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.TabDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.PanProducto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PanOpciones;
        internal System.Windows.Forms.Button btnDetalle;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button btnModificar;
        internal System.Windows.Forms.Panel PanSuperior;
        internal System.Windows.Forms.ComboBox cboTipoProducto;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.Panel PanInferior;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.TabControl TabControl;
        internal System.Windows.Forms.TabPage TabMedicamento;
        internal System.Windows.Forms.DataGridView dgvProducto;
        internal System.Windows.Forms.TabPage TabDetalle;
        internal System.Windows.Forms.DataGridView dgvLotes;
        internal System.Windows.Forms.Panel PanProducto;
        internal System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdProductoHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fPrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn fPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nStock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bAlternativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLaboratorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPrincipioActivo;
    }
}