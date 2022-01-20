using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Salida
    {
        public Salida()
        {
            this.nIdVenta = 0;
            this.nIdProducto = 0;
            this.nIdAlmacen = 0;
            this.nIdPedido = 0;
            this.sIdDocumento = "";
            this.sLaboratorio = "";
            this.sProducto = "";
            this.sSerie = "";
            this.nNumero = 0;
            this.dFecha = DateTime.Now;
            this.nPorcentaje = 0;
            this.fDescuento = 0M;
            this.fSubTotal = 0M;
            this.fIgv = 0M;
            this.fPrecioVenta = 0M;
            this.fTotal = 0M;
            this.nIdProveedor = 0;
            this.sNombre = "";
            this.sIdVendedor = "";
            this.sIdCajero = "";
            this.nCodigo = 0;
            this.sUsuario = "";
            this.bAlternativo = false;
            this.bEstado = true;
            this.listSalidaDetalle = new List<SalidaDetalle>();
            this.nIdHistorial = 0;
            this.nIdTarjeta = 0;
        }
        
        public int nTipo { get; set; }
        public int nIdVenta { get; set; }
        public int nIdProducto { get; set; }
        public int nIdAlmacen { get; set; }
        public int nIdPedido { get; set; }
        public string sIdDocumento { get; set; }
        public string sLaboratorio { get; set; }
        public string sProducto { get; set; }
        public string sSerie { get; set; }
        public int? nNumero { get; set; }
        public DateTime dFecha { get; set; }
        public DateTime dFechaRegistrado { get; set; }
        public int nPorcentaje { get; set; }
        public decimal fDescuento { get; set; }
        public decimal fSubTotal { get; set; }
        public decimal fIgv { get; set; }
        public decimal fPrecioVenta { get; set; }
        public decimal fTotal { get; set; }
        public int nIdProveedor { get; set; }
        public string sNombre { get; set; }
        public string sIdVendedor { get; set; }
        public string sIdCajero { get; set; }
        public int nCodigo { get; set; }
        public String sUsuario { get; set; }
        public bool bAlternativo { get; set; }
        public bool bEstado { get; set; }
        public int nIdHistorial { get; set; }
        public int nIdTarjeta { get; set; }

        public List<SalidaDetalle> listSalidaDetalle { get; set; }
    }
}
