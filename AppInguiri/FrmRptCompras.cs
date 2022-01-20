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
    public partial class FrmRptCompras : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptCompras frmInstance = null;
        CompraNegocio objCompraNeg = new CompraNegocio();
        ParametroNegocio objParaNeg = new ParametroNegocio();
        List<Venta> listadoVenta = null;

        //Singleton
        public static FrmRptCompras Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptCompras();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmRptCompras()
        {
            InitializeComponent();
        }

        private void dtFechaInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) dtFechaFin.Focus();
        }

        private void dtFechaFin_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            if (dgvCompra.Rows.Count < 1) return;

            List<ComprasRpt> lisComprasRpt = new List<ComprasRpt>();
            RptCompras rpt = new RptCompras();

            foreach (DataGridViewRow item in dgvCompra.Rows)
            {
                ComprasRpt objCompraRpt = new ComprasRpt();

                objCompraRpt.sRuc = item.Cells["sRuc"].Value.ToString();
                objCompraRpt.sRazonSocial = item.Cells["sRazonSocial"].Value.ToString();
                objCompraRpt.bCredito =Convert.ToBoolean(item.Cells["bCredito"].Value);
                objCompraRpt.sDocumento = item.Cells["sIdDocumento"].Value.ToString();
                objCompraRpt.sFecha =Convert.ToDateTime(item.Cells["dFecha"].Value);
                objCompraRpt.fTotal =Convert.ToDecimal(item.Cells["fTotal"].Value);

                lisComprasRpt.Add(objCompraRpt);
            }
            
            rpt.SetDataSource(lisComprasRpt);
            rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
            rpt.SetParameterValue("NombreEmpresa", objParaNeg.LeerUnParametro("ID_TITULO"));
            rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
            rpt.SetParameterValue("Titulo", "REPORTE DE COMPRAS");
            
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
            ListarCompra();
        }

        private void ListarCompra()
        {
            if (dtFechaFin.Value.Date < dtFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de final no puede ser menor a la fecha inicial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Compra objCompra = new Compra()
            {
                nTipo = 5,
                dFecha = dtFechaInicio.Value,
                sSerie = dtFechaFin.Value.ToString("yyyyMMdd"),
                nIdAlmacen = Funciones.CodAlmacenActual(),
                bCredito = cboTipo.SelectedIndex == 1 ? true : false,
                nCodigo = chkTodosCompras.Checked==true?1:0,
                nIdProveedor=lblCodigoProveedor.Text==""?0: Convert.ToInt32(lblCodigoProveedor.Text)
            };

            List<Compra> ListobjCompras = objCompraNeg.ListarCompras(objCompra);

            if (ListobjCompras.Count > 0)
            {
                dgvCompra.AutoGenerateColumns = false;
                dgvCompra.DataSource = ListobjCompras;
            }
            else
            {
                dgvCompra.DataSource = null;
            }

            lblTotal.Text = "Se Encontraron " + dgvCompra.Rows.Count + " Registros";
        }

        private void FrmRptCompras_Load(object sender, EventArgs e)
        {

        }

        private void FrmRptCompras_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    ListarProveedor();
                    break;
                case Keys.F2:
                    ActivaCompras();
                    break;
                case Keys.F3:
                    ActivaProveedores();
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

        private void ActivaCompras()
        {
            if (!chkTodosCompras.Checked)
            {
                chkTodosCompras.Checked = true;
            }
            else
            {
                chkTodosCompras.Checked = false;
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
                lblCodigoProveedor.Text = frmProveedor._proveedor.nIdProveedor.ToString();
                btnBuscar.Focus();
            }
        }

        private void chkTodosCompras_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodosCompras.Checked)
            {
                cboTipo.Enabled = false;
                cboTipo.SelectedIndex = -1;
            }
            else
            {
                cboTipo.Enabled = true;
                cboTipo.SelectedIndex = 0;
            }

        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblCodigoProveedor.Text = "";
            lblNombre.Text = "";
            lblRuc.Text = "";

            btnBuscar.Focus();
        }
    }
}