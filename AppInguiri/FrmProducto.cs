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
    public partial class FrmProducto : DevExpress.XtraEditors.XtraForm
    {
        private static FrmProducto frmInstance = null;
        ProductoNegocio objProducNeg = new ProductoNegocio();
        public List<Producto> listProducto = new List<Producto>();
        bool estado = true;

        //Singleton
        public static FrmProducto Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmProducto();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmProducto()
        {
            InitializeComponent();
        }

        #region Principal Load

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarProducto();
        }

        #endregion

        #region Metodo Privados
        private void CargarProducto()
        {
            listProducto.Clear();
            Producto objProducto = new Producto();
            objProducto.bEstado = estado;
            objProducto.nTipo = 1;

            listProducto = objProducNeg.ListarProducto(objProducto);

            if (listProducto.Count() > 0)
            {
                DgvProducto.AutoGenerateColumns = false;
                DgvProducto.DataSource = listProducto;
                LblTotal.Text = "Se Encontraron " + DgvProducto.Rows.Count + " Registros";
            }
            else
            {
                DgvProducto.DataSource = null;
            }

        }

        #endregion

        private void FrmProducto_KeyDown(object sender, KeyEventArgs e)
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
            FrmProductoActualiza frmProductoAct = new FrmProductoActualiza();
            frmProductoAct.frmProducto = this;
            frmProductoAct.Text = "Registro Producto";

            if (frmProductoAct.ShowDialog() == DialogResult.OK)
            {
                CargarProducto();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            if (DgvProducto.Rows.Count == 0) return;

            if (DgvProducto.CurrentCell != null || DgvProducto.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = DgvProducto.CurrentCell.RowIndex;
                DataGridViewRow row2 = DgvProducto.Rows[filaselecionada];
                Producto producto = (Producto)row2.DataBoundItem;

                FrmProductoActualiza frmProducto = new FrmProductoActualiza(producto);
                frmProducto.tipo = 1;
                frmProducto.Text = "Actualizar Producto";
                frmProducto.frmProducto = this;

                if (frmProducto.ShowDialog() == DialogResult.OK)
                {
                    CargarProducto();
                }
            }
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarProducto();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            if (DgvProducto.Rows.Count == 0) return;

            string productoporiaBuscar = Interaction.InputBox("", "Buscar Producto...");

            if (!productoporiaBuscar.Equals(""))
            {
                List<Producto> dt = new List<Producto>();
                foreach (Producto col in listProducto)
                {

                    if (col.sDescripcion.Contains(productoporiaBuscar.ToUpper()))
                    {
                        dt.Add(col);
                    }

                }
                if (dt.Count > 0)
                {
                    DgvProducto.DataSource = dt;
                }
                else
                {
                    DgvProducto.DataSource = null;
                }
            }
            else
            {
                DgvProducto.DataSource = listProducto;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvProducto.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idProdSele = Convert.ToInt32(DgvProducto.CurrentRow.Cells[0].Value);

                    Producto objCat = new Producto()
                    {
                        nIdProducto = idProdSele,
                        bEstado = estado,
                        sUsuario = Funciones.UsuarioActual()
                    };

                    respuesta = objProducNeg.EliminarActivarProducto(objCat);

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

                        CargarProducto();
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
                    MessageBox.Show("No se registran Producto para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Producto para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            CargarProducto();
        }
    }
}