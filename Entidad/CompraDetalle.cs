using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CompraDetalle
    {
        public CompraDetalle()
        {
            this.nIdMovimiento = 0;
            this.nIdCompraDetalle = 0;
            this.dFechaVencimiento = DateTime.Now;
        }

        public int nIdMovimiento { get; set; }
        public int nIdCompraDetalle { get; set; }
        public int nIdTarjeta { get; set; }
        public int nIdProducto { get; set; }
        public string sLote { get; set; }
        public DateTime dFechaVencimiento { get; set; }
        public int nCantidad { get; set; }
        public decimal fPrecioCompra { get; set; }
        public decimal fGanancia { get; set; }
        public decimal fPrecioVenta { get; set; }
        public decimal fSubTotal { get; set; }
        
    }
}
