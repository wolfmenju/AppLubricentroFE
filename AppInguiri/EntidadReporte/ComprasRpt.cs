using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInguiri.EntidadReporte
{
    public class ComprasRpt
    {
        public string sRuc { get; set; }
        public string sRazonSocial { get; set; }
        public bool bCredito { get; set; }
        public string sDocumento { get; set; }
        public DateTime sFecha { get; set; }
        public decimal fTotal { get; set; }
    }
}
