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
using Newtonsoft.Json;
using Comun;
using CrystalDecisions.CrystalReports.Engine;
using AppInguiri.EntidadReporte;
using System.IO;
using log4net;
using System.Configuration;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace AppInguiri
{
    public partial class FrmVentaListar : Form
    {
        #region Variables Privadas
        private VentaNegocio objVentNeg = new VentaNegocio();
        private bool cerrarFormulario = true;
        private bool? xBandero = false;
        private List<Venta> ListVenta = new List<Venta>();
        private Cliente cliente = new Cliente();
        private ClienteNegocio objCliNeg = new ClienteNegocio();
        private static ILog Log = LogManager.GetLogger(typeof(FrmVentaListar));
        private ParametroNegocio objParamNeg = new ParametroNegocio();
        private WsRestServiceDocumentoFeNegocio objneg = new WsRestServiceDocumentoFeNegocio();
        string sDireccion = "", sRuc = "", sRazonSocial = "",
            sUbigeo = "", sDepart = "", sProvi = "", sDist = "",
            _sUrlSunat = "", _RutaArchivosXml = "",
            sUserSunat = "", sPassSunat = "", sCertClaSunat = "",
            sUrlXmlSunat = "";

        #endregion

        public FrmVentaListar()
        {
            InitializeComponent();
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
            sUserSunat = objParamNeg.LeerUnParametro("ID_USER_SUNAT");
            sPassSunat = objParamNeg.LeerUnParametro("ID_PASS_SUNAT");
            sCertClaSunat = objParamNeg.LeerUnParametro("ID_CERT_SUNAT");
            sUrlXmlSunat = objParamNeg.LeerUnParametro("ID_URL_XML_SUNAT");
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ListarVenta();
        }

        private void ListarVenta()
        {
            if (dFechaFin.Value.Date < dFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de final no puede ser menor a la fecha inicial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }  

            Venta objVenta = new Venta()
            {
                nTipo=2,
                dFecha=dFechaInicio.Value,
                sSerie=dFechaFin.Value.ToString("yyyyMMdd"),
                nIdAlmacen=Funciones.CodAlmacenActual()
            };

            List<Venta> ListVentas= objVentNeg.ListarVentas(objVenta);

            if (ListVentas.Count > 0)
            {
                dgvVenta.AutoGenerateColumns = false;
                dgvVenta.DataSource = ListVentas;
            }
            else
            {
                dgvVenta.DataSource = null;
            }

            LblTotal.Text = "Se Encontraron " + dgvVenta.Rows.Count + " Registros";
            cerrarFormulario = false;
        }

        private void FrmVentaListar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarFormulario) e.Cancel = false;
            else e.Cancel = true;

            cerrarFormulario = true;
        }

        private void TabConsulta_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (TabConsulta.SelectedIndex == 0)
            {
                xBandero = true;
                TabConsulta.SelectedTab = TabCompras;
                LblTotal.Text = "Se Encontraron " + dgvDetalle.Rows.Count + " Registros";
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
                if (dgvVenta.RowCount > 0)
                {
                    xBandero = true;
                    TabConsulta.SelectedTab = TabDetalle;
                    xBandero = false;
                    Venta _vent = (Venta)dgvVenta.CurrentRow.DataBoundItem;
                    CargarDetalles(_vent.nIdVenta);
                }
                else
                {
                    cerrarFormulario = false;
                }
            }
        }

        public void CargarDetalles(int nIdVenta)
        {
            dgvDetalle.Rows.Clear();

            if (dgvVenta.RowCount > 0)
            {
                ListVenta.Clear();

                Venta objVenta = new Venta()
                {
                    nTipo = 3,
                    nIdVenta = nIdVenta,
                    bEstado = true
                };

                ListVenta = objVentNeg.ListarVentas(objVenta);

                if (ListVenta.Count > 0)
                {
                    dgvDetalle.AutoGenerateColumns = false;

                    foreach (var item in ListVenta)
                    {
                      dgvDetalle.Rows.Add(item.listVentaDetalle[0].nIdVentaDetalle , item.nIdVenta, item.nIdTarjeta,
                      item.nIdProducto, item.sProducto, item.listVentaDetalle[0].sLote, item.listVentaDetalle[0].nCantidad, 
                      item.listVentaDetalle[0].fPrecioVenta, item.listVentaDetalle[0].fSubTotal, item.listVentaDetalle[0].fDescuento,
                      item.fTotal);
                    }
                }
                else
                {
                    dgvDetalle.Rows.Clear();
                    //dgvDetalle = 0;
                }

                LblTotal.Text = "Se Encontraron " + dgvDetalle.Rows.Count + " Registros";
                cerrarFormulario = false;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            AnularVenta();
        }

        private void AnularVenta()
        {
            if (dgvVenta.RowCount > 0)
            {
                if (dgvVenta.CurrentCell != null || dgvVenta.CurrentCell.RowIndex != 0)
                {
                    int resp = 0;

                    Int32 filaselecionada = dgvVenta.CurrentCell.RowIndex;
                    Venta _venta = (Venta)dgvVenta.Rows[filaselecionada].DataBoundItem;

                    if (Globales.FechaActual().Date != _venta.dFecha)
                    {
                        MessageBox.Show("No puede Anular el Documento con Fecha Anterior a la Fecha Actual.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cerrarFormulario = false;
                        return;
                    }

                    if (MessageBox.Show("¿Desea Anular La Venta Seleccionada?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<VentaDetalle> listVentDeta = new List<VentaDetalle>();
                        VentaDetalle objVentDeta = null;

                        Venta objVenta = new Venta();
                        objVenta.nTipo = 1;
                        objVenta.nIdVenta = _venta.nIdVenta;
                        objVenta.nIdAlmacen = Funciones.CodAlmacenActual();
                        objVenta.dFecha = _venta.dFecha;
                        objVenta.fTotal = _venta.fTotal;
                        objVenta.sUsuario = Funciones.UsuarioActual();
                        CargarDetalles(objVenta.nIdVenta);

                        foreach (DataGridViewRow item in dgvDetalle.Rows)
                        {
                            objVentDeta = new VentaDetalle();
                            objVentDeta.nIdVentaDetalle = Convert.ToInt32(item.Cells["nIdVentaDetalle"].Value);
                            objVentDeta.nIdTarjeta = Convert.ToInt32(item.Cells["nIdTarjeta"].Value);
                            objVentDeta.nIdProducto = Convert.ToInt32(item.Cells["nIdProducto"].Value);
                            objVentDeta.sLote = item.Cells["sLote"].Value.ToString();
                            objVentDeta.nCantidad = Convert.ToInt32(item.Cells["nCantidad"].Value);
                            objVentDeta.fPrecioVenta = Convert.ToDecimal(item.Cells["fPrecioVenta"].Value);
                            objVentDeta.fSubTotal = Convert.ToDecimal(item.Cells["fSubTotal"].Value);
                            objVentDeta.fDescuento = Convert.ToDecimal(item.Cells["fDescuento"].Value);

                            listVentDeta.Add(objVentDeta);
                        }

                        objVenta.listVentaDetalle = listVentDeta;

                        resp= objVentNeg.AnularVenta(objVenta);

                        if (resp > 0)
                        {
                            MessageBox.Show("La Venta Se Anuló Con Exito", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarVenta();
                        }
                        else
                        {
                            MessageBox.Show("La Venta No Se Puede Anular", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }   
                    }
                }
            }

            cerrarFormulario = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvVenta.RowCount < 1)
            {
                MessageBox.Show("No existe Registro.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cerrarFormulario = false;
                return;
            }

            if (dgvVenta.CurrentCell != null || dgvVenta.CurrentCell.RowIndex != 0)
            {
                if (MessageBox.Show("¿Desea Reimprimir El Documento de La Venta Seleccionada?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Int32 filaselecionada = dgvVenta.CurrentCell.RowIndex;
                    Venta _venta = (Venta)dgvVenta.Rows[filaselecionada].DataBoundItem;

                    ImprimirComprobante(_venta.nIdVenta);
                }
            }  
        }

        private void ImprimirComprobante(int nidVentaRespu)
        {
            var instance = new System.Drawing.Printing.PrinterSettings();
            string impresosaPredt = instance.PrinterName;
            ReportDocument Rep = new ReportDocument();

            Venta objVenta = new Venta() { nTipo = 8, nIdVenta = nidVentaRespu };
            List<Venta> LisVenRep = objVentNeg.ListarVentas(objVenta);
            List<ReciboRpt> LisRecibo = new List<ReciboRpt>();

            if (LisVenRep.Count == 0)
            {
                MessageBox.Show("No se puede ReImprimir el Documento", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    string sSerie = "", sDescripcionDocumento = "", sSigla = "", sPaginaPie = "", sTipoDoc = "";

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
                        reciboRpt.fPrecioUnitario = decimal.Round((item.fPrecioVenta / item.nCodigo), 2);
                        reciboRpt.nCantidad = item.nCodigo;
                        reciboRpt.sIdVendedor = item.sIdVendedor;
                        reciboRpt.sNombre = item.sNombre;
                        reciboRpt.sPaginaPie = sPaginaPie;
                        reciboRpt.sPaginaTextoExo = item.bIgvAplica ? "" : "BIENES TRANSFERIDOS EN LA AMAZONÍA PARA SER CONSUMIDOS EN LA MISMA";
                        reciboRpt.fDescuento = item.fDescuento;
                        reciboRpt.fIgv = item.fIgv;
                        reciboRpt.sDireccion = cliente.sDireccion.Length == 0 ? "-" : cliente.sDireccion;
                        reciboRpt.fSubTotal = item.bIgvAplica ? item.fSubTotal: 0.0M;
                        reciboRpt.fExogerado = item.bIgvAplica ? 0.0M : item.fTotal;
                        reciboRpt.sProducto = item.sProducto;
                        reciboRpt.sFechaRegistro = item.dFecha.ToShortDateString();
                        reciboRpt.sTotalLetras = Funciones.NumeroALetras(item.fTotal);
                        reciboRpt.yCodigoQR = ImageToByte(codigoQR(sRuc + "|" + item.sIdDocumento + "|"
                            + sSerie + "|" + string.Format("{0:00000000}", item.nNumero + "|" + item.fPorcentajeIgv.ToString() + "|"
                            + item.fTotal.ToString() + "|"
                            + item.dFecha.ToShortDateString() + "|"
                            + sTipoDoc + "|" + cliente.sDni)));
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
            Rep = null;
            cerrarFormulario = false;
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


        private void FrmVentaListar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BtnBuscar_Click(sender, e);
                    break;
                case Keys.F3:
                    BtnDetalle_Click(sender, e);
                    break;
                case Keys.F4:
                    BtnEliminar_Click(sender, e);
                    break;
                case Keys.F5:
                    btnImprimir_Click(sender, e);
                    break;
                case Keys.F6:
                    btnNotificar_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void btnNotificar_Click(object sender, EventArgs e)
        {
            if (dgvVenta.RowCount > 0)
            {
                if (dgvVenta.CurrentCell != null || dgvVenta.CurrentCell.RowIndex != 0)
                {
                    Int32 filaselecionada = dgvVenta.CurrentCell.RowIndex;
                    Venta _venta = (Venta)dgvVenta.Rows[filaselecionada].DataBoundItem;

                    if (_venta.sIdDocumento.Equals("12"))
                    {
                        MessageBox.Show("El tipo de documento no es válido para notificación a Sunat.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cerrarFormulario = false;
                        return;
                    }

                    if (!_venta.bSunat)
                    {
                        if (MessageBox.Show("¿Desea Notificar a Sunat La Venta Seleccionada?", "InguiriSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (NotificacionSunat(_venta.nIdVenta))
                            {
                                MessageBox.Show("La Notificó del Documento se Realizó Correctamente a Sunat.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ListarVenta();
                            }
                            else
                            {
                                MessageBox.Show("La notificación a Sunat No se Pudo Realizar.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El documento selecionado ya fue nofificado a Sunat.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            cerrarFormulario = false;
        }
        
        private bool NotificacionSunat(int nidVentaRespu)
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
                    data.total_gravadas = LisVenRep[0].bIgvAplica ? (LisVenRep[0].fTotal - Decimal.Round(((LisVenRep[0].fTotal - LisVenRep[0].fIgv) * (LisVenRep[0].fPorcentajeIgv / 100)), 2)).ToString() : "0.00";
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
                    data.cliente_direccion = cliente.sDireccion == "" ? "null" : cliente.sDireccion;

                    data.serie_comprobante = LisVenRep[0].sDescripDocumento.Substring(0, 1) + LisVenRep[0].sSerie;
                    data.numero_comprobante = string.Format("{0:00000000}", LisVenRep[0].nNumero);
                    data.fecha_comprobante = LisVenRep[0].dFechaRegistrado.ToString("yyyy-MM-dd");
                    data.fecha_vto_comprobante = LisVenRep[0].dFechaRegistrado.ToString("yyyy-MM-dd");
                    data.moneda_cod = "PEN";
                    data.tipo_tributo = LisVenRep[0].bIgvAplica ? "IGV" : "EXO";
                    data.tipo_igv = LisVenRep[0].bIgvAplica ? "1000" : "9997";
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
                    data.emisor.usuariosol = sUserSunat;
                    data.emisor.clavesol = sPassSunat;
                    data.emisor.clave_certificado = sCertClaSunat;
                    data.emisor.url_xml = sUrlXmlSunat;
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
                        data.detalle[i].txtAFECTACION_NOMBRE = LisVenRep[0].bIgvAplica ? "IGV" : "EXO";
                        data.detalle[i].txtAFECTACION_TIPO = "VAT";
                    }

                    string SerializeRequestPerOutput = JsonConvert.SerializeObject(data);
                    Log.Info("Inicio de Not. Sunat: " + DateTime.Now + "->" + data.serie_comprobante + "-" + data.numero_comprobante);

                    var resultado = objneg.RegistroDocumentoFe(SerializeRequestPerOutput);

                    if (resultado.code.Equals("200") && resultado.data.respuesta.Equals("ok"))
                    {
                        Log.Info("Fin de Not. Sunat: " + DateTime.Now + "->" + data.serie_comprobante + "-" + data.numero_comprobante + "->" + resultado.mensaje);

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
                        Log.Error("Error de Not. Sunat: " + DateTime.Now + "->" + data.serie_comprobante + "-" + data.numero_comprobante + " " + resultado.mensaje);
                        MessageBox.Show(resultado.mensaje.ToString(), "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Error de Not. Sunat:" + ex.Message + "->" + data.serie_comprobante + "-" + data.numero_comprobante);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

    }
}
