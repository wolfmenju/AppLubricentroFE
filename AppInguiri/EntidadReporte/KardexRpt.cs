using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInguiri.EntidadReporte
{
    public class KardexRpt
    {
        public DateTime dFecha { get; set; }
        public string sDocumento { get; set; }
        public string sNumeracion { get; set; }
        public string sLote { get; set; }
        public int nEntrada { get; set; }
        public int nSalida { get; set; }
    }
}
