using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Servicio  
    {
        public Servicio()
        {
            this.sCodigoInterno = "";
            this.nTipo = 0;
            this.nSubTipo = 0;
            this.nIdServicio = 0;
            this.sDescripcion = "";
            this.bPaquete = false;
            this.fPrecio = 0M;
            this.sUsuario = "";
            this.bEstado = false;
        }

        
        public string sCodigoInterno { get; set; }
        public int nTipo { get; set; }
        public int nSubTipo { get; set; }
        public int nIdServicio { get; set; }
        public string sDescripcion { get; set; }
        public bool bPaquete { get; set; }
        public decimal fPrecio { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }

    }
}
