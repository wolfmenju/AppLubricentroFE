namespace AppInguiri
{
    partial class FrmCambiarClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCambiarClave));
            this.CmdGuardar = new System.Windows.Forms.Button();
            this.CmdCancelar = new System.Windows.Forms.Button();
            this.PanTodo = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.ChVerClave = new System.Windows.Forms.CheckBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtClaveNueva2 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtClaveNueva = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.PanTodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmdGuardar
            // 
            this.CmdGuardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CmdGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("CmdGuardar.Image")));
            this.CmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdGuardar.Location = new System.Drawing.Point(359, 103);
            this.CmdGuardar.Name = "CmdGuardar";
            this.CmdGuardar.Size = new System.Drawing.Size(84, 26);
            this.CmdGuardar.TabIndex = 4;
            this.CmdGuardar.Text = "&Guardar";
            this.CmdGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CmdGuardar.UseVisualStyleBackColor = true;
            this.CmdGuardar.Click += new System.EventHandler(this.CmdGuardar_Click);
            // 
            // CmdCancelar
            // 
            this.CmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("CmdCancelar.Image")));
            this.CmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdCancelar.Location = new System.Drawing.Point(449, 103);
            this.CmdCancelar.Name = "CmdCancelar";
            this.CmdCancelar.Size = new System.Drawing.Size(84, 26);
            this.CmdCancelar.TabIndex = 5;
            this.CmdCancelar.Text = "&Cancelar";
            this.CmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CmdCancelar.UseVisualStyleBackColor = true;
            this.CmdCancelar.Click += new System.EventHandler(this.CmdCancelar_Click);
            // 
            // PanTodo
            // 
            this.PanTodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanTodo.Controls.Add(this.lblLogin);
            this.PanTodo.Controls.Add(this.Label3);
            this.PanTodo.Controls.Add(this.ChVerClave);
            this.PanTodo.Controls.Add(this.lblUsuario);
            this.PanTodo.Controls.Add(this.Label6);
            this.PanTodo.Controls.Add(this.txtClaveNueva2);
            this.PanTodo.Controls.Add(this.Label5);
            this.PanTodo.Controls.Add(this.txtClaveNueva);
            this.PanTodo.Controls.Add(this.Label4);
            this.PanTodo.Controls.Add(this.txtClave);
            this.PanTodo.Controls.Add(this.Label1);
            this.PanTodo.Location = new System.Drawing.Point(5, 3);
            this.PanTodo.Name = "PanTodo";
            this.PanTodo.Size = new System.Drawing.Size(528, 94);
            this.PanTodo.TabIndex = 6;
            // 
            // lblLogin
            // 
            this.lblLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.Blue;
            this.lblLogin.Location = new System.Drawing.Point(92, 36);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(151, 20);
            this.lblLogin.TabIndex = 32;
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(9, 40);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(40, 13);
            this.Label3.TabIndex = 31;
            this.Label3.Text = "Logín";
            // 
            // ChVerClave
            // 
            this.ChVerClave.AutoSize = true;
            this.ChVerClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChVerClave.Location = new System.Drawing.Point(535, 39);
            this.ChVerClave.Name = "ChVerClave";
            this.ChVerClave.Size = new System.Drawing.Size(81, 17);
            this.ChVerClave.TabIndex = 30;
            this.ChVerClave.TabStop = false;
            this.ChVerClave.Text = "Ver Clave";
            this.ChVerClave.UseVisualStyleBackColor = true;
            // 
            // lblUsuario
            // 
            this.lblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Blue;
            this.lblUsuario.Location = new System.Drawing.Point(92, 10);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(412, 20);
            this.lblUsuario.TabIndex = 29;
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(9, 14);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(50, 13);
            this.Label6.TabIndex = 17;
            this.Label6.Text = "Usuario";
            // 
            // txtClaveNueva2
            // 
            this.txtClaveNueva2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClaveNueva2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveNueva2.Location = new System.Drawing.Point(353, 62);
            this.txtClaveNueva2.MaxLength = 60;
            this.txtClaveNueva2.Name = "txtClaveNueva2";
            this.txtClaveNueva2.PasswordChar = '*';
            this.txtClaveNueva2.Size = new System.Drawing.Size(151, 20);
            this.txtClaveNueva2.TabIndex = 2;
            this.txtClaveNueva2.Tag = "2";
            this.txtClaveNueva2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(258, 65);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(92, 13);
            this.Label5.TabIndex = 15;
            this.Label5.Text = "Confirma Clave";
            // 
            // txtClaveNueva
            // 
            this.txtClaveNueva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClaveNueva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveNueva.Location = new System.Drawing.Point(92, 62);
            this.txtClaveNueva.MaxLength = 60;
            this.txtClaveNueva.Name = "txtClaveNueva";
            this.txtClaveNueva.PasswordChar = '*';
            this.txtClaveNueva.Size = new System.Drawing.Size(151, 20);
            this.txtClaveNueva.TabIndex = 1;
            this.txtClaveNueva.Tag = "2";
            this.txtClaveNueva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(9, 65);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(80, 13);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Nueva Clave";
            // 
            // txtClave
            // 
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClave.Location = new System.Drawing.Point(353, 36);
            this.txtClave.MaxLength = 60;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(151, 20);
            this.txtClave.TabIndex = 0;
            this.txtClave.Tag = "2";
            this.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(258, 40);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(79, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Clave Actual";
            // 
            // FrmCambiarClave
            // 
            this.AcceptButton = this.CmdGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.CmdCancelar;
            this.ClientSize = new System.Drawing.Size(541, 132);
            this.ControlBox = false;
            this.Controls.Add(this.PanTodo);
            this.Controls.Add(this.CmdCancelar);
            this.Controls.Add(this.CmdGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCambiarClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambiar Clave de Acceso Actual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCambiarClave_FormClosing);
            this.Load += new System.EventHandler(this.FrmCambiarClave_Load);
            this.PanTodo.ResumeLayout(false);
            this.PanTodo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button CmdCancelar;
        protected System.Windows.Forms.Button CmdGuardar;
        internal System.Windows.Forms.Panel PanTodo;
        internal System.Windows.Forms.Label lblLogin;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.CheckBox ChVerClave;
        internal System.Windows.Forms.Label lblUsuario;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtClaveNueva2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtClaveNueva;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtClave;
        internal System.Windows.Forms.Label Label1;
    }
}