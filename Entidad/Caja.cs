using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Caja
    {
        public Caja()
        {
            this.nTipo = 0;
            this.nIdCaja = 0;
            this.nIdTurno = 0;
            this.dFechaInicio = DateTime.Now;
            this.dFechaFinal = DateTime.Now;
            this.fMontoInicio = 0M;
            this.fMontoFinal = 0M;
            this.sUsuario = "";
            this.bEstado = true;
        }

        public int nTipo { get; set; }
        public int nIdCaja { get; set; }
        public int nIdTurno { get; set; }
        public DateTime dFechaInicio { get; set; }
        public DateTime? dFechaFinal { get; set; }
        public decimal fMontoInicio { get; set; }
        public decimal? fMontoFinal { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
    }
}
