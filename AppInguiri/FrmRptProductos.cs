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
    public partial class FrmRptProductos : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptProductos frmInstance = null;
        ParametroNegocio objParaNeg = new ParametroNegocio();
        private ProductoNegocio objProdNeg = new ProductoNegocio();
        private List<Producto> listProd = new List<Producto>();        
        private bool cerrarFormulario = true;

        //Singleton
        public static FrmRptProductos Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptProductos();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }
        
        public FrmRptProductos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            cerrarFormulario = true;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ReporteProductos(cboDocumento.SelectedIndex);
            cerrarFormulario = false;
        }

        private void ReporteProductos(int tipoReporte)
        {
            listProd.Clear();
            Producto objProducto = new Producto();
            objProducto.bEstado = true;
            objProducto.nTipo = 7;

            listProd = objProdNeg.ListarProducto(objProducto);

            if (listProd.Count < 1) return;

            List<ProductoRpt> lisProductoRpt = new List<ProductoRpt>();
           
            foreach (Producto item in listProd)
            {
                ProductoRpt objProdRpt = new ProductoRpt();
                objProdRpt.sProducto = item.sDescripcion;
                objProdRpt.sPrincipioActivo = item.sPrincipioActivo;
                objProdRpt.sLaboratorio = item.sLaboratorio;
                objProdRpt.sPresentacion = item.sPresentacion;
                objProdRpt.bAlternativo = item.bAlternativo;
                objProdRpt.nStockMinimo = item.nStockMinimo;

                lisProductoRpt.Add(objProdRpt);
            }

            if (tipoReporte == 0)
            {
                RptProducto rpt = new RptProducto();
                rpt.SetDataSource(lisProductoRpt);
                rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
                rpt.SetParameterValue("NombreEmpresa", objParaNeg.LeerUnParametro("ID_TITULO"));
                rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
                RptMaestro Reporte = new RptMaestro();
                Reporte.Show();
                Reporte.Text = "";//cboOpcion.Text;
                Reporte.Focus();
                Reporte.cReporte.ReportSource = rpt;
            }
            else if (tipoReporte == 1)
            {
                RptProductoLaboratorio rpt = new RptProductoLaboratorio();
                rpt.SetDataSource(lisProductoRpt);
                rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
                rpt.SetParameterValue("NombreEmpresa", objParaNeg.LeerUnParametro("ID_TITULO"));
                rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
                RptMaestro Reporte = new RptMaestro();
                Reporte.Show();
                Reporte.Text = "";//cboOpcion.Text;
                Reporte.Focus();
                Reporte.cReporte.ReportSource = rpt;
            }
            else if (tipoReporte == 2)
            {
                RptProductoPresentacion rpt = new RptProductoPresentacion();
                rpt.SetDataSource(lisProductoRpt);
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
        
        private void FrmRptProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }

        private void FrmRptProductos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void FrmRptProductos_Load(object sender, EventArgs e)
        {
            cboDocumento.SelectedIndex = 0;
        }
    }
}