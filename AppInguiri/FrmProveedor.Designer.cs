﻿namespace AppInguiri
{
    partial class FrmProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProveedor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanOpciones = new System.Windows.Forms.Panel();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnRefrescar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.PanInferior = new System.Windows.Forms.Panel();
            this.ChkTodos = new System.Windows.Forms.CheckBox();
            this.LblTotal = new System.Windows.Forms.Label();
            this.PanTodo = new System.Windows.Forms.Panel();
            this.DgvProveedor = new System.Windows.Forms.DataGridView();
            this.nIdProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanOpciones.SuspendLayout();
            this.PanInferior.SuspendLayout();
            this.PanTodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // PanOpciones
            // 
            this.PanOpciones.BackColor = System.Drawing.Color.White;
            this.PanOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanOpciones.Controls.Add(this.BtnEliminar);
            this.PanOpciones.Controls.Add(this.BtnSalir);
            this.PanOpciones.Controls.Add(this.BtnRefrescar);
            this.PanOpciones.Controls.Add(this.BtnBuscar);
            this.PanOpciones.Controls.Add(this.BtnAgregar);
            this.PanOpciones.Controls.Add(this.BtnModificar);
            this.PanOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanOpciones.Location = new System.Drawing.Point(893, 0);
            this.PanOpciones.Name = "PanOpciones";
            this.PanOpciones.Size = new System.Drawing.Size(109, 482);
            this.PanOpciones.TabIndex = 12;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnEliminar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.Black;
            this.BtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BtnEliminar.Image")));
            this.BtnEliminar.Location = new System.Drawing.Point(3, 243);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(102, 52);
            this.BtnEliminar.TabIndex = 4;
            this.BtnEliminar.TabStop = false;
            this.BtnEliminar.Text = "&Eliminar  [F5]";
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
            this.BtnSalir.Image = global::AppInguiri.Properties.Resources.xSalir1;
            this.BtnSalir.Location = new System.Drawing.Point(3, 417);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(102, 52);
            this.BtnSalir.TabIndex = 5;
            this.BtnSalir.TabStop = false;
            this.BtnSalir.Text = "&Salir      [Esc]";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnRefrescar
            // 
            this.BtnRefrescar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnRefrescar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefrescar.ForeColor = System.Drawing.Color.Black;
            this.BtnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefrescar.Image")));
            this.BtnRefrescar.Location = new System.Drawing.Point(3, 127);
            this.BtnRefrescar.Name = "BtnRefrescar";
            this.BtnRefrescar.Size = new System.Drawing.Size(102, 52);
            this.BtnRefrescar.TabIndex = 2;
            this.BtnRefrescar.TabStop = false;
            this.BtnRefrescar.Text = "&Recargar [F3]";
            this.BtnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnRefrescar.UseVisualStyleBackColor = true;
            this.BtnRefrescar.Click += new System.EventHandler(this.BtnRefrescar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(3, 185);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(102, 52);
            this.BtnBuscar.TabIndex = 3;
            this.BtnBuscar.TabStop = false;
            this.BtnBuscar.Text = "  &Buscar  [F4]";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAgregar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.ForeColor = System.Drawing.Color.Black;
            this.BtnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregar.Image")));
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAgregar.Location = new System.Drawing.Point(3, 11);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(102, 52);
            this.BtnAgregar.TabIndex = 0;
            this.BtnAgregar.TabStop = false;
            this.BtnAgregar.Text = "  &Nuevo  [F1]";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnModificar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.ForeColor = System.Drawing.Color.Black;
            this.BtnModificar.Image = ((System.Drawing.Image)(resources.GetObject("BtnModificar.Image")));
            this.BtnModificar.Location = new System.Drawing.Point(3, 69);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(102, 52);
            this.BtnModificar.TabIndex = 1;
            this.BtnModificar.TabStop = false;
            this.BtnModificar.Text = "&Actualizar [F2]";
            this.BtnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // PanInferior
            // 
            this.PanInferior.BackColor = System.Drawing.Color.White;
            this.PanInferior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanInferior.Controls.Add(this.ChkTodos);
            this.PanInferior.Controls.Add(this.LblTotal);
            this.PanInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanInferior.Location = new System.Drawing.Point(0, 462);
            this.PanInferior.Name = "PanInferior";
            this.PanInferior.Size = new System.Drawing.Size(893, 20);
            this.PanInferior.TabIndex = 15;
            // 
            // ChkTodos
            // 
            this.ChkTodos.AutoSize = true;
            this.ChkTodos.Checked = true;
            this.ChkTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkTodos.Dock = System.Windows.Forms.DockStyle.Right;
            this.ChkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkTodos.ForeColor = System.Drawing.Color.Blue;
            this.ChkTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkTodos.Location = new System.Drawing.Point(821, 0);
            this.ChkTodos.Name = "ChkTodos";
            this.ChkTodos.Size = new System.Drawing.Size(68, 16);
            this.ChkTodos.TabIndex = 19;
            this.ChkTodos.Text = "Activos";
            this.ChkTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkTodos.UseVisualStyleBackColor = true;
            this.ChkTodos.CheckedChanged += new System.EventHandler(this.ChkTodos_CheckedChanged);
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
            this.PanTodo.Controls.Add(this.DgvProveedor);
            this.PanTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanTodo.Location = new System.Drawing.Point(0, 0);
            this.PanTodo.Name = "PanTodo";
            this.PanTodo.Size = new System.Drawing.Size(893, 462);
            this.PanTodo.TabIndex = 16;
            // 
            // DgvProveedor
            // 
            this.DgvProveedor.AllowUserToAddRows = false;
            this.DgvProveedor.AllowUserToDeleteRows = false;
            this.DgvProveedor.AllowUserToResizeColumns = false;
            this.DgvProveedor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvProveedor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvProveedor.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DgvProveedor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdProveedor,
            this.sDescripcion,
            this.sRuc,
            this.sDireccion,
            this.sCelular,
            this.sContacto});
            this.DgvProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProveedor.Location = new System.Drawing.Point(0, 0);
            this.DgvProveedor.MultiSelect = false;
            this.DgvProveedor.Name = "DgvProveedor";
            this.DgvProveedor.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvProveedor.RowHeadersVisible = false;
            this.DgvProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProveedor.Size = new System.Drawing.Size(891, 460);
            this.DgvProveedor.TabIndex = 11;
            // 
            // nIdProveedor
            // 
            this.nIdProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdProveedor.DataPropertyName = "nIdProveedor";
            this.nIdProveedor.HeaderText = "IdProveedor";
            this.nIdProveedor.Name = "nIdProveedor";
            this.nIdProveedor.ReadOnly = true;
            this.nIdProveedor.Visible = false;
            this.nIdProveedor.Width = 73;
            // 
            // sDescripcion
            // 
            this.sDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sDescripcion.DataPropertyName = "sRazonSocial";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sDescripcion.DefaultCellStyle = dataGridViewCellStyle3;
            this.sDescripcion.HeaderText = "Razón Social";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 92;
            // 
            // sRuc
            // 
            this.sRuc.DataPropertyName = "sRuc";
            this.sRuc.HeaderText = "Ruc/Dni";
            this.sRuc.Name = "sRuc";
            this.sRuc.ReadOnly = true;
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
            // sCelular
            // 
            this.sCelular.DataPropertyName = "sCelular";
            this.sCelular.HeaderText = "Celular";
            this.sCelular.Name = "sCelular";
            this.sCelular.ReadOnly = true;
            // 
            // sContacto
            // 
            this.sContacto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sContacto.DataPropertyName = "sContacto";
            this.sContacto.HeaderText = "Contacto";
            this.sContacto.Name = "sContacto";
            this.sContacto.ReadOnly = true;
            this.sContacto.Width = 76;
            // 
            // FrmProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(1002, 482);
            this.ControlBox = false;
            this.Controls.Add(this.PanTodo);
            this.Controls.Add(this.PanInferior);
            this.Controls.Add(this.PanOpciones);
            this.KeyPreview = true;
            this.Name = "FrmProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimientos de Proveedor";
            this.Load += new System.EventHandler(this.FrmProveedor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProveedor_KeyDown);
            this.PanOpciones.ResumeLayout(false);
            this.PanInferior.ResumeLayout(false);
            this.PanInferior.PerformLayout();
            this.PanTodo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProveedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PanOpciones;
        internal System.Windows.Forms.Button BtnEliminar;
        internal System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnRefrescar;
        internal System.Windows.Forms.Button BtnBuscar;
        internal System.Windows.Forms.Button BtnAgregar;
        internal System.Windows.Forms.Button BtnModificar;
        internal System.Windows.Forms.Panel PanInferior;
        internal System.Windows.Forms.CheckBox ChkTodos;
        internal System.Windows.Forms.Label LblTotal;
        internal System.Windows.Forms.Panel PanTodo;
        public System.Windows.Forms.DataGridView DgvProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCelular;
        private System.Windows.Forms.DataGridViewTextBoxColumn sContacto;
    }
}