using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Parametro
    {
        public Parametro()
        {
            this.nTipo = 0;
            this.nIdParametro = 0;
            this.sClave = "";
            this.sValor = "";
            this.sDescripcion = "";
            this.sUsuario = "";
            this.bEstado = true;
        }

        public int nTipo { get; set; }
        public int nIdParametro { get; set; }
        public string sClave { get; set; }
        public string sValor { get; set; }
        public string sDescripcion { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
    }
}
