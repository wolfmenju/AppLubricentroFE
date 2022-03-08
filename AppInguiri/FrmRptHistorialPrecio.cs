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
    public partial class FrmRptHistorialPrecio : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptHistorialPrecio frmInstance = null;
        VentaNegocio objVentaNeg = new VentaNegocio();
        ParametroNegocio objParaNeg = new ParametroNegocio();
        List<Venta> listadoVenta = null;
        AlmacenNegocio objAlmNeg = new AlmacenNegocio();


        //Singleton
        public static FrmRptHistorialPrecio Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptHistorialPrecio();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmRptHistorialPrecio()
        {
            InitializeComponent();
            CargarAlmacen();
        }

        private void CargarAlmacen()
        {
            List<Almacen> listAlm = objAlmNeg.ListarAlmacen(true);
            cboAlmacen.DisplayMember = "sDescripcion";
            cboAlmacen.ValueMember = "nIdAlmacen";
            cboAlmacen.DataSource = listAlm;
            cboAlmacen.SelectedValue = Funciones.CodAlmacenActual();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            if (dgvLotes.Rows.Count < 1) return;

            List<HistorialPrecioRpt> lisHistorialPrecioRpt = new List<HistorialPrecioRpt>();
            RptHistorialPrecio rpt = new RptHistorialPrecio();

            foreach (DataGridViewRow item in dgvLotes.Rows)
            {
                HistorialPrecioRpt objHistorialPrecioRpt = new HistorialPrecioRpt();

                objHistorialPrecioRpt.dFecha = Convert.ToDateTime(item.Cells["dFecha"].Value);
                objHistorialPrecioRpt.sLote = item.Cells["sIdDocumento"].Value.ToString();
                objHistorialPrecioRpt.nCantidad = Convert.ToInt32(item.Cells["nNumero"].Value.ToString());
                objHistorialPrecioRpt.fPrecio = Convert.ToDecimal(item.Cells["fPrecioVenta"].Value.ToString());
                objHistorialPrecioRpt.fTotal = Convert.ToDecimal(item.Cells["fTotal"].Value.ToString());
                lisHistorialPrecioRpt.Add(objHistorialPrecioRpt);
            }

            rpt.SetDataSource(lisHistorialPrecioRpt);
            rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
            rpt.SetParameterValue("Producto", lblDescripcion.Text.ToUpper());
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
            ListarHistorialPrecio();
        }

        private void ListarHistorialPrecio()
        {
            if (dtFechaFinal.Value.Date < dtFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de final no puede ser menor a la fecha inicial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Venta objVenta = new Venta()
            {
                nTipo = 9,
                nIdPedido = lblCodigo.Text==""?0: Convert.ToInt32(lblCodigo.Tag),
                dFecha = dtFechaInicio.Value,
                sIdVendedor = dtFechaFinal.Value.ToString("yyyyMMdd"),
                nIdAlmacen=(int)cboAlmacen.SelectedValue
            };

            List<Venta> ListVentas= objVentaNeg.ListarVentas(objVenta);

            if (ListVentas.Count > 0)
            {
                dgvLotes.AutoGenerateColumns = false;
                dgvLotes.DataSource = ListVentas;
            }
            else
            {
                dgvLotes.DataSource = null;
            }

            lblTotal.Text = "Se Encontraron " + dgvLotes.Rows.Count + " Registros";
        }

        private void ListarProductos()
        {
            FrmProductoListado frmProductoListado = new FrmProductoListado();
            frmProductoListado.Focus();
            frmProductoListado.ShowDialog();

            if (frmProductoListado._producto != null)
            {
                lblCodigo .Text = frmProductoListado._producto.sCodigoInterno.ToString();
                lblCodigo.Tag = frmProductoListado._producto.nIdProducto;
                lblDescripcion.Text = frmProductoListado._producto.sDescripcion.ToUpper();
                lblStock.Text = frmProductoListado._producto.nTotal.ToString();
                //lblTotal.Text=frmProductoListado._producto.nStock.ToString();
            }
        }

        private void FrmRptHistorialPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnBuscar_Click(sender, e);
                    break;
                case Keys.F1:
                    ListarProductos();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}