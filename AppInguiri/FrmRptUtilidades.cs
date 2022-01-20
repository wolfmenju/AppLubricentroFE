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
using System.IO;
using NPOI.HSSF.UserModel;

namespace AppInguiri
{
    public partial class FrmRptUtilidades : DevExpress.XtraEditors.XtraForm
    {
        private static FrmRptUtilidades frmInstance = null;
        VentaNegocio objVentaNeg = new VentaNegocio();
        ParametroNegocio objParaNeg = new ParametroNegocio();
        List<Venta> listadoVenta = null;
        AlmacenNegocio objAlmNeg = new AlmacenNegocio();
        
        //Singleton
        public static FrmRptUtilidades Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmRptUtilidades();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        public FrmRptUtilidades()
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarUtilidades();
        }

        private void ListarUtilidades()
        {
            if (dtFechaFinal.Value.Date < dtFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de final no puede ser menor a la fecha inicial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Venta objVenta = new Venta()
            {
                nTipo = 7,
                dFecha = dtFechaInicio.Value,
                sSerie = dtFechaFinal.Value.ToString("yyyyMMdd"),
                nIdAlmacen=(int)cboAlmacen.SelectedValue
            };

            List<Venta> ListVentas= objVentaNeg.ListarVentas(objVenta);

            if (ListVentas.Count > 0)
            {
                dgvUtilidades.AutoGenerateColumns = false;
                dgvUtilidades.DataSource = ListVentas;
            }
            else
            {
                dgvUtilidades.DataSource = null;
            }

            lblTotal.Text = "Se Encontraron " + dgvUtilidades.Rows.Count + " Registros";
        }

        private void FrmRptUtilidades_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    btnBuscar_Click(sender, e);
                    break;
                case Keys.F2:
                    btnDescargar_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            Descargar();
        }

        private void Descargar()
        {
            if (dgvUtilidades.Rows.Count != 0)
            {
                MessageBox.Show("Se exportarán sus datos a Excel, por favor espere...", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HSSFWorkbook libro = new HSSFWorkbook();
                HSSFSheet hoja = (HSSFSheet)libro.CreateSheet("Utilidades");
                HSSFRow fila = (HSSFRow)hoja.CreateRow(0);

                for (int i = 0; i < dgvUtilidades.Columns.Count; i++)
                {
                    if (dgvUtilidades.Columns[i].Visible)
                    {
                        fila.CreateCell(i).SetCellValue(dgvUtilidades.Columns[i].HeaderText);
                    }
                    else
                    {
                        hoja.SetColumnHidden(i, true);
                    }
                }

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";

                for (int i = 0; i < dgvUtilidades.Rows.Count; i++)
                {
                    fila = (HSSFRow)hoja.CreateRow(i + 1);
                    for (int j = 0; j < (dgvUtilidades.Columns.Count); j++)
                    {
                        if (dgvUtilidades.Columns[j].Visible)
                        {
                            fila.CreateCell(j).SetCellValue(dgvUtilidades.Rows[i].Cells[j].Value == null ? "" : dgvUtilidades.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                }

                for (int i = 0; i < dgvUtilidades.Columns.Count; i++)
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