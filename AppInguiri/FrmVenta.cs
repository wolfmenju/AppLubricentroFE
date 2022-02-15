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
        int DocDefault = 0;
        int nidVentaRespu = 0;
        WsRestServiceDocumentoFeNegocio objneg = new WsRestServiceDocumentoFeNegocio();

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
            lblIgv.Text = ((fIgv / 100) * fTotal).ToString("C");
            lblSubtotal.Text = (fTotal - ((fIgv / 100) * fTotal)).ToString("C");
            fSubTotal2 = decimal.Round((fTotal - ((fIgv / 100) * fTotal)), 2);
            fTotal = decimal.Round(fTotal, 2);
            fIgvResto = decimal.Round(((fIgv / 100) * fTotal), 2);
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
                frmDescuento.txtPago.Text = Convert.ToDecimal(row.Cells["fSubTotal"].Value).ToString("#0.00");
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
                lblNumero.Text = string.Format("{0:0000000000}", item.nUltimo + 1);
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
            if (dgvProducto.Rows.Count==0) return;

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
                objVenta.fSubTotal = fSubTotal2;
                objVenta.fIgv = fIgvResto;
                objVenta.fTotal = fTotal;
                objVenta.fPorcentajeIgv = (decimal)fIgv;
                objVenta.sUsuario = Funciones.UsuarioActual();
                objVenta.sIdCajero = Funciones.UsuarioActual();
                objVenta.sIdVendedor = txtPedido.Text.Length > 0 ? lblVendedor.Text : Funciones.UsuarioActual();

                foreach (DataGridViewRow item in dgvProducto.Rows)
                {
                    objVentDeta = new VentaDetalle();
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

                objVenta.listVentaDetalle = listVentDeta;

                nidVentaRespu = objVentNeg.RegistrarVenta(objVenta);

                if (nidVentaRespu > 0)
                {
                    //Metodo para nofiticar a Sunat
                    if (NotificacionSunat(nidVentaRespu))
                    {
                        MessageBox.Show("La Venta Se Realizó Con Éxito", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La Venta Se Realizó Con Éxito pero hubo problemas en la notificación a Sunat.", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    LimpiarValores();
                    CargaSerieDocumento();
                    Contado();

                    if (MessageBox.Show("¿Desea Imprimir El Comprobante?", "Informativo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ImprimirComprobante();
                    }
                    else
                    {
                        nidVentaRespu = 0;
                    }
                }
                else
                {
                    MessageBox.Show("La Venta No Se Pudo Realizar", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private bool NotificacionSunat( int nidVentaRespu)
        {
            Venta objVenta = new Venta() { nTipo = 8, nIdVenta = nidVentaRespu };

            List<Venta> LisVenRep = objVentNeg.ListarVentas(objVenta);

            if (LisVenRep.Count == 0)
            {
                WsDocumentoFeResponseData data = new WsDocumentoFeResponseData();
                data.tipo_operacion = "0101";
                data.total_gravadas = "42.37";
                data.total_inafecta = "0.00";
                data.total_exoneradas = "0.00";
                data.total_gratuitas = "0.00";
                data.total_exportacion = "0.00";
                data.total_descuento = "0.00";
                data.sub_total = "42.37";
                data.porcentaje_igv = "18.00";
                data.total_igv = "7.63";
                data.total_isc = "0.00";
                data.total_otr_imp = "0.00";
                data.total = "50.00";
                data.total_letras =Funciones.NumerosLetras(50);
                data.nro_guia_remision = "null";
                data.cod_guia_remision = "null";
                data.nro_otr_comprobante = "null";
                data.condicion_pago = "CONTADO";
                data.serie_comprobante = "F001";
                data.numero_comprobante = "00000596";
                data.fecha_comprobante = "2022-01-20";
                data.fecha_vto_comprobante = "2022-01-20";
                data.cod_tipo_documento = "01";
                data.cod_moneda = "PEN";
                data.tipo_tributo = "IGV";
                data.tipo_igv = "1000";
                data.cliente_numerodocumento = "20160123517";
                data.cliente_nombre = "COOPERATIVA DE SERVICIOS ESPECIALES PACHACUTEC LTDA";
                data.cliente_tipodocumento = "6";
                data.cliente_direccion = "null";
                data.cliente_pais = "PE";
                data.cliente_ciudad = "null";
                data.cliente_codigoubigeo = "null";
                data.cliente_departamento = "null";
                data.cliente_provincia = "null";
                data.cliente_distrito = "null"; 
                data.detalle = new detalle[LisVenRep.Count];

                for (int i = 0; i < LisVenRep.Count; i++)
                {
                    data.detalle[i] = new detalle();
                    data.detalle[i].txtITEM = (i+1).ToString();
                    data.detalle[i].txtUNIDAD_MEDIDA_DET = "ZZ";
                    data.detalle[i].txtCANTIDAD_DET = "1.00";
                    data.detalle[i].txtPRECIO_UNIT = "50.00";
                    data.detalle[i].txtPRECIO_UNIT_SIN_IGV = "42.37";
                    data.detalle[i].txtPRECIO_TIPO_CODIGO = "01";
                    data.detalle[i].txtIGV = "7.63";
                    data.detalle[i].txtISC = "0";
                    data.detalle[i].txtIMPORTE_TOTAL = "50.00";
                    data.detalle[i].txtIMPORTE_TOTAL_SIN_IGV = "42.37";
                    data.detalle[i].txtCODIGO_DET = "1";
                    data.detalle[i].txtDESCRIPCION_DET = "DD DSDS DSD";
                    data.detalle[i].txtCODIGO_PROD_SUNAT = "78181505";
                    data.detalle[i].txtAFECTACION_CODIGO = "1000";
                    data.detalle[i].txtAFECTACION_CODIGO_ALT = "10";
                    data.detalle[i].txtAFECTACION_NOMBRE = "IGV";
                    data.detalle[i].txtAFECTACION_TIPO = "VAT";
                }
                
                data.cuotas = new cuotas();
                data.cuotas.detalle_cuota = "Cuota001";
                data.cuotas.total_cuota = "50.00";
                data.emisor = new emisor();
                data.emisor.ruc = "20100066603";
                data.emisor.tipo_doc = "6";
                data.emisor.razon_social = "CITV LIDER SUR S.R.L.";
                data.emisor.codigo_ubigeo = "210101";
                data.emisor.direccion = "MZA. Ñ LOTE. 06 PARQUE INDUSTRIAL (COSTADO DE SENATI NUEVO) PUNO - PUNO - PUNO";
                data.emisor.direccion_departamento = "Puno";
                data.emisor.direccion_provincia = "Puno";
                data.emisor.direccion_distrito = "Puno";
                data.emisor.direccion_codigopais = "PE";
                data.emisor.sede = "Test";
                data.emisor.usuariosol = "MODDATOS";
                data.emisor.clavesol = "moddatos";
                data.emisor.clave_certificado = "123456";
                data.emisor.url_xml = "beta/";
                data.emisor.url_ws = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService";
                data.emisor.codigo_estab_anexo_sun = "0000";
                string SerializeRequestPerOutput = JsonConvert.SerializeObject(data);
                var resultado = objneg.RegistroDocumentoFe(SerializeRequestPerOutput);

                if (resultado.code == "200")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
            }

            return true;
        }

        private void ImprimirComprobante()
        {
            var instance = new System.Drawing.Printing.PrinterSettings();
            string impresosaPredt = instance.PrinterName;
            ReportDocument Rep = new ReportDocument();
            List<ReciboRpt> LisRecibo = new List<ReciboRpt>();

            try
            {
                Venta objVenta = new Venta() { nTipo = 8, nIdVenta = nidVentaRespu };
                
                List<Venta> LisVenRep = objVentNeg.ListarVentas(objVenta);

                if (LisVenRep.Count ==0)
                {
                    MessageBox.Show("No se puede imprimir", "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombre_Up = "";
                string nombre_Lo = "";
                
                foreach (var item in LisVenRep)
                {
                    nombre_Up = item.sIdDocumento;
                    nombre_Lo = nombre_Up.ToLower();
                   
                    ReciboRpt reciboRpt = new ReciboRpt();
                    reciboRpt.sDocumento = nombre_Lo.Replace(nombre_Lo[0], nombre_Up[0]);
                    reciboRpt.nNumero =Convert.ToInt32(item.nNumero);
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
                Rep.PrintOptions.PrinterName = impresosaPredt;
                Rep.PrintToPrinter(1, false, 0, 0);
                nidVentaRespu = 0;
                Rep = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message.ToString(), "InguiriSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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