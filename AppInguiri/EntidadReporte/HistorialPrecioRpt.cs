using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInguiri.EntidadReporte
{
    public class HistorialPrecioRpt
    {
        public DateTime dFecha { get; set; }
        public string sLote { get; set; }
        public int nCantidad { get; set; }
        public decimal fPrecio { get; set; }
        public decimal fTotal { get; set; }
    }
}
