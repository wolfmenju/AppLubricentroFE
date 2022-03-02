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
using System.Drawing;
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
    public partial class FrmVenta : DevExpress.XtraEditors.XtraForm
    {
        private static FrmVenta frmInstance = null;
        ProveedorNegocio objProveeNeg = new ProveedorNegocio();
        DocumentoNegocio objDocumentNeg = new DocumentoNegocio();
        ParametroNegocio objParamNeg = new ParametroNegocio();
        VentaNegocio objVentNeg = new VentaNegocio();
        List<Parametro> listadoParametro = new List<Parametro>();
        decimal fTotal = 0M, fIgv = 0M, fIgvResto = 0M, fSubTotal2 = 0M;
        private DocumentoSerieNegocio objDocumentSerieNeg = new DocumentoSerieNegocio();
        private List<DocumentoSerie> listDocumentoSerie = new List<DocumentoSerie>();
        private ClienteNegocio objCliNeg = new ClienteNegocio();
        private Cliente cliente= new Cliente();
        int DocDefault = 0;
        int nidVentaRespu = 0;
        WsRestServiceDocumentoFeNegocio objneg = new WsRestServiceDocumentoFeNegocio();
        string sDireccion = "", sRuc = "", sRazonSocial = "", 
            sUbigeo = "", sDepart="", sProvi="",sDist="",
            _sUrlSunat="", _RutaArchivosXml="", sAplicaIgv="";
        private static ILog Log= LogManager.GetLogger(typeof(FrmVenta));

        //Singleton
        public static FrmVenta Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmVenta();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }
        
        public FrmVenta()
        {
            InitializeComponent();
            CargarMaestro();
            CargarDatosEmpresa();
            CargarDatosConfiguracion();
        }

        private void CargarDatosConfiguracion()
        {
            _sUrlSunat = Convert.ToString(ConfigurationManager.AppSettings["UrlSunat"]);
            _RutaArchivosXml = Convert.ToString(ConfigurationManager.AppSettings["RutaArchivosXml"]);
        }

        private void CargarDatosEmpresa()
        {
            sDireccion = objParamNeg.LeerUnParametro("ID_DIRECCION");
            sRuc = objParamNeg.LeerUnParametro("ID_RUC");
            sRazonSocial = objParamNeg.LeerUnParametro("ID_RAZON_SOCIAL");
            sUbigeo = objParamNeg.LeerUnParametro("ID_UBIGEO");
            sDepart = objParamNeg.LeerUnParametro("ID_DIRECCION_DEPA");
            sProvi = objParamNeg.LeerUnParametro("ID_DIRECCION_PROV");
            sDist = objParamNeg.LeerUnParametro("ID_DIRECCION_DIST");
            sAplicaIgv = objParamNeg.LeerUnParametro("ID_IGV_APLICA");
        }

        public void CargarMaestro()
        {
            Documento objDoc = new Documento() { nTipo = 5, bEstado = true };
            List<Documento> lis = objDocumentNeg.ListarDocumento(objDoc);

            List<Documento> lis2 = new List<Documento>();

            foreach (var item in lis)
            {
                if (item.sDescripcion == "FACTURA" || item.sDescripcion == "TICKET"
                    || item.sDescripcion == "BOLETA")
                {
                    lis2.Add(item);
                }
            }

            cboDocumento.ValueMember = "sIdDocumento";
            cboDocumento.DisplayMember = "sDescripcion";
            
            cboDocumento.DataSource = lis2;
            
            for (int i = 0; i < lis2.Count; i++)
            {
                if (lis2[i].sDescripcion == "TICKET")
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
                    ListarCliente();
                    break;
                case Keys.F3:
                  
                    break;
                case Keys.F4:
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
                txtRuc.Text = frmCliente._cliente.sDni.ToUpper();
                txtNombre.Text = frmCliente._cliente.sNombres.ToUpper();
            }
        }
        
        private void ListarProducto()
        {
            FrmProductoListar frmProductoListar = new FrmProductoListar();
            frmProductoListar.frmVenta = frmInstance;
            frmProductoListar.ShowDialog();

            dgvProducto.DataSource = frmProductoListar.frmVenta.dgvProducto.DataSource;
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
                frmDescuento.frmVenta = frmInstance;
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

            foreach (var item in listDocumentoSerie)
            {
                lblSerie.Text = item.sSerie;
                lblNumero.Text = string.Format("{0:00000000}", item.nUltimo + 1);
                break;
            }    
        }

        private void cboTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 1)
            {
                txtDia.Enabled = true;
                txtDia.Focus();
            }
            else
            {
                txtDia.Enabled = false;
                txtDia.Clear();
                txtDescripcion.Focus();
            }
        }

        private void chkCliente_Click(object sender, EventArgs e)
        {
            Contado();
        }

        private void Contado()
        {
            if (txtPedido.Enabled)
            {
                if (chkCliente.CheckState == CheckState.Checked) ClienteContado();
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
                txtRuc.Text = ListCliente[0].sDni.ToString();
            }
            else
            {
                chkCliente.Checked = false;
                lblDescuento.Text = "";
                txtRuc.Clear();
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
            GuardarVenta();
        }

        private void GuardarVenta()
        {
            if (dgvProducto.Rows.Count < 1) return;
            if (!VerificacionDatos()) return;

            FrmPago frmPago = new FrmPago();
            frmPago.frmVenta = frmInstance;
            frmPago.lblTotal.Text = fTotal.ToString("#0.00");
            frmPago.lblVuelto.Text = "0.00";
            frmPago.txtPago.Text=fTotal.ToString("#0.00");
            frmPago.ShowDialog();
        }

        public void GuardarVentaTodo()
        {
            if (dgvProducto.Rows.Count == 0) return;

            if (MessageBox.Show("¿Desea Generar La Venta?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!VerificacionDatos()) return;

                List<VentaDetalle> listVentDeta = new List<VentaDetalle>();
                VentaDetalle objVentDeta = null;

                Venta objVenta = new Venta();
                objVenta.nTipo = 1;
                objVenta.nIdCliente = Convert.ToInt32(LblCodigoCliente.Text);
                objVenta.nIdPedido = lblPedido.Text.Length > 0 ? Convert.ToInt32(lblPedido.Text) : 0;
                objVenta.nIdAlmacen = Funciones.CodAlmacenActual();
                objVenta.sNombre = txtNombre.Text;
                objVenta.dFecha = dtFecha.Value;
                objVenta.sIdDocumento = cboDocumento.SelectedValue.ToString();
                objVenta.sSerie = lblSerie.Text;
                objVenta.nNumero = Convert.ToInt32(lblNumero.Text);
                objVenta.fTotal = fTotal;
                objVenta.sUsuario = Funciones.UsuarioActual();
                objVenta.sIdCajero = Funciones.UsuarioActual();
                objVenta.sIdVendedor = txtPedido.Text.Length > 0 ? lblVendedor.Text : Funciones.UsuarioActual();
                objVenta.bIgvAplica = sAplicaIgv.Equals("SI") ? true : false;

                if (sAplicaIgv.Equals("SI"))
                {
                    objVenta.fIgv = fIgvResto;
                    objVenta.fPorcentajeIgv = (decimal)fIgv;
                    objVenta.fSubTotal = fSubTotal2;
                }

                foreach (DataGridViewRow item in dgvProducto.Rows)
                {
                    objVentDeta = new VentaDetalle();
                    objVentDeta.nIdMovimiento = Convert.ToInt32(item.Cells["nIdMovimiento"].Value);
                    objVentDeta.nIdProducto = Convert.ToInt32(item.Cells["nIdProducto"].Value);
                    objVentDeta.dFechaVencimiento = Convert.ToDateTime(item.Cells["Vencimiento"].Value);
                    objVentDeta.nCantidad = Convert.ToInt32(item.Cells["nCantidad"].Value);
                    objVentDeta.fPrecioCompra = Convert.ToDecimal(item.Cells["fPrecioCompra"].Value);
                    objVentDeta.sLote = item.Cells["sLote"].Value.ToString();

                    if (sAplicaIgv.Equals("SI"))
                    {
                        objVentDeta.fIgvDetalle = decimal.Round(((objVentDeta.nCantidad *
                        Convert.ToDecimal(item.Cells["fPrecioVenta"].Value) - ((objVentDeta.nCantidad
                        * Convert.ToDecimal(item.Cells["fPrecioVenta"].Value)) * (fIgv / 100))) * (fIgv / 100)), 2);
                        objVentDeta.fSubTotal = Convert.ToDecimal(item.Cells["fSubTotal"].Value);
                    }

                    objVentDeta.fGanancia = Convert.ToDecimal(item.Cells["fGanancia"].Value);
                    objVentDeta.fPrecioVenta = Convert.ToDecimal(item.Cells["fPrecioVenta"].Value);
                    objVentDeta.bServicio = Convert.ToBoolean(item.Cells["bServicio"].Value);
                    objVentDeta.fDescuento = Convert.ToDecimal(item.Cells["fDescuento"].Value.ToString().Replace("S/", ""));

                    listVentDeta.Add(objVentDeta);
                }

                objVenta.listVentaDetalle = listVentDeta;

                nidVentaRespu = objVentNeg.RegistrarVenta(objVenta);

                if (nidVentaRespu > 0)
                {
                    //Metodo para nofiticar a Sunat
                    if (NotificacionSunat(nidVentaRespu))
                    {
                        MessageBox.Show("La Venta Se Realizó Con Éxito y Notificó Correctamente a Sunat.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La Venta Se Realizó Con Éxito pero hubo problemas en la notificación a Sunat.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("La Venta No Se Pudo Realizar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ImprimirComprobante();
                LimpiarValores();
                CargaSerieDocumento();
                Contado();

                nidVentaRespu = 0;
            }
        }


        private bool NotificacionSunat( int nidVentaRespu)
        {
            Venta objVenta = new Venta() { nTipo = 8, nIdVenta = nidVentaRespu };
            
            List<Venta> LisVenRep = objVentNeg.ListarVentas(objVenta);
            WsDocumentoFeResponseData data = null;
            if (LisVenRep[0].sDescripDocumento.Equals("TICKET")) return true;

            if (LisVenRep.Count > 0)
            {
                try
                {

                    data = new WsDocumentoFeResponseData();
                    data.tipo_operacion = "01";
                    data.total_gravadas = LisVenRep[0].bIgvAplica? (LisVenRep[0].fTotal - Decimal.Round(((LisVenRep[0].fTotal - LisVenRep[0].fIgv) * (LisVenRep[0].fPorcentajeIgv / 100)), 2)).ToString():"0.00";
                    data.total_inafecta = "0.00";
                    data.total_exoneradas = LisVenRep[0].bIgvAplica ? "0.00" : LisVenRep[0].fTotal.ToString();
                    data.total_gratuitas = "0.00";
                    data.total_exportacion = "0.00";
                    data.total_descuento = "0.00";
                    data.sub_total = "";
                    data.porcentaje_igv = LisVenRep[0].fPorcentajeIgv.ToString();
                    data.total_igv = (Decimal.Round(((LisVenRep[0].fTotal - LisVenRep[0].fIgv) * (LisVenRep[0].fPorcentajeIgv / 100)), 2)).ToString();
                    data.total_isc = "0.00";
                    data.total_otr_imp = "0.00";
                    data.total = LisVenRep[0].fTotal.ToString();
                    data.total_letras = Funciones.NumeroALetras(LisVenRep[0].fTotal);
                    data.nro_guia_remision = "";
                    data.cod_guia_remision = "";
                    data.nro_otr_comprobante = "";
                    data.condicion_pago = "CONTADO";

                    cliente = objCliNeg.LeerCliente(LisVenRep[0].nIdCliente);

                    if (cliente.sDni.Length > 8)
                    {
                        data.cliente_tipo_doc = "6";
                    }
                    else
                    {
                        if (cliente.sDni.Length.Equals("00000000"))
                        {
                            data.cliente_tipo_doc = "0";
                        }
                        else
                        {
                            data.cliente_tipo_doc = "1";
                        }
                    }

                    data.cliente_nro_doc = cliente.sDni;
                    data.cliente_nombre = cliente.sNombres;
                    data.cliente_direccion = cliente.sDireccion==""? "null": cliente.sDireccion;

                    data.serie_comprobante = LisVenRep[0].sDescripDocumento.Substring(0, 1) + LisVenRep[0].sSerie;
                    data.numero_comprobante = string.Format("{0:00000000}", LisVenRep[0].nNumero); 
                    data.fecha_comprobante = LisVenRep[0].dFechaRegistrado.ToString("yyyy-MM-dd");
                    data.fecha_vto_comprobante = LisVenRep[0].dFechaRegistrado.ToString("yyyy-MM-dd");
                    data.moneda_cod = "PEN";
                    data.tipo_tributo = LisVenRep[0].bIgvAplica ? "IGV" : "EXO";
                    data.tipo_igv = LisVenRep[0].bIgvAplica? "1000" : "9997";
                    data.tipo_comprobante_cod = LisVenRep[0].sIdDocumento;
                    data.cliente_pais = "PE";
                    data.cliente_codigo_ubigeo = "null";
                    data.cliente_departamento = "null";
                    data.cliente_provincia = "null";
                    data.cliente_distrito = "null";

                    data.emisor = new emisor();
                    data.emisor.ruc = sRuc;
                    data.emisor.tipo_doc = "6";
                    data.emisor.razon_social = sRazonSocial;
                    data.emisor.codigo_ubigeo = sUbigeo;
                    data.emisor.direccion = sDireccion;
                    data.emisor.direccion_departamento = sDepart;
                    data.emisor.direccion_provincia = sProvi;
                    data.emisor.direccion_distrito = sDist;
                    data.emisor.direccion_codigopais = "PE";
                    data.emisor.usuariosol = "MODDATOS";
                    data.emisor.clavesol = "moddatos";
                    data.emisor.clave_certificado = "123456";
                    data.emisor.url_xml = "beta/";
                    data.emisor.url_ws = _sUrlSunat;
                    data.emisor.codigo_estab_anexo_sun = "0000";

                    data.detalle = new detalle[LisVenRep.Count];

                    for (int i = 0; i < LisVenRep.Count; i++)
                    {
                        data.detalle[i] = new detalle();
                        data.detalle[i].txtITEM = (i + 1).ToString();
                        data.detalle[i].txtUNIDAD_MEDIDA_DET = "NI";
                        data.detalle[i].txtCANTIDAD_DET = LisVenRep[i].nCodigo.ToString();
                        data.detalle[i].txtPRECIO_UNIT = (LisVenRep[i].fPrecioVenta / LisVenRep[i].nCodigo).ToString();
                        data.detalle[i].txtPRECIO_UNIT_SIN_IGV = ((LisVenRep[i].fPrecioVenta - LisVenRep[i].fIgvDetalle) / LisVenRep[i].nCodigo).ToString();
                        data.detalle[i].txtPRECIO_TIPO_CODIGO = "01";
                        data.detalle[i].txtIGV = LisVenRep[i].fIgvDetalle.ToString();
                        data.detalle[i].txtISC = "0";
                        data.detalle[i].txtIMPORTE_TOTAL = LisVenRep[i].fIgvDetalle.ToString();
                        data.detalle[i].txtIMPORTE_TOTAL_SIN_IGV = (LisVenRep[i].fPrecioVenta - LisVenRep[i].fIgvDetalle).ToString();
                        data.detalle[i].txtCODIGO_DET = (i + 1).ToString();
                        data.detalle[i].txtDESCRIPCION_DET = LisVenRep[i].sCodigoInterno + "-" + LisVenRep[i].sProducto;
                        data.detalle[i].txtCODIGO_PROD_SUNAT = "";
                        data.detalle[i].txtAFECTACION_CODIGO = LisVenRep[0].bIgvAplica ? "1000" : "9997";
                        data.detalle[i].txtAFECTACION_CODIGO_ALT = LisVenRep[0].bIgvAplica ? "10" : "20";
                        data.detalle[i].txtAFECTACION_NOMBRE = LisVenRep[0].bIgvAplica ? "IGV": "EXO";
                        data.detalle[i].txtAFECTACION_TIPO = "VAT";
                    }

                    string SerializeRequestPerOutput = JsonConvert.SerializeObject(data);
                    Log.Info("Inicio de Not. Sunat: " + DateTime.Now + "->" + data.serie_comprobante +"-"+ data.numero_comprobante);

                    var resultado = objneg.RegistroDocumentoFe(SerializeRequestPerOutput);

                    if (resultado.code.Equals("200") && resultado.data.respuesta.Equals("ok"))
                    {
                        Log.Info("Fin de Not. Sunat: " + DateTime.Now + "->" + data.serie_comprobante +"-"+ data.numero_comprobante + "->" + resultado.mensaje);

                        Venta objVentaFE = new Venta();
                        objVentaFE.nIdVenta = LisVenRep[0].nIdVenta;
                        objVentaFE.sCdr = resultado.data.cdr;
                        objVentaFE.sUsuario = Funciones.UsuarioActual();

                        int resp = objVentNeg.ActualizarVentaNotficacionSunat(objVentaFE);

                        if (resp > 0)
                        {
                            File.WriteAllText(Path.Combine(_RutaArchivosXml, resultado.data.nombre_file + ".xml"), resultado.data.xml);
                        }

                        return true;
                    }
                    else
                    {
                        Log.Error("Error de Not. Sunat: " + DateTime.Now + "->" + data.serie_comprobante +"-"+ data.numero_comprobante + " " + resultado.mensaje);
                        MessageBox.Show(resultado.mensaje.ToString(), "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Error de Not. Sunat:"+ ex.Message+"->" + data.serie_comprobante +"-"+ data.numero_comprobante);
                    return false;
                }

            }
            else
            {
                return true;
            } 
        }

        private void ImprimirComprobante()
        {
            var instance = new System.Drawing.Printing.PrinterSettings();
            string impresosaPredt = instance.PrinterName;
            ReportDocument Rep = new ReportDocument();

            Venta objVenta = new Venta() { nTipo = 8, nIdVenta = nidVentaRespu };
            List<Venta> LisVenRep = objVentNeg.ListarVentas(objVenta);
            List<ReciboRpt> LisRecibo = new List<ReciboRpt>();

            if (LisVenRep.Count == 0)
            {
                MessageBox.Show("No se puede imprimir", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Ticket
            if (LisVenRep[0].sIdDocumento.Equals("12"))
            {
                try
                {
                    foreach (var item in LisVenRep)
                    {
                        ReciboRpt reciboRpt = new ReciboRpt();
                        reciboRpt.sDocumento = item.sDescripDocumento;
                        reciboRpt.nNumero = string.Format("{0:00000000}", item.nNumero); 
                        reciboRpt.fTotal = item.fTotal;
                        reciboRpt.fPrecio = item.fPrecioVenta;
                        reciboRpt.nCantidad = item.nCodigo;
                        reciboRpt.sIdVendedor = item.sIdVendedor;
                        reciboRpt.sNombre = item.sNombre;
                        reciboRpt.fDescuento = item.fDescuento;
                        reciboRpt.sProducto = item.sProducto;
                        reciboRpt.sFechaRegistro = item.dFecha.ToShortDateString();
                        LisRecibo.Add(reciboRpt);
                    }
                    
                    Rep.Load(Application.StartupPath + "\\RptRecibo.rpt");
                    //Rep.Load("D:\\PROYECTOS_VS_2015\\AppSGV\\AppInguiri\\Reporte"+"\\RptRecibo.rpt");

                    Rep.SetDataSource(LisRecibo);
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message.ToString(), "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            //Factura O boleta
            else 
            {
                try
                {

                    cliente = objCliNeg.LeerCliente(LisVenRep[0].nIdCliente);

                    string sSerie = "", sDescripcionDocumento="", sSigla="", sPaginaPie="", sTipoDoc="";

                    if (cliente.sDni.Length > 8)
                    {
                        sTipoDoc = "6";
                    }
                    else
                    {
                        if (cliente.sDni.Length.Equals("00000000"))
                        {
                            sTipoDoc = "0";
                        }
                        else
                        {
                            sTipoDoc = "1";
                        }
                    }
                    
                    if (LisVenRep[0].sIdDocumento.Equals("01"))
                    {
                        sDescripcionDocumento = "FACTURA ELECTRÓNICA";
                        sSigla = "F";
                        sPaginaPie = "Representación impresa de la FACTURA DE VENTA ELECTRÓNICA";
                        //Ruc
                        sTipoDoc = "6";
                    }
                    else
                    {
                        sDescripcionDocumento = "BOLETA ELECTRÓNICA";
                        sSigla = "B";
                        sPaginaPie = "Representación impresa de la BOLETA DE VENTA ELECTRÓNICA";
                        sTipoDoc = "DNI";
                    }

                    foreach (var item in LisVenRep)
                    {
                        ReciboRpt reciboRpt = new ReciboRpt();
                        sSerie = sSigla + item.sSerie;
                        reciboRpt.sDocumento = sDescripcionDocumento;
                        reciboRpt.nNumero = sSerie + "-" + string.Format("{0:00000000}", item.nNumero);
                        reciboRpt.fTotal = item.fTotal;
                        reciboRpt.fPrecio = item.fPrecioVenta;
                        reciboRpt.fPrecioUnitario =decimal.Round((item.fPrecioVenta / item.nCodigo),2);
                        reciboRpt.nCantidad = item.nCodigo;
                        reciboRpt.sIdVendedor = item.sIdVendedor;
                        reciboRpt.sNombre = item.sNombre;
                        reciboRpt.sPaginaPie = sPaginaPie;
                        reciboRpt.sPaginaTextoExo = item.bIgvAplica?"": "BIENES TRANSFERIDOS EN LA AMAZONÍA PARA SER CONSUMIDOS EN LA MISMA";
                        reciboRpt.fDescuento = item.fDescuento;
                        reciboRpt.fIgv = item.fIgv;
                        reciboRpt.sDireccion = cliente.sDireccion.Length == 0 ? "-" : cliente.sDireccion;
                        reciboRpt.fSubTotal = item.fSubTotal;
                        reciboRpt.fExogerado = item.bIgvAplica ? 0.0M : item.fTotal;
                       reciboRpt.sProducto = item.sProducto;
                        reciboRpt.sFechaRegistro = item.dFecha.ToShortDateString();
                        reciboRpt.sTotalLetras = Funciones.NumeroALetras(item.fTotal);
                        reciboRpt.yCodigoQR = ImageToByte(codigoQR(sRuc + "|" + item.sIdDocumento + "|" 
                            + sSerie+"|"+ string.Format("{0:00000000}",item.nNumero + "|" + item.fPorcentajeIgv.ToString() + "|"
                            + item.fTotal.ToString() + "|"
                            +item.dFecha.ToShortDateString()+"|"
                            + sTipoDoc +"|"+ cliente.sDni)));
                        reciboRpt.sRuc = cliente.sDni;
                        LisRecibo.Add(reciboRpt);
                    }
                    

                    Rep.Load(Application.StartupPath + "\\RptDocumentoFE.rpt");
                    //Rep.Load("D:\\PROYECTOS_VS_2015\\AppSGV\\AppInguiri\\Reporte"+"\\RptRecibo.rpt");

                    Rep.SetDataSource(LisRecibo);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message.ToString(), "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            Rep.PrintOptions.PrinterName = impresosaPredt;
            Rep.PrintToPrinter(1, false, 0, 0);
            nidVentaRespu = 0;
            Rep = null;
        }

        protected static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        protected Image codigoQR(string snumero)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            string sParametros = snumero;
            qrEncoder.TryEncode(sParametros, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, System.Drawing.Imaging.ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(150, 150)));
            return imagen;
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
                FrmProductoListar frmProductoListar = new FrmProductoListar();
                frmProductoListar.xTipo = 1;
                frmProductoListar.frmVenta = frmInstance;
                frmProductoListar.ShowDialog();
                
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
            cboDocumento.SelectedIndex = 0;
            cboTipo.SelectedIndex = 0;
            txtDia.Enabled = false;
            txtDescripcion.Focus();
            lblNumero.Text = "";
            lblSerie.Text="";
            txtDia.Clear();
            fTotal = 0M;
            fIgvResto = 0M;
            fSubTotal2 = 0M;
            cboDocumento.SelectedIndex = DocDefault;
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
            else if (cboDocumento.Text.Equals(""))
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
            else if (cboTipo.SelectedIndex == 1)
            {
                if (txtDia.Text.Equals(""))
                {
                    MessageBox.Show("El campo Dias se encuentra vacía, por favor ingrese un valor", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resp = false;
                }
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