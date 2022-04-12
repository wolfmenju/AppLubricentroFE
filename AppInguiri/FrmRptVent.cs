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
using NPOI.HSSF.UserModel;
using System.IO;

namespace AppInguiri
{
    public partial class FrmRptVent : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptVent frmInstance = null;
        private VentaNegocio objVentaNeg = new VentaNegocio();
        private ParametroNegocio objParaNeg = new ParametroNegocio();
        private MedioPagoNegocio objMedPagoNeg = new MedioPagoNegocio();
        private List<MedioPago> ListMedPago = new List<MedioPago>();
        private int nOpcion = 0;
        
        //Singleton
        public static FrmRptVent Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptVent();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmRptVent()
        {
            InitializeComponent();
            CargarMaestros();
        }

        private void CargarMaestros()
        {
            ListMedPago = objMedPagoNeg.ListarMedioPago(true);

            cbxOpcionDetalle.ValueMember = "nIdMedioPago";
            cbxOpcionDetalle.DisplayMember = "sDescripcion";
            cbxOpcionDetalle.DataSource = ListMedPago;

            if (ListMedPago.Count > 0)
            {
                cbxOpcionDetalle.SelectedIndex = 0;
            }
            else
            {
                cbxOpcionDetalle.Enabled = false;
                btnBuscar.Enabled = false;
                btnDescargar.Enabled = false;
                MessageBox.Show("Falta Agregar los medios de pagos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvReporteVentas.Columns.Clear();
            dgvReporteVentas.Columns.Add("nNumero", "N°");
            dgvReporteVentas.Columns.Add("sDescripDocumento", "Descripcion");
            dgvReporteVentas.Columns.Add("fTotal", "Total");

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
            dgvReporteVentas.Columns.Clear();

            if (nOpcion == 0)
            {
                dgvReporteVentas.Columns.Add("nNumero", "N°");
                dgvReporteVentas.Columns.Add("sDescripDocumento", "Descripcion");
                dgvReporteVentas.Columns.Add("fTotal", "Total");

                Venta objVenta = new Venta()
                {
                    dFecha=dtFechaInicio.Value.Date,
                    sIdVendedor=dtFechaFin.Value.Date.ToString("yyyyMMdd"),
                    nTipo = 13,
                    bEstado = true
                };

                List<Venta> ListVentas = objVentaNeg.ListarVentas(objVenta);

                if (ListVentas.Count > 0)
                {
                    foreach (var item in ListVentas)
                    {
                        dgvReporteVentas.Rows.Add(item.nNumero, item.sDescripDocumento, item.fTotal);
                    }
                }
                else
                {
                    dgvReporteVentas.DataSource = null;
                }
            }
            else if (nOpcion == 1)
            {
                //dgvReporteVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvReporteVentas.Columns.Add("sDescripDocumento", "Documento");
                dgvReporteVentas.Columns.Add("sSerie", "Numero");
                dgvReporteVentas.Columns.Add("sSunat", "Estado Sunat");
                dgvReporteVentas.Columns.Add("dFecha", "Fecha de Emisión");
                dgvReporteVentas.Columns.Add("sNombre", "Cliente");
                dgvReporteVentas.Columns.Add("sLaboratorio", "Número");
                dgvReporteVentas.Columns.Add("sMedioPago", "Medio de Pago");
                dgvReporteVentas.Columns.Add("fSubTotal", "Monto Pagado");
                dgvReporteVentas.Columns.Add("fIgv", "Igv");
                dgvReporteVentas.Columns.Add("fTotal", "Total");

                Venta objVenta = new Venta()
                {
                    dFecha = dtFechaInicio.Value.Date,
                    sIdVendedor = dtFechaFin.Value.Date.ToString("yyyyMMdd"),
                    sIdDocumento= !chkTodos.Checked? cbxOpcionDetalle.SelectedValue.ToString():"",
                    nTipo = 14,
                    bEstado = true
                };

                List<Venta> ListVentas = objVentaNeg.ListarVentas(objVenta);

                if (ListVentas.Count > 0)
                {
                    foreach (var item in ListVentas)
                    {
                        dgvReporteVentas.Rows.Add(item.sDescripDocumento,item.sSerie,item.sSunat,item.dFecha,
                            item.sNombre, item.sLaboratorio, item.sMedioPago, item.fSubTotal, item.fIgv,item.fTotal);
                    }
                }
                else
                {
                    dgvReporteVentas.DataSource = null;
                }
            }
        }

        private void FrmRptCompras_Load(object sender, EventArgs e)
        {

        }
    
        private void FrmRptCompras_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    //ListarProveedor();
                    break;
                case Keys.F2:
                    //ActivaCompras();
                    break;
                case Keys.F6:
                    btnDescargar_Click(sender,e);
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
        
        private void cbxOpcionPrincipal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvReporteVentas.Rows.Clear();
            nOpcion = cbxOpcionPrincipal.SelectedIndex;

            if (cbxOpcionPrincipal.SelectedIndex == 1)
            {
                chkTodos.Checked = true;
                chkTodos.Visible = true;
                cbxOpcionDetalle.Enabled = false;
                cbxOpcionDetalle.Visible = true;
                cbxOpcionDetalle.SelectedIndex = -1;
            }
            else
            {
                chkTodos.Visible = false;
                cbxOpcionDetalle.Visible = false;
            }
        }

        private void chkTodos_Click(object sender, EventArgs e)
        {
            dgvReporteVentas.Rows.Clear();

            if (chkTodos.Checked)
            {
                cbxOpcionDetalle.Enabled = false;
                cbxOpcionDetalle.SelectedIndex = -1;
            }
            else
            {
                cbxOpcionDetalle.Enabled = true;

                if (cbxOpcionDetalle.Items.Count > 0)
                {
                    cbxOpcionDetalle.SelectedIndex = 0;
                }
                else
                {
                    cbxOpcionDetalle.Enabled = false;
                }
            }
        }

        private void FrmRptVent_Load(object sender, EventArgs e)
        {
            cbxOpcionPrincipal.SelectedIndex = 0;
        }

        private void cbxOpcionDetalle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvReporteVentas.Rows.Clear();
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            Descargar();
        }

        private void Descargar()
        {
            if (dgvReporteVentas.Rows.Count != 0)
            {
                MessageBox.Show("Se exportarán sus datos a Excel, por favor espere...", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HSSFWorkbook libro = new HSSFWorkbook();
                HSSFSheet hoja = (HSSFSheet)libro.CreateSheet("Utilidades");
                HSSFRow fila = (HSSFRow)hoja.CreateRow(0);

                for (int i = 0; i < dgvReporteVentas.Columns.Count; i++)
                {
                    if (dgvReporteVentas.Columns[i].Visible)
                    {
                        fila.CreateCell(i).SetCellValue(dgvReporteVentas.Columns[i].HeaderText);
                    }
                    else
                    {
                        hoja.SetColumnHidden(i, true);
                    }
                }

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                double nImporte = 0.00;

                for (int i = 0; i < dgvReporteVentas.Rows.Count; i++)
                {
                    nImporte = nImporte + Convert.ToDouble(dgvReporteVentas.Rows[i].Cells["fTotal"].Value);
                    fila = (HSSFRow)hoja.CreateRow(i + 1);
                    for (int j = 0; j < (dgvReporteVentas.Columns.Count); j++)
                    {
                        if (dgvReporteVentas.Columns[j].Visible)
                        {
                            fila.CreateCell(j).SetCellValue(dgvReporteVentas.Rows[i].Cells[j].Value == null ? "" : dgvReporteVentas.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                }

                if (fila.RowNum > 0)
                {
                    fila = (HSSFRow)hoja.CreateRow(dgvReporteVentas.Rows.Count + 2);
                    fila.CreateCell(dgvReporteVentas.Columns.Count - 1).SetCellValue(nImporte.ToString("C"));
                }

                for (int i = 0; i < dgvReporteVentas.Columns.Count; i++)
                {
                    hoja.AutoSizeColumn(i);
                    hoja.HorizontallyCenter = true;
                }

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(fichero.FileName, FileMode.OpenOrCreate);
                    libro.Write(fs);
                    fs.Close();

                    MessageBox.Show("Se Exportó Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay data que Exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}