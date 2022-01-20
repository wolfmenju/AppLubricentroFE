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
    public partial class FrmCompraListar : Form
    {
        #region Variables Privadas
        CompraNegocio objCompraNeg = new CompraNegocio();
        private bool cerrarFormulario = true;
        bool? xBandero = false;
        List<Venta> ListVenta = new List<Venta>();
        
        #endregion

        public FrmCompraListar()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ListarCompra();
        }

        private void ListarCompra()
        {
            if (dFechaFin.Value.Date < dFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de final no puede ser menor a la fecha inicial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Compra objCompra = new Compra()
            {
                nTipo = 2,
                dFecha = dFechaInicio.Value,
                sSerie = dFechaFin.Value.ToString("yyyyMMdd"),
                nIdAlmacen = Funciones.CodAlmacenActual()
            };

            List<Compra> ListobjCompras = objCompraNeg.ListarCompras(objCompra);

            if (ListobjCompras.Count > 0)
            {
                dgvCompra.AutoGenerateColumns = false;
                dgvCompra.DataSource = ListobjCompras;
            }
            else
            {
                dgvCompra.DataSource = null;
            }

            LblTotal.Text = "Se Encontraron " + dgvCompra.Rows.Count + " Registros";
            cerrarFormulario = false;
        }

        private void FrmVentaListar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }

        private void FrmCompraListar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;

        }

        private void FrmCompraListar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BtnBuscar_Click(sender, e);
                    break;
                case Keys.F3:
                    BtnDetalle_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            Detalle();
        }

        private void Detalle()
        {
            if (TabConsulta.SelectedIndex == 0)
            {
                if (dgvCompra.RowCount > 0)
                {
                    xBandero = true;
                    TabConsulta.SelectedTab = TabDetalle;
                    xBandero = false;
                    Compra _comp = (Compra)dgvCompra.CurrentRow.DataBoundItem;
                    CargarDetalles(_comp.nIdCompra);
                }
                else
                {
                    cerrarFormulario = false;
                }
            }
        }

        public void CargarDetalles(int nIdCompra)
        {
            dgvDetalle.Rows.Clear();

            if (dgvCompra.RowCount > 0)
            {
                ListVenta.Clear();

                Compra objCompra = new Compra()
                {
                    nTipo = 3,
                    nIdCompra = nIdCompra,
                    bEstado = true
                };
                
                List<Compra> ListobjCompras = objCompraNeg.ListarCompras(objCompra);

                if (ListobjCompras.Count > 0)
                {
                    dgvDetalle.AutoGenerateColumns = false;

                    foreach (var item in ListobjCompras)
                    {
                        dgvDetalle.Rows.Add(item.listCompraDetalle[0].nIdCompraDetalle, item.nIdCompra, item.nIdTarjeta,
                        item.listCompraDetalle[0].nIdProducto, item.sProducto, item.listCompraDetalle[0].sLote, item.listCompraDetalle[0].nCantidad,
                        item.listCompraDetalle[0].fPrecioCompra, item.listCompraDetalle[0].fSubTotal);
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            AnularCompra();
        }

        private void AnularCompra()
        {
            if (dgvCompra.RowCount > 0)
            {
                if (dgvCompra.CurrentCell != null || dgvCompra.CurrentCell.RowIndex != 0)
                {
                    int resp = 0;
                    if (MessageBox.Show("¿Desea Anular La Compra Seleccionada?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Int32 filaselecionada = dgvCompra.CurrentCell.RowIndex;
                        Compra _compra = (Compra)dgvCompra.Rows[filaselecionada].DataBoundItem;

                        List<CompraDetalle> listCompDeta = new List<CompraDetalle>();
                        CompraDetalle objCompDeta = null;

                        Compra objCompra = new Compra();
                        objCompra.nTipo = 1;
                        objCompra.nIdCompra = _compra.nIdCompra;
                        objCompra.bCredito = _compra.bCredito;
                        objCompra.nIdAlmacen = _compra.nIdAlmacen;
                        objCompra.dFecha = _compra.dFecha;
                        objCompra.sUsuario = Funciones.UsuarioActual();
                        CargarDetalles(_compra.nIdCompra);
                        
                        foreach (DataGridViewRow item in dgvDetalle.Rows)
                        {
                            objCompDeta = new CompraDetalle();
                            objCompDeta.nIdCompraDetalle = Convert.ToInt32(item.Cells["IdDetalleCompra"].Value);
                            objCompDeta.nIdTarjeta = Convert.ToInt32(item.Cells["IdTarjeta"].Value);
                            objCompDeta.nIdProducto = Convert.ToInt32(item.Cells["IdProducto"].Value);
                            objCompDeta.sLote = item.Cells["Lote"].Value.ToString();
                            objCompDeta.nCantidad = Convert.ToInt32(item.Cells["Cantidad"].Value);

                            listCompDeta.Add(objCompDeta);
                        }

                        objCompra.listCompraDetalle = listCompDeta;

                        resp = objCompraNeg.AnularCompra(objCompra);

                        if (resp > 0)
                        {
                            MessageBox.Show("La Compra Se Anuló Con Exito", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarCompra();
                        }
                        else
                        {
                            MessageBox.Show("La Compra No Se Puede Anular", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }

            cerrarFormulario = false;
        }
    }
}
