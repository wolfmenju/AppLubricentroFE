using Comun;
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

namespace AppInguiri
{
    public partial class FrmInventarioProducto : Form
    {
        ProductoNegocio objProducNeg = new ProductoNegocio();
        CategoriaNegocio objCateNeg = new CategoriaNegocio();
        PresentacionNegocio objPreseNeg = new PresentacionNegocio();
        InventarioDetalleNegocio objInventarioDetalleNeg = new InventarioDetalleNegocio();
        public FrmInventarioDetalle frmInventarioDetalle = null;
        public int tipo = 0;
        private bool cerrarFormulario = true;
        private Producto producto = null;

        public FrmInventarioProducto(Producto _producto)
        {
            InitializeComponent();
            producto = _producto;
        }

        public FrmInventarioProducto()
        {
            InitializeComponent();
            
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInventarioProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }

        private void FrmInventarioProducto_Load(object sender, EventArgs e)
        {
            CargarDatosProductos();
        }

        private void CargarDatosProductos()
        {
            lblCodigo.Text = producto.nIdProducto.ToString();
            lblCodigoInterno.Text = producto.sCodigoInterno;
            lblProducto.Text = producto.sDescripcion.ToString();
            txtPrecioVenta.Text = producto.fPrecioVenta.ToString();
            txtPrecioCompra.Text = producto.fPrecioCompra.ToString();
            if (producto.dFechaVencimiento == null) producto.dFechaVencimiento = null;
            else dtFechaVencimiento.Value =Convert.ToDateTime(producto.dFechaVencimiento);

            if (producto.sLote == null) producto.sLote = null;
            else txtLote.Text = producto.sLote.ToUpper();

            ndStock.Value =(int) producto.nStock;
            
        }

        private void txtLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtPrecioCompra.Focus();
        }

        private void dtFechaVencimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtLote.Focus();
        }

        private void txtPrecioCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Guardar();
            }
        }

        private void Guardar()
        {
            if (!VerificarDatos())
            {
                cerrarFormulario = false;
                return;
            }
            if (Convert.ToDecimal(txtPrecioCompra.Text) < Convert.ToDecimal(txtPrecioVenta.Text))
            {
                InventarioDetalle objInventarioDetalle = new InventarioDetalle()
                {
                    nTipo = 1,
                    nStock = (int)ndStock.Value,
                    dFechaVencimiento = dtFechaVencimiento.Value,
                    nIdInventario = Convert.ToInt32(frmInventarioDetalle.lblCodigo.Text),
                    nIdProducto = producto.nIdProducto,
                    fPrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text),
                    fPrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text),
                    sLote = txtLote.Text.ToUpper(),
                    bTipoMovimiento = true,
                    nIdAlmacen = Funciones.CodAlmacenActual(),
                    dFecha = Convert.ToDateTime(frmInventarioDetalle.lblInicio.Text),
                    nSubTipo = 1,
                    nEntrada = (int)ndStock.Value,
                    nExistencia = (int)ndStock.Value,
                    fCostoUnitario = Convert.ToDecimal(txtPrecioVenta.Text),
                    bEstado = Convert.ToBoolean(chkFechaVencimiento.CheckState),
                    sIdLote = txtLote.Text.Trim()
                };

                int resp = 0;

                resp = objInventarioDetalleNeg.ActualizarInventarioDetalle(objInventarioDetalle);
                
                if (resp > 0)
                {
                    MessageBox.Show("El producto Se Logró Insertar Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmInventarioDetalle.CargarInventario();
                    cerrarFormulario = true;
                }
                else
                {
                    MessageBox.Show("El producto No Se Pudo Registrar Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cerrarFormulario = false;
                }

            }
            else
            {
                MessageBox.Show("El precio de venta no puede ser menor que el precio de compra.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cerrarFormulario = false;
            }
        }

        private bool VerificarDatos()
        {
            bool resp = true;

            if (dtFechaVencimiento.Value.Date<DateTime.Now.Date)
            {
                MessageBox.Show("La Fecha de Vencimiento del Producto no puede ser menor que la fecha actual.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtPrecioVenta.Text.Equals(""))
            {
                MessageBox.Show("El precio de venta no puede ser vacío", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (Convert.ToDecimal(txtPrecioVenta.Text)==0)
            {
                MessageBox.Show("El precio de venta no puede ser cero", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (txtPrecioCompra.Text.Equals(""))
            {
                MessageBox.Show("El precio de compra no puede ser vacío", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (Convert.ToDecimal(txtPrecioCompra.Text) == 0)
            {
                MessageBox.Show("El precio de compra no puede ser cero", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (ndStock.Value == 0)
            {
                MessageBox.Show("El Stock no puede ser cero", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
           
            return resp;
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e, txtPrecioCompra);
        }

        private void txtPrecioVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtPrecioVenta.Focus();
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e, txtPrecioVenta);
        }

        private void chkFechaVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(chkFechaVencimiento.CheckState) == true || Convert.ToInt32(chkFechaVencimiento.CheckState) == 1)
            {
                dtFechaVencimiento.Enabled = false;
                txtLote.Enabled = false;
                txtPrecioCompra.Focus();
            }
            else
            {
                dtFechaVencimiento.Enabled = true;
                txtLote.Enabled = true;
                dtFechaVencimiento.Focus();
            }
        }
    }
}


