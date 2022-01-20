using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Compra
    {
        public Compra()
        {
            this.nIdCompra = 0;
            this.nIdAlmacen = 0;
            this.sIdDocumento = "";
            this.sSerie = "";
            this.nNumero = 0;
            this.dFecha = DateTime.Now;
            this.nPorcentaje = 0;
            this.fSubTotal = 0M;
            this.fIgv = 0M;
            this.fTotal = 0M;
            this.nIdProveedor = 0;
            this.bCredito = false;
            this.nDias = 0;
            this.sUsuario = "";
            this.bEstado = true;
            this.nCodigo = 0;
            this.listCompraDetalle = new List<CompraDetalle>();
            this.nIdHistorial = 0;
            this.nIdTarjeta = 0;
            this.sRazonSocial = "";
            this.sProducto = "";
        }
        
        public int nTipo { get; set; }
        public int nIdCompra { get; set; }
        public int nIdAlmacen { get; set; }
        public string sIdDocumento { get; set; }
        public string sProducto { get; set; }
        public string sSerie { get; set; }
        public string sRuc { get; set; }
        public string sRazonSocial { get; set; }
        public int nNumero { get; set; }
        public DateTime dFecha { get; set; }
        public int nPorcentaje { get; set; }
        public decimal fSubTotal { get; set; }
        public decimal fIgv { get; set; }
        public decimal fTotal { get; set; }
        public int nIdProveedor { get; set; }
        public bool bCredito { get; set; }
        public int nDias { get; set; }
        public String sUsuario { get; set; }
        public bool bEstado { get; set; }
        public int nCodigo { get; set; }

        public int nIdHistorial { get; set; }
        public int nIdTarjeta { get; set; }

        public List<CompraDetalle> listCompraDetalle { get; set; }
    }
}
