using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class WsDocumentoFeResponseData
    {
        public string tipo_operacion { get; set; }
        public string total_gravadas { get; set; }
        public string total_inafecta { get; set; }
        public string total_exoneradas { get; set; }
        public string total_gratuitas { get; set; }
        public string total_exportacion { get; set; }
        public string total_descuento { get; set; }
        public string sub_total { get; set; }
        public string porcentaje_igv { get; set; }
        public string total_igv { get; set; }
        public string total_isc { get; set; }
        public string total_otr_imp { get; set; }
        public string total { get; set; }
        public string total_letras { get; set; }
        public string nro_guia_remision { get; set; }
        public string cod_guia_remision { get; set; }
        public string nro_otr_comprobante { get; set; }
        public string condicion_pago { get; set; }
        public string serie_comprobante { get; set; }
        public string numero_comprobante { get; set; }
        public string fecha_comprobante { get; set; }
        public string fecha_vto_comprobante { get; set; }
        public string tipo_comprobante_cod { get; set; }
        public string moneda_cod { get; set; }
        public string tipo_tributo { get; set; }
        public string tipo_igv { get; set; }

        public string cliente_nro_doc { get; set; }
        public string cliente_nombre { get; set; }
        public string cliente_tipo_doc { get; set; }
        public string cliente_direccion { get; set; }
        public string cliente_pais { get; set; }
        public string cliente_codigo_ubigeo { get; set; }
        public string cliente_departamento { get; set; }
        public string cliente_provincia { get; set; }
        public string cliente_distrito { get; set; }

        public detalle[] detalle { get; set; }
        public emisor emisor { get; set; }

    }

    public class detalle
    {
        public string txtITEM { get; set; }
        public string txtUNIDAD_MEDIDA_DET { get; set; }
        public string txtCANTIDAD_DET { get; set; }
        public string txtPRECIO_UNIT { get; set; }
        public string txtPRECIO_UNIT_SIN_IGV { get; set; }
        public string txtPRECIO_TIPO_CODIGO { get; set; }
        public string txtIGV { get; set; }
        public string txtISC { get; set; }
        public string txtIMPORTE_TOTAL { get; set; }
        public string txtIMPORTE_TOTAL_SIN_IGV { get; set; }
        public string txtCODIGO_DET { get; set; }
        public string txtDESCRIPCION_DET { get; set; }
        public string txtCODIGO_PROD_SUNAT { get; set; }
        public string txtAFECTACION_CODIGO { get; set; }
        public string txtAFECTACION_CODIGO_ALT { get; set; }
        public string txtAFECTACION_NOMBRE { get; set; }
        public string txtAFECTACION_TIPO { get; set; }
    }

    public class emisor
    {
        public string ruc { get; set; }
        public string tipo_doc { get; set; }
        public string razon_social { get; set; }
        public string codigo_ubigeo { get; set; }
        public string direccion { get; set; }
        public string direccion_departamento { get; set; }
        public string direccion_provincia { get; set; }
        public string direccion_distrito { get; set; }
        public string direccion_codigopais { get; set; }
        public string usuariosol { get; set; }
        public string clavesol { get; set; }
        public string clave_certificado { get; set; }
        public string url_xml { get; set; }
        public string url_ws { get; set; }
        public string codigo_estab_anexo_sun { get; set; }
    }

}
