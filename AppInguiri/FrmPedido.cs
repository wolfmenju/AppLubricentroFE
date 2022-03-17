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
using Newtonsoft.Json;
using System.Configuration;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using log4net;

namespace AppInguiri
{
    public partial class FrmPedido : DevExpress.XtraEditors.XtraForm
    {
        private static FrmPedido frmInstance = null;
        ProveedorNegocio objProveeNeg = new ProveedorNegocio();
        DocumentoNegocio objDocumentNeg = new DocumentoNegocio();
        ParametroNegocio objParamNeg = new ParametroNegocio();
        VentaNegocio objVentNeg = new VentaNegocio();
        PedidoNegocio objPedNeg = new PedidoNegocio();
        List<Parametro> listadoParametro = new List<Parametro>();
        decimal fTotal = 0M, fIgv = 0M, fIgvResto = 0M, fSubTotal2 = 0M;
        private DocumentoSerieNegocio objDocumentSerieNeg = new DocumentoSerieNegocio();
        private List<DocumentoSerie> listDocumentoSerie = new List<DocumentoSerie>();
        private ClienteNegocio objCliNeg = new ClienteNegocio();
        private Cliente cliente = new Cliente();
        
        int nidVentaRespu = 0;
        WsRestServiceDocumentoFeNegocio objneg = new WsRestServiceDocumentoFeNegocio();
        string sDireccion = "", sRuc = "", sRazonSocial = "",
            sUbigeo = "", sDepart = "", sProvi = "", sDist = "",
            _sUrlSunat = "", _RutaArchivosXml = "", sAplicaIgv = "",
            sUserSunat = "", sPassSunat = "", sCertClaSunat = "",
            sSunatOnline = "", sUrlXmlSunat = "";
        private static ILog Log = LogManager.GetLogger(typeof(FrmVenta));

        //Singleton
        public static FrmPedido Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmPedido();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmPedido()
        {
            InitializeComponent();
            CargarMaestro();
        }

        public void CargarMaestro()
        {
            dtFecha.Enabled = false;
            dtFecha.Value = Globales.FechaActual();
            fIgv = Convert.ToDecimal(objParamNeg.LeerUnParametro("ID_IGV"));
            sAplicaIgv = objParamNeg.LeerUnParametro("ID_IGV_APLICA");

            if (sAplicaIgv.Equals("NO")) lblTotalTextoSinIgv.Visible = true;
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (Globales.FechaActual().Date != Funciones.CodFechaActual().Date && e.KeyCode != Keys.Escape)
            {
                MessageBox.Show("No puede realizar Ventas con Fechas Anterior. Verifique si se Cerro Caja.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.F1:
                    ListarProducto();
                    break;
                case Keys.F2:
                    ListarCliente();
                    break;
                case Keys.F3:
                    rdMedicamento.Checked = true;
                    break;
                case Keys.F4:
                    rdServicios.Checked = true;
                    break;
                case Keys.F5:
                    btnGuardar_Click(sender, e);
                    break;
                case Keys.F6:
                    btnDescuento_Click(sender, e);
                    break;
                case Keys.F7:
                    btnEliminar_Click(sender, e);
                    break;
                case Keys.F8:
                    btnBuscar_Click(sender, e);
                    break;
                case Keys.F9:
                    Contado();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void ListarCliente()
        {
            FrmClienteListar frmCliente = new FrmClienteListar();
            frmCliente.ShowDialog();

            if (frmCliente._cliente != null)
            {
                LblCodigoCliente.Text = frmCliente._cliente.nIdCliente.ToString();
                txtRuc.Text = frmCliente._cliente.sNumeroDoc.ToUpper();
                txtNombre.Text = frmCliente._cliente.sNombres.ToUpper();
            }
        }

        private void ListarProducto()
        {
            if (rdMedicamento.Checked)
            {
                FrmProductoListar frmProductoListar = new FrmProductoListar();
                frmProductoListar.frmPedido = frmInstance;
                frmProductoListar.ShowDialog();
                dgvProducto.DataSource = frmProductoListar.frmPedido.dgvProducto.DataSource;

            }
            else
            {
                FrmServicioListar frmServicioListar = new FrmServicioListar();
                frmServicioListar.frmPedido = frmInstance;
                frmServicioListar.ShowDialog();
                dgvProducto.DataSource = frmServicioListar.frmPedido.dgvProducto.DataSource;
            }

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
                    fTotal = fTotal + (Convert.ToDecimal(item.Cells["fSubTotal"].Value));
                }
            }

            lblTotal.Text = fTotal.ToString("C");
            fTotal = decimal.Round(fTotal, 2);

            if (sAplicaIgv.Equals("SI"))
            {
                lblIgv.Text = ((fIgv / 100) * fTotal).ToString("C");
                lblSubtotal.Text = (fTotal - ((fIgv / 100) * fTotal)).ToString("C");
                fSubTotal2 = decimal.Round((fTotal - ((fIgv / 100) * fTotal)), 2);
                fIgvResto = decimal.Round(((fIgv / 100) * fTotal), 2);
            }
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            Descuento();
        }

        private void Descuento()
        {
            if (dgvProducto.RowCount == 0) return;

            if (dgvProducto.CurrentCell != null || dgvProducto.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = dgvProducto.CurrentCell.RowIndex;
                DataGridViewRow row = dgvProducto.Rows[dgvProducto.CurrentCell.RowIndex];

                FrmDescuento frmDescuento = new FrmDescuento();
                //frmDescuento.frmVenta = frmInstance;
                frmDescuento.lblTotal.Text = Convert.ToDecimal(row.Cells["fSubTotal"].Value).ToString("#0.00");
                frmDescuento.lblVuelto.Text = "0.00";
                //frmDescuento.txtPago.Text = Convert.ToDecimal(row.Cells["fSubTotal"].Value).ToString("#0.00");
                frmDescuento.ShowDialog();

                CalcularTotal();
            }

            this.ActiveControl = null;
            txtDescripcion.Focus();
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

        private void chkCliente_Click(object sender, EventArgs e)
        {
            Contado();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            if (Globales.FechaActual().Date != Funciones.CodFechaActual().Date)
            {
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnBuscar.Enabled = false;
                MessageBox.Show("No puede realizar Ventas con Fechas Anterior. Verifique si se Cerro Caja.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CalcularTotal();
        }

        private void Contado()
        {
            if (chkCliente.CheckState == CheckState.Checked)
            {
                ClienteContado();
            }
            else
            {
                LblCodigoCliente.Text = "";
                txtNombre.Clear();
                txtRuc.Clear();
                txtRuc.Focus();
            }
        }
    

        private void ClienteContado()
        {
            Cliente objCliente = new Cliente() { nTipo = 6, bEstado = true };

            List<Cliente> ListCliente= objCliNeg.ListarCliente(objCliente);

            if (ListCliente.Count > 0)
            {
                LblCodigoCliente.Text = ListCliente[0].nIdCliente.ToString();
                txtNombre.Text = ListCliente[0].sNombres.ToString();
                txtRuc.Text = ListCliente[0].sNumeroDoc.ToString();
            }
            else
            {
                chkCliente.Checked = false;
                lblDescuento.Text = "";
                txtRuc.Clear();
                MessageBox.Show("El documento al Paso no se Encuentra. Revisar el Administrador de Clientes.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        public void GuardarVentaTodo()
        {
            if (dgvProducto.Rows.Count == 0) return;

            if (MessageBox.Show("¿Desea Generar El Pedido?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!VerificacionDatos()) return;

                List<PedidoDetalle> listPedDeta = new List<PedidoDetalle>();
                PedidoDetalle objPedDeta = null;

                Pedido objPedido = new Pedido();
                objPedido.nTipo = 1;
                objPedido.nIdAlmacen = Funciones.CodAlmacenActual();
                objPedido.nIdCliente = Convert.ToInt32(LblCodigoCliente.Text);
                objPedido.dFecha = dtFecha.Value;

                //objVenta.nIdPedido = lblPedido.Text.Length > 0 ? Convert.ToInt32(lblPedido.Text) : 0;

                objPedido.sNombre = txtNombre.Text;

                //objVenta.sIdDocumento = cboDocumento.SelectedValue.ToString();
                //objVenta.sSerie = lblSerie.Text;
                //objVenta.nNumero = Convert.ToInt32(lblNumero.Text);
                objPedido.fTotal = fTotal;
                objPedido.sUsuario = Funciones.UsuarioActual();
                //objVenta.sIdVendedor = txtPedido.Text.Length > 0 ? lblVendedor.Text : Funciones.UsuarioActual();
                //objPedido.bIgvAplica = sAplicaIgv.Equals("SI") ? true : false;

                if (sAplicaIgv.Equals("SI"))
                {
                    objPedido.fIgv = fIgvResto;
                    objPedido.fPorcentajeIgv = (decimal)fIgv;
                    objPedido.fSubTotal = fSubTotal2;
                }

                foreach (DataGridViewRow item in dgvProducto.Rows)
                {
                    objPedDeta = new PedidoDetalle();
                    //objVentDeta.nIdMovimiento = Convert.ToInt32(item.Cells["nIdMovimiento"].Value);
                    objPedDeta.nIdProducto = Convert.ToInt32(item.Cells["nIdProducto"].Value);
                    objPedDeta.dFechaVencimiento = Convert.ToDateTime(item.Cells["Vencimiento"].Value);
                    objPedDeta.nCantidad = Convert.ToInt32(item.Cells["nCantidad"].Value);
                    objPedDeta.fPrecioCompra = Convert.ToDecimal(item.Cells["fPrecioCompra"].Value);
                    objPedDeta.sLote = item.Cells["sLote"].Value.ToString();

                    if (sAplicaIgv.Equals("SI"))
                    {
                        
                        //objVentDeta.fSubTotal = Convert.ToDecimal(item.Cells["fSubTotal"].Value);
                    }

                    objPedDeta.fGanancia = Convert.ToDecimal(item.Cells["fGanancia"].Value);
                    objPedDeta.fPrecioVenta = Convert.ToDecimal(item.Cells["fPrecioVenta"].Value);
                    objPedDeta.bServicio = Convert.ToBoolean(item.Cells["bServicio"].Value);
                    //objVentDeta.fDescuento = Convert.ToDecimal(item.Cells["fDescuento"].Value.ToString().Replace("S/", ""));

                    listPedDeta.Add(objPedDeta);
                }

                objPedido.ListDetallePedido = listPedDeta;

                nidVentaRespu = objPedNeg.RegistrarPedido(objPedido);

                if (nidVentaRespu > 0)
                {
                    MessageBox.Show("El Pedido Se Realizó Con Éxito.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El Pedido No Se Pudo Realizar.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //ImprimirComprobante();
                LimpiarValores();
                Contado();

                nidVentaRespu = 0;
            }
        }
        
        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ModificarCantidad();
        }

        private void ModificarCantidad()
        {
            if (dgvProducto.RowCount == 0) return;

            if (dgvProducto.CurrentCell != null || dgvProducto.CurrentCell.RowIndex != 0)
            {
                Int32 filaselecionada = dgvProducto.CurrentCell.RowIndex;
                bool servicio = false;
                servicio =(bool)dgvProducto.Rows[filaselecionada].Cells["bServicio"].Value;

                if (!servicio)
                {
                    FrmProductoListar frmProductoListar = new FrmProductoListar();
                    frmProductoListar.xTipo = 1;
                    frmProductoListar.frmPedido = frmInstance;
                    frmProductoListar.ShowDialog();
                }
                else
                {
                    FrmServicioListar frmServicioListar = new FrmServicioListar();
                    frmServicioListar.xTipo = 1;
                    frmServicioListar.frmPedido = frmInstance;
                    frmServicioListar.ShowDialog();
                }

                CalcularTotal();
            }

        }

        private void LimpiarValores()
        {
            txtDescripcion.Clear();
            txtRuc.Clear();
            dgvProducto.Rows.Clear();
            lblSubtotal.Text = "S/. 0.00";
            lblIgv.Text = "S/. 0.00";
            lblTotal.Text = "S/. 0.00";
            txtNombre .Text = "";
            LblCodigoCliente .Text = "";
            txtDescripcion.Focus();
            fTotal = 0M;
            fIgvResto = 0M;
            fSubTotal2 = 0M;
            dgvProducto.DataSource = null;
        }

        private bool VerificacionDatos()
        {
            bool resp = true;

            if (LblCodigoCliente.Text.Equals(""))
            {
                MessageBox.Show("Seleccione un Cliente.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resp = false;
            }        
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