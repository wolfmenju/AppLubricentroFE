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
    public partial class FrmRptKardex : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptKardex frmInstance = null;
        VentaNegocio objVentaNeg = new VentaNegocio();
        ProductoHistorialNegocio objProHistNeg = new ProductoHistorialNegocio();
        ParametroNegocio objParaNeg = new ParametroNegocio();
        List<ProductoHistorial> listadoProductoHistorial = null;

        AlmacenNegocio objAlmNeg = new AlmacenNegocio();
        
        //Singleton
        public static FrmRptKardex Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptKardex();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmRptKardex()
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
            if (dgvKardex.Rows.Count < 1) return;

            List<KardexRpt> listKardexRpt = new List<KardexRpt>();
            RptKardex rpt = new RptKardex();

            foreach (DataGridViewRow item in dgvKardex.Rows)
            {
                KardexRpt objKardexRpt = new KardexRpt();

                objKardexRpt.dFecha =Convert.ToDateTime(item.Cells["dFechaVencimiento"].Value);
                objKardexRpt.sDocumento = item.Cells["sAlmacen"].Value.ToString();
                objKardexRpt.sNumeracion = item.Cells["sLaboratorio"].Value.ToString();
                objKardexRpt.nEntrada =Convert.ToInt32(item.Cells["nStock"].Value.ToString());
                objKardexRpt.nSalida = Convert.ToInt32(item.Cells["nIdProductoHistorial"].Value.ToString());
                objKardexRpt.sLote = item.Cells["sLote"].Value.ToString();
                listKardexRpt.Add(objKardexRpt);
            }

            rpt.SetDataSource(listKardexRpt);
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

        private void cboOpcion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listadoProductoHistorial = null;
            dgvKardex.Rows.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ConsultaKardex(); 
        }

        private void ConsultaKardex()
        {
            if (dtFechaFinal.Value.Date < dtFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de final no puede ser menor a la fecha inicial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            ProductoHistorial objProdHistorial = new ProductoHistorial()
            {
                nTipo = chkFecha.Checked==true?8:7,
                nIdProducto = lblCodigo.Text==""?0:Convert.ToInt32(lblCodigo.Text),
                sLote  = dtFechaInicio.Value.ToString("yyyyMMdd"),
                sIdLote = dtFechaFinal.Value.ToString("yyyyMMdd"),
                nIdAlmacen = (int)cboAlmacen.SelectedValue
            };

            List<ProductoHistorial> ListProdHistorial = objProHistNeg.ListarProductoHistorial(objProdHistorial);

            if (ListProdHistorial.Count > 0)
            {
                dgvKardex.AutoGenerateColumns = false;
                dgvKardex.DataSource = ListProdHistorial;
            }
            else
            {
                dgvKardex.DataSource = null;
            }

            lblTotal.Text = "Se Encontraron " + dgvKardex.Rows.Count + " Registros";
        }

        private void FrmRptKardex_KeyDown(object sender, KeyEventArgs e)
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

        private void ListarProductos()
        {
            FrmProductoListado frmProductoListado = new FrmProductoListado();
            frmProductoListado.Focus();
            frmProductoListado.ShowDialog();

            if (frmProductoListado._producto != null)
            {
                lblCodigo.Text = frmProductoListado._producto.nIdProducto.ToString();
                lblDescripcion.Text = frmProductoListado._producto.sDescripcion.ToUpper();
                lblStock.Text = frmProductoListado._producto.nTotal.ToString();
                //lblTotal.Text=frmProductoListado._producto.nStock.ToString();
            }
        }

        private void chkFecha_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(chkFecha.CheckState) == true || Convert.ToInt32(chkFecha.CheckState) == 1)
            {
                dtFechaInicio.Value = DateTime.Now;
                dtFechaFinal.Value = DateTime.Now;
                dtFechaInicio.Enabled = true;
                dtFechaFinal.Enabled = true;
                dtFechaInicio.Focus();
            }
            else
            {
                dtFechaInicio.Value = DateTime.Now;
                dtFechaFinal.Value = DateTime.Now;
                dtFechaInicio.Enabled = false;
                dtFechaFinal.Enabled = false;
            } 

            dgvKardex.DataSource = null;
        }
    }
}