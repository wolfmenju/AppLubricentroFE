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
    public partial class FrmCambiarClave : Form
    {

        UsuarioNegocio objUserNeg = new UsuarioNegocio();
        public string sLogin="", sNombreUser="";
        int respuesta = 0;
        private bool cerrarFormulario = true;

        public FrmCambiarClave()
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
            else if (txtClaveNueva.Text.Equals(""))
            {
                MessageBox.Show("El campo Clave Nueva se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveNueva.Text = "";
                txtClaveNueva.Focus();
                resp = false;
            }
            else if (txtClaveNueva2.Text.Equals(""))
            {
                MessageBox.Show("El campo  Confirma Clave se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveNueva2.Text = "";
                txtClaveNueva2.Focus();
                resp = false;
            }
            else if (txtClaveNueva.Text != txtClaveNueva2.Text)
            {
                MessageBox.Show("La clave nueva no coincide, por favor ingrese nuevamente.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveNueva.Text = "";
                txtClaveNueva2.Text = "";
                txtClaveNueva.Focus();
                resp = false;
            }
            
            cerrarFormulario = resp;
            return resp;
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Usuario UserResp = objUserNeg.IniciarSesionUsuario(lblLogin.Text.Trim(), txtClave.Text.Trim());

                if (UserResp != null)
                {
                    Usuario objUser = new Usuario()
                    {
                        sLogin = lblLogin.Text.ToUpper().Trim(),
                        sClave = txtClaveNueva.Text.Trim(),
                        sUsuario = Funciones.UsuarioActual()
                    };

                    respuesta = objUserNeg.ResearUsuario(objUser);

                    if (respuesta > 0)
                    {
                        MessageBox.Show("Se Actualizó Correctamente la Contraseña", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se Actualizó Correctamente la Contraseña", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cerrarFormulario = false;
                    }

                }
                else
                {
                    MessageBox.Show("La contraseña del Usuario no es correcto.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarFormulario = false;
                }
            }
            
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            cerrarFormulario = true;
            this.Close();
        }


        private void FrmCambiarClave_Load(object sender, EventArgs e)
        {
            lblLogin.Text = sLogin;
            lblUsuario.Text = sNombreUser;
        }

        private void FrmCambiarClave_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;
        }
    }
}
