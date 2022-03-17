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
using CrystalDecisions.CrystalReports.Engine;
using AppInguiri.EntidadReporte;
using AppInguiri.Reporte;

namespace AppInguiri
{
    public partial class FrmAjusteStock : DevExpress.XtraEditors.XtraForm
    {
        private static FrmAjusteStock frmInstance = null;
        ProveedorNegocio objProveeNeg = new ProveedorNegocio();
        DocumentoNegocio objDocumentNeg = new DocumentoNegocio();
        ParametroNegocio objParamNeg = new ParametroNegocio();
        SalidaNegocio objVentNeg = new SalidaNegocio();
        List<Parametro> listadoParametro = new List<Parametro>();
        decimal fTotal = 0M, fIgv = 0M, fIgvResto = 0M, fSubTotal2 = 0M;
        private DocumentoSerieNegocio objDocumentSerieNeg = new DocumentoSerieNegocio();
        private List<DocumentoSerie> listDocumentoSerie = new List<DocumentoSerie>();
        private ClienteNegocio objCliNeg = new ClienteNegocio();
        int DocDefault = 0;
        int xTipo = 2;

        //Singleton
        public static FrmAjusteStock Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmAjusteStock();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }
        
        public FrmAjusteStock()
        {
            InitializeComponent();
            CargarMaestro();
        }
        
        public void CargarMaestro()
        {
            Documento objDoc = new Documento() { nTipo = 5, bEstado = true };
            List<Documento> lis = objDocumentNeg.ListarDocumento(objDoc);

            List<Documento> lis2 = new List<Documento>();

            foreach (var item in lis)
            {
                if (item.sDescripcion == "AJUSTE DE STOCK - INCREMENTO" || item.sDescripcion == "AJUSTE DE STOCK - DISMINUIR")
                {
                    lis2.Add(item);
                }
            }
            
            cboDocumento.ValueMember = "sIdDocumento";
            cboDocumento.DisplayMember = "sDescripcion";
            
            cboDocumento.DataSource = lis2;
            cboDocumento.Enabled = true;

            for (int i = 0; i < lis2.Count; i++)
            {
                if (lis2[i].sDescripcion == "AJUSTE DE STOCK")
                {
                    cboDocumento.SelectedIndex = i;
                    DocDefault = i;
                    break;
                }
            }
            
            if (cboDocumento.Items.Count > 0) CargaSerieDocumento();

            dtFecha.Value = Funciones.CodFechaActual();
            dtFecha.Enabled = false;

            fIgv = Convert.ToDecimal(objParamNeg.LeerUnParametro("ID_IGV"));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void FrmVenta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    ListarProducto();
                    break;
                case Keys.F2:
                    ListarProveedor();
                    break;
                case Keys.F3:
                    btnGuardar_Click(sender, e);
                    break;
                case Keys.F4:
                    btnEliminar_Click(sender, e);
                    break;
                case Keys.F5:
                    btnBuscar_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
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
                lblNombreProveedor.Text = frmProveedor._proveedor.sRazonSocial.ToUpper();
                LblCodigoProveedor.Text = frmProveedor._proveedor.nIdProveedor.ToString();
                txtDescripcion.Focus();
            }
        }

        private void ListarProducto()
        {
            FrmProductoListar frmProductoListar = new FrmProductoListar();
            frmProductoListar.xTipo = xTipo;
            frmProductoListar.frmDevuelve = frmInstance;
            frmProductoListar.ShowDialog();

            dgvProducto.DataSource = frmProductoListar.frmDevuelve.dgvProducto.DataSource;
            CalcularTotal();
            this.ActiveControl = null;
            txtDescripcion.Focus();
        }

        private void CalcularTotal()
        {
            fTotal = 0;
            
            if (dgvProducto.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvProducto.Rows)
                {
                    fTotal = fTotal+(Convert.ToDecimal(item.Cells["fSubTotal"].Value)- Convert.ToDecimal(item.Cells["fDescuento"].Value.ToString().Replace("S/","")));
                }
            }

            lblTotal.Text = fTotal.ToString("C");
            lblIgv.Text = ((fIgv / 100) * fTotal).ToString("C");
            lblSubtotal.Text = (fTotal - ((fIgv / 100) * fTotal)).ToString("C");
            fSubTotal2 = decimal.Round((fTotal - ((fIgv / 100) * fTotal)), 2);
            fTotal = decimal.Round(fTotal, 2);
            fIgvResto = decimal.Round(((fIgv / 100) * fTotal), 2);
        }
       
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProducto();
        }

        private void EliminarProducto()
        {
            if (dgvProducto.RowCount > 0)
            {
                if (dgvProducto.CurrentCell != null || dgvProducto.CurrentCell.RowIndex != 0)
                {
                    if (MessageBox.Show("¿Desea Eliminar El Producto Seleccionado?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Int32 filaselecionada = dgvProducto.CurrentCell.RowIndex;
                        DataGridViewRow row2 = dgvProducto.Rows[filaselecionada];
                        dgvProducto.Rows.Remove(row2);

                        CalcularTotal();
                    }
                }
            }

            this.ActiveControl = null;
            txtDescripcion.Focus();
        }

        private void cboDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargaSerieDocumento();
        }
        
        public void CargaSerieDocumento()
        {
            lblSerie.Focus();
            listDocumentoSerie.Clear();
            DocumentoSerie objDocSerie = new DocumentoSerie() {nTipo=5, sIdDocumento=cboDocumento.SelectedValue.ToString(),bEstado=true };
            listDocumentoSerie = objDocumentSerieNeg.ListarDocumentoSerie(objDocSerie);

            if (listDocumentoSerie.Count == 0)
            {
                MessageBox.Show("Debe Registrar un Correlativo para este Documento", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSerie.Text = "";
                lblNumero.Text = "";
                return;
            }

            dgvProducto.Rows.Clear();
            txtDescripcion.Clear();
            txtRuc.Clear();
            dgvProducto.Rows.Clear();
            lblSubtotal.Text = "S/. 0.00";
            lblIgv.Text = "S/. 0.00";
            lblTotal.Text = "S/. 0.00";
            LblCodigoProveedor.Text = "";
            lblNombreProveedor.Text = "";
            txtDescripcion.Focus();
            lblNumero.Text = "";
            lblSerie.Text = "";
            fTotal = 0M;
            fIgvResto = 0M;
            fSubTotal2 = 0M;

            foreach (var item in listDocumentoSerie)
            {
                lblSerie.Text = item.sSerie;
                lblNumero.Text = string.Format("{0:0000000000}", item.nUltimo + 1);
                break;
            }
            
            if (cboDocumento.SelectedValue.ToString() == "04")  xTipo = 3;
            else if (cboDocumento.SelectedValue.ToString() == "05") xTipo = 4;
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            FrmVentaListar frmVentaListar = new FrmVentaListar();
            frmVentaListar.ShowDialog();
            txtDescripcion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarVentaTodo();
        }

        int nidVentaRespu = 0;

        public void GuardarVentaTodo()
        {
            if (dgvProducto.Rows.Count==0) return;

            string Mensaje = "", MensajeRes="";
            if (xTipo == 2)
            {
                Mensaje = "Generar La Salida";
                MensajeRes = "La Salida";
            }
            else
            {
                Mensaje = "Generar el Ajuste del Stock";
                MensajeRes = "El Ajuste";
            }
         
            if (MessageBox.Show("¿Desea "+ Mensaje + " de los Productos?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!VerificacionDatos()) return;

                List<SalidaDetalle> listVentDeta = new List<SalidaDetalle>();
                SalidaDetalle objVentDeta = null;

                Salida objVenta = new Salida();
                objVenta.nTipo = 1;
                objVenta.nIdProveedor = Convert.ToInt32(LblCodigoProveedor.Text);
                objVenta.nIdPedido = lblPedido.Text.Length > 0 ? Convert.ToInt32(lblPedido.Text) : 0; 
                objVenta.nIdAlmacen = Funciones.CodAlmacenActual();
                //objVenta.sNombre = txtNombre.Text;
                objVenta.dFecha = dtFecha.Value;
                objVenta.sIdDocumento = cboDocumento.SelectedValue.ToString();
                objVenta.sSerie = lblSerie.Text;
                objVenta.nNumero = Convert.ToInt32(lblNumero.Text);
                objVenta.fSubTotal = fSubTotal2;
                objVenta.fIgv = fIgvResto;
                objVenta.fTotal = fTotal;
                objVenta.nPorcentaje = (int)fIgv;
                objVenta.sUsuario = Funciones.UsuarioActual();

                foreach (DataGridViewRow item in dgvProducto.Rows)
                {
                    objVentDeta = new SalidaDetalle();
                    objVentDeta.nIdMovimiento = Convert.ToInt32(item.Cells["nIdMovimiento"].Value);
                    objVentDeta.nIdProducto = Convert.ToInt32(item.Cells["nIdProducto"].Value);
                    objVentDeta.dFechaVencimiento = Convert.ToDateTime(item.Cells["Vencimiento"].Value);
                    objVentDeta.nCantidad = Convert.ToInt32(item.Cells["nCantidad"].Value);
                    objVentDeta.fPrecioCompra = Convert.ToDecimal(item.Cells["fPrecioCompra"].Value);
                    objVentDeta.sLote = item.Cells["sLote"].Value.ToString();
                    objVentDeta.fGanancia = Convert.ToDecimal(item.Cells["fGanancia"].Value);
                    objVentDeta.fPrecioVenta = Convert.ToDecimal(item.Cells["fPrecioVenta"].Value);
                    objVentDeta.fSubTotal = Convert.ToDecimal(item.Cells["fSubTotal"].Value);
                    objVentDeta.bServicio = Convert.ToBoolean(item.Cells["bServicio"].Value);
                    objVentDeta.fDescuento = Convert.ToDecimal(item.Cells["fDescuento"].Value.ToString().Replace("S/",""));

                    listVentDeta.Add(objVentDeta);
                }

                objVenta.listSalidaDetalle = listVentDeta;
                //Salida de Stock por Devolucion
                if(xTipo==2 || xTipo==4) nidVentaRespu = objVentNeg.ActualizaSalida(objVenta);
                else nidVentaRespu = objVentNeg.ActualizaIngreso(objVenta);

                if (nidVentaRespu > 0)
                {
                    MessageBox.Show(MensajeRes+" Se Realizó Con Éxito", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarValores();
                    CargaSerieDocumento();
           
                }
                else
                {
                    MessageBox.Show("La Transsacción No Se Pudo Realizar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        
        //Ingreso 1;

        private void LimpiarValores()
        {
            txtDescripcion.Clear();
            txtRuc.Clear();
            dgvProducto.Rows.Clear();
            lblSubtotal.Text = "S/. 0.00";
            lblIgv.Text = "S/. 0.00";
            lblTotal.Text = "S/. 0.00";
            LblCodigoProveedor .Text = "";
            lblNombreProveedor.Text = "";
            txtDescripcion.Focus();
            lblNumero.Text = "";
            lblSerie.Text="";
            fTotal = 0M;
            fIgvResto = 0M;
            fSubTotal2 = 0M;
            cboDocumento.SelectedIndex = DocDefault;
            dgvProducto.DataSource = null;
        }

        private bool VerificacionDatos()
        {
            bool resp = true;

            if (LblCodigoProveedor .Text.Equals(""))
            {
                MessageBox.Show("Seleccione un Proveedor.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            if (cboDocumento.Text.Equals(""))
            {
                MessageBox.Show("Seleccione el Tipo de Documento.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (lblSerie.Text.Equals(""))
            {
                MessageBox.Show("El campo Serie se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            else if (lblNumero.Text.Equals(""))
            {
                MessageBox.Show("El campo Numero de CP se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }
            //else if (cboTipo.SelectedIndex == 1)
            //{
            //    if (txtDia.Text.Equals(""))
            //    {
            //        MessageBox.Show("El campo Dias se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        resp = false;
            //    }
            //}
            else if (dgvProducto.RowCount == 0)
            {
                MessageBox.Show("No agrego ningun Producto., por favor agregue un Producto.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }

            return resp;
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtFecha.Focus();
            }
        }
    }
}