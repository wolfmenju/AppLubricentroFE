using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ProductoHistorial
    {
        public ProductoHistorial()
        {
            this.nIdProductoHistorial = 0;
            this.nIdProducto = 0;
            this.nIdAlmacen = 0;
            this.sLote = "";
            this.sAlmacen = "";
            this.sNombreProducto = "";
            this.sLaboratorio = "";
            this.nIdLote = 0;
            this.sIdLote = "";
            this.fPrecioCompra = 0.0M;
            this.fGanancia = 0.0M;
            this.fPrecioVenta = 0.0M;
            this.nStock = 0;
            this.dFechaVencimiento = DateTime.Now;
            this.bSeleccionar = false;
            this.sUsuario = "";
            this.bEstado = true;
            this.sCodigoInterno = "";

        }
        
        public int nTipo { get; set; }
        public int nIdProductoHistorial { get; set; }
        public int nIdProducto { get; set; }
        public string sCodigoInterno { get; set; }
        public int nIdAlmacen { get; set; }
        public string sLote { get; set; }
        public string sIdLote { get; set; }
        public string sAlmacen { get; set; }
        public string sLaboratorio { get; set; }
        public string sNombreProducto { get; set; }
        public int nIdLote { get; set; }
        public decimal? fPrecioCompra { get; set; }
        public decimal fGanancia { get; set; }
        public decimal? fPrecioVenta { get; set; }
        public int? nStock { get; set; }
        public DateTime? dFechaVencimiento { get; set; }
        public bool bSeleccionar { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }

    }
}
