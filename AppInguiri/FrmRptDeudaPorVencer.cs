using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Entidad;
using Negocio;
using Microsoft.VisualBasic;
using Comun;
using AppInguiri.EntidadReporte;
using AppInguiri.Reporte;
using AppInguiri.ReporteFormulario;

namespace AppInguiri
{
    public partial class FrmRptDeudaPorVencer : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptDeudaPorVencer frmInstance = null;
        DeudaNegocio objDeudaNeg = new DeudaNegocio();
        ParametroNegocio objParaNeg = new ParametroNegocio();

        //Singleton
        public static FrmRptDeudaPorVencer Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptDeudaPorVencer();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmRptDeudaPorVencer()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            if (dgvDeudas.Rows.Count < 1) return;

            List<DeudasVencerRpt> listDeudasVencerRpt = new List<DeudasVencerRpt>();
            RptDeudasVencer rpt = new RptDeudasVencer();

            foreach (DataGridViewRow item in dgvDeudas.Rows)
            {
                DeudasVencerRpt objDeudasVencerRpt = new DeudasVencerRpt();

                objDeudasVencerRpt.sDocumento = item.Cells["sIdDocumento"].Value.ToString();
                objDeudasVencerRpt.sNumeracion = item.Cells["sSerie"].Value.ToString();
                objDeudasVencerRpt.dFecha =Convert.ToDateTime(item.Cells["dFecha"].Value.ToString());

                objDeudasVencerRpt.sRuc = item.Cells["sRuc"].Value.ToString();
                objDeudasVencerRpt.sRazonSocial = item.Cells["sObservacion"].Value.ToString();
                objDeudasVencerRpt.nDias = Convert.ToInt32(item.Cells["nNumero"].Value.ToString());
                objDeudasVencerRpt.fSaldo = Convert.ToDecimal(item.Cells["fSaldo"].Value.ToString());
                
                listDeudasVencerRpt.Add(objDeudasVencerRpt);
            }

            rpt.SetDataSource(listDeudasVencerRpt);
            rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
            rpt.SetParameterValue("NombreEmpresa", objParaNeg.LeerUnParametro("ID_TITULO"));
            rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
            RptMaestro Reporte = new RptMaestro();
            Reporte.Show();
            Reporte.Text = "";//cboOpcion.Text;
            Reporte.Focus();
            Reporte.cReporte.ReportSource = rpt;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarDeudas();
        }

        private void ListarDeudas()
        {
            if (!ValidarDatos()) return;

            if (lblCodigo.Text.Equals("")) lblCodigo.Text = "0";

            if ((int)ndDias.Value>0)
            {
                Deuda objDeuda = new Deuda()
                {
                    nTipo = ChkTodos.CheckState == CheckState.Unchecked ? 9 : 8,
                    nIdProveedor = Convert.ToInt32(lblCodigo.Text),
                    nNumero = (int)ndDias.Value
                };

                List<Deuda> ListDeuda = objDeudaNeg.ListarDeuda(objDeuda);

                if (ListDeuda.Count > 0)
                {
                    dgvDeudas.AutoGenerateColumns = false;
                    dgvDeudas.DataSource = ListDeuda;
                }
                else
                {
                    dgvDeudas.DataSource = null;
                }
            }
           
            lblTotal.Text = "Se Encontraron " + dgvDeudas.Rows.Count + " Registros";
        }

        private bool ValidarDatos()
        {
            bool resp = true;

            if (!ChkTodos.Checked && lblCodigo.Text.Equals(""))
            {
                MessageBox.Show("Debe seleccionar un Proveedor.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
        
            return resp;
        }

        private void ActivaProveedores()
        {
            if (!ChkTodos.Checked)
            {
                ChkTodos.Checked = true;
            }
            else
            {
                ChkTodos.Checked = false;
            }
        }

        private void ListarProveedor()
        {
            if (ChkTodos.Checked)
            {
                MessageBox.Show("No puede seleccionar un Proveedor ya que marco Todos los Proveedores.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            FrmProveedorListar frmProveedor = new FrmProveedorListar();
            frmProveedor.ShowDialog();

            if (frmProveedor._proveedor != null)
            {
                lblRuc.Text = frmProveedor._proveedor.sRuc.ToUpper();
                lblNombre.Text = frmProveedor._proveedor.sRazonSocial.ToUpper();
                lblCodigo.Text = frmProveedor._proveedor.nIdProveedor.ToString();
                btnBuscar.Focus();
            }
        }
        
        private void ChkTodos_Click(object sender, EventArgs e)
        {
            lblCodigo.Text = "";
            lblRuc.Text = "";
            lblNombre.Text = "";
            dgvDeudas.DataSource = null;
            ndDias.Focus();
        }

        private void FrmRptDeudaPorVencer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    ListarProveedor();
                    break;
                case Keys.F4:
                    btnBuscar_Click(sender, e);
                    break;
                case Keys.F5:
                    btnImprimir_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}