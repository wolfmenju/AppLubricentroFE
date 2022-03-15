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

namespace AppInguiri
{
    public partial class FrmProductoListar : DevExpress.XtraEditors.XtraForm
    {
        public FrmCompra frmCompra = null;
        public FrmVenta frmVenta = null;
        public FrmAjusteStock FrmDevuelve = null;
        public int xTipo = 0;
        ProductoNegocio objProducNeg = new ProductoNegocio();
        ProductoHistorialNegocio objProducHistNeg = new ProductoHistorialNegocio();
        List<Producto> listProducto = new List<Producto>();
        List<ProductoHistorial> listProductoHist = new List<ProductoHistorial>();
        List<ProductoHistorial> listProductoHistMod = new List<ProductoHistorial>();
        bool estado = true;
        Producto _producto;
        ProductoHistorial _productoHistorial;

        public FrmProductoListar()
        {
            InitializeComponent();
        }

        #region Principal Load

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            CboTipoBusqueda.SelectedIndex = 1;

            if (xTipo == 1)
            {
                txtDescripcion.Enabled = false;
                BtnNuevo.Enabled = false;
                CboTipoBusqueda.Enabled = false;
                BusquedaProducto();
            }
            else if (xTipo == 2 || xTipo == 3 || xTipo == 4)
            {
                txtCompra.Enabled = false;
                txtVenta.Enabled = false;
                txtLote.Enabled = false;
                dtVencimiento.Enabled = false;
                if(xTipo == 2) NdCantidad.ReadOnly = true;
                else NdCantidad.ReadOnly = false;
            }
        }

        private void BusquedaProducto()
        {
            if (xTipo == 0 || xTipo == 2 || xTipo == 3 || xTipo == 4)
            {
                if (txtDescripcion.Text.Equals("")) return;

                listProducto.Clear();
                Producto objProducto = new Producto();
                objProducto.bEstado = CboTipoBusqueda.SelectedIndex == 1 ? true : false;
                objProducto.nTipo = 5;
                objProducto.sPrincipioActivo = txtDescripcion.Text.ToUpper();

                listProducto = objProducNeg.ListarProducto(objProducto);
                DgvProducto.AutoGenerateColumns = false;

                if (listProducto.Count() > 0)
                {

                    DgvProducto.DataSource = listProducto;
                }
                else
                {
                    DgvProducto.DataSource = null;
                }
            }
            else
            {
                listProducto.Clear();
                Int32 filaselecionada = frmVenta.dgvProducto.CurrentCell.RowIndex;

                Producto objProducto = new Producto();
                objProducto.nTipo = 10;
                objProducto.nIdProducto = Convert.ToInt32(frmVenta.dgvProducto.Rows[filaselecionada].Cells["nIdProducto"].Value);

                listProducto = objProducNeg.ListarProducto(objProducto);

                if (listProducto.Count() > 0)
                {
                    DgvProducto.AutoGenerateColumns = false;
                    DgvProducto.DataSource = listProducto;
                    NdCantidad.Text = Convert.ToString(frmVenta.dgvProducto.Rows[filaselecionada].Cells["nCantidad"].Value);
                }
                else
                {
                    DgvProducto.DataSource = null;
                }
            }

            LblTotal.Text = "Se Encontraron " + DgvProducto.Rows.Count + " Registros";
        }

        #endregion

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BusquedaProducto();
            }
            else if (e.KeyCode == Keys.Down && DgvProducto.RowCount > 0)
            {
                DgvProducto.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        //Lo cree desde el diseñador
        private void txtDescripcion_GotFocus(object sender, EventArgs e)
        {
            txtDescripcion.BackColor = Color.Yellow;
        }

        //Lo cree desde el diseñador
        private void txtDescripcion_LostFocus(object sender, EventArgs e)
        {
            txtDescripcion.BackColor = Color.White;
        }

        private void CboTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            DgvProducto.DataSource = null;

        }

        private void DgvProducto_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvProducto.RowCount > 0) CargarDetalles();
        }

        private void CargarDetalles()
        {
            DgvDetalles.DataSource = null;
            listProductoHist.Clear();
            listProductoHistMod.Clear();

            ProductoHistorial objProHis = new ProductoHistorial()
            {
                nTipo = 2,
                nIdAlmacen = Funciones.CodAlmacenActual(),
                nIdProducto = Convert.ToInt32(DgvProducto.CurrentRow.Cells[0].Value),
                bEstado = true
            };

            listProductoHist = objProducHistNeg.ListarProductoHistorial(objProHis);
            DgvDetalles.AutoGenerateColumns = false;

            if (listProductoHist.Count() > 0)
            {
                int correlativo = 0;

                foreach (ProductoHistorial item in listProductoHist)
                {
                    item.nIdAlmacen = correlativo;
                    listProductoHistMod.Add(item);
                    correlativo++;
                }
                
                DgvDetalles.DataSource = listProductoHistMod;

                if (xTipo == 1)
                {
                    Int32 filaselecionada = frmVenta.dgvProducto.CurrentCell.RowIndex;
                    DgvDetalles.Rows[Convert.ToInt32(frmVenta.dgvProducto.Rows[filaselecionada].Cells["nCorrelativo"].Value)].Cells["bSeleccionar"].Value = true;
                    CargaTotal(Convert.ToInt32(frmVenta.dgvProducto.Rows[filaselecionada].Cells["nCorrelativo"].Value));
                    return;
                }
            }
            else
            {
                DgvDetalles.DataSource = null;
            }


            if (frmVenta != null) CamposHabilitados(false);
            else if ((frmCompra != null)) CamposHabilitados(true);

            ValoresDefectos();
        }

        private void ValoresDefectos()
        {
            NdCantidad.Text = "1";
            txtCompra.Clear();
            txtVenta.Clear();
            txtLote.Clear();
            dtVencimiento.Value = DateTime.Now;
            lblMonto.Text = "0.00";
        }


        private void CamposHabilitados(bool estado)
        {
            txtCompra.Enabled = estado;
            txtVenta.Enabled = estado;
            txtLote.Enabled = estado;
            dtVencimiento.Enabled = estado;
        }

        private void DgvDetalles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDetalles.RowCount > 0)
            {
                int a = e.RowIndex;

                if (a < 0)
                    return;

                CargaTotal(a);
            }
        }

        private void CargaTotal(int a)
        {
            ProductoHistorial obj = null;

            obj = (ProductoHistorial)DgvDetalles.Rows[a].DataBoundItem;

            if ((bool)DgvDetalles.Rows[a].Cells["bSeleccionar"].Value == false)
            {
                foreach (DataGridViewRow item in DgvDetalles.Rows)
                {
                    if ((bool)item.Cells["bSeleccionar"].Value == true)
                    {
                        item.Cells["bSeleccionar"].Value = false;
                    }
                }

                DgvDetalles.Rows[a].Cells["bSeleccionar"].Value = true;

                foreach (DataGridViewRow item in DgvDetalles.Rows)
                {
                    if ((int)item.Cells["nIdProductoHistorial"].Value == obj.nIdProductoHistorial)
                    {
                        if ((bool)item.Cells["bSeleccionar"].Value == true)
                        {
                            
                            txtCompra.Text = item.Cells["fPrecioCompra"].Value.ToString();
                            txtVenta.Text = item.Cells["fPrecioVenta"].Value.ToString();
                            txtLote.Text = item.Cells["sLote"].Value.ToString();
                            
                            if (frmCompra != null)
                            {
                                lblMonto.Text = Convert.ToString(Convert.ToInt32(NdCantidad.Text) * Convert.ToDecimal(item.Cells["fPrecioCompra"].Value.ToString()));
                            }
                            else
                            {
                                lblMonto.Text = Convert.ToString(Convert.ToInt32(NdCantidad.Text) * Convert.ToDecimal(item.Cells["fPrecioVenta"].Value.ToString()));
                            }

                            if (xTipo == 2) NdCantidad.Text = item.Cells["nStock"].Value.ToString();
                            else NdCantidad.Text = "1";
                            dtVencimiento.Text = item.Cells["dFechaVencimiento"].Value.ToString();
                            CamposHabilitados(false);
                            break;
                        }
                    }
                }
            }
            else
            {
                if (xTipo == 1)
                {
                    foreach (DataGridViewRow item in DgvDetalles.Rows)
                    {
                        if ((int)item.Cells["nIdProductoHistorial"].Value == obj.nIdProductoHistorial)
                        {
                            if ((bool)item.Cells["bSeleccionar"].Value == true)
                            {
                                NdCantidad.Text = "1";
                                txtCompra.Text = item.Cells["fPrecioCompra"].Value.ToString();
                                txtVenta.Text = item.Cells["fPrecioVenta"].Value.ToString();
                                txtLote.Text = item.Cells["sLote"].Value.ToString();
                                lblMonto.Text = Convert.ToString(Convert.ToInt32(NdCantidad.Text) * Convert.ToDecimal(item.Cells["fPrecioVenta"].Value.ToString()));
                                dtVencimiento.Text = item.Cells["dFechaVencimiento"].Value.ToString();
                                CamposHabilitados(false);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (frmCompra != null)
                    {
                        DgvDetalles.Rows[a].Cells["bSeleccionar"].Value = false;
                        ValoresDefectos();
                        CamposHabilitados(true);
                    }
                }
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            FrmProductoActualiza frmProducto = new FrmProductoActualiza();
            frmProducto.Text = "Registro Producto";
            frmProducto.ShowDialog();
        }

        private void DgvDetalles_KeyDown(object sender, KeyEventArgs e)
        {
            if (DgvDetalles.RowCount > 0)

                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                {
                    Int32 a = DgvDetalles.CurrentCell.RowIndex;
                    CargaTotal(a);
                    NdCantidad.Focus();
                }
                else if (e.KeyCode == Keys.Down && DgvProducto.RowCount > 0)
                {
                    DgvDetalles.Focus();
                }

        }

        private void DgvProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (DgvDetalles.RowCount > 0)
                {
                    //DgvDetalles.Focus();
                    DgvDetalles.Select();
                }
            }
        }

        private void FrmProductoListar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e, txtCompra);
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e, txtVenta);
        }

        private void txtCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if ((int)txtCompra.TextLength > 0 && (int)txtVenta.TextLength > 0 && (int)txtLote.TextLength > 0 && Convert.ToInt32(NdCantidad.Text) > 0)
                if ((int)txtCompra.TextLength > 0 && (int)txtVenta.TextLength > 0 && Convert.ToInt32(NdCantidad.Text) > 0)
                {
                    txtVenta.Focus();
                    lblMonto.Text = Funciones.CalcularMonto(Convert.ToInt32(NdCantidad.Text), Convert.ToDecimal(txtCompra.Text)).ToString("C");
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el lote del producto o ingresar la información del nuevo lote.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dtVencimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCompra.Enabled && txtVenta.Enabled && Convert.ToInt32(NdCantidad.Text) > 0)
                //if (txtCompra.Enabled && txtVenta.Enabled && txtLote.Enabled && Convert.ToInt32(NdCantidad.Text) > 0)
                {
                    AgregarProducto();
                }
                else
                {
                    MessageBox.Show("Debe ingresar la información del nuevo lote.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCompra.Focus();
                }
            }

        }
        
        private void NdCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dtVencimiento.Enabled) return;
                
                if (xTipo == 2)
                {
                    /*
                    if (dtVencimiento.Value.Date >= DateTime.Now.Date)
                    {
                        MessageBox.Show("No es posible realizar la devolución de los productos. Debe ser productos Vencidos.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    */
                }
                else
                {
                    /*
                    if (frmVenta != null && dtVencimiento.Value.Date <= DateTime.Now.Date)
                    {
                        MessageBox.Show("No es posible realizar la venta de un Producto Vencido.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    */

                }

                if (!txtCompra.Enabled && !txtVenta.Enabled && Convert.ToInt32(NdCantidad.Text) > 0)
                //if (!txtCompra.Enabled && !txtVenta.Enabled && !txtLote.Enabled && !dtVencimiento.Enabled && Convert.ToInt32(NdCantidad.Text) > 0)
                {
                    AgregarProducto();
                }
                else
                {
                    MessageBox.Show("La cantidad del producto no puede puede ser cero (0).", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void AgregarProducto()
        {
            if (DgvProducto.Rows.Count == 0) return;

            if (DgvProducto.CurrentCell != null || DgvProducto.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada5 = DgvProducto.CurrentCell.RowIndex;
                Producto _pro= (Producto)DgvProducto.Rows[filaselecionada5].DataBoundItem;

                if (frmVenta != null)
                {
                    if (_pro.nTotal < Convert.ToInt32(NdCantidad.Text))
                    {
                        MessageBox.Show("La cantidad del Producto excede el Stock Mínimo.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (xTipo == 1)
                {
                    if (DgvDetalles.Rows.Count > 0)
                    {
                        if (DgvDetalles.CurrentCell != null || DgvDetalles.CurrentCell.RowIndex != 0)
                        {
                            Int32 filaselecionada1 = DgvDetalles.CurrentCell.RowIndex;
                            DataGridViewRow row3 = DgvDetalles.Rows[filaselecionada1];
                            ProductoHistorial productoHistorial = (ProductoHistorial)row3.DataBoundItem;
                            Int32 filaselecionada3 = frmVenta.dgvProducto.CurrentCell.RowIndex;
                            frmVenta.dgvProducto.Rows[filaselecionada3].Cells["nCorrelativo"].Value = productoHistorial.nIdAlmacen;
                            frmVenta.dgvProducto.Rows[filaselecionada3].Cells["nIdMovimiento"].Value = productoHistorial.nIdProductoHistorial;
                            frmVenta.dgvProducto.Rows[filaselecionada3].Cells["sLote"].Value = productoHistorial.sLote;
                            frmVenta.dgvProducto.Rows[filaselecionada3].Cells["Vencimiento"].Value = productoHistorial.dFechaVencimiento;
                            frmVenta.dgvProducto.Rows[filaselecionada3].Cells["nCantidad"].Value = NdCantidad.Text;
                            frmVenta.dgvProducto.Rows[filaselecionada3].Cells["fPrecioVenta"].Value = productoHistorial.fPrecioVenta;
                            frmVenta.dgvProducto.Rows[filaselecionada3].Cells["fPrecioCompra"].Value = productoHistorial.fPrecioCompra;
                            frmVenta.dgvProducto.Rows[filaselecionada3].Cells["fGanancia"].Value = productoHistorial.fPrecioVenta-productoHistorial.fPrecioCompra;
                            frmVenta.dgvProducto.Rows[filaselecionada3].Cells["fSubTotal"].Value = Convert.ToInt32(NdCantidad.Text) * productoHistorial.fPrecioVenta;
                            frmVenta.dgvProducto.Rows[filaselecionada3].Cells["fDescuento"].Value = 0.00;
                            frmVenta.dgvProducto.Refresh();
                            this.Close();                            
                        }
                    }
                }
                else
                {
                    Int32 filaselecionada = DgvProducto.CurrentCell.RowIndex;
                    DataGridViewRow row2 = DgvProducto.Rows[filaselecionada];
                    Producto producto = (Producto)row2.DataBoundItem;
                    _producto = producto;

                    if (DgvDetalles.Rows.Count > 0)
                    {
                        if (DgvDetalles.CurrentCell != null || DgvDetalles.CurrentCell.RowIndex != 0)
                        {
                            ProductoHistorial productoHistorial = new ProductoHistorial();

                            foreach (DataGridViewRow item in DgvDetalles.Rows)
                            {
                                if ((bool)item.Cells["bSeleccionar"].Value == true)
                                {
                                    productoHistorial = (ProductoHistorial)item.DataBoundItem;
                                    break;
                                }
                            }

                            if (productoHistorial.bSeleccionar)
                            {
                                if (!ExisteProducto()) return;
                                _productoHistorial = productoHistorial;

                            }
                            else
                            {
                                if ((int)txtCompra.TextLength > 0 && (int)txtVenta.TextLength > 0 && Convert.ToInt32(NdCantidad.Text) > 0)
                                //if ((int)txtCompra.TextLength > 0 && (int)txtVenta.TextLength > 0 && (int)txtLote.TextLength > 0 && Convert.ToInt32(NdCantidad.Text) > 0)
                                {
                                    ProductoHistorial objProducHistorial = new ProductoHistorial()
                                    {
                                        sLote = txtLote.Text,
                                        dFechaVencimiento = Convert.ToDateTime(dtVencimiento.Text),
                                        fPrecioCompra = Convert.ToDecimal(txtCompra.Text),
                                        fPrecioVenta = Convert.ToDecimal(txtVenta.Text)
                                    };

                                    _productoHistorial = objProducHistorial;
                                }
                                else
                                {
                                    MessageBox.Show("Debe seleccionar el lote del producto o ingresar la información del nuevo lote.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        if ((int)txtCompra.TextLength > 0 && (int)txtVenta.TextLength > 0 && Convert.ToInt32(NdCantidad.Text) > 0)
                        //if ((int)txtCompra.TextLength > 0 && (int)txtVenta.TextLength > 0 && (int)txtLote.TextLength > 0 && Convert.ToInt32(NdCantidad.Text) > 0)
                        {
                            ProductoHistorial objProducHistorial = new ProductoHistorial()
                            {
                                sLote = txtLote.Text,
                                dFechaVencimiento = Convert.ToDateTime(dtVencimiento.Text),
                                fPrecioCompra = Convert.ToDecimal(txtCompra.Text),
                                fPrecioVenta = Convert.ToDecimal(txtVenta.Text)
                            };

                            _productoHistorial = objProducHistorial;
                        }
                        else
                        {
                            MessageBox.Show("Debe ingresar la información del nuevo lote.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCompra.Focus();
                            return;
                        }
                    }

                    if (frmCompra != null)
                    {
                        frmCompra.DgProducto.Rows.Add(_productoHistorial.nIdProductoHistorial, producto.nIdProducto, producto.sDescripcion,
                            _productoHistorial.sLote, _productoHistorial.dFechaVencimiento, Convert.ToInt32(NdCantidad.Text),
                            _productoHistorial.fPrecioCompra, _productoHistorial.fPrecioVenta - _productoHistorial.fPrecioCompra, _productoHistorial.fPrecioVenta,
                            Convert.ToInt32(NdCantidad.Text) * Convert.ToDecimal(_productoHistorial.fPrecioCompra));
                    }
                    else if (frmVenta != null)
                    {
                        frmVenta.dgvProducto.Rows.Add(_productoHistorial.nIdAlmacen, _productoHistorial.nIdProductoHistorial, producto.nIdProducto, producto.sDescripcion,
                           _productoHistorial.sLote, _productoHistorial.dFechaVencimiento, Convert.ToInt32(NdCantidad.Text),
                           _productoHistorial.fPrecioCompra, _productoHistorial.fPrecioVenta - _productoHistorial.fPrecioCompra, _productoHistorial.fPrecioVenta,
                          Convert.ToInt32(NdCantidad.Text) * Convert.ToDecimal(_productoHistorial.fPrecioVenta), false, 0);
                    }
                    else if (FrmDevuelve != null)
                    {
                        FrmDevuelve.dgvProducto.Rows.Add(_productoHistorial.nIdAlmacen, _productoHistorial.nIdProductoHistorial, producto.nIdProducto, producto.sDescripcion,
                           _productoHistorial.sLote, _productoHistorial.dFechaVencimiento, Convert.ToInt32(NdCantidad.Text),
                           _productoHistorial.fPrecioCompra, _productoHistorial.fPrecioVenta - _productoHistorial.fPrecioCompra, _productoHistorial.fPrecioVenta,
                          Convert.ToInt32(NdCantidad.Text) * Convert.ToDecimal(_productoHistorial.fPrecioVenta), false, 0);
                    }
                }

                this.Close();
            }
        }

        private bool ExisteProducto()
        {
            bool resp = true;
            if (frmCompra != null)
            {
                if (frmCompra.DgProducto.RowCount > 0)
                {
                    foreach (DataGridViewRow item in frmCompra.DgProducto.Rows)
                    {
                        if ((int)item.Cells["nIdProducto"].Value == _producto.nIdProducto)
                        {
                            MessageBox.Show("El producto " + item.Cells["sDescripcion"].Value + " ya ha sido Agregado.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resp = false;
                            break;
                        }
                    }
                }
            }
            else if (frmVenta != null)
            {
                if (frmVenta.dgvProducto.RowCount > 0)
                {
                    foreach (DataGridViewRow item in frmVenta.dgvProducto.Rows)
                    {
                        if ((int)item.Cells["nIdProducto"].Value == _producto.nIdProducto)
                        {
                            MessageBox.Show("El producto " + item.Cells["sDescripcion"].Value + " ya ha sido Agregado.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resp = false;
                            break;
                        }
                    }
                }
            }

            return resp;
        }

        private void NdCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroEntero(e, NdCantidad);
        }

        private void NdCantidad_TextChanged(object sender, EventArgs e)
        {
            Calculo();
        }

        private void Calculo()
        {
            decimal fVuelto = 0.0M;
            
            foreach (DataGridViewRow item in DgvDetalles.Rows)
            {
                if ((bool)item.Cells["bSeleccionar"].Value == true)
                {
                    if (NdCantidad.Text.Equals("") || NdCantidad.Text.Equals("\r\n"))
                    {
                        fVuelto = 0 * Convert.ToDecimal(txtVenta.Text);
                    }
                    else
                    {
                        if (NdCantidad.Text.Trim().Equals("")) NdCantidad.Text = "0";
                        fVuelto = Convert.ToInt32(NdCantidad.Text) * Convert.ToDecimal(txtVenta.Text);

                    }

                    lblMonto.Text = fVuelto.ToString("C");
                    break;
                }
            }
        }
    }
}
     