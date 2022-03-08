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
    public partial class FrmRptProductoStock : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptProductoStock frmInstance = null;
        ProductoHistorialNegocio objProdHistorialNeg = new ProductoHistorialNegocio();
        ParametroNegocio objParaNeg = new ParametroNegocio();
        List<Venta> listadoVenta = null;
        AlmacenNegocio objAlmNeg = new AlmacenNegocio();
        
        //Singleton
        public static FrmRptProductoStock Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptProductoStock();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmRptProductoStock()
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
            if (dgvProducto.Rows.Count < 1) return;

            List<StockMinimoRpt> listStockMinimo = new List<StockMinimoRpt>();
            RptProductoStock rpt = new RptProductoStock();

            foreach (DataGridViewRow item in dgvProducto.Rows)
            {
                StockMinimoRpt objProStock = new StockMinimoRpt();
                objProStock.sCodigoInterno= item.Cells["sCodigoInterno"].Value.ToString();
                objProStock.sProducto = item.Cells["sNombreProducto"].Value.ToString();
                objProStock.sAlmacen = item.Cells["sAlmacen"].Value.ToString();
                objProStock.bAlternativo = Convert.ToBoolean(item.Cells["bSeleccionar"].Value);
                objProStock.sLaboratorio = item.Cells["sLaboratorio"].Value.ToString();
                objProStock.sLote = item.Cells["sLote"].Value.ToString().Equals("")?"DEFAULT": item.Cells["sLote"].Value.ToString();
                objProStock.dFechaVencimiento = Convert.ToDateTime(item.Cells["dFechaVencimiento"].Value);
                objProStock.nTotal = Convert.ToInt32(item.Cells["nStock"].Value);
                listStockMinimo.Add(objProStock);
            }

            rpt.SetDataSource(listStockMinimo);
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
            ListarHistorial();
        }

        private void ListarHistorial()
        {
            ProductoHistorial objProdHistorial = new ProductoHistorial()
            {
                nTipo =chkTodos.Checked==true?9:10,
                nIdAlmacen=cboAlmacen.SelectedValue==null?0: (int)cboAlmacen.SelectedValue,
                nStock=(int)ndInicio.Value,
                nIdProducto=(int)ndFin.Value
            };

            List<ProductoHistorial> ListProdHistorial= objProdHistorialNeg.ListarProductoHistorial(objProdHistorial);

            if (ListProdHistorial.Count > 0)
            {
                dgvProducto.AutoGenerateColumns = false;
                dgvProducto.DataSource = ListProdHistorial;
            }
            else
            {
                dgvProducto.DataSource = null;
            }

            lblTotal.Text = "Se Encontraron " + dgvProducto.Rows.Count + " Registros";
        }

        private void FrmRptProductoStock_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    
                    if (Convert.ToBoolean(chkTodos.Checked))
                        chkTodos.CheckState = CheckState.Unchecked;
                    else chkTodos.CheckState = CheckState.Checked;
                     
                    ActivarOpcion();
                    break;
                case Keys.F2:
                    btnBuscar_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            ActivarOpcion();
        }

        public void ActivarOpcion()
        {
            if (chkTodos.Checked)
            {
                cboAlmacen.SelectedIndex = -1;
                cboAlmacen.Enabled = false;
            }
            else
            {
                cboAlmacen.SelectedIndex = 0;
                cboAlmacen.Enabled = true;
            }
        }
    }
}