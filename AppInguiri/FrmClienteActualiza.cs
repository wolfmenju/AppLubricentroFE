using Comun;
using Entidad;
using Negocio;
using Newtonsoft.Json;
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
    public partial class FrmClienteActualiza : Form
    {
        ClienteNegocio objClienNeg = new ClienteNegocio();
        WsRestServiceConsultaDocumentoNegocio objConsultaDocumento = new WsRestServiceConsultaDocumentoNegocio();
        public int tipo = 0;
        private bool cerrarFormulario = true;
        private Cliente cliente = null;

        public FrmClienteActualiza(Cliente _cliente)
        {
            InitializeComponent();
            cliente = _cliente;
        }

        public FrmClienteActualiza()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            bool resp = true;

            if (txtRazonSocial.Text.Equals(""))
            {
                MessageBox.Show("El campo Razón Social se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtNumeroDoc.Text.Equals(""))
            {
                MessageBox.Show("El campo Ruc se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtDireccion.Text.Equals(""))
            {
                MessageBox.Show("El campo Dirección se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtDistrito .Text.Equals(""))
            {
                MessageBox.Show("El campo Distrito se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtProvincia.Text.Equals(""))
            {
                MessageBox.Show("El campo Provincia se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if ( txtDeparamento.Text.Equals(""))
            {
                MessageBox.Show("El campo Deparamento se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtUbigeo.Text.Equals(""))
            {
                MessageBox.Show("El campo Ubigeo se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            else if (txtCelular.Text.Equals(""))
            {
                MessageBox.Show("El campo Celular se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            cerrarFormulario = resp;
            return resp;
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta = 0;

            if (!Validar()){ return; }

            Cliente objClien = new Cliente()
            {
                sNombres = txtRazonSocial.Text.ToUpper().Trim(),
                sTipoDoc = cbxTipoDocumento.Text,
                sNumeroDoc = txtNumeroDoc.Text.ToUpper().Trim(),
                sDireccion = txtDireccion.Text.ToUpper().Trim(),
                sDistrito = txtDistrito.Text,
                sProvincia = txtProvincia.Text,
                sDepartamento = txtDeparamento.Text,
                bTipoPersona = Convert.ToBoolean(cbxTipoDocumento.SelectedIndex),
                sCelular = txtCelular.Text.ToUpper().Trim(),
                sUsuario = Funciones.UsuarioActual(),
                bEstado = true,
                bValidadoSunat = chkValidaExterna.Checked           
            };

            if (tipo ==0)
            {
                respuesta = objClienNeg.RegistrarCliente(objClien);

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
                objClien.nIdCliente = Convert.ToInt32(LblCodigo.Text);

                respuesta = objClienNeg.ActualizarCliente(objClien);

                if (respuesta == 1)
                {
                    MessageBox.Show("Se Actualizó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cerrarFormulario = true;
                }
                else
                {
                    MessageBox.Show("No se Actualizó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarFormulario = false;
                }

            }
        }

        private void FrmProveedorActualiza_Load(object sender, EventArgs e)
        {
            if (tipo == 0)
            {
                LblCodigo.Text = "AUTOGENERADO";
                cbxTipoDocumento.SelectedIndex = 0;
            }
            else
            {
                //Actualizar
                LblCodigo.Text = cliente.nIdCliente.ToString();
                txtRazonSocial.Text = cliente.sNombres.ToUpper();
                cbxTipoDocumento.SelectedIndex = Convert.ToInt32(cliente.bTipoPersona);
                txtNumeroDoc.Text = cliente.sNumeroDoc.ToUpper();
                txtDireccion.Text = cliente.sDireccion.ToUpper();
                txtCelular.Text = cliente.sCelular.ToUpper();
            }
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            cerrarFormulario = true;
            this.Close();
        }

        private void FrmProveedorActualiza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;
        }

        private void btnConsultaSunat_Click(object sender, EventArgs e)
        {
            ConsultaServiciosExternos();
        }

        private void ConsultaServiciosExternos()
        {
            if (txtNumeroDoc.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el número del " + cbxTipoDocumento.Text, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cbxTipoDocumento.Text.Equals("DNI"))
            {
                if (txtNumeroDoc.Text.Length != 8)
                {
                    MessageBox.Show("El número del " + cbxTipoDocumento.Text +" debe tener 8 digítos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (cbxTipoDocumento.Text.Equals("RUC"))
            {
                if (txtNumeroDoc.Text.Length != 11)
                {
                    MessageBox.Show("El número del " + cbxTipoDocumento.Text + " debe tener 11 digítos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            try
            {
                var WsConsultaDocResponse = objConsultaDocumento.ConsultaDocumentoServicioExterno(txtNumeroDoc.Text);

                if (WsConsultaDocResponse != null)
                {
                    txtNumeroDoc.Enabled = false;
                    txtRazonSocial.Text = WsConsultaDocResponse.nombre;
                    txtDireccion.Text = WsConsultaDocResponse.direccion;
                    txtDistrito.Text = WsConsultaDocResponse.distrito;
                    txtProvincia.Text = WsConsultaDocResponse.provincia;
                    txtDeparamento.Text = WsConsultaDocResponse.departamento;
                    txtUbigeo.Text = WsConsultaDocResponse.ubigeo;
                }
                else
                {
                    MessageBox.Show("El número ingresado del " + cbxTipoDocumento.Text + " No Existe.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show("El número ingresado del " + cbxTipoDocumento.Text + " No Existe.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chkValidaExterna_Click(object sender, EventArgs e)
        {
            DesactivarCampos();
        }

        private void DesactivarCampos()
        {
            if (chkValidaExterna.Checked)
            {
                txtRazonSocial.Enabled = false;
                txtDireccion.Enabled = false;
                txtDistrito.Enabled = false;
                txtProvincia.Enabled = false;
                txtDeparamento.Enabled = false;
                txtUbigeo.Enabled = false;
                //txtCelular.Enabled = false;
                btnConsultaSunat.Enabled = true;
            }
            else
            {
                txtRazonSocial.Enabled = true;
                txtDireccion.Enabled = true;
                txtDistrito.Enabled = true;
                txtProvincia.Enabled = true;
                txtDeparamento.Enabled = true;
                txtUbigeo.Enabled = true;
                //txtCelular.Enabled = true;
                btnConsultaSunat.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();   
        }

        private void LimpiarDatos()
        {
            foreach (Control c in PanSuperior.Controls)
            {
                if (c is TextBox & c.Text != String.Empty)
                {
                    c.Text = "";
                }
            }

            txtNumeroDoc.Enabled = true;
        }

        private void cbxTipoDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxTipoDocumento.Text.Equals("RUC"))
            {
                chkValidaExterna.Text = "Validación Sunat";
                txtNumeroDoc.MaxLength = 11;
            }
            else
            {
                chkValidaExterna.Text = "Validación Reniec";
                txtNumeroDoc.MaxLength = 8;
            }
        }

        private void txtNumeroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroEntero(e, txtNumeroDoc);
        }
    }
}


