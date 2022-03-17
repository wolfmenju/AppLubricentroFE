using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Pedido
    {
        public Pedido()
        {
            this.nTipo = 0;
            this.nIdAlmacen = 0;
            this.nIdPedido = 0;
            this.nNumero = 0;
            this.dFecha = DateTime.Now;
            this.fPorcentajeIgv = 0M;
            this.fSubTotal = 0M;
            this.fIgv = 0M;
            this.fPrecioVenta = 0M;
            this.fTotal = 0M;
            this.nIdCliente = 0;
            this.sNombre = "";
            this.nCodigo = 0;
            this.sUsuario = "";
            this.bEstado = true;
            this.ListDetallePedido = new List<PedidoDetalle>();
        }
        
        public int nTipo { get; set; }
        public int nIdPedido { get; set; }
        public int nIdAlmacen { get; set; }
        public int? nNumero { get; set; }
        public string sNombre { get; set; }
        public DateTime dFecha { get; set; }
        public decimal fPorcentajeIgv { get; set; }
        public decimal fSubTotal { get; set; }
        public decimal fIgv { get; set; }
        public decimal fPrecioVenta { get; set; }
        public decimal fTotal { get; set; }
        public int nIdCliente { get; set; }
        public int nCodigo { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
        public List<PedidoDetalle> ListDetallePedido {get;set; }
    }
}
