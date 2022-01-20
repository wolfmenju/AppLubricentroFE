using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInguiri.EntidadReporte
{
    public class DeudasVencerRpt
    {
        public string sDocumento { get; set; }
        public string sNumeracion { get; set; }
        public DateTime dFecha { get; set; }
        public string sRuc { get; set; }
        public string sRazonSocial { get; set; }
        public int nDias { get; set; }
        public decimal fSaldo { get; set; }
    }
}
