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
    public partial class FrmActualizaDato : Form
    {
        ProductoHistorialNegocio objProdHistNeg = new ProductoHistorialNegocio();
        private bool cerrarFormulario = true;
        ProductoHistorial _productoHistorial;
        public FrmActualizarPrecio frmActualizarPrecio;

        public int xTipo = 0;

        public FrmActualizaDato( ProductoHistorial productoHistorial)
        {
            InitializeComponent();
            _productoHistorial = productoHistorial;
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            GuardaTodo();
        }

        private void txtLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCompra.Focus();
            }
        }

        private void txtVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVenta.Focus();
            }
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e, txtVenta);
        }

        private void txtCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GuardaTodo();
            }
        }

        private void GuardaTodo()
        {
            if (!ValidarDatos()) return;

            int resp = 0;
            ProductoHistorial objProdHis = new ProductoHistorial();

            objProdHis.nTipo = 16;
            objProdHis.dFechaVencimiento = dtFechaVen.Value;
            objProdHis.nIdProducto = _productoHistorial.nIdProducto;
            objProdHis.nIdAlmacen = Funciones.CodAlmacenActual();
            objProdHis.nIdProductoHistorial = _productoHistorial.nIdProductoHistorial;
            objProdHis.fPrecioVenta = Convert.ToDecimal(txtVenta.Text);
            objProdHis.fPrecioCompra = Convert.ToDecimal(txtCompra.Text);
            objProdHis.sLote = txtLote.Text.Trim();

            objProdHis.sUsuario = Funciones.UsuarioActual();

            resp = objProdHistNeg.ActualizarProductoHistorial(objProdHis);

            if (resp > 0)
            {

                MessageBox.Show("Los Precios Se Lograron Actualizar Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmActualizarPrecio.CargarDetalles(objProdHis.nIdProducto);

                cerrarFormulario = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Los Datos No Se Lograron Insertar Correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cerrarFormulario = false;
            }
        }

        private bool ValidarDatos()
        {
            if (txtLote.Text.Equals(""))
            {
                MessageBox.Show("El campo Lote se encuentra vacía.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLote.Focus();
                cerrarFormulario = false;
                return false;
            }

            if (txtVenta.Text.Equals(""))
            {
                MessageBox.Show("El campo Venta se encuentra vacía.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVenta.Focus();
                cerrarFormulario = false;
                return false;
            }
            else if (txtCompra.Text.Equals(""))
            {
                MessageBox.Show("El campo Compra se encuentra vacía.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompra.Focus();
                cerrarFormulario = false;
                return false;
            }

            cerrarFormulario = true;
            return true;
        }

        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e, txtCompra);
        }
        
        private void dtFechaVen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtLote.Focus();
        }

        private void chkVencimiento_CheckedChanged(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void Seleccionar()
        {
            if (Convert.ToBoolean(chkVencimiento.CheckState) == true || (int)chkVencimiento.CheckState == 1)
            {
                dtFechaVen.Enabled = false;
                txtLote.Enabled = false;
                txtCompra.Focus();
            }
            else
            {
                dtFechaVen.Enabled = true;
                txtLote.Enabled = true;
                dtFechaVen.Focus();
            }
        }

        private void CmdCancelar_Click(object sender, EventArgs e)
        {
            cerrarFormulario = true;
            this.Close();
        }

        private void FrmActualizaDato_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }
    }
}
