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
    public partial class FrmCaja : Form
    {
        private static FrmCaja frmInstance = null;
        CajaNegocio objCajaNeg = new CajaNegocio();
        private bool cerrarFormulario = true;
        public FrmPrincipal frmPrincipal = null;

        public FrmCaja()
        {
            InitializeComponent();
        }

        //Singleton
        public static FrmCaja Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmCaja();
            }

            frmInstance.BringToFront();
            return frmInstance;
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            if (txtMonto.Text.Trim()=="")
            {
                MessageBox.Show("Debe ingresar un valor.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cerrarFormulario = false;
                return;
            }
            
            Decimal fMonto = Convert.ToDecimal(txtMonto.Text.Trim());
            int resp = 0;

            if (MessageBox.Show("¿Desea Aperturar La Caja Con Monto : " + fMonto.ToString("C") + " ?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Caja objCaja = new Caja();
                objCaja.nTipo = 1;
                fMonto = txtMonto.Text.Trim() == "" ? 0M : Convert.ToDecimal(txtMonto.Text.Trim());
                objCaja.dFechaInicio = dFecha.Value;
                objCaja.fMontoInicio = fMonto;
                objCaja.fMontoFinal = fMonto;
                objCaja.sUsuario = Funciones.UsuarioActual();

                resp = objCajaNeg.ActualizarCaja(objCaja);

                if (resp > 0)
                {
                    MessageBox.Show("La Caja Se Logró Aperturar Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
                    frmPrincipal.HabilitarMenu(false);
                    frmPrincipal.ValidarPermisosUsuario();
                    frmPrincipal.CodFecha.Caption = dFecha.Value.Date.ToShortDateString();
                    frmPrincipal.RibbonControl.Minimized = false;
                    frmPrincipal.RibbonControl.Visible = true;
                    cerrarFormulario = true;
                }
                else
                {
                    MessageBox.Show("La Caja No Se Pudo Aperturar, O Ya Hay Una Caja Aperturada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                txtMonto.Focus();
            }

        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void Cerrar()
        {
            this.Close();
            this.Dispose();
            frmPrincipal.Close();
            frmPrincipal.Dispose();
            frmPrincipal.frmLogin.Close();
            frmPrincipal.frmLogin.Dispose();
        }
        
        private void FrmCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {

        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Guardar();
        }
        
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e,txtMonto);
        }
    }
}
