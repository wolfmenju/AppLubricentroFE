using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInguiri.EntidadReporte
{
    public class StockMinimoRpt
    {
        public int nIdProducto { get; set; }
        public int nIdAlmacen { get; set; }
        public string sAlmacen { get; set; }
        public bool bAlternativo { get; set; }
        public string sProducto { get; set; }
        public string sLaboratorio { get; set; }
        public string sLote { get; set; }
        public DateTime dFechaVencimiento { get; set; }
        public int nMinimo { get; set; }
        public int nTotal { get; set; }
    }
}
