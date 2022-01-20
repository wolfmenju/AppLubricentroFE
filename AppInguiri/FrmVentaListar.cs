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
using CrystalDecisions.CrystalReports.Engine;
using AppInguiri.EntidadReporte;

namespace AppInguiri
{
    public partial class FrmVentaListar : Form
    {
        #region Variables Privadas
        VentaNegocio objVentNeg = new VentaNegocio();
        private bool cerrarFormulario = true;
        bool? xBandero = false;
        List<Venta> ListVenta = new List<Venta>();
        

        #endregion

        public FrmVentaListar()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ListarVenta();
        }

        private void ListarVenta()
        {
            if (dFechaFin.Value.Date < dFechaInicio.Value.Date)
            {

                MessageBox.Show("La fecha de final no puede ser menor a la fecha inicial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }  

            Venta objVenta = new Venta()
            {
                nTipo=2,
                dFecha=dFechaInicio.Value,
                sSerie=dFechaFin.Value.ToString("yyyyMMdd"),
                nIdAlmacen=Funciones.CodAlmacenActual()
            };

            List<Venta> ListVentas= objVentNeg.ListarVentas(objVenta);

            if (ListVentas.Count > 0)
            {
                dgvVenta.AutoGenerateColumns = false;
                dgvVenta.DataSource = ListVentas;
            }
            else
            {
                dgvVenta.DataSource = null;
            }

            LblTotal.Text = "Se Encontraron " + dgvVenta.Rows.Count + " Registros";
            cerrarFormulario = false;
        }

        private void FrmVentaListar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }

        private void TabConsulta_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (TabConsulta.SelectedIndex == 0)
            {
                xBandero = true;
                TabConsulta.SelectedTab = TabCompras;
                LblTotal.Text = "Se Encontraron " + dgvDetalle.Rows.Count + " Registros";
                xBandero = false;
                return;
            }

            if (xBandero == true) e.Cancel = false;
            else if (xBandero == false) e.Cancel = true;
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            Detalle();
        }

        private void Detalle()
        {
            if (TabConsulta.SelectedIndex == 0)
            {
                if (dgvVenta.RowCount > 0)
                {
                    xBandero = true;
                    TabConsulta.SelectedTab = TabDetalle;
                    xBandero = false;
                    Venta _vent = (Venta)dgvVenta.CurrentRow.DataBoundItem;
                    CargarDetalles(_vent.nIdVenta);
                }
                else
                {
                    cerrarFormulario = false;
                }
            }
        }

        public void CargarDetalles(int nIdVenta)
        {
            dgvDetalle.Rows.Clear();

            if (dgvVenta.RowCount > 0)
            {
                ListVenta.Clear();

                Venta objVenta = new Venta()
                {
                    nTipo = 3,
                    nIdVenta = nIdVenta,
                    bEstado = true
                };

                ListVenta = objVentNeg.ListarVentas(objVenta);

                if (ListVenta.Count > 0)
                {
                    dgvDetalle.AutoGenerateColumns = false;

                    foreach (var item in ListVenta)
                    {
                      dgvDetalle.Rows.Add(item.listVentaDetalle[0].nIdVentaDetalle , item.nIdVenta, item.nIdTarjeta,
                      item.nIdProducto, item.sProducto, item.listVentaDetalle[0].sLote, item.listVentaDetalle[0].nCantidad, 
                      item.listVentaDetalle[0].fPrecioVenta, item.listVentaDetalle[0].fSubTotal, item.listVentaDetalle[0].fDescuento,
                      item.fTotal);
                    }
                }
                else
                {
                    dgvDetalle.Rows.Clear();
                    //dgvDetalle = 0;
                }

                LblTotal.Text = "Se Encontraron " + dgvDetalle.Rows.Count + " Registros";
                cerrarFormulario = false;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            AnularVenta();
        }

        private void AnularVenta()
        {
            if (dgvVenta.RowCount > 0)
            {
                if (dgvVenta.CurrentCell != null || dgvVenta.CurrentCell.RowIndex != 0)
                {
                    int resp = 0;

                    if (MessageBox.Show("¿Desea Anular La Venta Seleccionada?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Int32 filaselecionada = dgvVenta.CurrentCell.RowIndex;
                        Venta _venta = (Venta)dgvVenta.Rows[filaselecionada].DataBoundItem;
                        
                        List<VentaDetalle> listVentDeta = new List<VentaDetalle>();
                        VentaDetalle objVentDeta = null;

                        Venta objVenta = new Venta();
                        objVenta.nTipo = 1;
                        objVenta.nIdVenta = _venta.nIdVenta;
                        objVenta.nIdAlmacen = Funciones.CodAlmacenActual();
                        objVenta.dFecha = _venta.dFecha;
                        objVenta.fTotal = _venta.fTotal;
                        objVenta.sUsuario = Funciones.UsuarioActual();
                        CargarDetalles(objVenta.nIdVenta);

                        foreach (DataGridViewRow item in dgvDetalle.Rows)
                        {
                            objVentDeta = new VentaDetalle();
                            objVentDeta.nIdVentaDetalle = Convert.ToInt32(item.Cells["nIdVentaDetalle"].Value);
                            objVentDeta.nIdTarjeta = Convert.ToInt32(item.Cells["nIdTarjeta"].Value);
                            objVentDeta.nIdProducto = Convert.ToInt32(item.Cells["nIdProducto"].Value);
                            objVentDeta.sLote = item.Cells["sLote"].Value.ToString();
                            objVentDeta.nCantidad = Convert.ToInt32(item.Cells["nCantidad"].Value);
                            objVentDeta.fPrecioVenta = Convert.ToDecimal(item.Cells["fPrecioVenta"].Value);
                            objVentDeta.fSubTotal = Convert.ToDecimal(item.Cells["fSubTotal"].Value);
                            objVentDeta.fDescuento = Convert.ToDecimal(item.Cells["fDescuento"].Value);

                            listVentDeta.Add(objVentDeta);
                        }

                        objVenta.listVentaDetalle = listVentDeta;

                        resp= objVentNeg.AnularVenta(objVenta);

                        if (resp > 0)
                        {
                            MessageBox.Show("La Venta Se Anuló Con Exito", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarVenta();
                        }
                        else
                        {
                            MessageBox.Show("La Venta No Se Puede Anular", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }   
                    }
                }
            }

            cerrarFormulario = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvVenta.RowCount < 1)
            {
                MessageBox.Show("No existe Registro.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cerrarFormulario = false;
                return;
            }

            if (dgvVenta.CurrentCell != null || dgvVenta.CurrentCell.RowIndex != 0)
            {
                if (MessageBox.Show("¿Desea Reimprimir El Recibo de La Venta Seleccionada?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Int32 filaselecionada = dgvVenta.CurrentCell.RowIndex;
                    Venta _venta = (Venta)dgvVenta.Rows[filaselecionada].DataBoundItem;

                    ImprimirComprobante(_venta.nIdVenta);
                }
            }  
        }

        private void ImprimirComprobante(int nIdVenta)
        {
            var instance = new System.Drawing.Printing.PrinterSettings();
            string impresosaPredt = instance.PrinterName;
            ReportDocument Rep = new ReportDocument();
            List<ReciboRpt> LisRecibo = new List<ReciboRpt>();

            try
            {
                Venta objVenta = new Venta() { nTipo = 8, nIdVenta = nIdVenta };

                List<Venta> LisVenRep = objVentNeg.ListarVentas(objVenta);

                if (LisVenRep.Count < 1)
                {
                    MessageBox.Show("No se puede imprimir", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombre_Up = "";
                string nombre_Lo = "";

                foreach (var item in LisVenRep)
                {
                    nombre_Up = item.sIdDocumento;
                    nombre_Lo = nombre_Up.ToLower();

                    ReciboRpt reciboRpt = new ReciboRpt();
                    reciboRpt.sDocumento = nombre_Lo.Replace(nombre_Lo[0], nombre_Up[0]);
                    reciboRpt.nNumero = Convert.ToInt32(item.nNumero);
                    reciboRpt.fTotal = item.fTotal;
                    reciboRpt.fDescuento = item.fDescuento;
                    reciboRpt.fPrecio = item.fPrecioVenta;
                    reciboRpt.nCantidad = item.nCodigo;
                    reciboRpt.sIdVendedor = item.sIdVendedor;
                    reciboRpt.sNombre = item.sNombre;
                    reciboRpt.sProducto = item.sProducto;
                    reciboRpt.sFechaRegistro = item.dFecha.ToShortDateString();
                    LisRecibo.Add(reciboRpt);
                }

                Rep.Load(Application.StartupPath + "\\RptRecibo.rpt");
                Rep.SetDataSource(LisRecibo);
                Rep.PrintOptions.PrinterName = impresosaPredt;
                Rep.PrintToPrinter(1, false, 0, 0);
                Rep = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cerrarFormulario = false;
        }

        private void FrmVentaListar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BtnBuscar_Click(sender, e);
                    break;
                case Keys.F3:
                    BtnDetalle_Click(sender, e);
                    break;
                case Keys.F4:
                    BtnEliminar_Click(sender, e);
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
