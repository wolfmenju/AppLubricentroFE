using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class InventarioDetalle
    {
        public InventarioDetalle()
        {
            this.nTipo = 0;
            this.nIdDetalleInventario = 0;
            this.nIdInventario = 0;
            this.nIdProducto = 0;
            this.sIdLote = "";
            this.dFechaVencimiento = DateTime.Now;
            this.nStock = 0;
            this.fPrecioCompra = 0M;
            this.fGanancia = 0M;
            this.fPrecioVenta = 0M;
            this.nSubTipo = 0;
            this.nIdTarjeta = 0;
            this.dFecha = DateTime.Now;
            this.nIdAlmacen = 0;
            this.bTipoMovimiento = false;
            this.nIdReferencia = 0;
            this.sIdDocumento = "";
            this.sSerie = "";
            this.nNumero = 0;
            this.nEntrada =0;
            this.nSalida = 0;
            this.nExistencia = 0;
            this.fCostoUnitario = 0M;
            this.fCostoPromedio = 0M;
            this.fDebe = 0;
            this.fHaber = 0;
            this.fSaldo = 0M;
            this.nIdHistorial = 0;
            this.sLote = "";
            this.sUsuario = "";
            this.bEstado = false;
        }


        public int nTipo { get; set; }
        public int nIdDetalleInventario { get; set; }
        public int nIdInventario { get; set; }
        public int nIdProducto { get; set; }
        public string sIdLote { get; set; }
        public DateTime dFechaVencimiento { get; set; }
        public int nStock { get; set; }
        public decimal? fPrecioCompra { get; set; }
        public decimal fGanancia { get; set; }
        public decimal? fPrecioVenta { get; set; }
        public int nSubTipo { get; set; }
        public int nIdTarjeta { get; set; }
        public DateTime dFecha { get; set; }
        public int nIdAlmacen { get; set; }
        public bool bTipoMovimiento { get; set; }
        public int nIdReferencia { get; set; }
        public string sIdDocumento { get; set; }
        public string sSerie { get; set; }
        public int nNumero { get; set; }
        public int nEntrada { get; set; }
        public int nSalida { get; set; }
        public int nExistencia { get; set; }
        public decimal fCostoUnitario { get; set; }
        public decimal fCostoPromedio { get; set; }
        public decimal fDebe { get; set; }
        public decimal fHaber { get; set; }
        public decimal fSaldo { get; set; }
        public int nIdHistorial { get; set; }
        public string sLote { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
    }
}
