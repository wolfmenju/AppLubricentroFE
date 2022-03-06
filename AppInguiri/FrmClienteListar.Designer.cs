namespace AppInguiri
{
    partial class FrmClienteListar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanSuperior = new System.Windows.Forms.Panel();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.DgProveedor = new System.Windows.Forms.DataGridView();
            this.IdProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanInferior = new System.Windows.Forms.Panel();
            this.LblTotal = new System.Windows.Forms.Label();
            this.PanTodo = new System.Windows.Forms.Panel();
            this.DgvCliente = new System.Windows.Forms.DataGridView();
            this.nIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNumeroDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgProveedor)).BeginInit();
            this.PanInferior.SuspendLayout();
            this.PanTodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // PanSuperior
            // 
            this.PanSuperior.BackColor = System.Drawing.Color.White;
            this.PanSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanSuperior.Controls.Add(this.BtnNuevo);
            this.PanSuperior.Controls.Add(this.txtDescripcion);
            this.PanSuperior.Controls.Add(this.txtRuc);
            this.PanSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanSuperior.Name = "PanSuperior";
            this.PanSuperior.Size = new System.Drawing.Size(815, 36);
            this.PanSuperior.TabIndex = 3;
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.Location = new System.Drawing.Point(728, 6);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(78, 23);
            this.BtnNuevo.TabIndex = 2;
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
            this.txtDescripcion.Location = new System.Drawing.Point(105, 7);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(615, 20);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.Tag = "2";
            this.txtDescripcion.GotFocus += new System.EventHandler(this.txtDescripcion_GotFocus);
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // txtRuc
            // 
            this.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.ForeColor = System.Drawing.Color.Black;
            this.txtRuc.Location = new System.Drawing.Point(11, 7);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(88, 20);
            this.txtRuc.TabIndex = 1;
            this.txtRuc.Tag = "2";
            this.txtRuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRuc_KeyDown);
            // 
            // DgProveedor
            // 
            this.DgProveedor.AllowUserToAddRows = false;
            this.DgProveedor.AllowUserToDeleteRows = false;
            this.DgProveedor.AllowUserToResizeColumns = false;
            this.DgProveedor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DgProveedor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgProveedor.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DgProveedor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProveedor,
            this.Documento,
            this.RazonSocial,
            this.Direccion});
            this.DgProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgProveedor.Location = new System.Drawing.Point(0, 0);
            this.DgProveedor.MultiSelect = false;
            this.DgProveedor.Name = "DgProveedor";
            this.DgProveedor.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgProveedor.RowHeadersVisible = false;
            this.DgProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgProveedor.Size = new System.Drawing.Size(815, 374);
            this.DgProveedor.TabIndex = 4;
            // 
            // IdProveedor
            // 
            this.IdProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdProveedor.DataPropertyName = "IdProveedor";
            this.IdProveedor.HeaderText = "IdProveedor";
            this.IdProveedor.Name = "IdProveedor";
            this.IdProveedor.ReadOnly = true;
            this.IdProveedor.Visible = false;
            // 
            // Documento
            // 
            this.Documento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Documento.DataPropertyName = "Ruc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Documento.DefaultCellStyle = dataGridViewCellStyle3;
            this.Documento.HeaderText = "Ruc/Dni";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            this.Documento.Width = 69;
            // 
            // RazonSocial
            // 
            this.RazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RazonSocial.DataPropertyName = "RazonSocial";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.RazonSocial.DefaultCellStyle = dataGridViewCellStyle4;
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.Width = 92;
            // 
            // Direccion
            // 
            this.Direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Direccion.DataPropertyName = "Direccion";
            this.Direccion.HeaderText = "Dirección";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 75;
            // 
            // PanInferior
            // 
            this.PanInferior.BackColor = System.Drawing.Color.White;
            this.PanInferior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanInferior.Controls.Add(this.LblTotal);
            this.PanInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanInferior.Location = new System.Drawing.Point(0, 374);
            this.PanInferior.Name = "PanInferior";
            this.PanInferior.Size = new System.Drawing.Size(815, 17);
            this.PanInferior.TabIndex = 5;
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
            // PanTodo
            // 
            this.PanTodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanTodo.Controls.Add(this.DgvCliente);
            this.PanTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanTodo.Location = new System.Drawing.Point(0, 36);
            this.PanTodo.Name = "PanTodo";
            this.PanTodo.Size = new System.Drawing.Size(815, 338);
            this.PanTodo.TabIndex = 6;
            // 
            // DgvCliente
            // 
            this.DgvCliente.AllowUserToAddRows = false;
            this.DgvCliente.AllowUserToDeleteRows = false;
            this.DgvCliente.AllowUserToResizeColumns = false;
            this.DgvCliente.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvCliente.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DgvCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdCliente,
            this.sTipoDoc,
            this.sNumeroDoc,
            this.sNombres,
            this.sDireccion});
            this.DgvCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCliente.Location = new System.Drawing.Point(0, 0);
            this.DgvCliente.MultiSelect = false;
            this.DgvCliente.Name = "DgvCliente";
            this.DgvCliente.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvCliente.RowHeadersVisible = false;
            this.DgvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCliente.Size = new System.Drawing.Size(813, 336);
            this.DgvCliente.TabIndex = 0;
            this.DgvCliente.DoubleClick += new System.EventHandler(this.DgvCliente_DoubleClick);
            // 
            // nIdCliente
            // 
            this.nIdCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdCliente.DataPropertyName = "nIdCliente";
            this.nIdCliente.HeaderText = "nIdCliente";
            this.nIdCliente.Name = "nIdCliente";
            this.nIdCliente.ReadOnly = true;
            this.nIdCliente.Visible = false;
            this.nIdCliente.Width = 62;
            // 
            // sTipoDoc
            // 
            this.sTipoDoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sTipoDoc.DataPropertyName = "sTipoDoc";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sTipoDoc.DefaultCellStyle = dataGridViewCellStyle8;
            this.sTipoDoc.HeaderText = "Tipo Doc.";
            this.sTipoDoc.Name = "sTipoDoc";
            this.sTipoDoc.ReadOnly = true;
            this.sTipoDoc.Width = 77;
            // 
            // sNumeroDoc
            // 
            this.sNumeroDoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sNumeroDoc.DataPropertyName = "sNumeroDoc";
            this.sNumeroDoc.HeaderText = "Número";
            this.sNumeroDoc.Name = "sNumeroDoc";
            this.sNumeroDoc.ReadOnly = true;
            this.sNumeroDoc.Width = 69;
            // 
            // sNombres
            // 
            this.sNombres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sNombres.DataPropertyName = "sNombres";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sNombres.DefaultCellStyle = dataGridViewCellStyle9;
            this.sNombres.HeaderText = "Nombres";
            this.sNombres.Name = "sNombres";
            this.sNombres.ReadOnly = true;
            this.sNombres.Width = 74;
            // 
            // sDireccion
            // 
            this.sDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sDireccion.DataPropertyName = "sDireccion";
            this.sDireccion.HeaderText = "Dirección";
            this.sDireccion.Name = "sDireccion";
            this.sDireccion.ReadOnly = true;
            this.sDireccion.Width = 75;
            // 
            // FrmClienteListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 391);
            this.ControlBox = false;
            this.Controls.Add(this.PanTodo);
            this.Controls.Add(this.PanSuperior);
            this.Controls.Add(this.DgProveedor);
            this.Controls.Add(this.PanInferior);
            this.KeyPreview = true;
            this.Name = "FrmClienteListar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda De Cliente";
            this.Load += new System.EventHandler(this.FrmClienteListar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmClienteListar_KeyDown);
            this.PanSuperior.ResumeLayout(false);
            this.PanSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgProveedor)).EndInit();
            this.PanInferior.ResumeLayout(false);
            this.PanInferior.PerformLayout();
            this.PanTodo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PanSuperior;
        internal System.Windows.Forms.Button BtnNuevo;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.TextBox txtRuc;
        internal System.Windows.Forms.DataGridView DgProveedor;
        internal System.Windows.Forms.DataGridViewTextBoxColumn IdProveedor;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        internal System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        internal System.Windows.Forms.Panel PanInferior;
        internal System.Windows.Forms.Label LblTotal;
        internal System.Windows.Forms.Panel PanTodo;
        internal System.Windows.Forms.DataGridView DgvCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTipoDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNumeroDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDireccion;
    }
}