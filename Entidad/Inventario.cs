using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Inventario
    {
        public Inventario()
        {
            this.nTipo = 0;
            this.nIdInventario = 0;
            this.sDecripcion = "";
            this.nItem = 0;
            this.dFechaInicio = DateTime.Now;
            this.dFechaFin = DateTime.Now;
            this.nIdAlmacen = 0;
            this.sUsuario = "";
            this.bEstado = false;
        }

        public int nTipo { get; set; }
        public int nIdInventario { get; set; }
        public string sDecripcion { get; set; }
        public int nItem { get; set; }
        public DateTime dFechaInicio { get; set; }
        public DateTime? dFechaFin { get; set; }
        public int nIdAlmacen { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
    }
}
