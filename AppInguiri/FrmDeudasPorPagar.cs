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
using AppInguiri.EntidadReporte;
using AppInguiri.Reporte;
using AppInguiri.ReporteFormulario;

namespace AppInguiri
{
    public partial class FrmDeudasPorPagar : DevExpress.XtraEditors.XtraForm
    {
        private static FrmDeudasPorPagar frmInstance = null;
        DeudaNegocio objDeudaNeg = new DeudaNegocio();
        List<Deuda> ListDeudaDeta = new List<Deuda>();

        bool? xBandero = false;

        //Singleton
        public static FrmDeudasPorPagar Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmDeudasPorPagar();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }
        
        public FrmDeudasPorPagar()
        {
            InitializeComponent();
        }
        
        private void FrmDeudasPorPagar_Load(object sender, EventArgs e)
        {

        }

        private void dtFechaFin_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
           
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDeudas();
        }

        public void CargarDeudas()
        {
            if (dtFechaFin.Value.Date < dtFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de final no puede ser menor a la fecha inicial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (lblCodigoProveedor.Text == "") lblCodigoProveedor.Text = "0";

            if (Convert.ToInt32(lblCodigoProveedor.Text) > 0 || rdFecha.Checked)
            {
                Deuda objDeuda = new Deuda()
                {
                    nTipo = rdFecha.Checked == true ? 3 : 4,
                    dFecha = dtFechaInicio.Value,
                    dFechaPago = dtFechaFin.Value,
                    nIdProveedor = lblCodigoProveedor.Text == "" ? 0 : Convert.ToInt32(lblCodigoProveedor.Text)
                };

                List<Deuda> ListDeudas = objDeudaNeg.ListarDeuda(objDeuda);

                if (ListDeudas.Count > 0)
                {
                    dgvDeudas.AutoGenerateColumns = false;
                    dgvDeudas.DataSource = ListDeudas;
                }
                else
                {
                    dgvDeudas.DataSource = null;
                }

                if (dgvDeudas.RowCount > 0) dgvDeudas.Focus();
                xBandero = true;
                TabConsulta.SelectedTab = TabCompras;
                xBandero = false;
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Un Proveedor, Presione La Tecla [F3]", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRuc.Focus();
            }

            lblTotal.Text = "Se Encontraron " + dgvDeudas.Rows.Count + " Registros";
        }

        private void TabConsulta_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (TabConsulta.SelectedIndex == 0)
            {
                xBandero = true;
                TabConsulta.SelectedTab = TabCompras;
                lblTotal.Text = "Se Encontraron " + dgvDeudaDetalle.Rows.Count + " Registros";
                xBandero = false;
                return;
            }

            if (xBandero == true) e.Cancel = false;
            else if (xBandero == false) e.Cancel = true;
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            Detalle();
        }

        private void Detalle()
        {
            if (TabConsulta.SelectedIndex == 0)
            {
                dgvDeudaDetalle.DataSource = null;

                if (dgvDeudas.RowCount > 0)
                {
                    xBandero = true;
                    TabConsulta.SelectedTab = TabDetalle;
                    xBandero = false;
                    Deuda _deu = (Deuda)dgvDeudas.CurrentRow.DataBoundItem;
                    CargarDetalles(_deu.nIdDeuda);
                }
            }
        }

        private void CargarDetalles(int nIdDeuda)
        {
            dgvDeudaDetalle.DataSource = null;

            if (dgvDeudas.RowCount > 0)
            {
                ListDeudaDeta.Clear();

                Deuda objDeuda = new Deuda()
                {
                    nTipo = 5,
                    nIdDeuda = nIdDeuda
                };

                ListDeudaDeta = objDeudaNeg.ListarDeuda(objDeuda);
                dgvDeudaDetalle.AutoGenerateColumns = false;

                if (ListDeudaDeta.Count > 0)
                {
                    dgvDeudaDetalle.DataSource = ListDeudaDeta;

                }
                else
                {
                    dgvDeudaDetalle.DataSource = null;
                }

                lblTotal.Text = "Se Encontraron " + dgvDeudaDetalle.Rows.Count + " Registros";
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            if (dgvDeudas.RowCount == 0) return;

            Deuda _deud = (Deuda)dgvDeudas.CurrentRow.DataBoundItem;
            FrmDeudasAbono frmDeudasAbono = new FrmDeudasAbono(_deud);
            frmDeudasAbono.frmDeudasPorPagar = this;
            frmDeudasAbono.ShowDialog();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ElimarAbono();
        }
        
        private void ElimarAbono()
        {
            if (TabConsulta.SelectedIndex == 1)
            {
                if (dgvDeudas.RowCount>0 && dgvDeudaDetalle.RowCount>0)
                {
                    if (MessageBox.Show("¿Desea Eliminar El Abono Realizado", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int resp = 0;
                        Deuda _deud = (Deuda)dgvDeudas.CurrentRow.DataBoundItem;
                        Deuda _deudDet = (Deuda)dgvDeudaDetalle.CurrentRow.DataBoundItem;

                        Deuda objDeuda = new Deuda()
                        {
                            nTipo = 7,
                            nSubTipo = 2,
                            nIdDetalleDeuda = _deudDet.nIdDetalleDeuda,
                            nIdDeuda = _deud.nIdDeuda,
                            fSaldo = _deudDet.fMonto,
                            sUsuario = Funciones.UsuarioActual()
                        };

                        resp = objDeudaNeg.RegistrarAbonoDeuda(objDeuda);

                        if (resp > 0)
                        {
                            MessageBox.Show("El Abono se eliminó con Exito", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDeudas();
                        }
                        else
                        {
                            MessageBox.Show("El Abono no se puede eliminó", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                xBandero = true;
                TabConsulta.SelectedTab = TabDetalle;
                xBandero = false;
                Deuda _deu = (Deuda)dgvDeudas.CurrentRow.DataBoundItem;
                CargarDetalles(_deu.nIdDeuda);
            }
        }

        private void FrmDeudasPorPagar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    if (rdFecha.Checked) Seleccionar();
                    break;
                case Keys.F2:
                    if (rdProveedor.Checked) Seleccionar();
                    break;
                case Keys.F3:
                    if (txtRuc.Enabled) ListarProveedor();
                    break;
                case Keys.F4:
                    btnBuscar_Click(sender,e);
                    break;
                case Keys.F5:
                    BtnAgregar_Click(sender, e);
                    break;
                case Keys.F6:
                    BtnDetalle_Click (sender, e);
                    break;
                case Keys.F7:
                    BtnEliminar_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close(); this.Dispose();
                    break;
            }
        }

        private void ListarProveedor()
        {
            FrmProveedorListar frmProveedor = new FrmProveedorListar();
            frmProveedor.ShowDialog();

            if (frmProveedor._proveedor != null)
            {
                txtRuc.Text = frmProveedor._proveedor.sRuc.ToUpper();
                lblNombre.Text = frmProveedor._proveedor.sRazonSocial.ToUpper();
                lblCodigoProveedor.Text = frmProveedor._proveedor.nIdProveedor.ToString();
            }
        }

        private void Seleccionar()
        {
            dgvDeudas.DataSource = null;

            if (rdFecha.Checked)
            {
                txtRuc.Enabled = false;
                dtFechaInicio.Enabled = true;
                dtFechaInicio.Focus();
                dtFechaFin.Enabled = true;
                txtRuc.Clear();
                lblCodigoProveedor.Text = "";
                lblCodigoProveedor.Text = "";
            }
            else if (rdProveedor.Checked)
            {
                txtRuc.Enabled = true;
                dtFechaInicio.Enabled = false;
                dtFechaFin.Enabled = false;
                txtRuc.Clear();
                dtFechaInicio.Value = DateTime.Now;
                dtFechaFin.Value = DateTime.Now;
            }  
        }

        private void rdFecha_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void rdProveedor_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }
    }
}