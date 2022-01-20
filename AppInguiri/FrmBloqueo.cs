using Comun;
using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppInguiri
{
    public partial class FrmBloqueo : Form
    {

        UsuarioNegocio objUserNeg = new UsuarioNegocio();
        public string sLogin = "";
        private bool cerrarFormulario = true;
        public bool bloqueado = true;
        public FrmPrincipal frmPrincipal = null;

        public FrmBloqueo()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            bool resp = true;

            if (txtClave.Text.Equals(""))
            {
                MessageBox.Show("El campo Clave se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Text = "";
                txtClave.Focus();
                resp = false;
            }

            cerrarFormulario = resp;
            return resp;
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Usuario user = objUserNeg.IniciarSesionUsuario(lblLogin.Text.Trim(), txtClave.Text.Trim());
            
            if (user != null)
            {
                this.Close();
                this.Dispose();
                cerrarFormulario = true;
                bloqueado = false;
            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cerrarFormulario = false;
            }

        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        
        private void FrmBloqueo_Load(object sender, EventArgs e)
        {
            lblLogin.Text = sLogin; 
        }

        private void FrmBloqueo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }
    }
}
