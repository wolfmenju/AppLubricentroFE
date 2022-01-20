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
    public partial class FrmDeudasAbono : Form
    {
       
        public FrmDeudasPorPagar frmDeudasPorPagar = null;
        DeudaNegocio objDeudaNeg = new DeudaNegocio();
        private Deuda deuda = null;
        private bool cerrarFormulario = true;

        public FrmDeudasAbono()
        {
            InitializeComponent();
        }

        public FrmDeudasAbono(Deuda _deuda)
        {
            InitializeComponent();
            deuda = _deuda;
        }
        
        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private bool VerificacionDatos()
        {
            bool resp = true;

            if (txtMonto.Text.Equals(""))
            {
                MessageBox.Show("Debes colocar un monto.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
                cerrarFormulario = resp;
            }

            else if (txtObservacion.Text.Equals(""))
            {
                MessageBox.Show("Debes colocar la observación.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
                cerrarFormulario = resp;
            }
            
            return resp;
        }

        private void Guardar()
        {
            if (!VerificacionDatos()) return;

            if (MessageBox.Show("¿Desea Realizar El Abono a la Deuda?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int resp = 0;

                Deuda objDeuda = new Deuda()
                {
                    nTipo = 6,
                    nSubTipo = 1,
                    dFecha = dtFecha.Value,
                    fSaldo = Convert.ToDecimal(txtMonto.Text),
                    sObservacion = txtObservacion.Text,
                    sUsuario = Funciones.UsuarioActual(),
                    nIdDeuda = deuda.nIdDeuda
                };

                resp = objDeudaNeg.RegistrarAbonoDeuda(objDeuda);

                if (resp > 0)
                {
                    MessageBox.Show("El Abono se realizó con Exito", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cerrarFormulario = true;
                    this.Close();
                    frmDeudasPorPagar.CargarDeudas();
                }
                else
                {
                    MessageBox.Show("El Abono no se realizó con Exito", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarFormulario = false;
                }
            }
            else
            {
                cerrarFormulario = false;
            }
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDeudasAbono_Load(object sender, EventArgs e)
        {
            if (deuda != null)
            {
                lblNombre.Text = deuda.sObservacion;
                lblDocumento.Text = deuda.sIdDocumento + " - " + deuda.sSerie;
                lblSaldo.Text = deuda.fSaldo.ToString("C");
                lblDias.Text = deuda.nNumero.ToString();
                dtFecha.Value = DateTime.Now;
                this.ActiveControl = txtMonto;
            }
        }

        private void FrmDeudasAbono_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e,txtMonto);
        }
    }
}
