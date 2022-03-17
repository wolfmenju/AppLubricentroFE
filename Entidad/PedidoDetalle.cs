using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class PedidoDetalle
    {
        public PedidoDetalle()
        {
            this.nTipo = 0;
            this.dFechaVencimiento = DateTime.Now;
            this.nIdPedidoDetalle = 0;
            this.nIdPedido = 0;
            this.nIdProducto = 0;
            this.nIdTarjeta = 0;
            this.nCantidad = 0;
            this.fPrecioCompra = 0.0M;
            this.fPrecioVenta = 0.0M;
            this.fGanancia = 0.0M;
            this.sLote = "";
            this.sUsuario = "";
            this.bEstado = false;
            this.bServicio = false;

        }

        public int nTipo { get; set; }
        public int nIdPedidoDetalle { get; set; }
        public int nIdPedido { get; set; }
        public int nIdProducto { get; set; }
        public int nIdTarjeta { get; set; }
        public int nCantidad { get; set; }
        public decimal fPrecioCompra { get; set; }
        public decimal fGanancia { get; set; }
        public decimal fPrecioVenta { get; set; }
        public string sLote { get; set; }
        public DateTime dFechaVencimiento { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
        public bool bServicio { get; set; }
    }
}
