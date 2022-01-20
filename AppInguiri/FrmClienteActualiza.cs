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
    public partial class FrmClienteActualiza : Form
    {
        ClienteNegocio objClienNeg = new ClienteNegocio();
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
            if (cbxTipoDocumento.Text.Equals(""))
            {
                MessageBox.Show("El campo Documento se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtRazonSocial.Text.Equals(""))
            {
                MessageBox.Show("El campo Razón Social se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtRuc.Text.Equals(""))
            {
                MessageBox.Show("El campo Ruc se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtDireccion.Text.Equals(""))
            {
                MessageBox.Show("El campo Dirección se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (Validar())
            { }
            else { return; }

            Cliente objClien = new Cliente()
            {
                sNombres = txtRazonSocial.Text.ToUpper().Trim(),
                sDni = txtRuc.Text.ToUpper().Trim(),
                sDireccion = txtDireccion.Text.ToUpper().Trim(),
                bTipoPersona =Convert.ToBoolean(cbxTipoDocumento.SelectedIndex),
                sCelular = txtCelular.Text.ToUpper().Trim(),
                sUsuario = Funciones.UsuarioActual(),
                bEstado = true
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
                txtRuc.Text = cliente.sDni.ToUpper();
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
    }
}


