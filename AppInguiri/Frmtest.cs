using Comun;
using Entidad;
using Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppInguiri
{
    public partial class Frmtest : Form
    {
        
        WsRestServiceDocumentoFeNegocio objneg = new WsRestServiceDocumentoFeNegocio();
        
        public Frmtest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            //data.total_letras = Funciones.NumeroALetras(523.20); //"CINCUENTA Y 00/100 SOLES";
            data.nro_guia_remision = "null";
            data.cod_guia_remision = "null";
            data.nro_otr_comprobante = "null";
            data.condicion_pago = "CONTADO";
            data.serie_comprobante = "F001";
            data.numero_comprobante = "00000596";
            data.fecha_comprobante = "2022-01-20";
            data.fecha_vto_comprobante = "2022-01-20";
            data.cliente_tipo_doc = "01";
            data.moneda_cod = "PEN";
            data.tipo_tributo = "IGV";
            data.tipo_igv = "1000";
            //data. = "20160123517";
            data.cliente_nombre = "COOPERATIVA DE SERVICIOS ESPECIALES PACHACUTEC LTDA";
            data.cliente_tipo_doc = "6";
            data.cliente_direccion = "null";
            data.cliente_pais = "PE";
            data.cliente_codigo_ubigeo = "null";
            data.cliente_departamento = "null";
            data.cliente_provincia = "null";
            data.cliente_distrito = "null";

            data.detalle = new detalle[1];
            data.detalle[0] = new detalle();

            data.detalle[0].txtITEM = "1";
            
            data.detalle[0].txtUNIDAD_MEDIDA_DET = "ZZ";
            data.detalle[0].txtCANTIDAD_DET = "1.00";
            data.detalle[0].txtPRECIO_UNIT = "50.00";
            data.detalle[0].txtPRECIO_UNIT_SIN_IGV = "42.37";
            data.detalle[0].txtPRECIO_TIPO_CODIGO = "01";
            data.detalle[0].txtIGV = "7.63";
            data.detalle[0].txtISC = "0";
            data.detalle[0].txtIMPORTE_TOTAL = "50.00";
            data.detalle[0].txtIMPORTE_TOTAL_SIN_IGV = "42.37";
            data.detalle[0].txtCODIGO_DET = "1";
            data.detalle[0].txtDESCRIPCION_DET = "DD DSDS DSD";
            data.detalle[0].txtCODIGO_PROD_SUNAT = "78181505";
            data.detalle[0].txtAFECTACION_CODIGO = "1000";
            data.detalle[0].txtAFECTACION_CODIGO_ALT = "10";
            data.detalle[0].txtAFECTACION_NOMBRE = "IGV";
            data.detalle[0].txtAFECTACION_TIPO = "VAT";
            
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
            data.emisor.usuariosol = "MODDATOS";
            data.emisor.clavesol = "moddatos";
            data.emisor.clave_certificado = "123456";
            data.emisor.url_xml = "beta/";
            data.emisor.url_ws = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService";
            data.emisor.codigo_estab_anexo_sun = "0000";

            string SerializeRequestPerOutput = JsonConvert.SerializeObject(data);

            var resultado = objneg.RegistroDocumentoFe(SerializeRequestPerOutput,1);

            MessageBox.Show("Mensaje " + resultado.mensaje);

        }
    }
}
