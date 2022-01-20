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
    public partial class FrmRptLoteProductoPorVencer : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptLoteProductoPorVencer frmInstance = null;
        VentaNegocio objVentaNeg = new VentaNegocio();
        ProductoHistorialNegocio objProHistNeg = new ProductoHistorialNegocio();
        ParametroNegocio objParaNeg = new ParametroNegocio();
        List<ProductoHistorial> listadoProductoHistorial = null;

        AlmacenNegocio objAlmNeg = new AlmacenNegocio();
        
        //Singleton
        public static FrmRptLoteProductoPorVencer Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptLoteProductoPorVencer();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmRptLoteProductoPorVencer()
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

            List<ProductoVencidoRpt> listProdVencido = new List<ProductoVencidoRpt>();
            RptProductoVencido rpt = new RptProductoVencido();
                
            foreach (DataGridViewRow item in dgvProducto.Rows)
            {
                ProductoVencidoRpt objProVenRpt = new ProductoVencidoRpt();

                objProVenRpt.nIdAlmacen = Convert.ToInt32(item.Cells["nIdAlmacen"].Value);
                objProVenRpt.sProducto = item.Cells["sNombreProducto"].Value.ToString();
                objProVenRpt.sAlmacen = item.Cells["sAlmacen"].Value.ToString();
                objProVenRpt.bAlternativo = item.Cells["bSeleccionar"].Value.ToString();
                objProVenRpt.sLaboratorio= item.Cells["sLaboratorio"].Value.ToString();
                objProVenRpt.sLote = item.Cells["sLote"].Value.ToString();
                objProVenRpt.sFeChaVencimiento =Convert.ToDateTime(item.Cells["dFechaVencimiento"].Value).ToString("dd/MM/yyyy");
                objProVenRpt.sDias = item.Cells["nStock"].Value.ToString();
                
                listProdVencido.Add(objProVenRpt);
            }

            rpt.SetDataSource(listProdVencido);
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

        private void cboOpcion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listadoProductoHistorial = null;
            dgvProducto.Rows.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Consulta(); 
        }

        private void Consulta()
        {
            ProductoHistorial objProHis = new ProductoHistorial()
            {
                nTipo = chkTodos.CheckState == CheckState.Unchecked ? 14 : 13,
                nIdAlmacen=Convert.ToInt32(cboAlmacen.SelectedValue),
                nStock=Convert.ToInt32(NdDias.Value),
                bEstado = true
            };

            listadoProductoHistorial= objProHistNeg.ListarProductoHistorial(objProHis);

            if (listadoProductoHistorial.Count > 0)
            {
                dgvProducto.AutoGenerateColumns = false;
                dgvProducto.DataSource = listadoProductoHistorial;
                lblTotal.Text = "Se Encontraron " + dgvProducto.Rows.Count + " Registros";
            }
            else
            {
                dgvProducto.Rows.Clear();
            }

        }

        private void FrmRptLoteProductoPorVencer_KeyDown(object sender, KeyEventArgs e)
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

        private void FrmRptLoteProductoPorVencer_Load(object sender, EventArgs e)
        {
           
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            Activar();
        }

        private void Activar()
        {
            if (cboAlmacen.Enabled)
            {
                cboAlmacen.Enabled = false;
                chkTodos.Checked = Convert.ToBoolean(CheckState.Checked);
            }
            else
            {
                if (cboAlmacen.Items.Count > 0)
                {
                    cboAlmacen.SelectedIndex = 0;
                    cboAlmacen.Enabled = true;
                    chkTodos.Checked = Convert.ToBoolean(CheckState.Unchecked);
                }
            }

            dgvProducto.DataSource = null;
            NdDias.Focus();
        }
        
    }
}