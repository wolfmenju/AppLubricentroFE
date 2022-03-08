using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInguiri.EntidadReporte
{
    public class ProductoVencidoRpt
    {
        public int nIdProducto { get; set; }
        public int nIdAlmacen { get; set; }
        public string sAlmacen { get; set; }
        public string bAlternativo { get; set; }
        public string sCodigoInterno { get; set; }
        public string sProducto { get; set; }
        public string sLaboratorio { get; set; }
        public string sLote { get; set; }
        public string sFeChaVencimiento { get; set; }
        public string sDias { get; set; }
    }
}
