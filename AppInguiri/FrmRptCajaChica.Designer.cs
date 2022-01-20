namespace AppInguiri
{
    partial class FrmRptCajaChica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRptCajaChica));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanOpciones = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.PanInferior = new System.Windows.Forms.Panel();
            this.LblTotal = new System.Windows.Forms.Label();
            this.PanSuperior = new System.Windows.Forms.Panel();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.DtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.PanTodo = new System.Windows.Forms.Panel();
            this.TabConsulta = new System.Windows.Forms.TabControl();
            this.TabCajaChica = new System.Windows.Forms.TabPage();
            this.dgvCajaChica = new System.Windows.Forms.DataGridView();
            this.nIdCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIdTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fMontoInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fMontoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanOpciones.SuspendLayout();
            this.PanInferior.SuspendLayout();
            this.PanSuperior.SuspendLayout();
            this.PanTodo.SuspendLayout();
            this.TabConsulta.SuspendLayout();
            this.TabCajaChica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaChica)).BeginInit();
            this.SuspendLayout();
            // 
            // PanOpciones
            // 
            this.PanOpciones.BackColor = System.Drawing.Color.White;
            this.PanOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanOpciones.Controls.Add(this.btnImprimir);
            this.PanOpciones.Controls.Add(this.BtnSalir);
            this.PanOpciones.Controls.Add(this.BtnBuscar);
            this.PanOpciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanOpciones.Location = new System.Drawing.Point(889, 0);
            this.PanOpciones.Name = "PanOpciones";
            this.PanOpciones.Size = new System.Drawing.Size(109, 480);
            this.PanOpciones.TabIndex = 11;
            // 
            // btnImprimir
            // 
            this.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = global::AppInguiri.Properties.Resources.xImprimir;
            this.btnImprimir.Location = new System.Drawing.Point(3, 65);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(102, 52);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.TabStop = false;
            this.btnImprimir.Text = "&Imprimir [F2]";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            this.BtnSalir.Location = new System.Drawing.Point(3, 415);
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
            // BtnBuscar
            // 
            this.BtnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(3, 7);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(102, 52);
            this.BtnBuscar.TabIndex = 3;
            this.BtnBuscar.TabStop = false;
            this.BtnBuscar.Text = "  &Buscar  [F1]";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // PanInferior
            // 
            this.PanInferior.BackColor = System.Drawing.Color.White;
            this.PanInferior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanInferior.Controls.Add(this.LblTotal);
            this.PanInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanInferior.Location = new System.Drawing.Point(0, 460);
            this.PanInferior.Name = "PanInferior";
            this.PanInferior.Size = new System.Drawing.Size(889, 20);
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
            this.PanSuperior.Controls.Add(this.Label6);
            this.PanSuperior.Controls.Add(this.Label2);
            this.PanSuperior.Controls.Add(this.DtFechaFinal);
            this.PanSuperior.Controls.Add(this.dtFechaInicio);
            this.PanSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSuperior.Location = new System.Drawing.Point(0, 0);
            this.PanSuperior.Name = "PanSuperior";
            this.PanSuperior.Size = new System.Drawing.Size(889, 37);
            this.PanSuperior.TabIndex = 13;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(15, 11);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(48, 13);
            this.Label6.TabIndex = 58;
            this.Label6.Text = "Fechas";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(178, 11);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(19, 13);
            this.Label2.TabIndex = 57;
            this.Label2.Text = "---";
            // 
            // DtFechaFinal
            // 
            this.DtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFechaFinal.Location = new System.Drawing.Point(200, 8);
            this.DtFechaFinal.Name = "DtFechaFinal";
            this.DtFechaFinal.Size = new System.Drawing.Size(106, 20);
            this.DtFechaFinal.TabIndex = 1;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(69, 7);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(106, 20);
            this.dtFechaInicio.TabIndex = 0;
            // 
            // PanTodo
            // 
            this.PanTodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanTodo.Controls.Add(this.TabConsulta);
            this.PanTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanTodo.Location = new System.Drawing.Point(0, 37);
            this.PanTodo.Name = "PanTodo";
            this.PanTodo.Size = new System.Drawing.Size(889, 423);
            this.PanTodo.TabIndex = 18;
            // 
            // TabConsulta
            // 
            this.TabConsulta.Controls.Add(this.TabCajaChica);
            this.TabConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabConsulta.Location = new System.Drawing.Point(0, 0);
            this.TabConsulta.Name = "TabConsulta";
            this.TabConsulta.SelectedIndex = 0;
            this.TabConsulta.Size = new System.Drawing.Size(887, 421);
            this.TabConsulta.TabIndex = 4;
            // 
            // TabCajaChica
            // 
            this.TabCajaChica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.TabCajaChica.Controls.Add(this.dgvCajaChica);
            this.TabCajaChica.Location = new System.Drawing.Point(4, 22);
            this.TabCajaChica.Name = "TabCajaChica";
            this.TabCajaChica.Padding = new System.Windows.Forms.Padding(3);
            this.TabCajaChica.Size = new System.Drawing.Size(879, 395);
            this.TabCajaChica.TabIndex = 0;
            this.TabCajaChica.Text = "Listado";
            // 
            // dgvCajaChica
            // 
            this.dgvCajaChica.AllowUserToAddRows = false;
            this.dgvCajaChica.AllowUserToDeleteRows = false;
            this.dgvCajaChica.AllowUserToResizeColumns = false;
            this.dgvCajaChica.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCajaChica.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCajaChica.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvCajaChica.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCajaChica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCajaChica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajaChica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdCaja,
            this.nIdTurno,
            this.sUsuario,
            this.dFechaInicio,
            this.fMontoInicio,
            this.dFechaFinal,
            this.fMontoFinal});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCajaChica.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCajaChica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCajaChica.Location = new System.Drawing.Point(3, 3);
            this.dgvCajaChica.MultiSelect = false;
            this.dgvCajaChica.Name = "dgvCajaChica";
            this.dgvCajaChica.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCajaChica.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCajaChica.RowHeadersVisible = false;
            this.dgvCajaChica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCajaChica.Size = new System.Drawing.Size(873, 389);
            this.dgvCajaChica.TabIndex = 2;
            // 
            // nIdCaja
            // 
            this.nIdCaja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdCaja.DataPropertyName = "nIdCaja";
            this.nIdCaja.HeaderText = "IdCaja";
            this.nIdCaja.Name = "nIdCaja";
            this.nIdCaja.ReadOnly = true;
            this.nIdCaja.Visible = false;
            // 
            // nIdTurno
            // 
            this.nIdTurno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nIdTurno.DataPropertyName = "nIdTurno";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nIdTurno.DefaultCellStyle = dataGridViewCellStyle3;
            this.nIdTurno.HeaderText = "Turno";
            this.nIdTurno.Name = "nIdTurno";
            this.nIdTurno.ReadOnly = true;
            this.nIdTurno.Width = 69;
            // 
            // sUsuario
            // 
            this.sUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sUsuario.DataPropertyName = "sUsuario";
            this.sUsuario.HeaderText = "Usuario";
            this.sUsuario.Name = "sUsuario";
            this.sUsuario.ReadOnly = true;
            this.sUsuario.Width = 82;
            // 
            // dFechaInicio
            // 
            this.dFechaInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFechaInicio.DataPropertyName = "dFechaInicio";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "g";
            dataGridViewCellStyle4.NullValue = null;
            this.dFechaInicio.DefaultCellStyle = dataGridViewCellStyle4;
            this.dFechaInicio.HeaderText = "Fecha Inicial";
            this.dFechaInicio.Name = "dFechaInicio";
            this.dFechaInicio.ReadOnly = true;
            this.dFechaInicio.Width = 105;
            // 
            // fMontoInicio
            // 
            this.fMontoInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fMontoInicio.DataPropertyName = "fMontoInicio";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.fMontoInicio.DefaultCellStyle = dataGridViewCellStyle5;
            this.fMontoInicio.HeaderText = "Monto Inicial";
            this.fMontoInicio.Name = "fMontoInicio";
            this.fMontoInicio.ReadOnly = true;
            this.fMontoInicio.Width = 105;
            // 
            // dFechaFinal
            // 
            this.dFechaFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFechaFinal.DataPropertyName = "dFechaFinal";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "g";
            dataGridViewCellStyle6.NullValue = null;
            this.dFechaFinal.DefaultCellStyle = dataGridViewCellStyle6;
            this.dFechaFinal.HeaderText = "Fecha Final";
            this.dFechaFinal.Name = "dFechaFinal";
            this.dFechaFinal.ReadOnly = true;
            this.dFechaFinal.Width = 98;
            // 
            // fMontoFinal
            // 
            this.fMontoFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fMontoFinal.DataPropertyName = "fMontoFinal";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.fMontoFinal.DefaultCellStyle = dataGridViewCellStyle7;
            this.fMontoFinal.HeaderText = "Monto Final";
            this.fMontoFinal.Name = "fMontoFinal";
            this.fMontoFinal.ReadOnly = true;
            this.fMontoFinal.Width = 99;
            // 
            // FrmRptCajaChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(998, 480);
            this.ControlBox = false;
            this.Controls.Add(this.PanTodo);
            this.Controls.Add(this.PanSuperior);
            this.Controls.Add(this.PanInferior);
            this.Controls.Add(this.PanOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRptCajaChica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Caja Chica";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRptCajaChica_KeyDown);
            this.PanOpciones.ResumeLayout(false);
            this.PanInferior.ResumeLayout(false);
            this.PanInferior.PerformLayout();
            this.PanSuperior.ResumeLayout(false);
            this.PanSuperior.PerformLayout();
            this.PanTodo.ResumeLayout(false);
            this.TabConsulta.ResumeLayout(false);
            this.TabCajaChica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaChica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel PanOpciones;
        internal System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnBuscar;
        internal System.Windows.Forms.Panel PanInferior;
        internal System.Windows.Forms.Label LblTotal;
        internal System.Windows.Forms.Panel PanSuperior;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DateTimePicker DtFechaFinal;
        internal System.Windows.Forms.DateTimePicker dtFechaInicio;
        internal System.Windows.Forms.Panel PanTodo;
        internal System.Windows.Forms.TabControl TabConsulta;
        internal System.Windows.Forms.TabPage TabCajaChica;
        internal System.Windows.Forms.DataGridView dgvCajaChica;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fMontoInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn fMontoFinal;
        internal System.Windows.Forms.Button btnImprimir;
    }
}