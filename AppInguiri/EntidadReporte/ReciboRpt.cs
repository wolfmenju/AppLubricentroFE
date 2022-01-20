using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInguiri.EntidadReporte
{
    public class ReciboRpt
    {
        public string sDocumento { get; set; }
        public int nNumero { get; set; }
        public decimal fTotal { get; set; }
        public decimal fDescuento { get; set; }
        public string sProducto { get; set; }
        public string sNombre { get; set; }
        public decimal fPrecio { get; set; }
        public int nCantidad { get; set; }
        public string sIdVendedor { get; set; }
        public string sFechaRegistro { get; set; }
    }
}
