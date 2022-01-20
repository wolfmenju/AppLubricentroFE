namespace AppInguiri
{
    partial class FrmPermiso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPermiso));
            this.PanSuperior = new System.Windows.Forms.Panel();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.DgvPermiso = new System.Windows.Forms.DataGridView();
            this.CodPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xCodMenux = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDescripcionx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanDerecho = new System.Windows.Forms.Panel();
            this.PanIzquierdo = new System.Windows.Forms.Panel();
            this.DgvTodoPermiso = new System.Windows.Forms.DataGridView();
            this.nIdMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.BtnRefrescar = new System.Windows.Forms.Button();
            this.BtnQuitar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnSiguiente = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.PanSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPermiso)).BeginInit();
            this.PanDerecho.SuspendLayout();
            this.PanIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTodoPermiso)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanSuperior
            // 
            this.PanSuperior.BackColor = System.Drawing.Color.White;
            this.PanSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSuperior.Controls.Add(this.cboUsuario);
            this.PanSuperior.Controls.Add(this.Label4);
            this.PanSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanSuperior.Name = "PanSuperior";
            this.PanSuperior.Size = new System.Drawing.Size(1082, 42);
            this.PanSuperior.TabIndex = 2;
            // 
            // cboUsuario
            // 
            this.cboUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(64, 10);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(422, 21);
            this.cboUsuario.TabIndex = 0;
            this.cboUsuario.TabStop = false;
            this.cboUsuario.SelectionChangeCommitted += new System.EventHandler(this.cboUsuario_SelectionChangeCommitted);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(11, 14);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(50, 13);
            this.Label4.TabIndex = 15;
            this.Label4.Text = "Usuario";
            // 
            // DgvPermiso
            // 
            this.DgvPermiso.AllowUserToAddRows = false;
            this.DgvPermiso.AllowUserToDeleteRows = false;
            this.DgvPermiso.AllowUserToResizeColumns = false;
            this.DgvPermiso.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvPermiso.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.DgvPermiso.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DgvPermiso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPermiso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvPermiso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPermiso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodPermiso,
            this.xCodMenux,
            this.Codificacion,
            this.xDescripcionx});
            this.DgvPermiso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPermiso.Location = new System.Drawing.Point(0, 0);
            this.DgvPermiso.MultiSelect = false;
            this.DgvPermiso.Name = "DgvPermiso";
            this.DgvPermiso.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPermiso.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DgvPermiso.RowHeadersVisible = false;
            this.DgvPermiso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPermiso.Size = new System.Drawing.Size(482, 418);
            this.DgvPermiso.TabIndex = 31;
            // 
            // CodPermiso
            // 
            this.CodPermiso.DataPropertyName = "nIdPermiso";
            this.CodPermiso.HeaderText = "CodPermiso";
            this.CodPermiso.Name = "CodPermiso";
            this.CodPermiso.ReadOnly = true;
            this.CodPermiso.Visible = false;
            // 
            // xCodMenux
            // 
            this.xCodMenux.DataPropertyName = "nIdMenu";
            this.xCodMenux.HeaderText = "CodMenu";
            this.xCodMenux.Name = "xCodMenux";
            this.xCodMenux.ReadOnly = true;
            this.xCodMenux.Visible = false;
            // 
            // Codificacion
            // 
            this.Codificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Codificacion.DataPropertyName = "nTag";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codificacion.DefaultCellStyle = dataGridViewCellStyle13;
            this.Codificacion.HeaderText = "Tag";
            this.Codificacion.Name = "Codificacion";
            this.Codificacion.ReadOnly = true;
            this.Codificacion.Width = 54;
            // 
            // xDescripcionx
            // 
            this.xDescripcionx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.xDescripcionx.DataPropertyName = "sDescripcion";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.xDescripcionx.DefaultCellStyle = dataGridViewCellStyle14;
            this.xDescripcionx.HeaderText = "Descripcion";
            this.xDescripcionx.Name = "xDescripcionx";
            this.xDescripcionx.ReadOnly = true;
            this.xDescripcionx.Width = 99;
            // 
            // PanDerecho
            // 
            this.PanDerecho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanDerecho.Controls.Add(this.DgvPermiso);
            this.PanDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanDerecho.Location = new System.Drawing.Point(598, 42);
            this.PanDerecho.Name = "PanDerecho";
            this.PanDerecho.Size = new System.Drawing.Size(484, 420);
            this.PanDerecho.TabIndex = 32;
            // 
            // PanIzquierdo
            // 
            this.PanIzquierdo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanIzquierdo.Controls.Add(this.DgvTodoPermiso);
            this.PanIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanIzquierdo.Location = new System.Drawing.Point(0, 42);
            this.PanIzquierdo.Name = "PanIzquierdo";
            this.PanIzquierdo.Size = new System.Drawing.Size(484, 420);
            this.PanIzquierdo.TabIndex = 33;
            // 
            // DgvTodoPermiso
            // 
            this.DgvTodoPermiso.AllowUserToAddRows = false;
            this.DgvTodoPermiso.AllowUserToDeleteRows = false;
            this.DgvTodoPermiso.AllowUserToResizeColumns = false;
            this.DgvTodoPermiso.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvTodoPermiso.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.DgvTodoPermiso.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DgvTodoPermiso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvTodoPermiso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.DgvTodoPermiso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTodoPermiso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdMenu,
            this.nTag,
            this.sDescripcion});
            this.DgvTodoPermiso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTodoPermiso.Location = new System.Drawing.Point(0, 0);
            this.DgvTodoPermiso.MultiSelect = false;
            this.DgvTodoPermiso.Name = "DgvTodoPermiso";
            this.DgvTodoPermiso.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvTodoPermiso.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.DgvTodoPermiso.RowHeadersVisible = false;
            this.DgvTodoPermiso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTodoPermiso.Size = new System.Drawing.Size(482, 418);
            this.DgvTodoPermiso.TabIndex = 2;
            // 
            // nIdMenu
            // 
            this.nIdMenu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdMenu.DataPropertyName = "nIdMenu";
            this.nIdMenu.HeaderText = "CodMenu";
            this.nIdMenu.Name = "nIdMenu";
            this.nIdMenu.ReadOnly = true;
            this.nIdMenu.Visible = false;
            // 
            // nTag
            // 
            this.nTag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nTag.DataPropertyName = "nTag";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nTag.DefaultCellStyle = dataGridViewCellStyle18;
            this.nTag.HeaderText = "Tag";
            this.nTag.Name = "nTag";
            this.nTag.ReadOnly = true;
            this.nTag.Width = 54;
            // 
            // sDescripcion
            // 
            this.sDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sDescripcion.DataPropertyName = "sDescripcion";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sDescripcion.DefaultCellStyle = dataGridViewCellStyle19;
            this.sDescripcion.HeaderText = "Descripción";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 99;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.White;
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.BtnRefrescar);
            this.Panel2.Controls.Add(this.BtnQuitar);
            this.Panel2.Controls.Add(this.BtnBuscar);
            this.Panel2.Controls.Add(this.BtnSiguiente);
            this.Panel2.Controls.Add(this.BtnSalir);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(484, 42);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(114, 420);
            this.Panel2.TabIndex = 34;
            // 
            // BtnRefrescar
            // 
            this.BtnRefrescar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnRefrescar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefrescar.ForeColor = System.Drawing.Color.Black;
            this.BtnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefrescar.Image")));
            this.BtnRefrescar.Location = new System.Drawing.Point(7, 179);
            this.BtnRefrescar.Name = "BtnRefrescar";
            this.BtnRefrescar.Size = new System.Drawing.Size(99, 52);
            this.BtnRefrescar.TabIndex = 8;
            this.BtnRefrescar.TabStop = false;
            this.BtnRefrescar.Text = "&Refrescar [F4]";
            this.BtnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnRefrescar.UseVisualStyleBackColor = true;
            this.BtnRefrescar.Click += new System.EventHandler(this.BtnRefrescar_Click);
            // 
            // BtnQuitar
            // 
            this.BtnQuitar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnQuitar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuitar.ForeColor = System.Drawing.Color.Black;
            this.BtnQuitar.Image = global::AppInguiri.Properties.Resources.Izquierda;
            this.BtnQuitar.Location = new System.Drawing.Point(7, 63);
            this.BtnQuitar.Name = "BtnQuitar";
            this.BtnQuitar.Size = new System.Drawing.Size(99, 52);
            this.BtnQuitar.TabIndex = 6;
            this.BtnQuitar.TabStop = false;
            this.BtnQuitar.Text = "&Quitar   [F2]";
            this.BtnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnQuitar.UseVisualStyleBackColor = true;
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(7, 121);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(99, 52);
            this.BtnBuscar.TabIndex = 7;
            this.BtnBuscar.TabStop = false;
            this.BtnBuscar.Text = "&Buscar     [F3]";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnSiguiente
            // 
            this.BtnSiguiente.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSiguiente.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSiguiente.ForeColor = System.Drawing.Color.Black;
            this.BtnSiguiente.Image = global::AppInguiri.Properties.Resources.Derecha;
            this.BtnSiguiente.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSiguiente.Location = new System.Drawing.Point(7, 5);
            this.BtnSiguiente.Name = "BtnSiguiente";
            this.BtnSiguiente.Size = new System.Drawing.Size(99, 52);
            this.BtnSiguiente.TabIndex = 5;
            this.BtnSiguiente.TabStop = false;
            this.BtnSiguiente.Text = "&Agregar [F1]";
            this.BtnSiguiente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSiguiente.UseVisualStyleBackColor = true;
            this.BtnSiguiente.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.BtnSalir.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Black;
            this.BtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("BtnSalir.Image")));
            this.BtnSalir.Location = new System.Drawing.Point(7, 355);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(99, 52);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.TabStop = false;
            this.BtnSalir.Text = "&Salir       [Esc]";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(1082, 462);
            this.ControlBox = false;
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.PanIzquierdo);
            this.Controls.Add(this.PanDerecho);
            this.Controls.Add(this.PanSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPermiso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos de Usuario";
            this.Load += new System.EventHandler(this.FrmPermiso_Load);
            this.SizeChanged += new System.EventHandler(this.FrmPermiso_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPermiso_KeyDown);
            this.PanSuperior.ResumeLayout(false);
            this.PanSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPermiso)).EndInit();
            this.PanDerecho.ResumeLayout(false);
            this.PanIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTodoPermiso)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PanSuperior;
        internal System.Windows.Forms.ComboBox cboUsuario;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DataGridView DgvPermiso;
        internal System.Windows.Forms.Panel PanDerecho;
        internal System.Windows.Forms.Panel PanIzquierdo;
        internal System.Windows.Forms.DataGridView DgvTodoPermiso;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnRefrescar;
        internal System.Windows.Forms.Button BtnQuitar;
        internal System.Windows.Forms.Button BtnBuscar;
        internal System.Windows.Forms.Button BtnSiguiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn xCodMenux;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDescripcionx;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
    }
}