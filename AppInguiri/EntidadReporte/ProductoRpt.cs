using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInguiri.EntidadReporte
{
    public class ProductoRpt
    {
        public int nIdProducto { get; set; }
        public string sProducto { get; set; }
        public string sPrincipioActivo { get; set; }
        public string sLaboratorio { get; set; }
        public string sPresentacion { get; set; }
        public bool bAlternativo { get; set; }
        public int nStockMinimo { get; set; }

    }
}
