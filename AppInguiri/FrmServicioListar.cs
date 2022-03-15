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
    public partial class FrmServicioListar : DevExpress.XtraEditors.XtraForm
    {
        public Servicio _servicio;
        public FrmVenta frmVenta = null;
        public int xTipo = 0;

        private ServicioNegocio objServicNeg = new ServicioNegocio();
        private List<Servicio> ListServicio = null;

        public FrmServicioListar()
        {
            InitializeComponent();
        }
        
        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvServicio.Rows.Count > 0 && e.KeyCode == Keys.Down)
            {
                dgvServicio.Focus();
            }
            else if( e.KeyCode == Keys.Enter)
            {
                if (txtDescripcion.Text.Trim().Length > 0) CargarServicios();
            }
        }
        
        private void CargarServicios()
        {
            ListServicio = new List<Servicio>();

            if (xTipo == 0)
            {
                Servicio objServic = new Servicio()
                {
                    nTipo = 5,
                    sUsuario = txtDescripcion.Text.Trim(),
                    bEstado = true
                };

                ListServicio = objServicNeg.ListarServicio(objServic);

                if (ListServicio.Count > 0)
                {
                    dgvServicio.AutoGenerateColumns = false;
                    dgvServicio.DataSource = ListServicio;
                }
                else
                {
                    dgvServicio.DataSource = null;
                }
            }
            else
            {
                Int32 filaselecionada = frmVenta.dgvProducto.CurrentCell.RowIndex;
                Servicio objServic = new Servicio()  { nTipo = 6};
                objServic.nIdServicio = Convert.ToInt32(frmVenta.dgvProducto.Rows[filaselecionada].Cells["nIdProducto"].Value);

                ListServicio = objServicNeg.ListarServicio(objServic);

                if (ListServicio.Count() > 0)
                {
                    dgvServicio.AutoGenerateColumns = false;
                    dgvServicio.DataSource = ListServicio;
                    NdCantidad.Text = Convert.ToString(frmVenta.dgvProducto.Rows[filaselecionada].Cells["nCantidad"].Value);
                }
                else
                {
                    dgvServicio.DataSource = null;
                }
            }
            
            lblTotal.Text = "Se Encontraron " + dgvServicio.Rows.Count + " Registros";
        }

        //Lo cree desde el diseñador
        private void txtDescripcion_GotFocus(object sender, EventArgs e)
        {
            txtDescripcion.BackColor = Color.Yellow;
        }

        private void FrmServicioListar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    SeleccionarServicio();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void SeleccionarServicio()
        {
            if ( dgvServicio.Rows.Count == 0) return;

            if (dgvServicio.CurrentCell != null || dgvServicio.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = dgvServicio.CurrentCell.RowIndex;
                DataGridViewRow row2 = dgvServicio.Rows[filaselecionada];
                Servicio servicio = (Servicio)row2.DataBoundItem;
                LblCompra.Text = servicio.fPrecio.ToString();
                NdCantidad.Text = "1";
            }

            Calculo();
        }

        private void Calculo()
        {
            decimal fVuelto = 0.0M;

            if (dgvServicio.Rows.Count == 0) return;

            if (dgvServicio.CurrentCell != null || dgvServicio.CurrentCell.RowIndex != 0)
            {
                if (NdCantidad.Text.Equals("") || NdCantidad.Text.Equals("\r\n"))
                {
                    fVuelto = 0 * Convert.ToDecimal(LblCompra.Text);
                }
                else
                {
                    if (NdCantidad.Text.Trim().Equals("")) NdCantidad.Text = "0";
                    fVuelto = Convert.ToInt32(NdCantidad.Text) * Convert.ToDecimal(LblCompra.Text);

                }
            }

            LblMonto.Text = fVuelto.ToString("C");
        }

        private void NdCantidad_TextChanged(object sender, EventArgs e)
        {
            Calculo();
        }

        private void NdCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroEntero(e, NdCantidad);
        }

        private void NdCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (NdCantidad.Text.Length == 0) return;

            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(NdCantidad.Text) > 0)
                //if (!txtCompra.Enabled && !txtVenta.Enabled && !txtLote.Enabled && !dtVencimiento.Enabled && Convert.ToInt32(NdCantidad.Text) > 0)
                {
                    AgregarProducto();
                }
                else
                {
                    MessageBox.Show("La cantidad del Servicio no puede puede ser cero (0).", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void AgregarProducto()
        {
            if (dgvServicio.Rows.Count == 0) return;

            if (dgvServicio.CurrentCell != null || dgvServicio.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = dgvServicio.CurrentCell.RowIndex;
                DataGridViewRow row2 = dgvServicio.Rows[filaselecionada];
                Servicio servicio = (Servicio)row2.DataBoundItem;

                if (xTipo == 1)
                {
                    if (frmVenta != null)
                    {
                        Int32 filaselecionada3 = frmVenta.dgvProducto.CurrentCell.RowIndex;
                        frmVenta.dgvProducto.Rows[filaselecionada3].Cells["nCorrelativo"].Value = 0;
                        frmVenta.dgvProducto.Rows[filaselecionada3].Cells["nIdMovimiento"].Value = 0;
                        frmVenta.dgvProducto.Rows[filaselecionada3].Cells["sLote"].Value = "";
                        frmVenta.dgvProducto.Rows[filaselecionada3].Cells["Vencimiento"].Value = Globales.FechaActual();
                        frmVenta.dgvProducto.Rows[filaselecionada3].Cells["nCantidad"].Value = NdCantidad.Text;
                        frmVenta.dgvProducto.Rows[filaselecionada3].Cells["fPrecioVenta"].Value = servicio.fPrecio;
                        frmVenta.dgvProducto.Rows[filaselecionada3].Cells["fPrecioCompra"].Value = servicio.fPrecio;
                        frmVenta.dgvProducto.Rows[filaselecionada3].Cells["fGanancia"].Value = servicio.fPrecio - servicio.fPrecio;
                        frmVenta.dgvProducto.Rows[filaselecionada3].Cells["fSubTotal"].Value = Convert.ToInt32(NdCantidad.Text) * servicio.fPrecio;
                        frmVenta.dgvProducto.Rows[filaselecionada3].Cells["fDescuento"].Value = 0.00;
                        frmVenta.dgvProducto.Refresh();
                    }

                }
                else
                {
                    if (frmVenta != null)
                    {
                        frmVenta.dgvProducto.Rows.Add(0, 0, servicio.nIdServicio, servicio.sDescripcion,
                          "", Globales.FechaActual(), Convert.ToInt32(NdCantidad.Text), servicio.fPrecio, servicio.fPrecio - servicio.fPrecio, servicio.fPrecio,
                          Convert.ToInt32(NdCantidad.Text) * Convert.ToDecimal(servicio.fPrecio), true, 0);
                    }
                }

                this.Close();
            }
        }

        private void dgvServicio_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServicio.RowCount > 0) SeleccionarServicio();
        }

        private void dgvServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (dgvServicio.RowCount > 0)
                {
                    NdCantidad.Focus();
                }
            }
        }

        private void FrmServicioListar_Load(object sender, EventArgs e)
        {
            if (xTipo == 1)
            {
                txtDescripcion.Enabled = false;
                CargarServicios();
            }
        }
    }
}