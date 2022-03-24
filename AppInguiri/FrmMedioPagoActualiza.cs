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
    public partial class FrmMedioPagoActualiza : Form
    {
        private MedioPagoNegocio objMedPagoNeg = new MedioPagoNegocio();
        public int tipo=0;
        public int idCategoria = 0;
        public string descripcion = "";
        public List<MedioPago> listarMedioPago = null;
        private bool cerrarFormulario = true;
        public FrmMedioPago frmMedioPago = null;

        public FrmMedioPagoActualiza()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            bool resp = true;
            if (txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show("El campo Descripción se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            cerrarFormulario = resp;
            return resp;
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            int respuesta =0, idCateSele=0;
            string descSele = "";

            if (!Validar()) return;

            if (!Funciones.Duplicados(txtDescripcion.Text, frmMedioPago.DgvMedioPago))
            {
                txtDescripcion.Clear();
                txtDescripcion.Focus();
                cerrarFormulario = false;
                return;
            }

            if (tipo == 2)
            {
                descSele = txtDescripcion.Text;
                
                MedioPago objMedPago = new MedioPago()
                {
                    sDescripcion = descSele,
                    sUsuario = Funciones.UsuarioActual()
                };

                respuesta = objMedPagoNeg.RegistrarMedioPago(objMedPago);

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
                idCateSele = Convert.ToInt32(LblCodigo.Text);
                descSele = txtDescripcion.Text;

                MedioPago objMedPago = new MedioPago()
                {
                    nIdMedioPago = idCategoria,
                    sDescripcion = descSele,
                    sUsuario = Funciones.UsuarioActual()
                };
                respuesta = objMedPagoNeg.ActualizarMedioPago(objMedPago);

                if (respuesta == 1)
                {
                    MessageBox.Show("Se Actualizó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmPresentacionNuevo_Load(object sender, EventArgs e)
        {
            if (tipo == 2)
            {
                LblCodigo.Text = "AUTOGENERADO";
            }
            else
            {
                //Actualizar
                LblCodigo.Text = Convert.ToString(idCategoria.ToString());
                txtDescripcion.Text = descripcion.ToString();
            }
        }

        private void FrmPresentacionActualiza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;
        }
    }
}
