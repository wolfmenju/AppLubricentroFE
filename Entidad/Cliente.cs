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
            this.sTipoDoc = "";
            this.sNumeroDoc = "";
            this.sDireccion = "";
            this.sDistrito = "";
            this.sProvincia = "";
            this.sDepartamento = "";
            this.sUbigeo = "";
            this.sCelular = "";
            this.sUsuario = "";
            this.bTipoPersona = false;
            this.bEstado = true;
            this.bValidadoSunat = false;
            this.dFechaValidaSunat = null;
        }
        
        public int nTipo { get; set; }
        public int nIdCliente { get; set; }
        public string sNombres { get; set; }
        public bool bTipoPersona { get; set; }
        public string sTipoDoc { get; set; }
        public string sNumeroDoc { get; set; }
        public string sDireccion { get; set; }
        public string sDistrito { get; set; }
        public string sProvincia { get; set; }
        public string sDepartamento { get; set; }
        public string sUbigeo { get; set; }
        public string sCelular { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
        public bool bValidadoSunat { get; set; }
        public DateTime? dFechaValidaSunat { get; set; }

    }
}
