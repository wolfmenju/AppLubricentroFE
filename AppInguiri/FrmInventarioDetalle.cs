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
using Microsoft.VisualBasic;
using Comun;

namespace AppInguiri
{
    public partial class FrmInventarioDetalle : Form
    {
        #region Variables Privadas
        private InventarioNegocio objInventNeg = new InventarioNegocio();
        public static FrmInventarioDetalle frmInstance = null;
        private ProductoNegocio objProducNeg = new ProductoNegocio();
        List<Producto> listProducto = null;

        #endregion

        #region Principal Load

        //Singleton
        public static FrmInventarioDetalle Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmInventarioDetalle();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmInventarioDetalle()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            if (dgvInventarioDetalle.RowCount > 0)
            {
                if (dgvInventarioDetalle.CurrentCell != null || dgvInventarioDetalle.CurrentCell.RowIndex != 0)
                {
                    Producto _producto = (Producto)dgvInventarioDetalle.CurrentRow.DataBoundItem;
                    FrmInventarioProducto frmInventarioProducto = new FrmInventarioProducto(_producto);
                    frmInventarioProducto.frmInventarioDetalle = this;
                    frmInventarioProducto.ShowDialog();
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            if (dgvInventarioDetalle.Rows.Count == 0) return;

            string itemporiaBuscar = Interaction.InputBox("", "Buscar Producto...");

            if (!itemporiaBuscar.Equals(""))
            {
                List<Producto> dt = new List<Producto>();

                foreach (Producto col in listProducto)
                {

                    if (col.sDescripcion.Contains(itemporiaBuscar))
                    {
                        dt.Add(col);
                    }
                }

                if (dt.Count > 0)
                {
                    dgvInventarioDetalle.DataSource = dt;
                }
                else
                {
                    dgvInventarioDetalle.DataSource = null;
                }
            }
            else
            {
                dgvInventarioDetalle.DataSource = listProducto;
            }
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarInventario();
        }
        
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        #endregion

        #region Metodo Privados
        
        #endregion

        private void FrmInventarioDetalle_Load(object sender, EventArgs e)
        {
            CargarInventario();
        }
        
        public void CargarInventario()
        {
            Producto objProducto = new Producto();
            objProducto.bEstado = true;
            objProducto.nTipo = 4;
            objProducto.nIdLaboratorio = Convert.ToInt32(lblCodigo.Text);

            listProducto = new List<Producto>();
            listProducto = objProducNeg.ListarProducto(objProducto);

            if (listProducto.Count() > 0)
            {
                dgvInventarioDetalle.AutoGenerateColumns = false;
                dgvInventarioDetalle.DataSource = listProducto;
                LblTotal.Text = "Se Encontraron " + dgvInventarioDetalle.Rows.Count + " Registros";
            }
            else
            {
                dgvInventarioDetalle.DataSource = null;
            }
        }

        private void FrmInventarioDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnModificar_Click(sender, e);
                    break;
                case Keys.F2:
                    BtnRefrescar_Click(sender, e);
                    break;
                case Keys.F3:
                    BtnBuscar_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    this.Dispose();
                    break;
            }
        }
        
    }
}
