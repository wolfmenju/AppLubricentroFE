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
    public partial class FrmMedioPago : Form
    {
        #region Variables Privadas
        private MedioPagoNegocio objMedPagoNeg = new MedioPagoNegocio();
        private List<MedioPago> listMedioPago = new List<MedioPago>();
        private bool estado = true;
        private static FrmMedioPago frmInstance = null;

        //Singleton
        public static FrmMedioPago Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmMedioPago();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        #endregion

        #region Principal Load

        public FrmMedioPago()
        {
            InitializeComponent();
        }
        
        private void FrmMedioPago_Load(object sender, EventArgs e)
        {
            CargarMedioPago();
        }

        #endregion

        #region Eventos
        private void FrmPresentacion_KeyDown(object sender, KeyEventArgs e)
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

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            CargarMedioPago();
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

            CargarMedioPago();

        }
    
        #endregion

        #region Metodo Privados
        private void CargarMedioPago()
        {
            listMedioPago.Clear();
            listMedioPago = objMedPagoNeg.ListarMedioPago(estado);

            if (listMedioPago.Count() > 0)
            {
                DgvMedioPago.AutoGenerateColumns = false;
                DgvMedioPago.DataSource = listMedioPago;
               
            }
            else
            {
                DgvMedioPago.DataSource = null;
            }

            LblTotal.Text = "Se Encontraron " + DgvMedioPago.Rows.Count + " Registros";
        }
        private void Eliminar()
        {
            int respuesta = 0;

            if (DgvMedioPago.RowCount > 0)
            {
                string msg = "";
                if (estado) { estado = false; msg = "Eliminar"; }
                else { estado = true; msg = "Activar"; }

                DialogResult res;
                res = MessageBox.Show("¿Desea " + msg + " el registro?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    int idMedPagoSele = Convert.ToInt32(DgvMedioPago.CurrentRow.Cells[0].Value);

                    MedioPago objMedPago = new MedioPago()
                    {
                        nIdMedioPago = idMedPagoSele,
                        bEstado = estado,
                        sUsuario = Funciones.UsuarioActual()
                    };

                    respuesta = objMedPagoNeg.EliminarActivarMedioPago(objMedPago);

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

                        CargarMedioPago();
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
                    MessageBox.Show("No se registran Categoria para eliminar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("No se registran Categoria para Activar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Buscar()
        {
            if (DgvMedioPago.Rows.Count == 0) return;

            string medioPagoBuscar = Interaction.InputBox("", "Buscar Medio de Pago...");

            if (!medioPagoBuscar.Equals(""))
            {
                List<MedioPago> dt = new List<MedioPago>();

                foreach (MedioPago col in listMedioPago)
                {

                    if (col.sDescripcion.Contains(medioPagoBuscar.ToUpper()))
                    {
                        dt.Add(col);
                    }
                }

                if (dt.Count > 0)
                {
                    DgvMedioPago.DataSource = dt;
                }
                else
                {
                    DgvMedioPago.DataSource = null;
                }
            }
            else
            {
                DgvMedioPago.DataSource = listMedioPago;
            }
        }
        
        private void Modificar()
        {
            if (DgvMedioPago.Rows.Count == 0) return;

            int idCategSele = Convert.ToInt32(DgvMedioPago.CurrentRow.Cells[0].Value);
            string descSele = Convert.ToString(DgvMedioPago.CurrentRow.Cells[1].Value);

            FrmMedioPagoActualiza frmMedPago = new FrmMedioPagoActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmMedPago.tipo = 3;
            frmMedPago.idCategoria = idCategSele;
            frmMedPago.descripcion = descSele;
            frmMedPago.frmMedioPago = this;
            frmMedPago.Text = "Actualizar Medio de Pago";

            if (frmMedPago.ShowDialog() == DialogResult.OK)
            {
                CargarMedioPago();
            }
        }
        //validar que solo se acepten letras en la descripcion
        private void Agregar()
        {
            FrmMedioPagoActualiza frmMedPago = new FrmMedioPagoActualiza();
            //frmPresent.MdiParent = this.MdiParent;
            frmMedPago.frmMedioPago = this;
            frmMedPago.tipo = 2;
            frmMedPago.Text = "Registar de Medio de Pago";

            if (frmMedPago.ShowDialog() == DialogResult.OK)
            {
                CargarMedioPago();
            }
        }
        #endregion
        
    }
}
