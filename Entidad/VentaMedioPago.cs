using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class VentaMedioPago
    {
        public VentaMedioPago()
        {
            this.nIdVentaMedioPago = 0;
            this.nIdVenta = 0;
            this.nIdMedioPago = 0;
            this.fMonto = 0.0M;
        }

        public int nIdVentaMedioPago { get; set; }
        public int nIdVenta { get; set; }
        public int nIdMedioPago { get; set; }
        public decimal fMonto { get; set; }
    }
}
