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
    public partial class FrmProductoListado : DevExpress.XtraEditors.XtraForm
    {
        public Producto _producto;

        ProductoNegocio objProducNeg = new ProductoNegocio();
        List<Producto> ListProducto = new List<Producto>();

        public FrmProductoListado()
        {
            InitializeComponent();
            CargarMaestros();
        }

        
        private void CargarMaestros()
        {
           
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
                nTipo = 8,
                nIdProducto = Funciones.CodAlmacenActual(),
                sPrincipioActivo = txtDescripcion.Text.Trim(),
                bEstado = true
            };

            ListProducto = objProducNeg.ListarProducto(objPro);

            if (ListProducto.Count > 0)
            {
                dgvProducto.AutoGenerateColumns = false;
                dgvProducto.DataSource = ListProducto;
            }
            else
            {
                dgvProducto.DataSource = null;
            }
            
            lblTotal.Text = "Se Encontraron " + dgvProducto.Rows.Count + " Registros";
        }

        //Lo cree desde el diseñador
        private void txtDescripcion_GotFocus(object sender, EventArgs e)
        {
            txtDescripcion.BackColor = Color.Yellow;
        }

        private void FrmProductoListado_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    SeleccionarProducto();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void SeleccionarProducto()
        {
            if ( dgvProducto.Rows.Count == 0) return;

            if (dgvProducto.CurrentCell != null || dgvProducto.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = dgvProducto.CurrentCell.RowIndex;
                DataGridViewRow row2 = dgvProducto.Rows[filaselecionada];
                Producto producto = (Producto)row2.DataBoundItem;
                _producto = producto;
                this.Close();
            }
        }

    }
}