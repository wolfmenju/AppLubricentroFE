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
    public partial class FrmPago : Form
    {
        public int tipo=0;
        public string descripcion = "";
        public string direccion = "";
        public FrmVenta frmVenta = null;
        
        public FrmPago()
        {
            InitializeComponent();
        }

        private void FrmPago_Load(object sender, EventArgs e)
        {

        }


        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Verifica();
        }

        private void Verifica()
        {
            if ( Convert.ToDecimal(lblVuelto.Text.Replace("S/","")) >= 0)
            {
                frmVenta.GuardarVentaTodo();
                this.Close();
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
            fTotal = Convert.ToDecimal(lblTotal.Text);
            if (txtPago.Text.Trim().Equals("")) txtPago.Text = "0";
            fPago = Convert.ToDecimal(txtPago.Text.Trim());

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
    }
}
