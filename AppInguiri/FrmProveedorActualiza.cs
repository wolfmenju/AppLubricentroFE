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
    public partial class FrmProveedorActualiza : Form
    {
        ProveedorNegocio objProveeNeg = new ProveedorNegocio();
        public int tipo = 0;
        private bool cerrarFormulario = true;
        private Proveedor proveedor = null;
        public FrmProveedor frmProveedor = null;

        public FrmProveedorActualiza(Proveedor _proveedor)
        {
            InitializeComponent();
            proveedor = _proveedor;
        }

        public FrmProveedorActualiza()
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
            else if (txtContacto.Text.Equals(""))
            {
                MessageBox.Show("El campo Contacto se encuentra vacía, por favor ingrese un valor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            cerrarFormulario = resp;
            return resp;
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta = 0;

            if (!Validar()) return;

            if (!Funciones.Duplicados(txtRazonSocial.Text, frmProveedor.DgvProveedor))
            {
                txtRazonSocial.Clear();
                txtRazonSocial.Focus();
                cerrarFormulario = false;
                return;
            }
            
            Proveedor objProvee = new Proveedor()
            {
                sRazonSocial = txtRazonSocial.Text.ToUpper().Trim(),
                sRuc = txtRuc.Text.ToUpper().Trim(),
                sDireccion = txtDireccion.Text.ToUpper().Trim(),
                sCelular = txtCelular.Text.ToUpper().Trim(),
                sContacto = txtContacto.Text.ToUpper().Trim(),
                sUsuario = Funciones.UsuarioActual(),
                bEstado = true
            };

            if (tipo ==0)
            {

                respuesta = objProveeNeg.RegistrarProveedor(objProvee);

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
                objProvee.nIdProveedor = Convert.ToInt32(LblCodigo.Text);

                respuesta = objProveeNeg.ActualizarProveedor(objProvee);

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
            }
            else
            {
                //Actualizar
                LblCodigo.Text = proveedor.nIdProveedor.ToString();
                txtRazonSocial.Text = proveedor.sRazonSocial.ToUpper();
                txtRuc.Text = proveedor.sRuc.ToUpper();
                txtDireccion.Text = proveedor.sDireccion.ToUpper();
                txtContacto.Text = proveedor.sContacto.ToUpper();
                txtCelular.Text = proveedor.sCelular.ToUpper();
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


