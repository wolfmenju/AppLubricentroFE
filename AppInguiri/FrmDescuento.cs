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
    public partial class FrmDescuento : Form
    {
        
        public FrmVenta frmVenta = null;

        private bool cerrarFormulario = true;

        public FrmDescuento()
        {
            InitializeComponent();
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void Calcular()
        {
            if (txtPago.Text.Equals("") || txtPago.Text.Equals("\r\n")) return;

            decimal fTotal = 0.0M, fPago = 0.0M, fVuelto = 0.0M;
            fTotal = Convert.ToDecimal(lblTotal.Text);
            if (txtPago.Text.Trim().Equals("")) txtPago.Text = "0";
            fPago = Convert.ToDecimal(txtPago.Text.Trim());

            if ((fPago - fTotal) >= 0)
            {
                Label5.Text = "Vuelto";
                fVuelto = fPago - fTotal;
            }
            else
            {
                Label5.Text = "Falta";
                fVuelto = (fPago - fTotal) * -1;
            }

            lblVuelto.Text = fVuelto.ToString("C");
        }

        private void Verifica()
        {
            if (Convert.ToDecimal(lblVuelto.Text.Replace("S/", "")) >= 0)
            {
                if (Convert.ToDecimal(txtPago.Text.Trim()) < Convert.ToDecimal(lblTotal.Text))
                {
                    Int32 filaselecionada = frmVenta.dgvProducto.CurrentCell.RowIndex;
                    frmVenta.dgvProducto.Rows[filaselecionada].Cells["fDescuento"].Value =Convert.ToDecimal(txtPago.Text.Trim()).ToString("C");
                    //frmVenta.dgvProducto.Rows[filaselecionada].Cells["fSubTotal"].Value =Convert.ToDecimal(frmVenta.dgvProducto.Rows[filaselecionada].Cells["fSubTotal"].Value) - Convert.ToDecimal(txtPago.Text.Trim());

                    frmVenta.dgvProducto.Refresh();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No Se Puede Aplicar Un Descuento Mayor Al Precio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPago.Text = txtPago.Text.Trim();
                    txtPago.Focus();
                }
            }
            else
            {
                MessageBox.Show("Falta " + Label5.Text, "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPago.Focus();
            }
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarNumeroDecimal(e, txtPago);
        }

        private void FrmDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Verifica();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;

            }
        }
    }
}
