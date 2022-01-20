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
    public partial class FrmActualizarPrecio : DevExpress.XtraEditors.XtraForm
    {
        private static FrmActualizarPrecio frmInstance = null;
        ProductoNegocio objProducNeg = new ProductoNegocio();
        ProductoHistorialNegocio objProdHistNeg = new ProductoHistorialNegocio();
        bool? xBandero = false;
        List<Producto> ListProducto = new List<Producto>();
        List<ProductoHistorial> ListProdHistorial = new List<ProductoHistorial>();

        //Singleton
        public static FrmActualizarPrecio Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmActualizarPrecio();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }
        
        public FrmActualizarPrecio()
        {
            InitializeComponent();
        }

        private void FrmActualizarPrecio_Load(object sender, EventArgs e)
        {
            cboTipoProducto.SelectedIndex = 0;
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvProducto.Rows.Count > 0 && e.KeyCode == Keys.Down)
            {
                dgvProducto.Focus();
            }
            else if( e.KeyCode == Keys.Enter)
            {
                if (txtDescripcion.Text.Trim().Length > 0) CargarProductos();
            }
        }
        
        private void CargarProductos()
        {
            ListProducto.Clear();
            dgvProducto.DataSource = null;

            Producto objPro = new Producto()
            {
                nTipo = 9,
                nIdProducto = Funciones.CodAlmacenActual(),
                sPrincipioActivo = txtDescripcion.Text.Trim(),
                bEstado = cboTipoProducto.SelectedIndex == 0 ? true : false
            };

            ListProducto=objProducNeg.ListarProducto(objPro);

            if (ListProducto.Count > 0)
            {
                dgvProducto.AutoGenerateColumns = false;
                dgvProducto.DataSource = ListProducto;  
            }

            lblTotal.Text = "Se Encontraron " + dgvProducto.Rows.Count + " Registros";
        }

        //Lo cree desde el diseñador
        private void txtDescripcion_GotFocus(object sender, EventArgs e)
        {
            txtDescripcion.BackColor = Color.Yellow;
        }


        public void Buscar()
        {
           
        }

        private void FrmActualizarPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    CambioFicha();
                    break;
                case Keys.F2:
                    CambiaPrecio();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (TabControl.SelectedIndex == 0)
            {
                xBandero = true;
                TabControl.SelectedTab = TabMedicamento;
                lblTotal.Text = "Se Encontraron " + dgvLotes.Rows.Count + " Registros";
                xBandero = false;
                return;
            }

            if (xBandero==true) e.Cancel = false;
            else if (xBandero == false) e.Cancel = true;
        }
        
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            CambioFicha();
        }

        private void dgvProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvProducto.RowCount > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (dgvProducto.CurrentRow.Index == 0) txtDescripcion.Focus();

                        break;
                }
            }
        }

        private void CambioFicha()
        {
            if (TabControl.SelectedIndex == 0)
            {
                if (dgvProducto.RowCount > 0)
                {
                    xBandero = true;
                    TabControl.SelectedTab = TabDetalle;
                    xBandero = false;
                    Producto _prod=(Producto) dgvProducto.CurrentRow.DataBoundItem;
                    lblNombre.Text = _prod.sDescripcion + " " + _prod.sLaboratorio + " " + _prod.sPrincipioActivo;
                    CargarDetalles(_prod.nIdProducto);
                }
            }
        }

        int nidProducto = 0;

        public void CargarDetalles(int nIdProd)
        {
            if (dgvProducto.RowCount > 0)
            {
                ListProdHistorial.Clear();
                ProductoHistorial objProHis = new ProductoHistorial()
                {
                    nTipo = 2,
                    nIdAlmacen = Funciones.CodAlmacenActual(),
                    nIdProducto= nIdProd,
                    bEstado=true
                };

                ListProdHistorial=objProdHistNeg.ListarProductoHistorial(objProHis);

                if (ListProdHistorial.Count > 0)
                {
                    dgvLotes.AutoGenerateColumns = false;
                    dgvLotes.DataSource = ListProdHistorial;
                    nidProducto = nIdProd;
                }
                else
                {
                    dgvLotes.DataSource = null;
                    nidProducto = 0;
                }

                lblTotal.Text = "Se Encontraron " + dgvLotes.Rows.Count + " Registros";
            }
        }

        private void cboTipoProducto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDescripcion.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CambiaPrecio();
        }

        private void CambiaPrecio()
        {
            if (TabControl.SelectedIndex == 1)
            {
                if (dgvProducto.RowCount > 0)
                {
                    if (dgvLotes.RowCount > 0)
                    {
                        ProductoHistorial _ProductoHistorial = (ProductoHistorial)dgvLotes.CurrentRow.DataBoundItem;
                        _ProductoHistorial.nIdProducto = nidProducto;
                        FrmActualizaDato frmActualizaDato = new FrmActualizaDato(_ProductoHistorial);
                        frmActualizaDato.frmActualizarPrecio = this;
                        frmActualizaDato.txtLote.Text = _ProductoHistorial.sLote;
                        frmActualizaDato.txtVenta.Text = _ProductoHistorial.fPrecioVenta.ToString();
                        frmActualizaDato.txtCompra.Text = _ProductoHistorial.fPrecioCompra.ToString();
                        frmActualizaDato.chkVencimiento.Checked =frmActualizaDato.txtLote.Text.Trim()=="" ? true : false;
                        frmActualizaDato.ShowDialog();
                        frmActualizaDato.Focus();
                    }
                }
            }
        }
    }
}