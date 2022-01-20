using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInguiri.EntidadReporte
{
    public class CajaChicaRpt
    {
        public int nTurno { get; set; }
        public string sUsuario { get; set; }
        public DateTime dFechaInicial { get; set; }
        public decimal fMontoInicial { get; set; }
        public DateTime dFechaFinal { get; set; }
        public decimal fMontoFinal { get; set; }

    }
}
