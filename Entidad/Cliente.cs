using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cliente
    {
        public Cliente()
        {
            this.nTipo = 0;
            this.nIdCliente = 0;
            this.sNombres = "";
            this.sDni = "";
            this.sDireccion = "";
            this.sCelular = "";
            this.sUsuario = "";
            this.bTipoPersona = false;
            this.bEstado = true;

        }
        
        public int nTipo { get; set; }
        public int nIdCliente { get; set; }
        public string sNombres { get; set; }
        public bool bTipoPersona { get; set; }
        public string sDni { get; set; }
        public string sDireccion { get; set; }
        public string sCelular { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }

    }
}
