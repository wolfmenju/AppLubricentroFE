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
    public partial class FrmProveedorListar : DevExpress.XtraEditors.XtraForm
    {
        public Proveedor _proveedor;
        
        ProveedorNegocio objProveeNeg = new ProveedorNegocio();
        List<Proveedor> listProveedor = new List<Proveedor>();
        bool estado = true;

        public FrmProveedorListar()
        {
            InitializeComponent();
        }

        #region Principal Load

        #endregion

 
        private void FrmProveedorListar_Load(object sender, EventArgs e)
        {
            CargarProveedor();
        }

        private void CargarProveedor()
        {
            listProveedor.Clear();
            listProveedor = objProveeNeg.ListarProveedor(estado);

            if (listProveedor.Count() > 0)
            {
                DgvProveedor.AutoGenerateColumns = false;
                DgvProveedor.DataSource = listProveedor;
                LblTotal.Text = "Se Encontraron " + DgvProveedor.Rows.Count + " Registros";
            }
            else
            {
                DgvProveedor.DataSource = null;
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
            else if (e.KeyCode == Keys.Down && DgvProveedor.RowCount > 0)
            {
                DgvProveedor.Focus();
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
            else if (e.KeyCode == Keys.Down && DgvProveedor.RowCount > 0)
            {
                DgvProveedor.Focus();
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
                if (DgvProveedor.Rows.Count == 0) return;

                List<Proveedor> dt = new List<Proveedor>();

                foreach (Proveedor col in listProveedor)
                {
                    if (xTipo)
                    {
                        if (col.sRazonSocial.Contains(txtDescripcion.Text.ToUpper()))
                        {
                            dt.Add(col);
                        }
                    }
                    else
                    {
                        if (col.sRuc.Contains(txtRuc.Text.ToUpper()))
                        {
                            dt.Add(col);
                        }
                    }
                }
                if (dt.Count > 0)
                {
                    DgvProveedor.DataSource = dt;
                }
                else
                {
                    DgvProveedor.DataSource = null;
                }
            }
            else
            {
                DgvProveedor.DataSource = listProveedor;
            }
        }

        private void DgvProveedor_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarProveedor();
        }

        private void SeleccionarProveedor()
        {
            if (DgvProveedor.Rows.Count == 0) return;

            if (DgvProveedor.CurrentCell != null || DgvProveedor.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = DgvProveedor.CurrentCell.RowIndex;
                DataGridViewRow row2 = DgvProveedor.Rows[filaselecionada];
                Proveedor proveedor = (Proveedor)row2.DataBoundItem;
                _proveedor = proveedor;
                this.Close();
            }
        }

        private void FrmProveedorListar_KeyDown(object sender, KeyEventArgs e)
        {
            if (DgvProveedor.RowCount == 0) return;

            switch (e.KeyCode)
            {
                case Keys.Space:
                    SeleccionarProveedor();
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
            FrmProveedorActualiza frmProveedorActualiza = new FrmProveedorActualiza();
            frmProveedorActualiza.Text = "Registrar Proveedor";
            frmProveedorActualiza.ShowDialog();
        }
    }
}