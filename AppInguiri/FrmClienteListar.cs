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
    public partial class FrmClienteListar : DevExpress.XtraEditors.XtraForm
    {
        public Cliente _cliente;

        ClienteNegocio objClieNeg = new ClienteNegocio();
        List<Cliente> listCliente = new List<Cliente>();
        bool estado = true;

        public FrmClienteListar()
        {
            InitializeComponent();
        }

        #region Principal Load

        #endregion

        private void FrmClienteListar_Load(object sender, EventArgs e)
        {
            CargarCliente();
        }

        private void CargarCliente()
        {
            listCliente.Clear();
            Cliente objCliente = new Cliente() {nTipo=5,bEstado=true };
            listCliente = objClieNeg.ListarCliente(objCliente);

            if (listCliente.Count() > 0)
            {
                DgvCliente.AutoGenerateColumns = false;
                DgvCliente.DataSource = listCliente;
                LblTotal.Text = "Se Encontraron " + DgvCliente.Rows.Count + " Registros";
            }
            else
            {
                DgvCliente.DataSource = null;
            }

        }

        //Lo cree desde el diseñador
        private void txtDescripcion_GotFocus(object sender, EventArgs e)
        {
            txtRuc.Clear();
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BusquedaProveedor(true);
            }
            else if (e.KeyCode == Keys.Down && DgvCliente.RowCount > 0)
            {
                DgvCliente.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BusquedaProveedor(false);
            }
            else if (e.KeyCode == Keys.Down && DgvCliente.RowCount > 0)
            {
                DgvCliente.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void BusquedaProveedor(bool xTipo)
        {
            if (!txtDescripcion.Text.Equals("") || !txtRuc.Text.Equals(""))
            {
                if (DgvCliente.Rows.Count == 0) return;

                List<Cliente> dt = new List<Cliente>();

                foreach (Cliente col in listCliente)
                {
                    if (xTipo)
                    {
                        if (col.sNombres.Contains(txtDescripcion.Text.ToUpper()))
                        {
                            dt.Add(col);
                        }
                    }
                    else
                    {
                        if (col.sNumeroDoc.Contains(txtRuc.Text.ToUpper()))
                        {
                            dt.Add(col);
                        }
                    }
                }
                if (dt.Count > 0)
                {
                    DgvCliente.DataSource = dt;
                }
                else
                {
                    DgvCliente.DataSource = null;
                }
            }
            else
            {
                DgvCliente.DataSource = listCliente;
            }
        }

        private void DgvCliente_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarCliente();
        }
        
        private void SeleccionarCliente()
        {
            if (DgvCliente.Rows.Count == 0) return;

            if (DgvCliente.CurrentCell != null || DgvCliente.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = DgvCliente.CurrentCell.RowIndex;
                DataGridViewRow row2 = DgvCliente.Rows[filaselecionada];
                Cliente cliente = (Cliente)row2.DataBoundItem;
                _cliente = cliente;
                this.Close();
            }
        }

        private void FrmClienteListar_KeyDown(object sender, KeyEventArgs e)
        {
            if (DgvCliente.RowCount == 0) return;

            switch (e.KeyCode)
            {
                case Keys.Space:
                    SeleccionarCliente();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            FrmClienteActualiza frmClienteActualiza = new FrmClienteActualiza();
            frmClienteActualiza.Text = "Registrar Cliente";
            frmClienteActualiza.ShowDialog();
        }
    }
}