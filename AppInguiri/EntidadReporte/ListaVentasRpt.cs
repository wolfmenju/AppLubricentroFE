using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInguiri.EntidadReporte
{
    public class ListaVentasRpt
    {
        public int nIdVenta { get; set; }
        public string sProducto { get; set; }
        public DateTime dFecha { get; set; }
        public string sDocumento { get; set; }
        public string sIdCajero { get; set; }
        public string sNombreCliente { get; set; }
        public int nCantidad { get; set; }
        public decimal fPrecio { get; set; }
        public decimal fDescuento { get; set; }
    }
}
