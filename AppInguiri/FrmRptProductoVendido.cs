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
    public partial class FrmRptProductoVendido : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptProductoVendido frmInstance = null;
        VentaNegocio objVentaNeg = new VentaNegocio();
        ParametroNegocio objParaNeg = new ParametroNegocio();
        List<Venta> listadoVenta = null;

        //Singleton
        public static FrmRptProductoVendido Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptProductoVendido();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmRptProductoVendido()
        {
            InitializeComponent();
            CargarMaestros();
        }

        private void CargarMaestros()
        {
            cboOpcion.SelectedIndex = 0;
        }

        private void dtFechaInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) dtFechaFin.Focus();
        }

        private void dtFechaFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboOpcion.Items.Count>0)
            {
                cboOpcion.Focus();
                cboOpcion.DroppedDown = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            if (dgvProducto.Rows.Count < 1) return;

            List<ProductoVendidoRpt> listProdVendido = new List<ProductoVendidoRpt>();
            RptProductoVendido rpt = new RptProductoVendido();
                
            foreach (DataGridViewRow item in dgvProducto.Rows)
            {
                ProductoVendidoRpt objProVenRpt = new ProductoVendidoRpt();

                objProVenRpt.nIdProducto = Convert.ToInt32(item.Cells["nIdProducto"].Value);
                objProVenRpt.sDescrípcion = item.Cells["sNombre"].Value.ToString();
                objProVenRpt.bAlternativo = Convert.ToString(item.Cells["bAlternativo"].Value);
                objProVenRpt.sLaboratorio = item.Cells["sLaboratorio"].Value.ToString();
                objProVenRpt.sTotal = item.Cells["fTotal"].Value.ToString();
                listProdVendido.Add(objProVenRpt);
            }

            rpt.SetDataSource(listProdVendido);
            rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
            rpt.SetParameterValue("Titulo", cboOpcion.Text);
            rpt.SetParameterValue("NombreEmpresa", objParaNeg.LeerUnParametro("ID_TITULO"));
            rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
            RptMaestro Reporte = new RptMaestro();
            Reporte.Show();
            Reporte.Text = cboOpcion.Text;
            Reporte.Focus();
            Reporte.cReporte.ReportSource = rpt;
            
        }

        private void FrmRptProductoVendido_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    btnBuscar_Click(sender, e);
                    break;
                case Keys.F2:
                    btnImprimir_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboOpcion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listadoVenta = null;
            dgvProducto.DataSource = null;
            txtNumero.Focus();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroEntero(e,txtNumero);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarStock();
        }

        private void CargarStock()
        {
            listadoVenta=new List<Venta>();

            Venta objVenta = new Venta()
            {
                nTipo = cboOpcion.SelectedIndex == 0 ? 5 : 6,
                nIdAlmacen = Funciones.CodAlmacenActual(),
                dFecha=dtFechaInicio.Value,
                sSerie=dtFechaFin .Value.ToString("yyyyMMdd"),
                nNumero=Convert.ToInt32(txtNumero.Text)
            };

            listadoVenta=objVentaNeg.ListarVentas(objVenta);

            if (listadoVenta.Count>0)
            {
                dgvProducto.AutoGenerateColumns = false;
                dgvProducto.DataSource = listadoVenta;
                lblTotal.Text = "Se Encontraron " + dgvProducto.Rows.Count + " Registros";
            }
            else
            {
                dgvProducto.Rows.Clear();
            }

        }
    }
}