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
    public partial class FrmCerrarCaja : Form
    {
        private static FrmCerrarCaja frmInstance = null;
        public FrmPrincipal frmPrincipal = null;

        private CajaNegocio objCajaNeg = new CajaNegocio();

        private bool cerrarFormulario = true;

        public FrmCerrarCaja()
        {
            InitializeComponent();
        }

        //Singleton
        public static FrmCerrarCaja Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmCerrarCaja();
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
            if (MessageBox.Show("¿Desea Cerrar La Caja Con El Turno Actual?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int res = 0;
                Caja objCaja = new Caja();
                objCaja.nTipo = 2;
                objCaja.dFechaInicio = dFecha.Value;
                objCaja.sUsuario = Funciones.UsuarioActual();

                res = objCajaNeg.ActualizarCaja(objCaja);

                if (res > 0)
                {
                    MessageBox.Show("La Caja Se Logró Cerrar Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
                    frmPrincipal.Close();
                    frmPrincipal.Dispose();
                    frmPrincipal.frmLogin.Close();
                    frmPrincipal.frmLogin.Dispose();
                }
                else
                {
                    MessageBox.Show("La Caja No Se Pudo Cerrar Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void Cerrar()
        {

        }

        private void FrmCerrarCaja_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            decimal fInicial = 0M, fFinal = 0M, fSaldo = 0M;
            dFecha.Value = Convert.ToDateTime(frmPrincipal.CodFecha.Caption);
            Caja objCaja = new Caja();
            objCaja.nTipo = 9;
            objCaja.dFechaInicio= Convert.ToDateTime(frmPrincipal.CodFecha.Caption);

            List<Caja> LisCaja=  objCajaNeg.ListarCaja(objCaja);

            if (LisCaja.Count > 0)
            {
                foreach (var item in LisCaja)
                {
                    fInicial = item.fMontoInicio;
                    fFinal =Convert.ToDecimal(item.fMontoFinal);
                    fSaldo = fFinal - fInicial;
                    break;
                }
            }

            lblInicial.Text = fInicial.ToString("C");
            lblFinal.Text = fFinal.ToString("C");
            lblSaldo.Text = fSaldo.ToString("C");
        }
    }
}
