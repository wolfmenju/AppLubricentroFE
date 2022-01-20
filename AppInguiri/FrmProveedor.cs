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
    public partial class FrmProveedor : DevExpress.XtraEditors.XtraForm
    {
        private static FrmProveedor frmInstance = null;
        ProveedorNegocio objProveeNeg = new ProveedorNegocio();
        List<Proveedor> listProveedor = new List<Proveedor>();
        bool estado = true;

        //Singleton
        public static FrmProveedor Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmProveedor();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmProveedor()
        {
            InitializeComponent();
        }

        #region Principal Load

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedor();
        }

        #endregion


        #region Metodo Privados
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

        #endregion


        private void FrmProveedor_KeyDown(object sender, KeyEventArgs e)
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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            FrmProveedorActualiza frmProveedor = new FrmProveedorActualiza();
            frmProveedor.Text = "Registar Proveedor";

            if (frmProveedor.ShowDialog() == DialogResult.OK)
            {
                CargarProveedor();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            if (DgvProveedor.Rows.Count == 0) return;

            if (DgvProveedor.CurrentCell != null || DgvProveedor.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = DgvProveedor.CurrentCell.RowIndex;
                DataGridViewRow row2 = DgvProveedor.Rows[filaselecionada];
                Proveedor proveedor = (Proveedor)row2.DataBoundItem;

                FrmProveedorActualiza frmProveedor = new FrmProveedorActualiza(proveedor);
                frmProveedor.tipo = 1;
                frmProveedor.Text = "Actualizar Proveedor";

                if (frmProveedor.ShowDialog() == DialogResult.OK)
                {
                    CargarProveedor();
                }
            }
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarProveedor();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            if (DgvProveedor.Rows.Count == 0) return;

            string proveedorporiaBuscar = Interaction.InputBox("", "Buscar Proveedor...");

            if (!proveedorporiaBuscar.Equals(""))
            {
                List<Proveedor> dt = new List<Proveedor>();
                foreach (Proveedor col in listProveedor)
                {

                    if (col.sRazonSocial.Contains(proveedorporiaBuscar.ToUpper()))
                    {
                        dt.Add(col);
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvProveedor.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idProveeSele = Convert.ToInt32(DgvProveedor.CurrentRow.Cells[0].Value);

                    Proveedor objProvee = new Proveedor()
                    {
                        nIdProveedor = idProveeSele,
                        bEstado = estado,
                        sUsuario = Funciones.UsuarioActual()
                    };

                    respuesta = objProveeNeg.EliminarActivarProveedor(objProvee);

                    if (respuesta == 1)
                    {
                        if (estado)
                        {
                            estado = false;
                            MessageBox.Show("Se Activó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            estado = true;
                            MessageBox.Show("Se Eliminó Correctamente", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        CargarProveedor();
                    }
                }
                else
                {
                    if (estado) { estado = false; }
                    else { estado = true; }
                }
            }
            else
            {
                if (estado)
                {
                    MessageBox.Show("No se registran Proveedor para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("No se registran Proveedor para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkTodos_CheckedChanged(object sender, EventArgs e)
        {
            estado = ChkTodos.Checked;

            if (ChkTodos.Checked)
            {
                BtnEliminar.Image = Properties.Resources.X;
                BtnEliminar.Text = "&Eliminar  [F5]";
            }
            else
            {
                BtnEliminar.Image = Properties.Resources.xActivar;
                BtnEliminar.Text = "&Activar  [F5]";
            }

            CargarProveedor();
        }
    }
}