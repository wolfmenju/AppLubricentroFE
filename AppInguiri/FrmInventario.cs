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
    public partial class FrmInventario : Form
    {
        #region Variables Privadas
        private InventarioNegocio objInventNeg = new InventarioNegocio();
        private bool estado = true;
        private static FrmInventario frmInstance = null;
        private static FrmInventarioDetalle frmInventarioDetalle = null;
        private List<Inventario> ListInvetario = null;
        
        #endregion

        #region Principal Load

        //Singleton
        public static FrmInventario Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmInventario();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmInventario()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            FrmInventarioInicial frmInventarioInicial = new FrmInventarioInicial();
            frmInventarioInicial.frmInventario = this;
            frmInventarioInicial.ShowDialog();
            frmInventarioInicial.Focus();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            if (dgvInventario.RowCount > 0)
            {
                if (dgvInventario.CurrentCell != null || dgvInventario.CurrentCell.RowIndex != 0)
                {
                    Inventario _inventario = (Inventario)dgvInventario.CurrentRow.DataBoundItem;

                    if (_inventario.bEstado)
                    {
                        frmInventarioDetalle = FrmInventarioDetalle.Instance();
                        frmInventarioDetalle.MdiParent = frmInstance.MdiParent;
                        frmInventarioDetalle.lblCodigo.Text = _inventario.nIdInventario.ToString();
                        frmInventarioDetalle.LblCodigoAlmacen.Text = _inventario.nIdAlmacen.ToString();
                        frmInventarioDetalle.lblAlmacen.Text = _inventario.sDecripcion;
                        frmInventarioDetalle.lblInicio.Text = _inventario.dFechaInicio.ToString("dd/MM/yyyy");
                        frmInventarioDetalle.Show();
                        frmInventarioDetalle.Focus();
                    }
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            if (dgvInventario.Rows.Count == 0) return;

            string itemporiaBuscar = Interaction.InputBox("", "Buscar Inventario...");

            if (!itemporiaBuscar.Equals(""))
            {
                List<Inventario> dt = new List<Inventario>();
                foreach (Inventario col in ListInvetario)
                {

                    if (col.nItem.ToString().Contains(itemporiaBuscar))
                    {
                        dt.Add(col);
                    }
                }

                if (dt.Count > 0)
                {
                    dgvInventario.DataSource = dt;
                }
                else
                {
                    dgvInventario.DataSource = null;
                }
            }
            else
            {
                dgvInventario.DataSource = ListInvetario;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void Cerrar()
        {
            if (dgvInventario.RowCount > 0)
            {
                if (dgvInventario.CurrentCell != null || dgvInventario.CurrentCell.RowIndex != 0)
                {
                    if (MessageBox.Show("¿Desea Cerrar El Inventario Actual?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Inventario _inventario = (Inventario)dgvInventario.CurrentRow.DataBoundItem;

                        if (_inventario.bEstado)
                        {
                            Inventario objInventario = new Inventario()
                            {
                                nTipo = 3,
                                bEstado = false,
                                nIdInventario = _inventario.nIdInventario,
                                sUsuario = Funciones.UsuarioActual()
                            };

                            int resp = 0;
                            resp = objInventNeg.ActualizarInventario(objInventario);
                            
                            if (resp > 0)
                            {
                                MessageBox.Show("El Inventario Culminó Exitosamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("El Inventario no se Culminó Exitosamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
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

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            CargarInventario();
        }
        
        public void CargarInventario()
        {
            ListInvetario = new List<Inventario>();

            Inventario objInventa = new Inventario()
            {
                nTipo=1,
                bEstado=true
            };

            ListInvetario = objInventNeg.ListarInventario(objInventa);

            if (ListInvetario.Count > 0)
            {
                dgvInventario.AutoGenerateColumns = false;
                dgvInventario.DataSource = ListInvetario;
                LblTotal.Text = "Se Encontraron " + dgvInventario.Rows.Count + " Registros";
            }
            else
            {
                dgvInventario.DataSource = null;
            }
        }

        private void FrmInventario_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    BtnAgregar_Click(sender, e);
                    break;
                case Keys.F2:
                    BtnModificar_Click(sender, e);
                    break;
                case Keys.F3:
                    BtnRefrescar_Click(sender, e);
                    break;
                case Keys.F4:
                    BtnBuscar_Click(sender, e);
                    break;
                case Keys.F5:
                    BtnEliminar_Click(sender, e);
                    break;
            }
        }
    }
}
