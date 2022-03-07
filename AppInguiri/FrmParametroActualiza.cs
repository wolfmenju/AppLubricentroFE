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
    public partial class FrmParametroActualiza : Form
    {
        private ParametroNegocio objRepreNeg = new ParametroNegocio();
        public FrmPrincipal frmPrincipal = null;
        public int tipo=0;
        Parametro Parametro;


        private bool cerrarFormulario = true;

        public FrmParametroActualiza()
        {
            InitializeComponent();
        }

        public FrmParametroActualiza(Parametro _objPara)
        {
            InitializeComponent();
            Parametro = _objPara;
        }

        private bool Validar()
        {
            bool resp = true;

            if (txtClave.Text.Equals(""))
            {
                MessageBox.Show("El campo Clave se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            if (txtValor.Text.Equals(""))
            {
                MessageBox.Show("El campo Valor se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            
            if (txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show("El campo Descripción se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            
            else if (tipo == 2)
            {
                if (LblCodigo.Text.Equals(""))
                {
                    MessageBox.Show("El campo Codigo se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resp = false;
                }
            }

            cerrarFormulario = resp;
            return resp;
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta = 0;
            string idParameSele="";
            string claveParameSele = "";
            string valorParameSele = "";
            string descripParameSele = "";
            
            if (!Validar()) return;
            if (tipo == 2)
            {
                claveParameSele = txtClave.Text.ToUpper();
                valorParameSele = txtValor.Text.ToUpper();
                descripParameSele = txtDescripcion.Text.ToUpper();

                Parametro objPara = new Parametro()
                {
                    sClave = claveParameSele,
                    sValor= valorParameSele,
                    sDescripcion = descripParameSele, 
                    sUsuario = Funciones.UsuarioActual()
                };

                respuesta = objRepreNeg.RegistrarParametro(objPara);

                if (respuesta == 1)
                {
                    MessageBox.Show("Se Registro Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cerrarFormulario = true;
                }
                else
                {
                    MessageBox.Show("No se Registro Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarFormulario = false;
                }
            }
            else
            {
                idParameSele = LblCodigo.Text;
                claveParameSele = txtClave.Text.ToUpper();
                valorParameSele = txtValor.Text.ToUpper();
                descripParameSele = txtDescripcion.Text.ToUpper();

                Parametro objPara = new Parametro()
                {
                    nIdParametro=Convert.ToInt32(idParameSele),
                    sClave = claveParameSele,
                    sValor = valorParameSele,
                    sDescripcion = descripParameSele,
                    sUsuario = Funciones.UsuarioActual()
                };

                respuesta = objRepreNeg.ActualizarParametro(objPara);

                if (respuesta == 1)
                {
                    MessageBox.Show("Se Actualizó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Se modificaron configuracion del Sistema, por lo que se Cerrará.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
                    frmPrincipal.Close();
                    frmPrincipal.Dispose();
                    frmPrincipal.frmLogin.Close();
                    frmPrincipal.frmLogin.Dispose();
                    cerrarFormulario = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se Actualizó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarFormulario = false;
                }

            }
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            cerrarFormulario = true;
            this.Close();
        }
        
        private void FrmDocumentoActualiza_Load(object sender, EventArgs e)
        {
            if (tipo == 2)
            {
                LblCodigo.Text = "AUTOGENERADO";
            }
            else
            {
                //Actualizar
                LblCodigo.Text = Parametro.nIdParametro.ToString();
                txtClave.Text = Parametro.sClave;
                txtValor.Text = Parametro.sValor;
                txtDescripcion.Text = Parametro.sDescripcion;
                txtDescripcion.SelectionStart = txtDescripcion.Text.Length;
                
            }
        }

        private void FrmDocumentoActualiza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;
        }
        
    }
}
