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
    public partial class FrmServicio : DevExpress.XtraEditors.XtraForm
    {
        private static FrmServicio frmInstance = null;
        private ServicioNegocio objServicNeg = new ServicioNegocio();
        private List<Servicio> listServicio = null;
        bool estado = true;

        //Singleton
        public static FrmServicio Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmServicio();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        public FrmServicio()
        {
            InitializeComponent();
        }

        #region Principal Load
        
        private void FrmServicio_Load(object sender, EventArgs e)
        {
            CargarServicio();
        }

        #endregion

        #region Metodo Privados
        private void CargarServicio()
        {
            listServicio = new List<Servicio>();        
            listServicio = objServicNeg.ListarServicio(new Servicio() { nTipo = 1, bEstado = estado });

            if (listServicio.Count() > 0)
            {
                DgvServicio.AutoGenerateColumns = false;
                DgvServicio.DataSource = listServicio;
            }
            else
            {
                DgvServicio.DataSource = null;
            }
            
            LblTotal.Text = "Se Encontraron " + DgvServicio.Rows.Count + " Registros";

        }

        #endregion

        private void FrmServicio_KeyDown(object sender, KeyEventArgs e)
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
            FrmServicioActualiza frmServicioActualiza = new FrmServicioActualiza();
            //frmServicioActualiza.frmProducto = this;
            frmServicioActualiza.Text = "Registro Servicio";

            if (frmServicioActualiza.ShowDialog() == DialogResult.OK)
            {
                CargarServicio();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            if (DgvServicio.Rows.Count == 0) return;

            if (DgvServicio.CurrentCell != null || DgvServicio.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = DgvServicio.CurrentCell.RowIndex;
                DataGridViewRow row2 = DgvServicio.Rows[filaselecionada];
                Servicio servicio = (Servicio)row2.DataBoundItem;

                FrmServicioActualiza frmServicio = new FrmServicioActualiza(servicio);
                frmServicio.tipo = 1;
                frmServicio.Text = "Actualizar Servicio";

                if (frmServicio.ShowDialog() == DialogResult.OK)
                {
                    CargarServicio();
                }
            }
        }
        
        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarServicio();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            if (DgvServicio.Rows.Count == 0) return;

            string servicioBuscar = Interaction.InputBox("", "Buscar Servicio...");

            if (!servicioBuscar.Equals(""))
            {
                List<Servicio> dt = new List<Servicio>();
                foreach (Servicio col in listServicio)
                {

                    if (col.sDescripcion.Contains(servicioBuscar.ToUpper()))
                    {
                        dt.Add(col);
                    }

                }
                if (dt.Count > 0)
                {
                    DgvServicio.DataSource = dt;
                }
                else
                {
                    DgvServicio.DataSource = null;
                }
            }
            else
            {
                DgvServicio.DataSource = listServicio;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvServicio.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idServiSele = Convert.ToInt32(DgvServicio.CurrentRow.Cells[0].Value);

                    Servicio objSer = new Servicio()
                    {
                        nIdServicio = idServiSele,
                        bEstado = estado,
                        sUsuario = Funciones.UsuarioActual()
                    };

                    respuesta = objServicNeg.EliminarActivarServicio(objSer);

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

                        CargarServicio();
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
                    MessageBox.Show("No se registran Servicio para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Servicio para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            CargarServicio();
           
        }
    }
}