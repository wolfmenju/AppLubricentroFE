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
        public string nNumero { get; set; }
        public decimal fTotal { get; set; }
        public string sTotalLetras { get; set; }
        public decimal fDescuento { get; set; }
        public string sProducto { get; set; }
        public string sNombre { get; set; }
        public string sRuc { get; set; }
        public string sDireccion { get; set; }
        public decimal fPrecio { get; set; }
        public decimal fPrecioUnitario { get; set; }
        public int nCantidad { get; set; }
        public string sIdVendedor { get; set; }
        public string sFechaRegistro { get; set; }
        public byte[] yCodigoQR { get; set; }
        public decimal fSubTotal { get; set; }
        public decimal fExogerado { get; set; }
        public decimal fIgv { get; set; }
        public string sPaginaPie { get; set; }
        public string sPaginaTextoExo { get; set; }

    }
}
