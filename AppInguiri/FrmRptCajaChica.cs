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
using Microsoft.VisualBasic;
using Comun;
using AppInguiri.ReporteFormulario;
using AppInguiri.EntidadReporte;
using AppInguiri.Reporte;

namespace AppInguiri
{
    public partial class FrmRptCajaChica : Form
    {
        #region Variables Privadas
        private SedeNegocio objSedeNeg = new SedeNegocio();
        private List<Sede> listSede = new List<Sede>();
        private bool estado = true;
        private static FrmRptCajaChica frmInstance = null;
        private CajaNegocio objCajaNeg = new CajaNegocio();
        ParametroNegocio objParaNeg = new ParametroNegocio();

        #endregion

        #region Principal Load

        //Singleton
        public static FrmRptCajaChica Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptCajaChica();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmRptCajaChica()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos
     

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #endregion

        #region Metodo Privados
     

        private void Buscar()
        {
            Caja objCaja = new Caja()
            {
                nTipo = 10,
                dFechaInicio = dtFechaInicio.Value,
                dFechaFinal = DtFechaFinal.Value,
                bEstado = true
            };
        
            List<Caja> LisCaja = objCajaNeg.ListarCaja(objCaja);

            if (LisCaja.Count > 0)
            {
                dgvCajaChica.AutoGenerateColumns = false;
                dgvCajaChica.DataSource = LisCaja;
            }
            else
            {
                dgvCajaChica.DataSource = null;
            }

            LblTotal.Text = "Se Encontraron " + dgvCajaChica.Rows.Count + " Registros";


        }
        #endregion

        private void FrmRptCajaChica_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnBuscar_Click(sender, e);
                    break;
                case Keys.F2:
                    btnImprimir_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            if (dgvCajaChica.Rows.Count < 1) return;

            List<CajaChicaRpt> lisCajaChicaRptRpt = new List<CajaChicaRpt>();
            RptCajaChica rpt = new RptCajaChica();

            foreach (DataGridViewRow item in dgvCajaChica.Rows)
            {
                CajaChicaRpt objCajaChicaRpt = new CajaChicaRpt();

                objCajaChicaRpt.nTurno = Convert.ToInt32(item.Cells["nIdTurno"].Value);
                objCajaChicaRpt.sUsuario = item.Cells["sUsuario"].Value.ToString();
                objCajaChicaRpt.dFechaInicial =Convert.ToDateTime(item.Cells["dFechaInicio"].Value.ToString());
                objCajaChicaRpt.fMontoInicial = Convert.ToDecimal(item.Cells["fMontoInicio"].Value.ToString());
                if(item.Cells["dFechaFinal"].Value!=null)
                    objCajaChicaRpt.dFechaFinal = Convert.ToDateTime(item.Cells["dFechaFinal"].Value.ToString());
                if (item.Cells["fMontoFinal"].Value != null)
                    objCajaChicaRpt.fMontoFinal = Convert.ToDecimal(item.Cells["fMontoFinal"].Value.ToString());
                lisCajaChicaRptRpt.Add(objCajaChicaRpt);
            }

            rpt.SetDataSource(lisCajaChicaRptRpt);
            rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
            rpt.SetParameterValue("NombreEmpresa", objParaNeg.LeerUnParametro("ID_TITULO"));
            rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
            RptMaestro Reporte = new RptMaestro();
            Reporte.Show();
            Reporte.Text = "";//cboOpcion.Text;
            Reporte.Focus();
            Reporte.cReporte.ReportSource = rpt;
        }
    }
}
