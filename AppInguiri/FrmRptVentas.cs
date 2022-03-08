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
    public partial class FrmRptVentas : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptVentas frmInstance = null;
        VentaNegocio objVentaNeg = new VentaNegocio();
        ParametroNegocio objParaNeg = new ParametroNegocio();
        private bool cerrarFormulario = true;

        //Singleton
        public static FrmRptVentas Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptVentas();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmRptVentas()
        {
            InitializeComponent();
        }

        private void dtFechaInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) dtFechaFin.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            if (dtFechaFin.Value.Date < dtFechaInicio.Value.Date)
            {

                MessageBox.Show("La fecha de final no puede ser menor a la fecha inicial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            List<ListaVentasRpt> listadoVentas = new List<ListaVentasRpt>();
            RptListaVenta rpt = new RptListaVenta();

            Venta objVenta = new Venta()
            {
                nTipo = 10,
                dFecha = dtFechaInicio.Value,
                sIdVendedor = dtFechaFin.Value.ToString("yyyyMMdd"),
                bEstado=true
            };

            List<Venta> ListVentas = objVentaNeg.ListarVentas(objVenta);

            if (ListVentas.Count > 0)
            {
                foreach (var item in ListVentas)
                {
                    ListaVentasRpt objProVenRpt = new ListaVentasRpt();
                    objProVenRpt.nIdVenta = item.nIdVenta;
                    objProVenRpt.sNombreCliente = item.sNombre;
                    objProVenRpt.dFecha = item.dFecha;
                    objProVenRpt.sDocumento = item.sIdDocumento;
                    objProVenRpt.sIdCajero = item.sIdCajero;
                    objProVenRpt.sCodigoInterno = item.sCodigoInterno;
                    objProVenRpt.sProducto = item.sProducto;
                    objProVenRpt.nCantidad = item.nCodigo;
                    objProVenRpt.fPrecio =decimal.Round(item.fPrecioVenta- item.fIgv,2);
                    objProVenRpt.fDescuento = item.fDescuento;
                    objProVenRpt.fIgv = item.fIgv;
                    listadoVentas.Add(objProVenRpt);
                }

                rpt.SetDataSource(listadoVentas);
                rpt.SetParameterValue("Usuario", Funciones.UsuarioActual());
                rpt.SetParameterValue("Empresa", objParaNeg.LeerUnParametro("ID_TITULO"));
                rpt.SetParameterValue("Nombres", Funciones.UsuarioActual());
                RptMaestro Reporte = new RptMaestro();
                Reporte.Show();
                Reporte.Focus();
                Reporte.cReporte.ReportSource = rpt;
            }
            else
            {
                MessageBox.Show("No se encontraron registros.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            cerrarFormulario = false;
        }



        private void FrmRptVentas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    btnBuscar_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void FrmRptVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }
    }
}