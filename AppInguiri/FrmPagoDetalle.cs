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
    public partial class FrmPagoDetalle : Form
    {
        public int tipo=0;
        public string descripcion = "";
        public string direccion = "";
        public FrmVenta frmVenta = null;
        private MedioPagoNegocio objMedPagoNeg = new MedioPagoNegocio();
        private List<MedioPago> ListMedPago = new List<MedioPago>();
        private List<MedioPago> list = new List<MedioPago>();
        private decimal fTotal = 0;
        private bool cerrarFormulario = true;

        public FrmPagoDetalle()
        {
            InitializeComponent();
            CargarMaestros();
        }

        private void CargarMaestros()
        {
            ListMedPago = objMedPagoNeg.ListarMedioPago(true);
            
            cbxTipoMedioPago.ValueMember = "nIdMedioPago";
            cbxTipoMedioPago.DisplayMember = "sDescripcion";
            cbxTipoMedioPago.DataSource = ListMedPago;

            cbxTipoMedioPago.SelectedIndex = 0;

            foreach (var item in ListMedPago)
            {
                list.Add(item);
            }
        }

        private void FrmPagoDetalle_Load(object sender, EventArgs e)
        {
            txtMonto.Focus();
        }
        
        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Verifica();
        }

        private void Verifica()
        {
            if ( Convert.ToDecimal(lblVuelto.Text.Replace("S/","")) >= 0)
            {
                if (MessageBox.Show("¿Esta Segudo que Desea Generar La Venta?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                    this.Dispose();
                    frmVenta.GuardarVentaTodo();
                }
                else
                {
                    cerrarFormulario = false;
                }
            }
            else
            {
                MessageBox.Show("Falta " + label5.Text, "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPago.Focus();
            }
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
       {
            Funciones.ValidarNumeroDecimal(e, txtPago);
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void Calcular()
        {
            if (txtPago.Text.Equals("") || txtPago.Text.Equals("\r\n")) return;

            decimal fTotal = 0.0M, fPago = 0.0M, fVuelto = 0.0M;
            fTotal = Convert.ToDecimal(lblTotal.Text.Replace("S/", ""));
            if (txtPago.Text.Trim().Equals("")) txtPago.Text = "0";
            fPago = Convert.ToDecimal(txtPago.Text.Replace("S/", ""));

            if ((fPago - fTotal) >= 0)
            {
                label5.Text = "Vuelto";
                fVuelto = fPago - fTotal;
            }
            else
            {
                label5.Text = "Falta";
                fVuelto = (fPago - fTotal) * -1;
            }

            lblVuelto.Text = fVuelto.ToString("C");
        }

        private void FrmPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cbxTipoMedioPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtMonto.Focus();
            txtMonto.Clear();
        }

        private void AgregarMetodoPago()
        {
            if (txtMonto.Text.Length == 0 || Convert.ToDecimal(txtMonto.Text) == 0)
            {
                MessageBox.Show("El Monto Ingresado de ser mayor que Cero (0).", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MedioPago medioPago = (MedioPago)cbxTipoMedioPago.SelectedItem;

            dgvMedioPagos.Rows.Add(medioPago.nIdMedioPago, medioPago.sDescripcion,decimal.Round(Convert.ToDecimal(txtMonto.Text),2));
            fTotal = 0;

            if (dgvMedioPagos.RowCount > 0)
            {
                foreach (DataGridViewRow item2 in dgvMedioPagos.Rows)
                {
                    fTotal = fTotal + (Convert.ToDecimal(item2.Cells["fMonto"].Value));
                }
            }

            dgvMedioPagos.Refresh();

            foreach (var item in ListMedPago)
            {
                if (item.nIdMedioPago == medioPago.nIdMedioPago)
                {
                    list.Remove(item);
                    break;
                }
            }

            if (list.Count > 0)
            {
                list = list.OrderBy(o => o.nIdMedioPago).ToList();

                cbxTipoMedioPago.ValueMember = "nIdMedioPago";
                cbxTipoMedioPago.DisplayMember = "sDescripcion";
                cbxTipoMedioPago.DataSource = list;
                cbxTipoMedioPago.SelectedIndex = 0;
                txtMonto.ReadOnly = false;
                cbxTipoMedioPago.Enabled = true;
                btnAgregar.Enabled = true;
            }
            else
            {
                cbxTipoMedioPago.DataSource = null;
                list.Clear();
                txtMonto.ReadOnly = true;
                cbxTipoMedioPago.Enabled = false;
                btnAgregar.Enabled = false;
            }

            txtPago.Text = fTotal.ToString("C");
            txtMonto.Clear();
            cbxTipoMedioPago.Refresh();

            if (txtPago.Text == lblTotal.Text)
            {
                txtMonto.ReadOnly = true;
                cbxTipoMedioPago.Enabled = false;
                btnAgregar.Enabled = false;
                CmdGuardar.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarMetodoPago();
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregarMetodoPago();
            }
        }
        
        private void dgvMedioPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMedioPagos.RowCount == 0) return;

            if (dgvMedioPagos.CurrentCell != null || dgvMedioPagos.CurrentCell.RowIndex != 0)
            {
                if (Convert.ToInt32(dgvMedioPagos.CurrentCell.ColumnIndex) == 3 && e.RowIndex != -1)
                {
                    int filaseleccionada = dgvMedioPagos.CurrentCell.RowIndex;
                    DataGridViewRow row = dgvMedioPagos.Rows[filaseleccionada];
                  
                    foreach (var item in ListMedPago)
                    {
                        if (item.nIdMedioPago== Convert.ToInt32(row.Cells["IdMedioPago"].Value))
                        {
                            list.Add(item);
                            break;
                        }
                    }
                    
                    cbxTipoMedioPago.DataSource = null;
                    dgvMedioPagos.Rows.Remove(row);
                    dgvMedioPagos.Refresh();
                    fTotal = 0;

                    if (dgvMedioPagos.RowCount > 0)
                    {
                        foreach (DataGridViewRow item2 in dgvMedioPagos.Rows)
                        {
                            fTotal = fTotal + (Convert.ToDecimal(item2.Cells["fMonto"].Value));
                        }
                    }

                    if (list.Count > 0)
                    {
                        list = list.OrderBy(o => o.nIdMedioPago).ToList();
                        cbxTipoMedioPago.ValueMember = "nIdMedioPago";
                        cbxTipoMedioPago.DisplayMember = "sDescripcion";
                        cbxTipoMedioPago.DataSource = list;
                        cbxTipoMedioPago.SelectedIndex = 0;

                        txtMonto.ReadOnly = false;
                        cbxTipoMedioPago.Enabled = true;
                        btnAgregar.Enabled = true;

                    }
                    else
                    {
                        cbxTipoMedioPago.DataSource = null;
                        list.Clear();

                        txtMonto.ReadOnly = true;
                        cbxTipoMedioPago.Enabled = false;
                        btnAgregar.Enabled = false;
                    }

                    txtPago.Text = fTotal.ToString("C");
                    txtMonto.Clear();
                    cbxTipoMedioPago.Refresh();
                }
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e, txtMonto);
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            GenerarVenta();
        }

        private void GenerarVenta()
        {
            if (dgvMedioPagos.RowCount > 0)
            {
                Verifica();
            }
            else
            {
                MessageBox.Show("Debe Elegir un Medio de Pago.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cerrarFormulario = false;
                return;
            }
        }

        private void FrmPagoDetalle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }
    }
}
